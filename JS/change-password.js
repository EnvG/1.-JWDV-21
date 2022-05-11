$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#change-button").click(function (e) {
    let email = $("#email").val();
    let password = $("#password").val();
    let confirmPassword = $("#confirm-password").val();

    if (password !== confirmPassword) {
      alert("Пароли не совпадают");
      $("#password-confirmation").val("");
    } else {
      $.ajax({
        type: "GET",
        url: `${API_URL}/user/change-password?email=${email}&password=${password}`,
        success: function (response) {
          if (response == null) {
            alert("Новый пароль не может совпадать с текущим");
            return;
          }

          if (response) {
            alert("Пароль изменён");
          } else {
            alert("Ошибка изменения пароля");
          }
        },
      });
    }
  });
});
