$(document).ready(function () {

    $("#street").select2({
        placeholder: "Select a Street",
        allowClear: true
    });

    $("#submit").on('click', function () {
        $("#anim").removeClass("invisible");
        $("#anim").addClass("glyphicon-refresh-animate");       
        $.ajax({
            url: "/Booking/BookingDOAerodroma",
            type: 'POST',
            data: {
                pickUpDate: $("#InputDate").val(),
                pickUpTime: $("#InputTime").val(),
                pickUpFrom: $("#InputPickupFrom option:selected").text(),
                fullName: $("#InputFullName").val(),
                location: $("#InputLocation option:selected").text(),
                zipCode: $("#InputZipCode option:selected").text(),
                phone: $("#InputTelFirst").val(),
                email: $("#InputEmail").val(),
                typeOfCar: $("#car_type option:selected").text(),
                suitcases: $("#suitcases option:selected").text(),
                handLaggage: $("#hand_package option:selected").text(),
                payment: $("#payment option:selected").text(),
                street: $("#street option:selected").text()

            },
            success: function (data) {
                $("#anim").removeClass("glyphicon-refresh-animate");
                $("#anim").addClass("invisible");
                alert(data.poruka);
            },
            error: function () {
                alert("GRESKAA!");
            }
        });



    });

    $("#InputLocation").change(function () {
        var id;
        id = $("#InputLocation").val();
        $.ajax({
            url: '/Booking/ListaOblasti',
            type: 'POST',
            //dataType: "json",
            data: {
                id: id
            },
            success: function (data) {
                $("#InputZipCode").html(data);
                $("#InputZipCode").val()
                $("#InputZipCode").change(function () {
                    //alert("asdasd");
                    $.ajax({
                        url: '/Booking/ListaUlica',
                        type: 'POST',
                        //dataType: "json",
                        data: {
                            id: $("#InputZipCode").val()
                            //tekst: request.term
                        },
                        success: function (data) {
                            $("#street").html(data);
                            $("#street").select2({
                                placeholder: "Select a Street",
                                allowClear: true
                            });
                        }
                    });
                    //$("#street").autocomplete({
                    //    source: function (request, response) {
                    //        $.ajax({
                    //            url: '/Booking/ListaUlica',
                    //            type: 'POST',
                    //            dataType: "json",
                    //            data: {
                    //                id: $("#InputZipCode").val(),
                    //                tekst: request.term
                    //            },
                    //            success: function (data) {                                    
                    //                var obj = $.parseJSON(data);
                    //                response(obj, function (item) {                                        
                    //                });
                    //            }
                    //        });
                    //    },
                    //    minLength: 2,
                    //    select: function (event, ui) {
                    //        //alert();
                    //        naziv = ui.item.label;
                    //        id = ui.item.value;
                    //    },
                    //    open: function () {
                    //        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                    //    },
                    //    close: function () {
                    //        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                    //        if ($("#InputZipCode").val() != "") {
                    //            $("#InputZipCode").attr("value", naziv);
                    //            $("#InputZipCode2").attr("value", id);
                    //        }

                    //    }
                    //});
                });
            }

        });
    });

    //OPTIONS ZA PLAGIN PLACEHOLDERLABEL
    var option = {
        placeholderColor: "#898989", // Color placeholder
        labelColor: "#4AA2CC", // Color label (after the focus)
        labelSize: "10px", // Size of label (after the focus)
        useBorderColor: true, // If true a border input is altered after focus
        inInput: true, // If true the label is actually in half vertically
        timeMove: 200 // Time effect move after focus
    }


    //$('input[placeholder]').jvFloat();
    $(".datum").datepicker();
    $(".datum").datepicker( "option", "showAnim","drop");

    //kada se klikne na datum, da navbar ne prekrije kalendar
    $(".datum").click(function () {
        $(".ui-datepicker").css("z-index", "9999");
    });
});