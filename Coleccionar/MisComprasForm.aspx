<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="MisComprasForm.aspx.cs" Inherits="Coleccionar.MisComprasForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .imagen {
            transition: all .2s ease-in-out;
            height: 150px;
            width: 150px;
        }

        .imagen-seleccionable:hover {
            transform: scale(1.025);
            box-shadow: 0 0 12px 1px #f0ff0a;
            cursor: pointer;
        }
    </style>
    <div class="col-md-12">
        <asp:Label ID="lblComprasRealizadas" runat="server" Text="Label"></asp:Label>  
    </div>

    <div class="grillaPublicaciones">
        <asp:GridView ID="gvComprasPublicadas" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="ID_Publicacion" ShowHeader="False" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID_Publicacion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("ID_Publicacion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tipo_Publicacion" HeaderText="Tipo_Publicacion" Visible="False" />
                <asp:BoundField DataField="ID_Categoria" HeaderText="ID_Categoria" Visible="False" />
                <asp:BoundField DataField="ID_SubCategoria" HeaderText="ID_SubCategoria" ShowHeader="False" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="ID_Categoria_Descripcion" HeaderText="Categoria" />
                <asp:BoundField DataField="ID_SubCategoria_Descripcion" HeaderText="SubCategoria" />
                <asp:BoundField DataField="Estado_Publicacion" HeaderText="Estado_Publicacion" Visible="False" />
                <asp:BoundField DataField="ID_Usuario" HeaderText="ID_Usuario" Visible="False" />
                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" />
                <asp:BoundField DataField="Estado_Producto" HeaderText="Estado_Producto" Visible="False" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Estado_Visibilidad" HeaderText="Estado_Visibilidad" Visible="False" />
                <asp:BoundField DataField="Estado_Producto_Descripcion" HeaderText="Estado" />
                <asp:TemplateField HeaderText="idFoto" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Foto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="idfoto" runat="server" Text='<%# Bind("Foto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Foto">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgFoto" runat="server" class="imagen imagen-seleccionable" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
