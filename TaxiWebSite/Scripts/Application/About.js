$(document).ready(function () {
    
    if ($("#lang").val() == "ger") {
        $("#home").html(resourcesG.home);
        $("#about").html(resourcesG.about);
        $("#booking").html(resourcesG.booking);
        $("#toairport").html(resourcesG.toairport);
        $("#fromairport").html(resourcesG.fromairport);
        $("#contact").html(resourcesG.contact);
        //$("#text").html(resourcesG.text);
        $("#aboutnaslov1").html(resourcesG.aboutnaslov1);
        $("#aboutnaslov2").html(resourcesG.aboutnaslov2);
        $("#aboutsadrzaj1").html(resourcesG.aboutsadrzaj1);
        $("#aboutnaslov3").html(resourcesG.aboutnaslov3);
        $("#aboutsadrzaj2").html(resourcesG.aboutsadrzaj2);
        $("#aboutnaslov4").html(resourcesG.aboutnaslov4);
        $("#aboutsadrzaj3").html(resourcesG.aboutsadrzaj3);

    }
    else {
        $("#home").html(resources.home);
        $("#about").html(resources.about);
        $("#booking").html(resources.booking);
        $("#toairport").html(resources.toairport);
        $("#fromairport").html(resources.fromairport);
        $("#contact").html(resources.contact);
        //$("#text").html(resources.text);
        $("#aboutnaslov1").html(resources.aboutnaslov1);
        $("#aboutnaslov2").html(resources.aboutnaslov2);
        $("#aboutsadrzaj1").html(resources.aboutsadrzaj1);
        $("#aboutnaslov3").html(resources.aboutnaslov3);
        $("#aboutsadrzaj2").html(resources.aboutsadrzaj2);
        $("#aboutnaslov4").html(resources.aboutnaslov4);
        $("#aboutsadrzaj3").html(resources.aboutsadrzaj3);

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
                //$("#text").html(resources.text);
                $("#aboutnaslov1").html(resources.aboutnaslov1);
                $("#aboutnaslov2").html(resources.aboutnaslov2);
                $("#aboutsadrzaj1").html(resources.aboutsadrzaj1);
                $("#aboutnaslov3").html(resources.aboutnaslov3);
                $("#aboutsadrzaj2").html(resources.aboutsadrzaj2);
                $("#aboutnaslov4").html(resources.aboutnaslov4);
                $("#aboutsadrzaj3").html(resources.aboutsadrzaj3);
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
                //$("#text").html(resourcesG.text);
                $("#aboutnaslov1").html(resourcesG.aboutnaslov1);
                $("#aboutnaslov2").html(resourcesG.aboutnaslov2);
                $("#aboutsadrzaj1").html(resourcesG.aboutsadrzaj1);
                $("#aboutnaslov3").html(resourcesG.aboutnaslov3);
                $("#aboutsadrzaj2").html(resourcesG.aboutsadrzaj2);
                $("#aboutnaslov4").html(resourcesG.aboutnaslov4);
                $("#aboutsadrzaj3").html(resourcesG.aboutsadrzaj3);
            }
        });
    });

});