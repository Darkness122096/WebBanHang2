<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="LoaiSanPham.aspx.cs" Inherits="admin_LoaiSanPham" %>

<asp:Content ID="cHead" runat="server"  ContentPlaceHolderID="head">

    <style type="text/css">
        .text-center {
            margin-right: 7px;
        }
    </style>

</asp:Content>

<asp:Content ID="cBody" runat="server"  ContentPlaceHolderID="admin_body">
   
     <asp:GridView ID="gvSp" runat="server" DataKeyNames="MaLoai" 
         CssClass="table table-hover text-center " 
         AutoGenerateColumns="False" Width="550px" AllowPaging="True" 
         OnPageIndexChanging="gvSp_PageIndexChanging" 
         OnSelectedIndexChanging="gvSp_SelectedIndexChanging" 
         ShowFooter="True" Height="816px" 
         OnRowEditing="gvSp_RowEditing" 
         OnRowCancelingEdit="gvSp_RowCancelingEdit" 
         OnRowUpdating="gvSp_RowUpdating" 
         OnRowDeleting="gvSp_RowDeleting" OnRowDataBound="gvSp_RowDataBound">
         
         <Columns>

             <asp:TemplateField HeaderText="Số Thứ Tự">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="lbSTT"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Tên Loại" ControlStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:Label ID="lbname" runat="server" Text='<%#Eval("TenLoai")%>'></asp:Label>
                </ItemTemplate>
                 <EditItemTemplate>
                     <asp:HiddenField  ID="hdmaloai" runat="server" Value='<%#Eval("MaLoai")%>'/>
                     <asp:TextBox runat="server" ID="txtEdit" Text='<%#Eval("TenLoai")%>'></asp:TextBox>
                 </EditItemTemplate>
                 <FooterTemplate>
                     <div class="container-fluid">
                          <asp:TextBox ID="txtthem" CssClass="form-control" runat="server"></asp:TextBox>
                     </div>
                 </FooterTemplate>

        <ControlStyle CssClass="text-center"></ControlStyle>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Chức Năng">
                 <ItemTemplate>
                     <asp:Button  ID="btnSua" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary"/>
                     <asp:Button  ID="btnXoa" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-primary"/>
                 </ItemTemplate>

                 <FooterTemplate>
                     <asp:Button ID="btnthem" runat="server" Text="save" CssClass="btn btn-success text-center"  CommandName="luusp"/>
                 </FooterTemplate>

                 <EditItemTemplate>
                     <asp:Button  ID="btnUpdate" runat="server" Text="Cập Nhật" CommandName="Update" CssClass="btn btn-primary"/>
                     <asp:Button  ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-primary"/>
                 </EditItemTemplate>
             </asp:TemplateField>
         </Columns>

    
         <HeaderStyle CssClass="text-center" />

    
     </asp:GridView>

     
</asp:Content>