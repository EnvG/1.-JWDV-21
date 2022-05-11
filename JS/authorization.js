$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#auth-button").click(() => {
    // Введённые данные
    let email = $("#email").val();
    let password = $("#password").val();

    // Запрос авторизации к API
    $.ajax({
      type: "GET",
      url: `${API_URL}/user/auth?email=${email}&password=${password}`,
      success: function (response) {
        if (response) {
          alert("Авторизация прошла успешно");
        } else {
          alert("Неверный email или пароль");
        }
      },
    });

    // Очистка поля ввода пароля
    $("#password").val("");
  });
});
