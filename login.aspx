<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="smartCampos.login" %>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../Content/css/login.css">
    <title>Login</title>
</head>
<body>

    <div class="login-card">
        <h1>Login</h1>

        <form id="form" runat="server">
            <label for="Email">Email:</label>
            <asp:TextBox runat="server"  TextMode="Email" ID="txtEmail" required="required" placeholder="Digite o seu email" CssId="Email"></asp:TextBox>

            <label for="Senha">Senha:</label>
            <asp:TextBox runat="server"  ID="txtSenha" required="required" TextMode="Password" placeholder="Digite sua senha" CssId="Senha"></asp:TextBox>
            <a href="#" class="esqueceu">Esqueceu a senha?</a>

            <!-- Botão com ícone -->  
            <asp:Button ID="btnLogin" onclick="btnLogin_Click" runat="server" Text="Login" CssClass="btn-login" />
            <%--<span class="icone">&#10003;</span>--%>
        </form>
        
        <p class="cadastro-texto">
            Não tem uma conta? <a href="/Cadastre-se">cadastre-se</a>
        </p>
    </div>

</body>
</html>
