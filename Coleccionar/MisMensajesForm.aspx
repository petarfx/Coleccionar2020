<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="MisMensajesForm.aspx.cs" Inherits="Coleccionar.MisMensajesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:Label ID="lblCantidad" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="row">
        <div class="col-lg-12 ">
            <div class="table-responsive">
                <div id="panelGrilla" class="grillaPublicaciones centrado" runat="server">
                    <asp:GridView ID="gvMensajes" CssClass="table table-striped table-bordered table-hover" runat="server" Style="margin: 0 auto; width: 100%" AutoGenerateColumns="False" OnRowDataBound="gvMensajes_RowDataBound" EmptyDataText="Actualmente no posee mensjes." OnSelectedIndexChanged="gvMensajes_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Visible="false" ID="sobreCerrado" class="btn btn-mini"><i class="fa fa-envelope"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" Visible="false" ID="sobreAbierto" class="btn btn-mini"><i class="fa fa-envelope-open"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID_Mensaje" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID_Mensaje") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("ID_Mensaje") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID_Remitente" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ID_Remitente") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidRemitente" runat="server" Text='<%# Bind("ID_Remitente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="De">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Remitente_Alias") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAliasRemitente" runat="server" Text='<%# Bind("Remitente_Alias") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Publicacion_Nombre" HeaderText="Publicación" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora" />
                            <asp:TemplateField HeaderText="Notificacion" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Notificacion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidnoti" runat="server" Text='<%# Bind("Notificacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leido" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Leido") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidleido" runat="server" Text='<%# Bind("Leido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contenido">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblContenido" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ver">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkVer" runat="server" CommandName="SELECT">Leer</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
