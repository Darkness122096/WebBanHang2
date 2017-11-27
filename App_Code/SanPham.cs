using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SanPham
/// </summary>
public class _SanPham
{
    public _SanPham()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection sqlcon;
    SqlCommand sqlcmd;
    SqlDataAdapter sqlAdap;
    string strCon = ConfigurationManager.ConnectionStrings["QuanLyBanHang"].ConnectionString;
    public DataSet _SelectSP()
    {
        DataSet ds = new DataSet();
        sqlcon = new SqlConnection(strCon);
        string query = @"select MaSP, TenSP, NamSX, HinhAnh, 
                case when TinhTrang = -1 then N'Hàng Chưa Về' 
                     when TinhTrang = 0 then N'Hàng Chưa Về'
	                 else N'Còn Hàng' End TinhTrang,
                MoTa, sp.MaLoai ,TenLoai 
                from SanPham sp , LoaiSP lsp 
                where sp.MaLoai = lsp.MaLoai";
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
}