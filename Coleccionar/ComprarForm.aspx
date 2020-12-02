<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ComprarForm.aspx.cs" Inherits="Coleccionar.ComprarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">
        <div class=" col-lg-6 col-md-6 col-sm-8 col-lg-offset-3 col-md-offset-3 col-sm-offset-2">

            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Compra"></asp:Label>
                    </div>
                </div>

                <div id="div_txtMetodoEntrega" class="form-group required" style="padding-top: 10px">
                    <label for="rbMetodoEntrega" class="control-label col-md-4  requiredField">Método de Entrega<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:RadioButtonList ID="rbMetodoEntrega" runat="server">
                            <asp:ListItem Text="Envío a Domicilio" Value="envio" Selected="True" />
                            <asp:ListItem Text="Retiro al Domicilio de Vendedor" Value="retiro" />
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div id="div_ddlMedioDePago" class="form-group required" style="padding-top: 10px">
                    <label for="ddlMedioDePago" class="control-label col-md-4  requiredField">Medio De Pago<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:DropDownList ID="ddlMedioDePago" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" class="btn btn-primary" CausesValidation="False" OnClick="btnSiguiente_Click" />
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

</asp:Content>
