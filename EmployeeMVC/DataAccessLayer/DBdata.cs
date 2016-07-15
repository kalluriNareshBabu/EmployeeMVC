using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeMVC.Models;
using Microsoft.ApplicationBlocks.Data;

namespace EmployeeMVC.DataAccessLayer
{
    public class DBdata
    {
        public string insert(DataModels dm)
        {
            SqlConnection con = null;
            string result = "";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_manage_user_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", 0);
                cmd.Parameters.AddWithValue("@name", dm.name);
                cmd.Parameters.AddWithValue("@email", dm.email);
                cmd.Parameters.AddWithValue("@mobile", dm.mobile);
                cmd.Parameters.AddWithValue("@gender", dm.gender);
                cmd.Parameters.AddWithValue("@type", "insert");
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet select()
        {
            SqlConnection con = null;
            DataSet ds = new DataSet();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("sp_manage_user_data", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userid", 0);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@email", null);
                cmd.Parameters.AddWithValue("@mobile", null);
                cmd.Parameters.AddWithValue("@gender", null);
                cmd.Parameters.AddWithValue("@type", "select");
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                
                return ds;
            }
            catch
            {
                return ds = null;
            }
            finally
            {
                con.Close();
            }
        }

        public static void login_check(LoginModels dm, out string msg, out int res)
        {
            try
            {
                
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@email", dm.email);
                p[1] = new SqlParameter("@password", dm.password);
                p[2] = new SqlParameter("@res", SqlDbType.Int);
                p[2].Direction = ParameterDirection.Output;
                p[3] = new SqlParameter("@msg", SqlDbType.VarChar, 200);
                p[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DBconnect.GetConnectionString(), CommandType.StoredProcedure, "sp_user_login", p);
                res = Convert.ToInt32(p[2].Value);
                msg = Convert.ToString(p[3].Value);
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }
    }
}