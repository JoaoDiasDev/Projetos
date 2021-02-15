<?php

$firstname = $lastname = $email = $message = $phone = "";

$firstname_error = $lastname_error = $email_error = $message_error = $phone_error = "";



    if (empty($_POST['firstname'])) {
        $firstname_error = "Primeiro Nome é necessario";
    } else {
        $firstname = $_POST['firstname'];
    }
    

    if (empty($_POST['lastname'])) {
        $lastname_error = "Sobrenome é necessario";
    } else {
        $lastname = $_POST['lastname'];
    }

    if (empty($_POST['email'])) {
        $email_error = "Email é necessario";
    } else {
        $email = $_POST['email'];   
    }

    if (empty($_POST['message'])) {
        $message_error = "Mensagem é necessaria";
    } else {
        $message = $_POST['message'];
    }

    if (empty($_POST['phone'])) {
        $phone_error = "Telefone é necessario.";
    } else {
        $phone = $_POST['phone'];
    }

    $email_from = 'CTRLPlus Site';
    $email_subject = 'Nova Mensagem do CTRLPlus Site';
    $email_body = "Nome: $name $lastname.\n".
                "Email: $email.\n".
                    "Telefone: $phone.\n".
                        "Message: $message.\n";

    $to = "jmmatheusrca@gmail.com";
    $headers = "from: $email_from \r\n";
    $headers .= "Reply-to: $email \r\n";

    mail($to, $email_subject, $email_body, $headers);

    header("location: send_fale_conosco.php");
   

 ?>