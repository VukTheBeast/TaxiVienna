$(document).ready(function () {
    var jan;
    var feb;
    var mar;
    var okt;
    var randomScalingFactor;
    var barChartData;
    $.ajax({
        url: '/AdminPanel/DAL',
        type: 'POST',
        dataType: "json",
        data: {
            
        },
        success: function (data) {
            jan = data.Data[0];
            feb = data.Data[1];
            mar = data.Data[2];
            okt = data.Data[3];

            randomScalingFactor = function () { return Math.round(Math.random() * 10) };

            barChartData = {
                labels: ["January", "February", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"],
                datasets: [
                    //{
                    //    fillColor: "rgba(220,220,220,0.5)",
                    //    strokeColor: "rgba(220,220,220,0.8)",
                    //    highlightFill: "rgba(220,220,220,0.75)",
                    //    highlightStroke: "rgba(220,220,220,1)",
                    //    data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
                    //},
                    {
                        fillColor: "rgba(151,187,205,0.5)",
                        strokeColor: "rgba(151,187,205,0.8)",
                        highlightFill: "rgba(151,187,205,0.75)",
                        highlightStroke: "rgba(151,187,205,1)",
                        data: [jan, feb, mar, randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), okt, randomScalingFactor(), randomScalingFactor()]
                    }
                ]

            }
        }
    });



    
    window.onload = function () {
        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive: true
        });
    }
});