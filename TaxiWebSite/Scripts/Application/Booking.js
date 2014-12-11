$(document).ready(function () {

    $("#street").select2({
        placeholder: "Select a Street",
        allowClear: true
    });


    //validacija forme
    $("#frm_Reservacija").validate({
        rules: {
            InputDate: { required: true },
            pickupHRS: { required: true },
            pickupMIN: { required: true },
            InputFullName: { required: true },
            InputLocation: { required: true },
            InputZipCode: { required: true },
            InputEmail: { email: true },
            street: { required: true }

        },
        messages: {
            InputDate: "<span style='color:red'>&nbsp;*</span>",
            pickupHRS: "<span style='color:red'>&nbsp;*</span>",
            pickupMIN: "<span style='color:red'>&nbsp;*</span>",
            InputFullName: "<span style='color:red'>&nbsp;*</span>",
            InputLocation: "<span style='color:red'>&nbsp;*</span>",
            InputZipCode: "<span style='color:red'>&nbsp;*</span>",
            InputEmail: "<span style='color:red'>&nbsp;*</span>",
            street: "<span style='color:red'>&nbsp;*</span>"
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
        //errorPlacement: function (error, element) {
            
        //}
    });

    $("#submit").on('click', function () {
      //  $("#anim").removeClass("invisible");
        if ($("#frm_Reservacija").validate().form()) {
            $("#anim").addClass("glyphicon-refresh-animate");
            $.ajax({
                url: "/Booking/BookingDOAerodroma",
                type: 'POST',
                data: {
                    pickUpDate: $("#InputDate").val(),
                    pickUpTime: $("#pickupHRS").val() + ":" + $("#pickupMIN").val(),
                    house: $("#house").val(),
                    flor: $("#flor").val(),
                    door: $("#door").val(),
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
                    street: $("#street option:selected").text(),
                    comment: $("#comment").val(),
                    isReturn: $("#return").is(':checked'),
                    ReturnDate: $("#ReturnDate").val(),
                    ReturnTime: $("#pickupHRSReturn").val() + ":" + $("#pickupMINReturn").val(),
                    price: $("#lblPrice").text(),
                    ID_Ulice: $("#street").val()


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
            });//kraj ajax
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
                            //pokreni akciju za cenu
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
                //pokreni akciju za cenu
                izracunajCenu();
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

    //pri selektovanju datuma, da skine error mesage
    $(".datum").change(function () {
        $(this).siblings('label').hide();
    });
    //$('input[placeholder]').jvFloat();
    $(".datum").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd-mm-yy',
        minDate: 0
    });
    $(".datum").datepicker( "option", "showAnim","drop");

    //kada se klikne na datum, da navbar ne prekrije kalendar
    $(".datum").click(function () {
        $(".ui-datepicker").css("z-index", "9999");
    });

    $(".datumReturn").datepicker();
    $(".datumReturn").datepicker("option", "showAnim", "drop");

    //kada se klikne na datum, da navbar ne prekrije kalendar
    $(".datumReturn").click(function () {
        $(".ui-datepicker").css("z-index", "9999");
    });



    $("#return").change(
    function () {
        if ($(this).is(':checked')) {
            $("#divTrip").show(300);
        }
        else {
            $("#divTrip").hide(200);
        }
    });


    $("#payment").change(function () {

       // alert($(this).val());
        if ($(this).val() == "card") {
            $("#mess_divCard").show(300);
        }
    });

});//doc ready