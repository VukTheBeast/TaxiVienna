$(function () {
   
    var icon;
        $.ajax({
            url: "http://api.openweathermap.org/data/2.5/weather?q=Vienna,at",
            dataType: "json"
        }).done(function (data) {
            var a, b;
            icon = data.weather[0].icon;            
            a = parseInt(data.main["temp"]);
            b = a - 273;
            $("#temperatura").html(b + "°C");
            $("#ikonica").attr('src', "http://openweathermap.org/img/w/" + icon + ".png");
        });        
});