using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class SanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _lay_ds_du_lieu_SP();
        }
    }
    protected void _lay_ds_du_lieu_SP()
    {
        DataSet ds = new _SanPham()._SelectSP();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grSP.DataSource = ds.Tables[0];
                    grSP.DataBind();
                   
                }
            }
        }
    }

    protected void grSP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("style", "cursor:pointer");
        Label lbIndex = (Label)e.Row.Cells[0].FindControl("lbSTT");
        if (lbIndex != null)
        {
            lbIndex.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
}