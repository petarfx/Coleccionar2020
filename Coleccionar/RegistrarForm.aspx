<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="RegistrarForm.aspx.cs" Inherits="Coleccionar.RegistrarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">
        <div id="divMensaje" runat="server" style="display:none" visible="true" cssclass="showhide col-lg-10 col-lg-offset-1 alert-dismissible fade in">
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
                    <div id="div_txtAlias" class="col-md-6" style="padding-top: 10px">
                        <label for="txtAlias" class="control-label col-md-4  requiredField">Alias<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtAlias" class="form-control" placeholder="Ingrese el Alias" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAlias" runat="server" ControlToValidate="txtAlias" ErrorMessage="Debe ingresar el Alias" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="div_txtEmail" class="col-md-6" style="padding-top: 10px">
                        <label for="txtEmail" class="control-label col-md-4  requiredField">Email<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtEmail" class="form-control" placeholder="Ingrese el Email" runat="server" MaxLength="15" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe ingresar el Email" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtApellido" class="col-md-6" style="padding-top: 10px">
                        <label for="txtApellido" class="control-label col-md-4  requiredField">Apellido<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtApellido" class="form-control" placeholder="Ingrese el Apellido" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar el Apellido" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="div_txtNombre" class="col-md-6" style="padding-top: 10px">
                        <label for="txtNombre" class="control-label col-md-4  requiredField">Nombre<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtNombre" class="form-control" placeholder="Ingrese el Nombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar el Nombre" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtDni" class="col-md-6" style="padding-top: 10px">
                        <label for="txtDni" class="control-label col-md-4  requiredField">DNI<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtDni" class="form-control" placeholder="Ingrese el DNI" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Debe ingresar el DNI" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="div_txtFecNac" class="col-md-6" style="padding-top: 10px">
                        <label for="txtFecNac" class="control-label col-md-4  requiredField">Fecha de Nacimiento<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <input type="date" id="txtFecNac" class="form-control" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvFecNac" runat="server" ControlToValidate="txtFecNac" ErrorMessage="Debe ingresar la Fecha de Nacimiento" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtCalle" class="col-md-6" style="padding-top: 10px">
                        <label for="txtCalle" class="control-label col-md-4 requiredField">Calle<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtCalle" class="form-control" placeholder="Ingrese la Calle" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="Debe ingresar la Calle" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="div_txtCalleNumero" class="col-md-6" style="padding-top: 10px">
                        <label for="txtCalleNumero" class="control-label col-md-4 requiredField">Numero<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtCalleNumero" class="form-control" placeholder="Ingrese el Número de domicilio" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCalleNumero" runat="server" ControlToValidate="txtCalleNumero" ErrorMessage="Debe ingresar el Numero de Domicilio" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtPiso" class="col-md-6" style="padding-top: 10px">
                        <label for="txtPiso" class="control-label col-md-4 ">Piso </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtPiso" class="form-control" placeholder="Ingrese el Piso" runat="server" MaxLength="3"></asp:TextBox>
                        </div>
                    </div>

                    <div id="div_txtDepto" class="col-md-6" style="padding-top: 10px">
                        <label for="txtDepto" class="control-label col-md-4 ">Depto </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtDepto" class="form-control" placeholder="Ingrese el Departamento" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_ddlProvincia" class="col-md-6" style="padding-top: 10px">
                        <label for="ddlProvincia" class="control-label col-md-4  requiredField">Provincia<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:DropDownList ID="ddlProvincia" class="form-control" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Debe ingresar la Provincia" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div id="div_ddlLocalidad" class="col-md-6" style="padding-top: 10px">
                        <label for="ddlLocalidad" class="control-label col-md-4  requiredField">Localidad<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:DropDownList ID="ddlLocalidad" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Debe ingresar la Localidad" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtContraseña" class="col-md-6" style="padding-top: 10px">
                        <label for="txtContraseña" class="control-label col-md-4  requiredField">Contraseña<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtContraseña" class="form-control" placeholder="Ingrese la Contraseña" runat="server" MaxLength="15" TextMode="Password" ToolTip="La contraseña debe contener hasta 15 dígitos"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Debe ingresar la Contraseña" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div id="div_txtContraseña2" class="col-md-6" style="padding-top: 10px">
                        <label for="txtContraseña2" class="control-label col-md-4  requiredField">Confirmar Contraseña<span class="asteriskField">*</span> </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtContraseña2" class="form-control" placeholder="Reingrese la Contraseña" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContraseña2" runat="server" ControlToValidate="txtContraseña2" ErrorMessage="Debe ingresar la confirmación de la contraseña" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvContraseñas" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtContraseña2" ErrorMessage="Las contraseñas deben coincidir" ForeColor="Red">*</asp:CompareValidator>
                        </div>
                    </div>
                </div>

                <div class="row form-group">
                    <div id="div_txtTelefono" class="col-md-6" style="padding-top: 10px">
                        <label for="txtTelefono" class="control-label col-md-4 ">Telefono </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtTelefono" class="form-control" placeholder="Ingrese el telefono" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_txtCelular" class="col-md-6" style="padding-top: 10px">
                        <label for="txtCelular" class="control-label col-md-4 ">Celular </label>
                        <div class="controls col-md-8 ">
                            <asp:TextBox ID="txtCelular" class="form-control" placeholder="Ingrese el Celular" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" CausesValidation="False" OnClick="btnAceptar_Click" />

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
</asp:Content>
