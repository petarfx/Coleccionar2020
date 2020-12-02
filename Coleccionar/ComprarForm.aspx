<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ComprarForm.aspx.cs" Inherits="Coleccionar.ComprarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">
        <div class=" col-lg-6 col-md-6 col-sm-8 col-lg-offset-3 col-md-offset-3 col-sm-offset-2" id="pnlPaso1" runat="server">
            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Confirmar Compra"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-8 left" style="text-align: left">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="textodelNombre" class="control-label col-md-4  requiredField">Nombre</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="labeldelacat" class="control-label col-md-4  requiredField">Categoria</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblCategoria" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="labeldelasubcat" class="control-label col-md-4  requiredField">SubCategoria</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblSubCategoria" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="textodelPrecio" class="control-label col-md-4  requiredField">Precio</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblPrecio" runat="server" Text="$$$"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <asp:Image ID="imgFoto" Style="width: 120px; height: 120px" runat="server" />
                    </div>
                </div>

                <div id="div_txtMetodoEntrega" class="form-group required" style="padding-top: 10px">
                    <label for="rbMetodoEntrega" class="control-label col-md-3  requiredField">Método de Entrega<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rbMetodoEntrega" runat="server" OnSelectedIndexChanged="rbMetodoEntrega_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Text="Envío a Domicilio" Value="envio" />
                                    <asp:ListItem Text="Retiro al Domicilio de Vendedor" Value="retiro" />
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div id="div_lblMetodoEntrega" class="form-group required espacioDown espacioTop">
                    <div class="controls col-md-12 ">
                        <asp:UpdatePanel ID="UpdatePanelEntrega" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMetodoEntrega" runat="server" Visible="false" Text="lblMetodoEntrega"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div id="div_ddlMedioDePago" class="form-group required" style="padding-top: 10px">
                    <label for="ddlMedioDePago" class="control-label col-md-3  requiredField">Medio De Pago<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
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

        <div class=" col-lg-6 col-md-6 col-sm-8 col-lg-offset-3 col-md-offset-3 col-sm-offset-2" id="pnlTarjetaCredito" runat="server" visible="false">
            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="Label1" runat="server" Text="Confirmar Compra"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 centrado">
                        Tarjeta de Crédito
                    </div>
                </div>
                <div id="div_ddlTarjeta" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lblddlTarjeta" class="control-label col-md-3  requiredField">Tarjeta<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:DropDownList ID="ddlTarjeta" runat="server">
                            <asp:ListItem Value="1">Visa</asp:ListItem>
                            <asp:ListItem Value="2">MasterCard</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="div_txtTApyn" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTApyn" class="control-label col-md-3  requiredField">Apellido y Nombre<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:TextBox ID="txtTApyn" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div id="div_txtTNumero" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTNumero" class="control-label col-md-3  requiredField">Número<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:TextBox ID="txtTNumero" MaxLength="16" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div id="div_txtTFecVto" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTFecVto" class="control-label col-md-3  requiredField">Fecha Vto<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:TextBox ID="txtTFecVto" MaxLength="4" runat="server" ></asp:TextBox>
                    </div>
                </div>

                <div id="div_txtTCodSeg" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTCodSeg" class="control-label col-md-3  requiredField">Codigo Seguridad<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:TextBox ID="txtTCodSeg" runat="server" MaxLength="3" TextMode="Password"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnTSiguiente" runat="server" Text="Siguiente" class="btn btn-primary" CausesValidation="False" OnClick="btnTSiguiente_Click"  />
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>
    
        <div class=" col-lg-6 col-md-6 col-sm-8 col-lg-offset-3 col-md-offset-3 col-sm-offset-2" id="pnlConfirmar" runat="server" visible="false">
            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="Label2" runat="server" Text="Confirmar Compra"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 centrado">
                        Confirme los datos antes de continuar
                    </div>
                </div>
                <div id="div_cNombre" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="cnombre" class="control-label col-md-3  requiredField">Producto:<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                       <asp:Label ID="lblCNombre" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>

                <div id="div_tcPrecio" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lblcPrecio" class="control-label col-md-3  requiredField">Precio<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:Label ID="lblCPrecio" runat="server" Text="$$$"></asp:Label>
                    </div>
                </div>

                <div id="div_txtme" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTme" class="control-label col-md-3  requiredField">Entrega<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                         <asp:Label ID="lblCMetodoEntrega" runat="server" Text="me"></asp:Label>                       
                    </div>
                </div>

                <div id="div_txtTFecVto" class="form-group required col-md-12" style="padding-top: 10px">
                    <label for="lbltxtTFecVto" class="control-label col-md-3  requiredField">Medio de Pago<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-9 ">
                        <asp:Label ID="lblCMedioPago" runat="server" Text="me"></asp:Label>
                    </div>
                </div>

                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Compra" class="btn btn-primary" CausesValidation="False" OnClick="btnConfirmar_Click"  />
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 espacioDown">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" CausesValidation="False" OnClick="btnCancelar_Click"  />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
