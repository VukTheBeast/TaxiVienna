$(document).ready(function () {    
    if ($("#lang").val() == "ger") {
        $("#lblEmail").html(resourcesG.email + " " + "<i class='fa fa-star-o'></i>");
        $("#InputEmail").attr('placeholder', resourcesG.plhemail);
        $("#lblName").html(resourcesG.fullname + " " + "<i class='fa fa-star-o'></i>");
        $("#InputFullName").attr('placeholder', resourcesG.plhfullname);
        $("#lblPickUpDate").html(resourcesG.pickupdate + " " + "<i class='fa fa-star-o'></i>");
        $("#lblFlightFrom").html(resourcesG.flightfrom + " " + "<i class='fa fa-star-o'></i>");
        $("#InputDate").attr('placeholder', resourcesG.plhpickupdate);
        $("#lblPickUpHRS").html(resourcesG.pickupHRS + " " + "<i class='fa fa-star-o'></i>");
        $("#lblHouse").html(resourcesG.house);
        $("#lblFloor").html(resourcesG.floor);
        $("#lblDoor").html(resourcesG.door);
        $("#lblPickUpFrom").html(resourcesG.pickupfrom);
        $("#from1").html(resourcesG.from1);
        $("#from2").html(resourcesG.from2);
        $("#from3").html(resourcesG.from3);
        $("#from4").html(resourcesG.from4);
        $("#lblLocation").html(resourcesG.location + " " + "<i class='fa fa-star-o'></i>");
        $("#lblStreet").html(resourcesG.street + " " + "<i class='fa fa-star-o'></i>");
        $("#lblPhone").html(resourcesG.phone);
        $("#InputTelFirst").attr('placeholder', resourcesG.plhphone);
        $("#lblCarType").html(resourcesG.cartype);
        $("#car1").html(resourcesG.car1);
        $("#car2").html(resourcesG.car2);
        $("#car3").html(resourcesG.car3);
        $("#lblSuitcase").html(resourcesG.suitcase);
        $("#suit1").html(resourcesG.suit1);
        $("#suit2").html(resourcesG.suit2);
        $("#suit3").html(resourcesG.suit3);
        $("#suit4").html(resourcesG.suit4);
        $("#suit5").html(resourcesG.suit5);
        $("#suit6").html(resourcesG.suit6);
        $("#suit7").html(resourcesG.suit7);
        $("#suit8").html(resourcesG.suit8);
        $("#suit9").html(resourcesG.suit9);
        $("#suit10").html(resourcesG.suit10);
        $("#lblHand").html(resourcesG.hand);
        $("#hand1").html(resourcesG.hand1);
        $("#hand2").html(resourcesG.hand2);
        $("#hand3").html(resourcesG.hand3);
        $("#hand4").html(resourcesG.hand4);
        $("#hand5").html(resourcesG.hand5);
        $("#hand6").html(resourcesG.hand6);
        $("#hand7").html(resourcesG.hand7);
        $("#hand8").html(resourcesG.hand8);
        $("#hand9").html(resourcesG.hand9);
        $("#hand10").html(resourcesG.hand10);
        $("#lblPayment").html(resourcesG.payment);
        $("#pay1").html(resourcesG.pay1);
        $("#pay2").html(resourcesG.pay2);
        $("#pay3").html(resourcesG.pay3);
        $("#lblComment").html(resourcesG.comment);
        $("#lblPrice1").html(resourcesG.price);
        $("#lblReturn").html(resourcesG.lblreturn);
        $("#title").html(resourcesG.fromairport);
        $("#lblReturnDate").html(resourcesG.pickupdate);
        $("#lblReturnTime").html(resourcesG.pickupHRS);
        $("#ReturnDate").attr('placeholder', resourcesG.plhpickupdate);
        $("#lblSee").html(resourcesG.see);
        $("#home").html(resourcesG.home);
        $("#about").html(resourcesG.about);
        $("#booking").html(resourcesG.booking);
        $("#toairport").html(resourcesG.toairport);
        $("#fromairport").html(resourcesG.fromairport);
        $("#contact").html(resourcesG.contact);
        $("#see").html(resourcesG.see);
        $("#lblFlightNumber").html(resourcesG.flightnumber + " " + "<i class='fa fa-star-o'></i>");
        $("#lblDate2").html(resourcesG.pickupdate);
        $("#lblPickupHrs2").html(resourcesG.pickupHRS);
    }
    else {
        $("#lblEmail").html(resources.email + " " + "<i class='fa fa-star-o'></i>");
        $("#InputEmail").attr('placeholder', resources.plhemail);
        $("#lblName").html(resources.fullname + " " + "<i class='fa fa-star-o'></i>");
        $("#InputFullName").attr('placeholder', resources.plhfullname);
        $("#lblPickUpDate").html(resources.pickupdate + " " + "<i class='fa fa-star-o'></i>");
        $("#InputDate").attr('placeholder', resources.plhpickupdate);
        $("#lblPickUpHRS").html(resources.pickupHRS + " " + "<i class='fa fa-star-o'></i>");
        $("#lblHouse").html(resources.house);
        $("#lblFloor").html(resources.floor);
        $("#lblDoor").html(resources.door);
        $("#lblPickUpFrom").html(resources.pickupfrom);
        $("#from1").html(resources.from1);
        $("#from2").html(resources.from2);
        $("#from3").html(resources.from3);
        $("#from4").html(resources.from4);
        $("#lblLocation").html(resources.location + " " + "<i class='fa fa-star-o'></i>");
        $("#lblStreet").html(resources.street + " " + "<i class='fa fa-star-o'></i>");
        $("#lblPhone").html(resources.phone);
        $("#InputTelFirst").attr('placeholder', resources.plhphone);
        $("#lblCarType").html(resources.cartype);
        $("#car1").html(resources.car1);
        $("#car2").html(resources.car2);
        $("#car3").html(resources.car3);
        $("#lblSuitcase").html(resources.suitcase);
        $("#suit1").html(resources.suit1);
        $("#suit2").html(resources.suit2);
        $("#suit3").html(resources.suit3);
        $("#suit4").html(resources.suit4);
        $("#suit5").html(resources.suit5);
        $("#suit6").html(resources.suit6);
        $("#suit7").html(resources.suit7);
        $("#suit8").html(resources.suit8);
        $("#suit9").html(resources.suit9);
        $("#suit10").html(resources.suit10);
        $("#lblHand").html(resources.hand);
        $("#hand1").html(resources.hand1);
        $("#hand2").html(resources.hand2);
        $("#hand3").html(resources.hand3);
        $("#hand4").html(resources.hand4);
        $("#hand5").html(resources.hand5);
        $("#hand6").html(resources.hand6);
        $("#hand7").html(resources.hand7);
        $("#hand8").html(resources.hand8);
        $("#hand9").html(resources.hand9);
        $("#hand10").html(resources.hand10);
        $("#lblPayment").html(resources.payment);
        $("#pay1").html(resources.pay1);
        $("#pay2").html(resources.pay2);
        $("#pay3").html(resources.pay3);
        $("#lblComment").html(resources.comment);
        $("#lblPrice1").html(resources.price);
        $("#lblReturn").html(resources.lblreturn);
        $("#title").html(resources.fromairport);
        $("#lblReturnDate").html(resources.pickupdate);
        $("#lblReturnTime").html(resources.pickupHRS);
        $("#ReturnDate").attr('placeholder', resources.plhpickupdate);
        $("#lblSee").html(resources.see);
        $("#home").html(resources.home);
        $("#about").html(resources.about);
        $("#booking").html(resources.booking);
        $("#toairport").html(resources.toairport);
        $("#fromairport").html(resources.fromairport);
        $("#contact").html(resources.contact);
        $("#see").html(resources.see);
        $("#lblFlightFrom").html(resources.flightfrom + " " + "<i class='fa fa-star-o'></i>");
        $("#lblFlightNumber").html(resources.flightnumber + " " + "<i class='fa fa-star-o'></i>");
        $("#lblDate2").html(resources.pickupdate);
        $("#lblPickupHrs2").html(resources.pickupHRS);

    }

    $("#street").select2({
        placeholder: "Select a Street",
        allowClear: true
    });

    $("#flagEng").on('click', function () {
        $.ajax({
            url: '/Home/SetSession',
            type: 'POST',
            //dataType: "json",
            data: {
                lang: "eng"
            },
            success: function (data) {
                $("#lblEmail").html(resources.email + " " + "<i class='fa fa-star-o'></i>");
                $("#InputEmail").attr('placeholder', resources.plhemail);
                $("#lblName").html(resources.fullname + " " + "<i class='fa fa-star-o'></i>");
                $("#InputFullName").attr('placeholder', resources.plhfullname);
                $("#lblPickUpDate").html(resources.pickupdate + " " + "<i class='fa fa-star-o'></i>");
                $("#InputDate").attr('placeholder', resources.plhpickupdate);
                $("#lblPickUpHRS").html(resources.pickupHRS + " " + "<i class='fa fa-star-o'></i>");
                $("#lblHouse").html(resources.house);
                $("#lblFloor").html(resources.floor);
                $("#lblDoor").html(resources.door);
                $("#lblPickUpFrom").html(resources.pickupfrom);
                $("#from1").html(resources.from1);
                $("#from2").html(resources.from2);
                $("#from3").html(resources.from3);
                $("#from4").html(resources.from4);
                $("#lblLocation").html(resources.location + " " + "<i class='fa fa-star-o'></i>");
                $("#lblStreet").html(resources.street + " " + "<i class='fa fa-star-o'></i>");
                $("#lblPhone").html(resources.phone);
                $("#InputTelFirst").attr('placeholder', resources.plhphone);
                $("#lblCarType").html(resources.cartype);
                $("#car1").html(resources.car1);
                $("#car2").html(resources.car2);
                $("#car3").html(resources.car3);
                $("#lblSuitcase").html(resources.suitcase);
                $("#suit1").html(resources.suit1);
                $("#suit2").html(resources.suit2);
                $("#suit3").html(resources.suit3);
                $("#suit4").html(resources.suit4);
                $("#suit5").html(resources.suit5);
                $("#suit6").html(resources.suit6);
                $("#suit7").html(resources.suit7);
                $("#suit8").html(resources.suit8);
                $("#suit9").html(resources.suit9);
                $("#suit10").html(resources.suit10);
                $("#lblHand").html(resources.hand);
                $("#hand1").html(resources.hand1);
                $("#hand2").html(resources.hand2);
                $("#hand3").html(resources.hand3);
                $("#hand4").html(resources.hand4);
                $("#hand5").html(resources.hand5);
                $("#hand6").html(resources.hand6);
                $("#hand7").html(resources.hand7);
                $("#hand8").html(resources.hand8);
                $("#hand9").html(resources.hand9);
                $("#hand10").html(resources.hand10);
                $("#lblPayment").html(resources.payment);
                $("#pay1").html(resources.pay1);
                $("#pay2").html(resources.pay2);
                $("#pay3").html(resources.pay3);
                $("#lblComment").html(resources.comment);
                $("#lblPrice1").html(resources.price);
                $("#lblReturn").html(resources.lblreturn);
                $("#title").html(resources.fromairport);
                $("#lblReturnDate").html(resources.pickupdate);
                $("#lblReturnTime").html(resources.pickupHRS);
                $("#ReturnDate").attr('placeholder', resources.plhpickupdate);
                $("#lblSee").html(resources.see);
                $("#home").html(resources.home);
                $("#about").html(resources.about);
                $("#booking").html(resources.booking);
                $("#toairport").html(resources.toairport);
                $("#fromairport").html(resources.fromairport);
                $("#contact").html(resources.contact);
                $("#see").html(resources.see);
                $("#lblFlightFrom").html(resources.flightfrom + " " + "<i class='fa fa-star-o'></i>");
                $("#lblFlightNumber").html(resources.flightnumber + " " + "<i class='fa fa-star-o'></i>");
                $("#lblDate2").html(resources.pickupdate);
                $("#lblPickupHrs2").html(resources.pickupHRS);
                //$("#lblPrice").text(data.cena + " " + "€");
                //alert(data.cena);
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
                $("#lblEmail").html(resourcesG.email + " " + "<i class='fa fa-star-o'></i>");
                $("#InputEmail").attr('placeholder', resourcesG.plhemail);
                $("#lblName").html(resourcesG.fullname + " " + "<i class='fa fa-star-o'></i>");
                $("#InputFullName").attr('placeholder', resourcesG.plhfullname);
                $("#lblPickUpDate").html(resourcesG.pickupdate + " " + "<i class='fa fa-star-o'></i>");
                $("#lblDate2").html(resourcesG.pickupdate);
                $("#InputDate").attr('placeholder', resourcesG.plhpickupdate);
                $("#lblPickUpHRS").html(resourcesG.pickupHRS + " " + "<i class='fa fa-star-o'></i>");
                $("#lblHouse").html(resourcesG.house);
                $("#lblFloor").html(resourcesG.floor);
                $("#lblDoor").html(resourcesG.door);
                $("#lblPickUpFrom").html(resourcesG.pickupfrom);
                $("#from1").html(resourcesG.from1);
                $("#from2").html(resourcesG.from2);
                $("#from3").html(resourcesG.from3);
                $("#from4").html(resourcesG.from4);
                $("#lblLocation").html(resourcesG.location + " " + "<i class='fa fa-star-o'></i>");
                $("#lblStreet").html(resourcesG.street + " " + "<i class='fa fa-star-o'></i>");
                $("#lblPhone").html(resourcesG.phone);
                $("#InputTelFirst").attr('placeholder', resourcesG.plhphone);
                $("#lblCarType").html(resourcesG.cartype);
                $("#car1").html(resourcesG.car1);
                $("#car2").html(resourcesG.car2);
                $("#car3").html(resourcesG.car3);
                $("#lblSuitcase").html(resourcesG.suitcase);
                $("#suit1").html(resourcesG.suit1);
                $("#suit2").html(resourcesG.suit2);
                $("#suit3").html(resourcesG.suit3);
                $("#suit4").html(resourcesG.suit4);
                $("#suit5").html(resourcesG.suit5);
                $("#suit6").html(resourcesG.suit6);
                $("#suit7").html(resourcesG.suit7);
                $("#suit8").html(resourcesG.suit8);
                $("#suit9").html(resourcesG.suit9);
                $("#suit10").html(resourcesG.suit10);
                $("#lblHand").html(resourcesG.hand);
                $("#hand1").html(resourcesG.hand1);
                $("#hand2").html(resourcesG.hand2);
                $("#hand3").html(resourcesG.hand3);
                $("#hand4").html(resourcesG.hand4);
                $("#hand5").html(resourcesG.hand5);
                $("#hand6").html(resourcesG.hand6);
                $("#hand7").html(resourcesG.hand7);
                $("#hand8").html(resourcesG.hand8);
                $("#hand9").html(resourcesG.hand9);
                $("#hand10").html(resourcesG.hand10);
                $("#lblPayment").html(resourcesG.payment);
                $("#pay1").html(resourcesG.pay1);
                $("#pay2").html(resourcesG.pay2);
                $("#pay3").html(resourcesG.pay3);
                $("#lblComment").html(resourcesG.comment);
                $("#lblPrice1").html(resourcesG.price);
                $("#lblReturn").html(resourcesG.lblreturn);
                $("#title").html(resourcesG.fromairport);
                $("#lblReturnDate").html(resourcesG.pickupdate);
                $("#lblReturnTime").html(resourcesG.pickupHRS);
                $("#ReturnDate").attr('placeholder', resourcesG.plhpickupdate);
                $("#lblSee").html(resourcesG.see);
                $("#home").html(resourcesG.home);
                $("#about").html(resourcesG.about);
                $("#booking").html(resourcesG.booking);
                $("#toairport").html(resourcesG.toairport);
                $("#fromairport").html(resourcesG.fromairport);
                $("#contact").html(resourcesG.contact);
                $("#see").html(resourcesG.see);
                $("#lblFlightFrom").html(resourcesG.flightfrom + " " + "<i class='fa fa-star-o'></i>");
                $("#lblFlightNumber").html(resourcesG.flightnumber + " " + "<i class='fa fa-star-o'></i>");
                $("#lblPickupHrs2").html(resourcesG.pickupHRS);
                //$("#lblPrice").text(data.cena + " " + "€");
                //alert(data.cena);
            }
        });
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