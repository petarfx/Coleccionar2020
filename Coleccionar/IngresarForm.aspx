<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IngresarForm.aspx.cs" Inherits="Coleccionar.IngresarForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div id="fb-root"></div>
    <a href="#" onclick="loginByFacebook();">Login with Facebook</a>--%>

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
                    <div class="col-md-6">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" CausesValidation="False" OnClick="btnAceptar_Click" />
                    </div>
                    <div class="col-md-6">
                        <div id="fb-root"></div>
                        <a href="#" onclick="loginByFacebook();" class="fa fa-facebook-f btn btn-primary" style="height: 34px;">  Facebook</a>
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

    <%-- now this is some required facebook's JS, two things to pay attention to
    1. setting the ApplicationID, To make this project work you have to edit "callback.aspx.cs" and put your facebook-app-key there
    2. Adjust the permissions you want to get from user, set that in scope options below. --%>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({
                appId: '810925979668061',
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true, // parse XFBML
                oauth: true // enable OAuth 2.0
            });
        };
        (function () {
            var e = document.createElement('script'); e.async = true;
            e.src = document.location.protocol +
                '//connect.facebook.net/en_US/all.js';
            document.getElementById('fb-root').appendChild(e);
        }());

        function loginByFacebook() {
            FB.login(function (response) {
                if (response.authResponse) {
                    FacebookLoggedIn(response);
                } else {
                    console.log('User cancelled login or did not fully authorize.');
                }
            }, { scope: 'user_birthday,user_hometown,user_location,email' });
        }

        function FacebookLoggedIn(response) {
            var loc = '/RegistrarForm.aspx';
            if (loc.indexOf('?') > -1)
                window.location = loc + '&authprv=facebook&access_token=' + response.authResponse.accessToken;
            else
                window.location = loc + '?authprv=facebook&access_token=' + response.authResponse.accessToken;
        }
    </script>
</asp:Content>
