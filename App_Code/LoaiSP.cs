using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoaiSP
/// </summary>
public class LoaiSP
{
    public LoaiSP()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection sqlcon;
    SqlCommand sqlcmd;
    SqlDataAdapter sqlAdap;
    string strCon = ConfigurationManager.ConnectionStrings["QuanLyBanHang"].ConnectionString;
    public DataSet _Select()
    {
        DataSet ds = new DataSet();
        sqlcon = new SqlConnection(strCon);
        string query = @"select * from LoaiSP";
        sqlcmd = new SqlCommand(query, sqlcon);
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
    public int _Insert(string tenloai)
    {
        int count = 0;
        sqlcon = new SqlConnection(strCon);
        string query = @"if(not exists (select TenLoai from LoaiSP where TenLoai=@tenloai))
begin
INSERT INTO [LoaiSP]
			   ([TenLoai])
		 VALUES
			   (@tenloai)
			
end";
        sqlcmd = new SqlCommand(query, sqlcon);
        sqlcmd.Parameters.Add("@tenloai", SqlDbType.NVarChar).Value = tenloai;
        try
        {
            sqlcon.Open();
            count = sqlcmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally { sqlcon.Close(); }
        return count;
    }

    public int _UpDate(string tenloai , int maloai)
    {
        int count = 0;
        sqlcon = new SqlConnection(strCon);
       
        //Không dùng parameter
        /*string query = @"update LoaiSP set TenLoai = '" + tenloai + @" where MaLoai =" + maloai;
        sqlcmd = new SqlCommand(query, sqlcon);
        sqlcmd.CommandType = CommandType.Text;*/
        
        //dung parameter
        string query2 = @"update LoaiSP set TenLoai = @tenloai  where MaLoai = @maloai";
        sqlcmd = new SqlCommand(query2, sqlcon);
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.Parameters.Add("@maloai", SqlDbType.Int).Value = maloai;
        sqlcmd.Parameters.Add("@tenloai", SqlDbType.NVarChar).Value = tenloai;
        try
        {
            sqlcon.Open();
            count = sqlcmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally { sqlcon.Close(); }
        return count;
    }

    public int _Delete(int maloai)
    {
        int count = 0;
        sqlcon = new SqlConnection(strCon);
        string query = @"Delete LoaiSP where MaLoai = @maloai";
        sqlcmd = new SqlCommand(query, sqlcon);
        sqlcmd.Parameters.Add("@maloai", SqlDbType.Int).Value = maloai;
        try
        {
            sqlcon.Open();
            count = sqlcmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally { sqlcon.Close(); }
        return count;
    }
}