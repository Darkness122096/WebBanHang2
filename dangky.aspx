<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="dangky.aspx.cs" Inherits="dangky" %>

<asp:Content runat="server" ID="chead" ContentPlaceHolderID="head"></asp:Content>
<asp:Content runat="server" ID="ccontent" ContentPlaceHolderID="Center">
    <div class="row reg">
        <div class="form-inline col-md-12">
            <label class="col-md-1">User Name</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="UserName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqtxtUser" runat="server" ControlToValidate="txtUser" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-md-12">
            <label class="col-md-1">PassWord</label>
            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="PassWord"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqtxtPass" runat="server" ControlToValidate="txtPass" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-md-12">
            <label class="col-md-1">Full Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqtxtName" runat="server" ControlToValidate="txtName" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-md-12">
            <label class="col-md-1">Dia Chi</label>
            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" placeholder="Dia Chi"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqtxtDiaChi" runat="server" ControlToValidate="txtDiaChi" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-md-12">
            <label class="col-md-1">SDT</label>
            <asp:TextBox ID="txtSDT" runat="server"  CssClass="form-control" placeholder="SDT"></asp:TextBox>
            <asp:RequiredFieldValidator ID="qrtxtSDT" runat="server" ControlToValidate="txtSDT" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-md-12">
            <asp:Button runat="server" ID="btnReg" CssClass="btn btn-primary" OnClick="btnReg_Click" Text="Dang Ky" />
        </div>
        <div class="form-inline col-md-12">
            <div class="jumbotron" id="dErrors" runat="server" visible="false"></div>
        </div>
    </div>
</asp:Content>