$(document).ready(function () {

    $("#street").select2({
        placeholder: "Select a Street",
        allowClear: true
    });

    $("#frm_ReservacijaFromAirport").validate({
        rules: {
            InputDate: { required: true },
            flightFromlightFrom: { required: true },
            flightNumber: { required: true },
            scheduled_time_hr: { required: true },
            pickup_time_min: { required: true },
            InputPickup: { required: true },
            InputFullName: { required: true },
            InputLocation: { required: true },
            s2id_autogen1: { required: true },
            InputZipCode: { required: true },
            street: { required: true },
            InputTelFirst: { required: true },
            InputEmail: { email: true, required: true }
        },
        messages: {
            InputDate: "<span style='color:red'>&nbsp;*</span>",
            flightFromlightFrom: "<span style='color:red'>&nbsp;*</span>",
            flightNumber: "<span style='color:red'>&nbsp;*</span>",
            scheduled_time_hr: "<span style='color:red'>&nbsp;*</span>",
            pickup_time_min: "<span style='color:red'>&nbsp;*</span>",
            InputPickup: "<span style='color:red'>&nbsp;*</span>",
            InputFullName: "<span style='color:red'>&nbsp;*</span>",
            InputLocation: "<span style='color:red'>&nbsp;*</span>",
            s2id_autogen1: "<span style='color:red'>&nbsp;*</span>",
            InputZipCode: "<span style='color:red'>&nbsp;*</span>",
            street: "<span style='color:red'>&nbsp;*</span>",
            InputTelFirst: "<span style='color:red'>&nbsp;*</span>",
            InputEmail: "<span style='color:red'>&nbsp;*</span>"
        },
        errorPlacement: function (error, element) {
            //da select i datapicker element lepo postave error msg...
        if (element.is('select') || $("#InputDate").hasClass('datum')) {
            element.css("display", "inline-block");
            error.css("display", "inline-block");
            error.insertAfter(element);
        } else {
            error.insertAfter(element);
        }
    }
    });



    $("#submitFrom").on('click', function () {
        // $("#anim").removeClass("invisible");
        if ($("#frm_ReservacijaFromAirport").validate().form()) {
            $("#anim").addClass("glyphicon-refresh-animate");
            $.ajax({
                url: "/BookingFrom/BookingFromAerodroma",
                type: 'POST',
                data: {
                    pickUpDate: $("#InputDate").val(),
                    flightFromlightFrom: $("#flightFromlightFrom").val(),
                    flightNumber: $("#flightNumber").val(),
                    pickUpTime: $("#scheduled_time_hr").val() + ":" + $("#pickup_time_min").val(),
                    pickUpFrom: $("#InputPickup option:selected").text(),
                    fullName: $("#InputFullName").val(),
                    location: $("#InputLocation option:selected").text(),
                    zipCode: $("#InputZipCode option:selected").text(),
                    street: $("#street option:selected").text(),
                    phone: $("#InputTelFirst").val(),
                    email: $("#InputEmail").val(),
                    typeOfCar: $("#car_type option:selected").text(),
                    suitcases: $("#suitcases option:selected").text(),
                    handLaggage: $("#hand_package option:selected").text(),
                    isReturn: $("#returnTrip").is(':checked'),
                    returnData: $("#returnDate").val(),
                    returnTime: $("#pickup_time_hrRET").val() + ":" + $("#pickup_time_minRET").val(),
                    payment: $("#payment option:selected").text(),
                    ID_Ulice: $("#street").val(),
                    price: $("#lblPrice").text()


                },
                success: function (data) {
                    $("#anim").removeClass("glyphicon-refresh-animate");
                    var n = noty({
                        text: data.poruka,
                        type: 'success',
                        layout: 'center'
                    });
                },
                error: function () {
                    var n = noty({
                        text: 'Booking was not ordered, some problem accure. Please try again.',
                        type: 'error',
                        layout: 'center'
                    });
                }
            });

        }
        else {
            var n = noty({
                text: 'Fields marked with <span style="color:red">*</span> are required!',
                type: 'information',
                layout: 'center',
                timeout: 1000
            });
        }

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
                            izracunajCenu();
                            $("#street").html(data);
                            $("#street").select2({
                                placeholder: "Select a Street",
                                allowClear: true
                            });
                        }
                    });
                 
                });
            }

        });
    });

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
                izracunajCenu()
                $("#street").html(data);
                $("#street").select2({
                    placeholder: "Select a Street",
                    allowClear: true
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
    $(".datum").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd-mm-yy',
        minDate: 0
    });
    $(".datum").datepicker("option", "showAnim", "drop");

    //kada se klikne na datum, da navbar ne prekrije kalendar
    $(".datum").click(function () {
        $(".ui-datepicker").css("z-index", "9999");
    });




    $("#returnTrip").change(
        function () {
            if ($(this).is(':checked')) {
                $("#divTrip").show(300);
            }
            else {
                $("#divTrip").hide(200);
            }
        });


    $("#payment").change(function () {

        //alert($(this).val());
        if ($(this).val() == "card") {
            $("#mess_divCard").show(300);
        }
    });
    function izracunajCenu() {
        $.ajax({
            url: '/Booking/Cena',
            type: 'POST',
            dataType: "json",
            data: {
                klasa: $("#car_type").val(),
                zona: $("#InputZipCode").val()
            },
            success: function (data) {
                $("#lblPrice").text(data.cena + " " + "€");
                //alert(data.cena);
            }
        });
    }
    $("#car_type").change(function () {
        izracunajCenu();
    });

});