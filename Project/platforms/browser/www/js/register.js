var baseUri = "http://192.168.5.12:55555/api/";

$(document).ready(function() {

    document.addEventListener("deviceready", function(){

      $("#signup").click(function() {

        username = $("#username").val();
        password = $("#password").val();
        confPassword = $("#confirmPassword").val();

        if(isFormValid(username, password, confPassword)) {
          validationSucceded();
          register(username, password);
        } else {
          validationFailed();
        }

      });

    });
});

function register(username, password) {
  $.post(baseUri+"register", {
    username: this.username,
    password: this.password
  }).done(function() {
    registrationSucceded();
  }).fail(function() {
    registrationFailed();
  });
}

function validationSucceded() {
  $("#validation-fail").hide();
}

function validationFailed() {
  $("#validation-fail").show();
}

function registrationSucceded() {
  $("#register-fail").hide();
}

function registrationFailed() {
  $("#register-fail").show();
}

function isFormValid(username, password, confPassword) {
  return (passwordConfirmed(password, confPassword) && validLength(username, password));
}

function validLength(username, password) {
  return username.length >= 4 && password.length >= 4 ? true : false;
}

function passwordConfirmed(pass1, pass2) {
  return pass1 == pass2 ? true : false;
}