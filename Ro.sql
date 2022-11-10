create database RepairOrder
use RepairOrder

create table ROCrude
(
	ROID int primary key,
	CNAME varchar(20),
	CADDRESS varchar(20),
	CMAKE varchar(20),
	MLGE int,
)

create procedure AddRO
	@CNAME varchar(20),
	@CADDRESS varchar(20),
	@CMAKE varchar(20),
	@MLGE int
As
	declare @gid int
	exec GenID @gid out
	insert into ROCrude values(@gid,@CNAME,@CADDRESS,@CMAKE,@MLGE)

create Procedure GenID @OID int output
as
	if (select count(ROID) from ROCrude) <= 0
	begin
		set @OID = 1
	end
	else
	begin  
		select @OID = MAX(ROID) + 1 from ROCrude
	end

exec AddRO 'Steve','chicago','Audi Q3',1480
select * from ROCrude

create procedure UpdateRO 
	@ROID int,
	@CNAME varchar(50),
	@CADDRESS varchar(max),
	@CMAKE varchar(20),
	@MLGE INT,
	@sts varchar(100) output
As
	declare @cnt int
	select @cnt = COUNT(ROID) from ROCrude where ROID = @ROID
	if @cnt > 0
		begin
			update ROCrude set CNAME = @CNAME,@CADDRESS = @CADDRESS,@CMAKE = @CMAKE where ROID = @ROID
			set @sts = 'Customer Data Modified Successfully'
		end
	else
		begin
			set @sts = 'Customer Data not found to Modify'
		end

declare @sts varchar(100)	
exec UpdateRO 1,'Rupesh','CHICAGO','Audi Q3',20000,@sts output
print @sts

select * from ROCrude

create procedure DeleteRO 
	@ROID int,
	@sts varchar(100) output
As
	declare @cnt int
	select @cnt = COUNT(ROID) from ROCrude where ROID = @ROID
	if @cnt > 0
		begin
			delete ROCrude where ROID = @ROID
			set @sts = 'Repair Order Deleted Successfully'
		end
	else
		begin
			set @sts = 'Repair Order not found to Delete'
		end

declare @sts varchar(100)	
exec deleteRo 3,@sts output
print @sts

create procedure FindRO 
	@ROID int
As
	select * from ROCrude where ROID = @ROID

exec FINDRO 1

create procedure ROSummary
As
	select * from ROCrude
	
exec ROSummary

declare @oid int
exec GenID @oid output
print @oid

	

