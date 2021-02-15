	<!-- Script Source Files -->

	<!-- jQuery -->
	<script src="js/jquery-3.4.1.min.js"></script>
	<!-- Bootstrap JS -->
	<script src="js/bootstrap.min.js"></script>
	<!-- Popper JS -->
	<script src="js/popper.min.js"></script>
	<!-- Font Awesome -->
	<script src="js/all.min.js"></script>

	<!-- End Script Source Files -->

	<!-- Reset Contact Form -->

	<script>
function submitForm() {
    // Get the first form with the name
    // Usually the form name is not repeated
    // but duplicate names are possible in HTML
    // Therefore to work around the issue, enforce the correct index
    var frm = document.getElementsByName('submitform_')[0];
    if (frm.submit() = true) {
        frm.reset(); // Reset all form data
    }; // Submit the form

    return false; // Prevent page refresh
}
	</script>




	<script>
var form = document.querySelector('.needs-validation');

form.addEventListener('submit', function(event) {
    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
    }
    form.classList.add('was-validated')
})
	</script>
