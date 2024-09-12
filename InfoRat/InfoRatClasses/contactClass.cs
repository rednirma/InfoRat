using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InfoRat.InfoRatClasses
{
    class ContactClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public int ID { get; set; }

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;


        public DataTable Select()
        { 
        SqlConnection conn = new SqlConnection(myconnstr);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Table_Details";
                SqlCommand cmd = new SqlCommand(sql, conn); 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);   
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally 
            {
                conn.Close();   
            }
            return dt;
        }

        public bool Insert(ContactClass C ) {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstr);
            try
            {
                string sql = "INSERT INTO Table_Details (FirstName, LastName, Contact) VALUES (@FirstName, @LastName, @Contact)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", C.FirstName);
                cmd.Parameters.AddWithValue("@LastName", C.LastName);
                cmd.Parameters.AddWithValue("@Contact", C.Contact);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch { }
            finally 
            {
                conn.Close();   
            }
            return isSuccess;
        }
        public bool Update(ContactClass C) 
        { 
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstr);
            try 
            {
                string sql = "UPDATE Table_Details SET FirstName=@FirstName, LastName=@LastName, Contact=@Contact WHERE ID=@ID";
                SqlCommand cmd= new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", C.FirstName);
                cmd.Parameters.AddWithValue("@LastName", C.LastName);
                cmd.Parameters.AddWithValue("@Contact", C.Contact);
                cmd.Parameters.AddWithValue("@ID", C.ID);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) { isSuccess = true; }
                else { isSuccess = false; }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isSuccess;
        }

        public bool Delete(ContactClass C) 
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstr);
            try 
            {
                string sql = "DELETE FROM Table_Details where ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", C.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else { isSuccess = false; }
            }
            catch(Exception ex) { }
            finally { conn.Close(); }
            return isSuccess;
            
        }
    }
}
