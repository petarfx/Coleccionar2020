<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="SuccessMessage.aspx.cs" Inherits="Coleccionar.SuccessMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">
        <div >
            <div class=" col-lg-4 col-md-6 col-sm-8 col-lg-offset-4 col-md-offset-3 col-sm-offset-2 DivAntiguo">
                <div class="form-group espacioTop">
                    <asp:Label ID="lblTitulo" runat="server" Text="Label" CssClass="tituloPublicacion"></asp:Label>
                </div>
                <div class="form-group espacioTop">
                    <asp:Label ID="lblMensaje" runat="server" Text="Label" CssClass="tituloDescripcionPublicacion"></asp:Label>
                </div>
                <div class="form-group espacioTop espacioDown">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary amplio botonPirata" CausesValidation="False" OnClick="btnAceptar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
