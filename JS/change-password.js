$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#change-button").click(function (e) {
    // Введённые данные
    let email = $("#email").val();
    let password = $("#password").val();
    let confirmPassword = $("#confirm-password").val();

    // Если поле пароля не совпадает с полем подтверждения пароля,
    // то предупредить об этом пользователя
    if (password !== confirmPassword) {
      alert("Пароли не совпадают");
      $("#password-confirmation").val("");
    } else {
      // Иначе выполнить запрос в API
      $.ajax({
        type: "GET",
        url: `${API_URL}/user/change-password?email=${email}&password=${password}`,
        success: function (response) {
          // Если результат запроса — null,
          // то новый пароль совпадает с текущим,
          // предупредить об этом пользователя
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
