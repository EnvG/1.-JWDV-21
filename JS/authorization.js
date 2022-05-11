$(document).ready(function () {
    const API_URL = 'https://localhost:7283'

    $('#auth-button').click(() => {
        let email = $('#email').val();
        let password = $('#password').val();

        console.log(email, password);

        $.get(`${API_URL}/WeatherForecast`, null,
            function (data, textStatus, jqXHR) {
                console.log(data);
            },
            "dataType"
        );
    })
});