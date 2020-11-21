<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicarVentaForm.aspx.cs" Inherits="Coleccionar.PublicarVentaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .imagePreview {
            width: 90px; /*100%;*/
            height: 90px;
            /*background-position: center center;
            background: url(http://cliquecities.com/assets/no-image-e3699ae23f866f6cbdf8ba2443ee5c4e.jpg);*/
            background-color: #fff;
            background-size: cover;
            background-repeat: no-repeat;
            display: inline-block;
            box-shadow: 0px -3px 6px 2px rgba(0,0,0,0.2);
            z-index: 900;
        }

        .botonfoto {
            display: block;
            border-radius: 0px;
            box-shadow: 0px 4px 6px 2px rgba(0,0,0,0.2);
            margin-top: -5px;
        }

        .imgUp {
            margin-bottom: 15px;
        }

        .del {
            position: absolute;
            top: 0px;
            right: 15px;
            width: 30px;
            height: 30px;
            text-align: center;
            line-height: 30px;
            background-color: rgba(255,255,255,0.6);
            cursor: pointer;
        }

        .imgAdd {
            width: 30px;
            height: 30px;
            border-radius: 50%;
            background-color: #4bd7ef;
            color: #fff;
            box-shadow: 0px 0px 2px 1px rgba(0,0,0,0.2);
            text-align: center;
            line-height: 30px;
            margin-top: 0px;
            cursor: pointer;
            font-size: 30px;
            margin-left: 47px;
        }
    </style>


    <div class="row ">
        <div class=" col-lg-4 col-md-6 col-sm-8 col-lg-offset-4 col-md-offset-3 col-sm-offset-2">

            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Publicar Producto"></asp:Label>
                    </div>
                </div>

                <div id="div_ddlCategoria" class="form-group required">
                    <label for="ddlCategoria" class="control-label col-md-4  requiredField">Categoría<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:DropDownList ID="ddlCategoria" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Debe ingresar la Categoría" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_ddlSubCategoria" class="form-group required">
                    <label for="ddlSubCategoria" class="control-label col-md-4  requiredField">Sub Categoría<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:DropDownList ID="ddlSubCategoria" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSubCategoria" runat="server" ControlToValidate="ddlSubCategoria" ErrorMessage="Debe ingresar la Sub-Categoría" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_txtTitulo" class="form-group required" style="padding-top: 10px">
                    <label for="txtTitulo" class="control-label col-md-4  requiredField">Título<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:TextBox ID="txtTitulo" class="form-control" placeholder="Ingrese el Título" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Debe ingresar el Título" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_txtDescripcion" class="form-group required" style="padding-top: 10px">
                    <label for="txtDescripcion" class="control-label col-md-4  requiredField">Descripcion<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Ingrese la Descripcion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Debe ingresar el Descripción" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_ddlEstadoProducto" class="form-group required">
                    <label for="ddlEstadoProducto" class="control-label col-md-4  requiredField">Estado del Producto<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:DropDownList ID="ddlEstadoProducto" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEstadoProducto" runat="server" ControlToValidate="ddlEstadoProducto" ErrorMessage="Debe ingresar el Estado del Producto" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_txtPrecio" class="form-group required">
                    <label for="txtPrecio" class="control-label col-md-4  requiredField">Precio<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:TextBox ID="txtPrecio" class="form-control" placeholder="Ingrese el Precio" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Debe ingresar el Precio" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="form-group required">
                    <div class="col-sm-4 imgUp">
                        <div class="imagePreview"></div>
                        <label class="btn btn-primary">
                            Cargar<input type="file" class="uploadFile img" value="Upload Photo" style="width: 0px; height: 0px; overflow: hidden;">
                        </label>
                    </div>
                    <!-- col-2 -->
                    <i class="fa fa-plus imgAdd"></i>
                </div>

                <%--<div class="col-sm-4 imgUp">
                    <i class="fa fa-plus imgAdd"></i>
                    <div class="imagePreview"></div>
                    <label class="btn btn-primary">
                        Upload<input type="file" class="uploadFile img" value="Upload Photo" style="width: 0px; height: 0px; overflow: hidden;">
                    </label>      
                </div>--%>




                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" CausesValidation="False" />

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
    <script src="https://kit.fontawesome.com/92296f671b.js" crossorigin="anonymous"></script>
</asp:Content>
