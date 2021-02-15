<!DOCTYPE html>
<html lang="pt-br">

<head>
    <?php include 'includes/head.php'; ?>
</head>

<body>


    <?php $page = 'index'; include 'includes/navbar.php'; ?>

    <!-- Start Landing Header-->
    <div class="landing">

        <h4>Quer maior visibilidade para seu projeto?</h4>
        <h1>Entre em contato conosco!</h1>

        <div class="row home justify-content-center text-center px-md-5 px-lg-0">

            <div class="col-3 col-sm-2 col-lg-1 p-0">
                <span class="fa-stack fa-2x">
                    <a href="https://www.instagram.com/" target="_blank">
                        <i class="fas fa-circle fa-stack-2x"></i>
                        <i class="fab fa-instagram fa-stack-1x fa-inverse"></i>
                    </a>
                </span>
            </div>

            <div class="col-3 col-sm-2 col-lg-1 p-0">
                <span class="fa-stack fa-2x">
                    <a href="https://www.facebook.com/" target="_blank">
                        <i class="fas fa-circle fa-stack-2x"></i>
                        <i class="fab fa-facebook fa-stack-1x fa-inverse"></i>
                    </a>
                </span>
            </div>

            <div class="col-3 col-sm-2 col-lg-1 p-0">
                <span class="fa-stack fa-2x">
                    <a href="https://www.youtube.com/" target="_blank">
                        <i class="fas fa-circle fa-stack-2x"></i>
                        <i class="fab fa-youtube fa-stack-1x fa-inverse"></i>
                    </a>
                </span>
            </div>

            <div class="col-3 col-sm-2 col-lg-1 p-0">
                <span class="fa-stack fa-2x">
                    <a href="https://twitter.com/home" target="_blank">
                        <i class="fas fa-circle fa-stack-2x"></i>
                        <i class="fab fa-twitter fa-stack-1x fa-inverse"></i>
                    </a>
                </span>
            </div>

        </div>

    </div>


    <!-- End Landing Header -->





    <!-- Heading -->

    <div class="container">
        <div class="row py-0 py-md-3 py-lg-5">

            <div class="col-12 text-center text-uppercase mt-5">
                <h1 class="text-dark pb-3">

                    Como Trabalhamos

                </h1>
                <div class="border-top border-dark w-100 max-auto"></div>
            </div>


        </div>
    </div>

    <!-- Three Column Section -->
    <section class="three_column">
        <div class="container pb-4">
            <div class="row pt-3 pb-5 text-center">

                <div class="col-lg-4 p-4">
                    <h3 class="my-4">Marketing em Redes Sociais</h3>
                    <img src="img/social_media_index.jpg" alt="Redes Sociais" class="w-100 rounded">
                    <p class="lead pt-3">Fazemos toda a parte de marketing e divulgação de sua empresa ou projeto nas
                        redes
                        sociais, de sua escolha, trabalhamos com todas as redes sociais mais utilizadas no Brasil e no
                        mundo.
                    </p>
                    <a href="fale_conosco.php" class="btn btn-outline-dark btn-md">Saiba Mais</a>
                </div>

                <div class="col-lg-4 p-4">
                    <h3 class="my-4">Desenvolvimento de Sites</h3>
                    <img src="img/website_index.jpg" alt="Telas de computador e pessoa desenvolvendo" class="w-100 rounded">
                    <p class="lead pt-3">Desenvolvemos sites conforme a sua empresa ou projeto necessite, verificando as
                        funçoes que o site necessite junto ao cliente, bem como o layout mais apropriado para cada
                        ocasião.
                    </p>
                    <a href="fale_conosco.php" class="btn btn-outline-dark btn-md">Saiba mais</a>
                </div>

                <div class="col-lg-4 p-4">
                    <h3 class="my-5">Aplicativos Mobile</h3>
                    <img src="img/phone_index.jpg" alt="Celular escrito SOCIAL" class="w-100 rounded">
                    <p class="lead pt-3">Desenvolvemos aplicativos mobile de acordo com o que a sua empresa ou projeto
                        necessite, validando sempre com o cliente conforme for avançando no desenvolvimento do
                        aplicativo
                    </p>
                    <a href="fale_conosco.php" class="btn btn-outline-dark btn-md">Em breve</a>
                </div>

            </div>
        </div>
    </section>
    <!-- End Three Column Section -->


    <!-- Start Fixed Background IMG -->
    <div class="fixed-background">



        <div class="fixed-wrap">
            <div class="fixed"></div>
        </div>
    </div>
    <!-- End Fixed Background IMG -->


    <!-- Heading -->


    <div class="pt-5"></div>

    <!-- Two Column Section -->
    <section class="two_column">
        <div class="container pb-5">
            <div class="row pt-3 pb-5 px-4">

                <div class="col-lg-6 mb-5 my-lg-auto">

                    <h3 class="text-dark mb-3">Sobre Nos</h3>
                    <p class="lead">Somos um grupo de amigos cada um com sua area de formação e especiliadade que
                        decidiram
                        se unir e formar esta empresa pioneira na região onde oferecemos serviços de forma objetiva e
                        profissional.</p>
                    <a href="sobre_nos.php" class="btn btn-outline-dark btn-md">Saiba mais</a>
                </div>

                <div class="col-lg-6"><img src="img/quem_somos_index.jpg" alt="Grupo de Pessoas Trabalhando" class="w-100 rounded"></div>

            </div>
        </div>
    </section>
    <!-- End Two Column Section -->






    <?php include 'includes/footer.php'; ?>


    <?php include 'includes/socket.php'; ?>

    <?php include 'includes/scripts.php'; ?>

</body>

</html>