$(document).ready(function () {

    if ($("#lang").val() == "ger") {
        $("#home").html(resourcesG.home);
        $("#about").html(resourcesG.about);
        $("#booking").html(resourcesG.booking);
        $("#toairport").html(resourcesG.toairport);
        $("#fromairport").html(resourcesG.fromairport);
        $("#contact").html(resourcesG.contact);
        $("#text").load("/AGB/Ger");
        //$("#text").html(resourcesG.text);


    }
    else {
        $("#home").html(resources.home);
        $("#about").html(resources.about);
        $("#booking").html(resources.booking);
        $("#toairport").html(resources.toairport);
        $("#fromairport").html(resources.fromairport);
        $("#contact").html(resources.contact);
        $("#text").load("/AGB/Eng");
        //$("#text").html(resources.text);


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
                $("#text").load("/AGB/Eng");
                //$("#text").html(resources.text);

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
                $("#text").load("/AGB/Ger");
                //$("#text").html(resourcesG.text);

            }
        });
    });

});