<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IngresarForm.aspx.cs" Inherits="Coleccionar.IngresarForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <script>

        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            console.log("aca entro cuando aprieto el boton de FB");
            console.log('statusChangeCallback');
            console.log(response);
            // The response object is returned with a status field that lets the
            // app know the current login status of the person.
            // Full docs on the response object can be found in the documentation
            // for FB.getLoginStatus().
            if (response.status === 'connected') {
                // Logged into your app and Facebook.
                FB.api('/me', { fields: 'email, short_name, last_name' }, function (response) {

                    console.log(response);

                    var data = $.ajax({
                        type: 'POST',
                        url: '@Url.Action("SocialLogin", "Home")',
                        data: {
                            'nombre': response.short_name,
                            'apellido': response.last_name,
                            'email': response.email
                        },
                        success: function (result) {

                            window.location.href = result;
                        },
                        error: function (ex) {
                            //alert('Error.' + ex);
                        }
                    });
                });

                FB.Event.subscribe('auth.authResponseChange', function (response) {
                    if (response && response.status == 'connected') {
                        //alert('Usuario conectado');
                    }
                });

            } else {
                //console.log("No está logueado");
            }
        }

        // This function is called when someone finishes with the Login
        // Button.  See the onlogin handler attached to it in the sample
        // code below.
        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: '810925979668061', //ColeccionarID
                cookie: true,  // enable cookies to allow the server to access
                // the session
                xfbml: true,  // parse social plugins on this page
                version: 'v9.0' // use graph api version 2.8
            });

            // Now that we've initialized the JavaScript SDK, we call
            // FB.getLoginStatus().  This function gets the state of the
            // person visiting this page and can return one of three states to
            // the callback you provide.  They can be:
            //
            // 1. Logged into your app ('connected')
            // 2. Logged into Facebook, but not your app ('not_authorized')
            // 3. Not logged into Facebook and can't tell if they are logged into
            //    your app or not.
            //
            // These three cases are handled in the callback function.
        };

        // Load the SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/es_LA/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));


    </script>

    <div id="fb-root"></div>
<script async defer crossorigin="anonymous" src="https://connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v9.0&appId=810925979668061&autoLogAppEvents=1" nonce="HZEoQYgW"></script>
    <div class="row ">
        <div class=" col-lg-4 col-md-6 col-sm-8 col-lg-offset-4 col-md-offset-3 col-sm-offset-2">

            <div class="panel panel-info sombreado">

                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblTitulo" runat="server" Text="Ingreso"></asp:Label>
                    </div>
                </div>

                <div id="div_txtAlias" class="form-group required" style="padding-top: 10px">
                    <label for="txtAlias" class="control-label col-md-4  requiredField">Alias<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:TextBox ID="txtAlias" class="form-control" placeholder="Ingrese el Alias" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtAlias" runat="server" ControlToValidate="txtAlias" ErrorMessage="Debe ingresar el Alias" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div id="div_txtPassword" class="form-group required" style="padding-top: 10px">
                    <label for="txtPassword" class="control-label col-md-4  requiredField">Contraseña<span class="asteriskField">*</span> </label>
                    <div class="controls col-md-8 ">
                        <asp:TextBox ID="txtPassword" class="form-control" placeholder="Ingrese la Contraseña" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Debe ingresar la Contraseña" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group-12 col-lg-12 col-md-12 text-center">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" CausesValidation="False" OnClick="btnAceptar_Click" />


                </div>

                <div class="form-group">
                    <div class="form-group-12 col-lg-12 col-md-12 text-center">
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <fb:login-button size="large" width="600px" scope="public_profile,email" onlogin="checkLoginState();">Iniciar con Facebook</fb:login-button>
                            <%--<div class="fb-login-button" data-size="medium" data-button-type="login_with" data-layout="rounded" data-auto-logout-link="false" data-use-continue-as="false" data-width=""></div>--%>
                        </div>
                        <div class="col-md-4"></div>
                    </div>
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
