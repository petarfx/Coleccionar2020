<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedOut.Master" AutoEventWireup="true" CodeBehind="VerPublicacionForm.aspx.cs" Inherits="Coleccionar.VerPublicacionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .carousel-indicators li {
            text-indent: 0 !important;
            height: 25px !important;
            width: 25px !important;
            line-height: 25px !important;
            border-radius: 25px !important;
            background-color: #d1d1d1;
            color: #444;
            text-align: center;
        }

            .carousel-indicators li.active {
                background-color: #fff;
            }
    </style>
    <div id="myCarousel" class="carousel carrouselPublicacion marginTop slide col-lg-5 col-lg-offset-2 col-sm-12" data-ride="carousel" style="height: 355px;">
        <%--style="width: 848px;"--%>
        <asp:Repeater ID="rptMain" runat="server" OnItemDataBound="OnItemDataBound">
            <ItemTemplate>
                <ol class="carousel-indicators">
                    <asp:Repeater ID="rptIndicators" runat="server">
                        <ItemTemplate>
                            <li data-target="#myCarousel" data-slide-to='<%# Container.ItemIndex%>' class='<%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                <%#Eval("Banner_Name")%>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <asp:Repeater ID="rptSlides" runat="server">
                        <ItemTemplate>
                            <div align="center" <%# Container.ItemIndex == 0 ? "class=\"item active\"" : "class=\"item\"" %>>
                                <img src='<%#Eval("Banner_Image")%>' class="img-responsive" alt="" style="height: 349px;">
                                <%--style="width: 848px; height: 388px"--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span><span class="sr-only">Next</span> </a>
    </div>
    <div class="col-lg-4 col-lg-offset-1 col-sm-12 datosPublicacion marginTop espacioTop">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label ID="lblEstadoProducto" runat="server" Text="texto" CssClass="estadoProdPublicacion"></asp:Label>
                <asp:Label ID="lblTipoPublicacion" runat="server" Text="tipo" CssClass="estadoProdPublicacion"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label ID="lblTitulo" runat="server" Text="titulo" CssClass="tituloPublicacion"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label ID="lblCategoriaSubCategoria" runat="server" Text="categoria" CssClass="categoriaPublicacion"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label ID="lblPrecio" runat="server" Text="precio" CssClass="precioPublicacion"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label ID="lblFecha" runat="server" Text="fecha" CssClass="fechaPublicacion"></asp:Label>
            </div>
        </div>
        <div class="row espacioDown espacioTop">
            <div class="col-md-10 col-md-offset-1">
                <asp:Button ID="btnPreguntar" runat="server" Text="Preguntar" CssClass="btn btn-success" Style="width: 100%" />
            </div>
        </div>
        <div class="row espacioDown">
            <div class="col-md-10 col-md-offset-1">
                <asp:Button ID="btnComprar" runat="server" Text="Comprar" CssClass="btn btn-primary" Style="width: 100%" OnClick="btnComprar_Click" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-10 col-lg-offset-1 divPublicacionDescripcion">
            <div class="row">
                <asp:Label ID="titulodeladescripcion" CssClass="tituloDescripcionPublicacion" runat="server" Text="Descripción"></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="lblDescripcion" CssClass="descripcionPublicacion" runat="server" Text="descripcion"></asp:Label>
            </div>
        </div>
    </div>

    <!-- Modal LoTengo -->
    <div class="modal fade" id="loTengoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content sombreadoModal">
                <div class="modal-header col-md-12 DivAntiguo">
                    <div class="col-md-2 col-sm-3 col-xs-3">
                        <asp:Image ID="imgTitulo" ImageUrl="~/img/logoLoro.png" Style="width: 75px; height: 75px" runat="server" />
                    </div>
                    <div class="col-md-10 col-sm-9 col-xs-9 divTextoCentradoVertical">
                        <%--<h5 class="modal-title" id="eliminarModalLabel"></h5>--%>
                        <asp:Label ID="lblLoTengoTitulo" runat="server" Text="Lo Tengo" CssClass="tituloModalGrande"></asp:Label>
                    </div>
                    <%--<div class="col-md-1">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>--%>
                </div>
                <div class="DivAntiguo ">
                    <div class="modal-body centrado">
                        <asp:Label ID="lblLoTengoMsj" runat="server" Text="" CssClass="textoCuerpoModalGrande"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer DivAntiguo">
                    <div class="col-md-5 col-md-offset-1 col-sm-6 col-xs-12">
                        <asp:Button ID="btnLoTengo" class="btn botonPirata" style="width:100%" CausesValidation="False" runat="server" Text="CONTINUAR" OnClick="btnLoTengo_Click" />
                    </div>
                    <div class="col-md-5 col-md-offset-1 col-sm-6 col-xs-12">
                        <button type="button" class="btn botonPirata" data-dismiss="modal" style="width:100%">CANCELAR</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/coleccionarScripts.js" type="text/javascript"></script>
</asp:Content>
