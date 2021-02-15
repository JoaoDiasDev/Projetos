<!DOCTYPE html>
<html lang="pt-br">

<head>

    <?php include 'includes/head.php'; ?>
</head>

<body>





    <?php $page = 'fale_conosco'; include 'includes/navbar.php'; ?>



    <section class="fale_conosco">
        <div class="container">
            <div class="contactinfo">
                <div>
                    <h2>Dados para Contato</h2>
                    <ul class="info">
                        <li>
                            <span><img src="/img/Location.png" alt="Locallizacao"></span>
                            <span>Rua São Jose 232<br>
                                Itaocara - RJ<br>
                                28570-000
                            </span>
                        </li>
                        <li>
                            <span><img src="/img/mail.png" alt="Email"></span>
                            <span>controlplus@outlook.com.br
                            </span>
                        </li>
                        <li>
                            <span><img src="/img/call.png" alt="Telefone"></span>
                            <span>22997988055
                            </span>
                        </li>
                    </ul>
                </div>
                <!-- Social media Icons List begin
                <ul class="sci">
                    <li><a href="" class=""><img src="/img/call.png" alt=""></a></li>
                    <li><a href="" class=""><img src="/img/location.png" alt=""></a></li>
                    <li><a href="" class=""><img src="/img/mail.png" alt=""></a></li>
                    <li><a href="" class=""><img src="/img/mail.png" alt=""></a></li>
                    <li><a href="" class=""><img src="/img/call.png" alt=""></a></li>
                </ul>
                Social Media Icons List End -->


            </div>

            <div class="contactform" id="contactform" name="contactform">
                <h2>Mande uma Mensagem</h2>
                <form class="main-form needs-validation"  name="submitform_" id="submitform_" method="POST"
                    action="submit_fale_conosco.php">
                    <div class="formbox" id="formbox" name="formbox">
                        <div class="inputbox w50">

                            <input type="text" name="firstname" id="firstname" required>
                            <span>Primeiro Nome</span>



                        </div>
                        <div class="inputbox w50">
                            <input type="text" name="lastname" id="lastname" required>
                            <span>Sobrenome</span>


                        </div>
                        <div class="inputbox w50">
                            <input type="text" name="email" id="email" required>
                            <span>Email</span>


                        </div>
                        <div class="inputbox w50">
                            <input type="text" name="phone" id="phone" required>
                            <span>Telefone</span>
                        </div>
                        <div class="inputbox w100">
                            <textarea name="message" id="message" required></textarea>
                            <span>Escreva sua mensagem aqui...</span>
                        </div>
                        <div class="inputbox w100">
                            <button type="submit" id="btnsubmit" name="btnsubmit">Enviar</button>

                </form>
            </div>
        </div>



    </section>




    <?php include 'includes/footer.php'; ?>


    <?php include 'includes/socket.php'; ?>

    <?php include 'includes/scripts.php'; ?>
</body>

</html>