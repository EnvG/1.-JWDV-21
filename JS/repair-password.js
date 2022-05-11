$(document).ready(function () {
  const API_URL = "https://localhost:7283";

  $("#repair-button").click(() => {
    let email = $("#email").val();

    $.ajax({
      type: "GET",
      url: `${API_URL}/user/repair-password?email=${email}`,
      success: function (response) {
        if (response) {
          document.location.href = "/changePassword.html";
        } else {
          alert("Пользователь с данным email не найден");
        }
      },
    });
  });
});
