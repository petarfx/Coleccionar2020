<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="Coleccionar.Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">
        <div id="divMensaje" runat="server" style="display: none" visible="true" cssclass="showhide col-lg-10 col-lg-offset-1 alert-dismissible fade in">
            <a href="#" class="close" data-dismiss="alert" aria-label="cerrar">&times;</a>
            <strong>
                <asp:Label ID="lblmsjTitulo" runat="server" Text="Título"></asp:Label></strong><asp:Label ID="lblmsjCuerpo" runat="server" Text="Mensaje"></asp:Label>
        </div>
        <%--<div class=" col-lg-4 col-md-6 col-sm-8 col-lg-offset-4 col-md-offset-3 col-sm-offset-2">--%>
        <div class="col-lg-8 col-md-10 col-sm-12 col-lg-offset-2 col-md-offset-1">
            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Alta de Usuario"></asp:Label>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtRemitente_Alias" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Alias" class="control-label col-md-4 ">Alias</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Alias" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_txtRemitente_Email" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Email" class="control-label col-md-4 ">Email</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_Remitente_Provincia_Descripcion" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Provincia_Descripcion" class="control-label col-md-4 ">Provincia</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Provincia_Descripcion" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Remitente_Localidad_Descripcion" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Localidad_Descripcion" class="control-label col-md-4 ">Localidad</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Localidad_Descripcion" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_Remitente_Calle_Descripcion" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Calle_Descripcion" class="control-label col-md-4 ">Calle</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Calle_Descripcion" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Remitente_Numero_Calle" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Numero_Calle" class="control-label col-md-4 ">Número</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Numero_Calle" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_Remitente_Piso" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Piso" class="control-label col-md-4 ">Piso</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Piso" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Remitente_Depto" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Depto" class="control-label col-md-4 ">Depto</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Depto" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_Remitente_Celular" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Celular" class="control-label col-md-4 ">Nro. cel.</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Celular" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Remitente_Telefono" class="col-md-6" style="padding-top: 5px">
                        <label for="txtRemitente_Telefono" class="control-label col-md-4 ">Tel. Fijo.</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtRemitente_Telefono" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_Publicacion_Nombre" class="col-md-6" style="padding-top: 5px">
                        <label for="txtPublicacion_Nombre" class="control-label col-md-4 ">Publicación:</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtPublicacion_Nombre" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Fecha" class="col-md-6" style="padding-top: 5px">
                        <label for="txtFecha" class="control-label col-md-4 ">Fecha/Hora</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtFecha" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_MensajeCuerpo" class="col-md-12" style="padding-top: 5px"">
                        <label for="txtMensajeCuerpo" class="control-label col-md-2 ">Mensaje:</label>
                        <div class="controls col-md-10 ">
                            <asp:TextBox ID="txtMensajeCuerpo" class="form-control" runat="server" Height="90px"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">

                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-primary" CausesValidation="False" OnClick="btnVolver_Click" />
                </div>

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
                            <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="Scripts/coleccionarScripts.js" type="text/javascript"></script>
    </div>
</asp:Content>
