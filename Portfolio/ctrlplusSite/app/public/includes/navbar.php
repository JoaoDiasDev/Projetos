	<!-- Navigation -->
	<nav class="navbar bg-dark navbar-dark navbar-expand-lg sticky-top">
	    <div class="container px-1">

	        <a href="#" class="navbar-brand"><img src="img/CTRL_logo.png" alt="Logo" title="Logo"></a>
	        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive">
	            <span class="navbar-toggler-icon"></span>
	        </button>

	        <div class="collapse navbar-collapse" id="navbarResponsive">
	            <ul class="navbar-nav ml-auto">
	                <li class="nav-item"><a href="index.php"  class="nav-link  <?php if($page=='index'){echo 'active';}?>">Inicio</a></li>
	                <li class="nav-item"><a href="sobre_nos.php"  class="nav-link <?php if($page=='sobre_nos'){echo 'active';}?>">Sobre Nos</a></li>
	                <li class="nav-item"><a href="fale_conosco.php"  class="nav-link <?php if($page=='fale_conosco'){echo 'active';}?>">Fale Conosco</a></li>
	                <li class="nav-item"><a href="projetos.php"  class="nav-link <?php if($page=='projetos'){echo 'active';}?>">Projetos</a></li>
	               <!-- <li class="nav-item"><a href="orcamentos.php" class="nav-link <?php if($page=='orcamentos'){echo 'active';}?>">Orçamentos</a></li> -->
	            </ul>
	        </div>
	    </div>

	</nav>
	<!-- End Navigation -->