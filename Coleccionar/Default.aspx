<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coleccionar.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .counter {
            text-align: center;
            font-size: 100px;
        }
    </style>

    <script type="text/javascript">

        $('.carousel').carousel({
            interval: 2000,
            pause: true,
            wrap: false
        });
    </script>

    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- Compiled and minified Bootstrap CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" >
<!-- Minified JS library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!-- Compiled and minified Bootstrap JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" ></script--%>


    <div class="row ">

        <asp:Panel ID="Panel1" runat="server" Visible="true">
            <div class="panel panel-info sombreado" visible="true" id="">
                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Sumate a Coleccionar"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">Tenemos más de </label>
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" id="cont1" style="font-size: 50px; text-align: center;">0</label>
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">usuarios registrados.</label>
                    </div>

                    <div class="col-md-3">
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">Tenemos más de </label>
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" id="cont2" style="font-size: 50px; text-align: center;">0</label>
                        <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">Art&iacute;culos en venta.</label>
                    </div>



                    <div class="col-md-3">
                        <label for="txtDesactivar" class="control-label col-md-12 requiredField" style="text-align: center;">Tenemos más de </label>
                        <label for="txtDesactivar" class="control-label col-md-12 requiredField" id="cont3" style="font-size: 50px; text-align: center;">0</label>
                        <label for="txtDesactivar" class="control-label col-md-12 requiredField" style="text-align: center;">Productos solicitados.</label>

                    </div>
                    <div class="col-md-3">
                        <div class="item">
                            <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">Tenemos más de </label>
                            <label for="txtDesactivar" class="control-label col-md-12  requiredField" id="cont4" style="font-size: 50px; text-align: center;">0</label>
                            <label for="txtDesactivar" class="control-label col-md-12  requiredField" style="text-align: center;">Productos vendidos.</label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>


        <div class="col-md-12">
            <div style="width: 500px; height: 400px; display: block; margin: auto;">

                <div id="myCarouselCustom" class="carousel slide" data-ride="carousel">
                    <!-- Indicators (indica abajo el numero de slide -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarouselCustom" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarouselCustom" data-slide-to="1"></li>
                        <li data-target="#myCarouselCustom" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">


                            <a href="">
                                <img src="img/im2.jpg" /></a>
                            <div class="carousel-caption" style="text-shadow: 3px 3px 3px blue;">
                                <h1>Compr&aacute; lo que necesites</h1>

                            </div>
                        </div>

                        <div class="item">

                            <a href="">
                                <img src="img/im3.jpg" /></a>
                            <div class="carousel-caption" style="text-shadow: 3px 3px 3px blue;">
                                <h1>Vend&eacute; lo que ya no uses</h1>

                            </div>
                        </div>

                        <div class="item">

                            <a href>
                                <img src="img/im1.jpg" /></a>
                            <div class="carousel-caption" style="text-shadow: 3px 3px 3px blue;">
                                <h1>Public&aacute; lo que est&aacute;s buscando</h1>

                            </div>
                        </div>
                    </div>


                </div>
                <!-- Custom Controls -->
            </div>
        </div>
    </div>
    <div class="row">


        <div class="col-md-12">
            <h1>¿Quienes somos?</h1>
            <label for="txtDesactivar" class="control-label col-md-12  requiredField">
                COLECCIONAR es una aplicación web que agiliza tu búsqueda para que puedas tener aquello que siempre quisiste, además podrás comprar y vender con mayor rapidez que en otras páginas.</br>
A medida que pasa el tiempo hay cosas que dejamos de usar, y mucha gente podría estar buscando.</br>
Quizás tengas en tu casa algo por lo que alguien pagaría mucho dinero, y no lo sabes. </br>
Por eso COLECCIONAR te da la posibilidad de que vendas aquellas cosas que ya no uses.</br>
 Así mismo, si estás buscando algo hace tiempo, podes realizar una publicación de búsqueda para que otros puedan ayudarte a encontrarlo. Si alguna persona tiene lo que necesitas podrías comprárselo acordando el precio.</br>
Con COLECCIONAR podrás Ganar dinero!!
Aquello que tenes en tu casa guardado y ocupa espacio. Aquello que pensas que no tiene valor: Véndelo en COLECCIONAR.

 
            </label>
        </div>
    </div>

    <script>
        let cont1 = document.getElementById('cont1'),
            cont2 = document.getElementById('cont2'),
            cont3 = document.getElementById('cont3'),
            cont4 = document.getElementById('cont4')
        let cant1 = 0, cant2 = 0, cant3 = 0, cant4 = 0
        tiem = 25
        let tiempo1 = setInterval(() => {
            cont1.textContent = cant1 += 1

            if (cant1 === 27) {
                clearInterval(tiempo1)
            }
        }, 10);
        let tiempo2 = setInterval(() => {
            cont2.textContent = cant2 += 1

            if (cant2 === 50) {
                clearInterval(tiempo2)
            }
        }, 5);

        let tiempo3 = setInterval(() => {
            cont3.textContent = cant3 += 1

            if (cant3 === 28) {
                clearInterval(tiempo3)
            }
        }, 1);
        let tiempo4 = setInterval(() => {
            cont4.textContent = cant4 += 1

            if (cant4 === 47) {
                clearInterval(tiempo4)
            }
        }, 1);
    </script>

</asp:Content>
