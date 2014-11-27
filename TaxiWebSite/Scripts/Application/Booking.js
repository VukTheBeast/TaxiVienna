$(document).ready(function () {

    
    $("#submit").on('click', function () {
        $("#anim").removeClass("invisible");
        $("#anim").addClass("glyphicon-refresh-animate");
        $.ajax({
            url: "/Booking/BookingDOAerodroma",
            type: 'POST',
            data: {
                pickUpDate:$("#InputDate").val(),
                pickUpTime: $("#InputTime").val(),
                pickUpFrom:$("#InputPickupFrom option:selected" ).text(),
                fullName: $("#InputFullName").val(),
                location: $("#InputLocation option:selected" ).text(),
                zipCode: $("#InputZipCode option:selected" ).text(),
                phone: $("#InputTelFirst").val(),
                email: $("#InputEmail").val(),
                typeOfCar: $("#car_type option:selected" ).text(),
                suitcases: $("#suitcases option:selected" ).text(),
                handLaggage: $("#hand_package option:selected" ).text(),
                payment:$("#payment option:selected" ).text(),
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








});