<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="SanPham.aspx.cs" Inherits="SanPham" %>

<asp:Content ID="cHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="cBody" ContentPlaceHolderID="admin_body" runat="server">

    <asp:GridView ID="grSP" DataKeyNames="MaSP" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-responsive text-center" OnRowDataBound="grSP_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Số Thứ Tự">
                <ItemTemplate>
                    <asp:Label ID="lbSTT" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tên Sản Phẩm">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlTenSP"><%#Eval("TenSP") %></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="NamSX" HeaderText="Năm Sản Xuất" />

            <asp:BoundField DataField="TinhTrang" HeaderText="Tình Trạng" />

            <asp:BoundField DataField="TenLoai" HeaderText="Tên Loại" />

            <asp:TemplateField HeaderText="Hình">


            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>