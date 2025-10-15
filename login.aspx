<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="smartCampos.login" %>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="login.css">
    <title>Login</title>
</head>
<body>

    <div class="login-card">
        <h1>Login</h1>

        <form action="/login" method="post">
            <label for="Email">Email:</label>
            <input type="text" id="Email" name="Email" placeholder="Digite o seu email" required>

            <label for="Senha">Senha:</label>
            <input type="password" id="Senha" name="Senha" placeholder="Digite sua senha" required>

            <a href="#" class="esqueceu">Esqueceu a senha?</a>

            <!-- Botão com ícone -->
            <button type="submit" class="btn-login">
                Login
                <span class="icone">&#10003;</span>
            </button>
        </form>

        <p class="cadastro-texto">
            Não tem uma conta? <a href="/Cadastre-se">cadastre-se</a>
        </p>
    </div>

</body>
</html>
