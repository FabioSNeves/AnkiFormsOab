<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="website.Pages.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro</title>
    <link type="text/css" rel="stylesheet" href="../Content/bootstrap.min.css" />
 		<meta name="viewport" content="width=device-width"/>
		<style>
			.navbar-header button{
				color: #fff;
			}

			footer{
				background: #333;
				color: #fff;
				text-align: center;
				padding: 20px 0;
			}

            main{
                padding-top: 50px;
            }

		</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <!--Começo cabeçalho-->
        <header class="row">
			<nav class="navbar-inverse navbar-fixed-top">
				<div class="navbar-header">
					<a href="../Default.aspx" class="navbar-brand">AnkiOAB</a>
					<button type="button" data-target=".navbar-collapse" data-toggle="collapse" class="navbar-toggle">Menu</button>
				</div>
				<div class="collapse navbar-collapse">
					<ul class="nav navbar-nav">
						<li><a href="About.aspx">About</a></li>
						<li><a href="#">Blog</a></li>
						<li class="dropdown">

						<a href="#" data-toggle="dropdown" class="dropdown-toggle">Entre<span class="caret"></span></a>
							<ul class="dropdown-menu">
								<li><a href="Login.aspx">Login</a></li>
								<li><a href="Cadastro.aspx">Cadastro</a></li>
							</ul>
						</li>
					</ul>
					<div class="navbar-form navbar-right">
						<div class="form-group">
							<input type="text" placeholder="Search" class="form-control"/>
						</div>
						<input type="submit" value="Buscar" class="btn btn-default"/>
					</div>
				</div>
			</nav>
		</header>
        <!--Fim cabeçalho-->
        <main>
		    <div class="span10 offset1">

                <div class="row">
                    <h3 class="well">Cadastro</h3>
                </div>
		    </div>
        </main>
		<footer class="row navbar-fixed-bottom">
			AnkiOAB © 2016 - Todos os direitos reservados.
        </footer>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="../Scripts/jquery-1.9.0.min.js"/>
                    <asp:ScriptReference Path="../Scripts/bootstrap.min.js"/>
                </Scripts>
            </asp:ScriptManager>
    </div>
    </form>
</body>
</html>
