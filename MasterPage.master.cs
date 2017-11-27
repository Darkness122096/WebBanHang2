using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"]!= null)
        {
            ulRegister.Visible = false;
            ulUser.Visible = true;
            lbluser.Text = Session["fullname"].ToString();
        }
    }

    protected void btnLogouts_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["fullname"] = null;
        Response.Redirect("~/TrangChu.aspx");
    }
}
