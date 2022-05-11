$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#repair-button").click(() => {
    // Введённые данные
    let email = $("#email").val();

    // Запрос к API
    $.ajax({
      type: "GET",
      url: `${API_URL}/user/repair-password?email=${email}`,
      success: function (response) {
        if (response) {
          // Переход на страницу изменения пароля
          document.location.href = "/changePassword.html";
        } else {
          alert("Пользователь с данным email не найден");
        }
      },
    });
  });
});
