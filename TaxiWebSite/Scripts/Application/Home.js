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
        //alert($("#lang").val());
        if ($("#lang").val() == "ger") {
            $("#home").html(resourcesG.home);
            $("#about").html(resourcesG.about);
            $("#booking").html(resourcesG.booking);
            $("#toairport").html(resourcesG.toairport);
            $("#fromairport").html(resourcesG.fromairport);
            $("#contact").html(resourcesG.contact);
            $("#text").html(resourcesG.text);

        }
        else {
            $("#home").html(resources.home);
            $("#about").html(resources.about);
            $("#booking").html(resources.booking);
            $("#toairport").html(resources.toairport);
            $("#fromairport").html(resources.fromairport);
            $("#contact").html(resources.contact);
            $("#text").html(resources.text);
        }

        $("#flagEng").on('click', function () {
            $.ajax({
                url: '/Home/SetSession',
                type: 'POST',
                //dataType: "json",
                data: {
                    lang: "eng"
                },
                success: function (data) {
                    $("#home").html(resources.home);
                    $("#about").html(resources.about);
                    $("#booking").html(resources.booking);
                    $("#toairport").html(resources.toairport);
                    $("#fromairport").html(resources.fromairport);
                    $("#contact").html(resources.contact);
                    $("#text").html(resources.text);
                }
            });
        });

        $("#flagGer").on('click', function () {
            $.ajax({
                url: '/Home/SetSession',
                type: 'POST',
                //dataType: "json",
                data: {
                    lang: "ger"
                },
                success: function (data) {
                    $("#home").html(resourcesG.home);
                    $("#about").html(resourcesG.about);
                    $("#booking").html(resourcesG.booking);
                    $("#toairport").html(resourcesG.toairport);
                    $("#fromairport").html(resourcesG.fromairport);
                    $("#contact").html(resourcesG.contact);
                    $("#text").html(resourcesG.text);
                }
            });
        });

});