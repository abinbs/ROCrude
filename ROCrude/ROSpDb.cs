using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CustomerDemo;
using Model;

namespace CustomerDemo
{
    class ROSpDb
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public ROSpDb()
        {
            string conStr = "server=.;database=RepairOrder;user id=sa;pwd=Temp1234";
            con = new SqlConnection(conStr);
        }

       

        public void AddRO(RO c)
        {
            //string conStr = "server=.;database=Solera_Employees;user id=sa;pwd=sa";
            //SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("AddRO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CNAME", c.CNAME));
            cmd.Parameters.Add(new SqlParameter("@CADDRESS", c.CADDRESS));
            cmd.Parameters.Add(new SqlParameter("@CMAKE", c.CMAKE));
            cmd.Parameters.Add(new SqlParameter("@MLGE", c.MLGE));

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            Console.WriteLine("record inserted");
            //Console.Read();
        }

        public string UpdateRO(int ROID, RO c)
        {
            string updStr = $"UpdateRO";
            cmd = new SqlCommand(updStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ROID", c.ROID));
            cmd.Parameters.Add(new SqlParameter("@CNAME", c.CNAME));
            cmd.Parameters.Add(new SqlParameter("@CADDRESS", c.CADDRESS));
            cmd.Parameters.Add(new SqlParameter("@CMAKE", c.CMAKE));
            cmd.Parameters.Add(new SqlParameter("@MLGE", c.MLGE));
            SqlParameter sp = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            string returnData = "";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                returnData = cmd.Parameters[5].Value.ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return returnData;
            Console.WriteLine("record updated");
            //Console.Read();
        }
        public string DeleteRO(int roid)
        {
            string delStr = $"DeleteRO";
            cmd = new SqlCommand(delStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ROID", roid));
            SqlParameter sp = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            string returnData = "";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                returnData = cmd.Parameters[1].Value.ToString();

            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return returnData;

        }
        public RO FindRO(int roid)
        {
            string selStr = $"FindRO";
            cmd = new SqlCommand(selStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ROID", roid));
            SqlDataReader dr = null;
            RO cr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cr = new RO
                    {
                        ROID = dr.GetInt32(0),
                        CNAME = dr.GetString(1),
                        CADDRESS = dr.GetString(2),
                        CMAKE = dr.GetString(3),
                        MLGE = dr.GetInt32(4)
                    };
                }
                else
                {
                    cr = null;
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return cr;
        }
        public List<RO> GetRO()
        {
            string finStr = $"ROSummary";
            cmd = new SqlCommand(finStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            List<RO> cr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cr = new List<RO>();
                    while (dr.Read())
                    {
                        RO c = new RO
                        {
                            ROID = dr.GetInt32(0),
                            CNAME = dr.GetString(1),
                            CADDRESS = dr.GetString(2),
                            CMAKE = dr.GetString(3),
                            MLGE = dr.GetInt32(4)
                        };
                        cr.Add(c);
                    }
                    return cr;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

        }
    }
}
