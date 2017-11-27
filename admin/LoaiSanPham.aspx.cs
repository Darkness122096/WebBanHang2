using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_LoaiSanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAll();
        }
    }

    protected void gvSp_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }

    protected void gvSp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSp.PageIndex = e.NewPageIndex;
        if(ViewState["Loaisanpham"]!= null)
        {
            DataSet ds = (DataSet) ViewState["Loaisanpham"];
            gvSp.DataSource = ds.Tables[0];
            gvSp.DataBind();
        }
    }

    protected void gvSp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "luusp")
        {
            string str = ((TextBox)gvSp.FooterRow.FindControl("txtthem")).Text;
            int count = new LoaiSP()._Insert(str);
            if (count > 0)
            {
                getAll();
            }
        }
    }

    protected void getAll()
    {
        DataSet ds = new LoaiSP()._Select();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSp.DataSource = ds.Tables[0];
                    gvSp.DataBind();
                    ViewState["Loaisanpham"] = ds;
                }

            }
        }
    }
    protected void gvSp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSp.EditIndex = e.NewEditIndex;
        getAll();
    }

    protected void gvSp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSp.EditIndex = -1;
        getAll();
    }

    protected void gvSp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index = e.RowIndex; //lấy số thứ tự tự động đang đc update
        string str = ((TextBox)gvSp.Rows[index].FindControl("txtEdit")).Text ;
        string str2 = ((HiddenField)gvSp.Rows[index].FindControl("hdmaloai")).Value;
        LoaiSP loaisp = new LoaiSP();
        int ml = int.Parse(str2);
        int kq = loaisp._UpDate(str, ml);
        gvSp.EditIndex = -1;
        getAll();
    }

    protected void gvSp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex; //lấy số thứ tự tự động đang đc update
        string str2 = gvSp.DataKeys[index].Value.ToString();
        LoaiSP loaisp = new LoaiSP();
        int kq = loaisp._Delete(int.Parse(str2));
        gvSp.EditIndex = -1;
        getAll();

    }

    protected void gvSp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("style","cursor:pointer");
        Label lbIndex = (Label)e.Row.Cells[0].FindControl("lbSTT");
        if(lbIndex != null)
        {
            lbIndex.Text = (e.Row.RowIndex + 1).ToString();
        } 
    }
}