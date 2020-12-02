<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="OK.aspx.cs" Inherits="Coleccionar.OK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var timeLeft = 10;
        function decrementCounter() {
            var seg = "segundos.";
            if (timeLeft > 0) {
                if (timeLeft == 1)
                    seg = "segundo."
                document.all('countDown').innerHTML = "Datos cargados correctamente, será redirijido a la pantalla principal en " + timeLeft + " " + seg;
                timeLeft--;
                setTimeout("decrementCounter()", 1000);

            }
            else {
                window.location = "Default.aspx";
            }
        }

        $(window).on("load", function () { decrementCounter(); });

    </script>

    <label id="countDown" class="cuentaRegresiva">10</label>
 
    <%--    <input type="button" value="Display alert box in 10 seconds" onclick="decrementCounter()" />--%>
</asp:Content>
