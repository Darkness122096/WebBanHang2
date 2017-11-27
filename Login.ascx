<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Login" %>
<div class="form-horizontal">
    <div class="form-group row">
        <label>Username</label>
        <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" placeholder="UserName"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="Login" ID="rqfUser" runat="server" ControlToValidate="txtUser" Text="*"></asp:RequiredFieldValidator>
    </div>
     <div class="form-group row">
        <label>PassWord</label>
        <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" placeholder="Pass"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="Login" ID="rqfPass" runat="server" ControlToValidate="txtPass" Text="*"></asp:RequiredFieldValidator>
    </div>
     <div class="form-group row">
       <asp:Button  ID="btnDangnhap" ValidationGroup="Login" CssClass="btn btn-info" runat="server" OnClick="btnDangnhap_Click" Text="Login"/>
    </div>
</div>