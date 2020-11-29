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
        <div class="row espacioDown espacioTop">
            <div class="col-md-10 col-md-offset-1">
                <asp:Button ID="btnPreguntar" runat="server" Text="Preguntar" CssClass="btn btn-success" Style="width: 100%" />
            </div>
        </div>
        <div class="row espacioDown">
            <div class="col-md-10 col-md-offset-1">
                <asp:Button ID="btnComprar" runat="server" Text="Comprar" CssClass="btn btn-primary" Style="width: 100%" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-10 col-lg-offset-1 divPublicacionDescripcion">
            <div class="row">
                <asp:Label ID="titulodeladescripcion" CssClass="tituloDescripcionPublicacion" runat="server" Text="Descrición"></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="lblDescripcion" CssClass="descripcionPublicacion" runat="server" Text="descripcion"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
