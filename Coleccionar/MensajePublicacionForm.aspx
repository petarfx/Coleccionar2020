<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="MensajePublicacionForm.aspx.cs" Inherits="Coleccionar.MensajePublicacionForm" %>

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
                        <asp:Label ID="lblTitulo" runat="server" Text="Enviar Mensaje"></asp:Label>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtDestinatario_Alias" class="col-md-6" style="padding-top: 5px">
                        <label for="txtDestinatario_Alias" class="control-label col-md-4 ">Para</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtDestinatario_Alias" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_Publicacion_Nombre" class="col-md-6" style="padding-top: 5px">
                        <label for="txtPublicacion_Nombre" class="control-label col-md-4 ">Publicación:</label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtPublicacion_Nombre" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_MensajeCuerpo" class="col-md-12" style="padding-top: 5px" >
                        <label for="txtMensajeCuerpo" class="control-label col-md-2 ">Mensaje:</label>
                        <div class="controls col-md-10 ">
                            <asp:TextBox ID="txtMensajeCuerpo"  class="form-control" runat="server" Height="90px" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ErrorMessage="Debe ingresar el mensaje" ControlToValidate="txtMensajeCuerpo" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div class="form-group-12 col-lg-12 col-md-12 text-center">                   
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-primary" CausesValidation="true" OnClick="btnEnviar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" CausesValidation="false" OnClick="btnCancelar_Click" />
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

