$(document).ready(function () {
    var jan;
    var feb;
    var mar;
    var okt;
    var barChartData;
    $.ajax({
        url: '/AdminPanel/DAL',
        type: 'POST',
        dataType: "json",
        data: {
            
        },
        success: function (data) {
             barChartData = {
                labels: ["January", "February", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"],
                datasets: [

                    {
                        fillColor: "rgba(151,187,205,0.5)",
                        strokeColor: "rgba(151,187,205,0.8)",
                        highlightFill: "rgba(151,187,205,0.75)",
                        highlightStroke: "rgba(151,187,205,1)",
                        data: [data["1"], data["2"], data["3"], data["4"], data["5"], data["6"], data["7"], data["8"], data["9"], data["10"], data["11"], data["12"]]
                        //data: [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
                    }
                ]

             }
             var ctx = document.getElementById("canvas").getContext("2d");
             window.myBar = new Chart(ctx).Bar(barChartData, {
                 responsive: true
             });
        }
    });
    
    //var randomScalingFactor = function () { return Math.round(Math.random() * 10) };

    
    //window.onload = function (event) {

    //    event.preventDefault();
    //    var ctx = document.getElementById("canvas").getContext("2d");
    //    window.myBar = new Chart(ctx).Bar(barChartData, {
    //        responsive: true
    //    });
    //}
    
   
});

