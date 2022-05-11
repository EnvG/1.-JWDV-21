$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#auth-button").click(() => {
    // Введённые данные
    let fullname = $("#fullname").val();
    let email = $("#email").val();
    let pasword = $("#password").val();
    let confirmPassword = $("#password-confirmation").val();

    // Если поле пароля не совпадает с полем подтверждения пароля,
    // то предупредить об этом пользователя
    if (pasword !== confirmPassword) {
      alert("Пароли не совпадают");
      $("#password-confirmation").val("");
    } else {
      // Иначе выполнить запро к API
      $.ajax({
        type: "GET",
        url: `${API_URL}/user/registration?fullname=${fullname}&email=${email}&password=${pasword}`,
        success: function (response) {
          if (response) {
            alert("Пользователь зарегистрирован");
          } else {
            alert("Ошибка регистрации");
          }
        },
      });
    }
  });
});
