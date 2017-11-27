using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dangky : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        string stru = txtUser.Text.Trim();
        string strp = txtPass.Text.Trim();
        string strname = txtName.Text.Trim();
        string strdc = txtDiaChi.Text.Trim();
        string strsdt = txtSDT.Text.Trim();

        clsUsers obju = new clsUsers();
        int kq = obju._insert_users(stru, strp, strname, strdc, strsdt);
        dErrors.Visible = true;
        dErrors.InnerText = (kq > 0) ? "Them moi thanh cong" : "That bai";
    }
}