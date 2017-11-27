using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;

public partial class Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDangnhap_Click(object sender, EventArgs e)
    {
        string struser = txtUser.Text.Trim();
        string strpass = txtPass.Text.Trim();
        DataSet ds = new clsUsers()._dangnhap(struser, strpass);
            if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["user"] = ds.Tables[0].Rows[0]["username"].ToString();
                    Session["fullname"] = ds.Tables[0].Rows[0]["fullname"].ToString();
                    Response.Redirect(Request.RawUrl.ToString(), true);
                }
                else
                {

                }
            }
            else
            {

            }
            
        }
    }
}