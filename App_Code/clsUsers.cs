using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for clsUsers
/// </summary>
public class clsUsers
{
    public clsUsers()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection sqlcon;
    SqlCommand sqlcmd;
    SqlDataAdapter sqlAdap;
    string strCon = ConfigurationManager.ConnectionStrings["QuanLyBanHang"].ConnectionString;
    public int _insert_users(string uname, string upass, string ufullname, string udiachi, string sdt)
    {

        int count = 0;
        sqlcon = new SqlConnection(strCon);
        string query = @"if(not exists (select username from users where username=@username))
begin
	INSERT INTO [USERS]
			   ([username]
			   ,[address]
			   ,[tel]
			   ,[password]
			   ,[fullname]
			   ,[role]
			   ,[active])
		 VALUES
			   (
			   @username
			   ,@add
			   ,@tel
			   ,@password
			   ,@fullname
			   ,0
			   ,1)
end";
        sqlcmd = new SqlCommand(query, sqlcon);
        sqlcmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = uname;
        sqlcmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = upass;
        sqlcmd.Parameters.Add("@fullname", SqlDbType.NVarChar).Value = ufullname;
        sqlcmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = udiachi;
        sqlcmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
        try
        {
            sqlcon.Open();
            count = sqlcmd.ExecuteNonQuery();
        }
        catch (Exception ex) {
            throw new Exception(ex.ToString());
        }
        finally { sqlcon.Close(); }
        return count;
    }

    public DataSet _dangnhap(string name , string pass){
        DataSet ds = new DataSet();
        sqlcon= new SqlConnection(strCon);
        string query = @"select * from users where username='" + name + @"' and password='" +pass+ @"'";
        sqlcmd = new SqlCommand(query,sqlcon);
        try
        {
            sqlcon.Open();
            sqlAdap = new SqlDataAdapter(sqlcmd);
            sqlAdap.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally { if (sqlcon.State == ConnectionState.Open) { sqlcon.Close(); } }
        return ds;
    }
}