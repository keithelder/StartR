$(function () {
    var qualification = $.connection.qualification;
    // Add client-side hub methods that the server will call
    $.extend(qualification.client, {
        updateQualification: function (myClient) {
            alert(myClient.PredictiveScore);
        }
        // myCilent is of type Domain.ClientQualification
    });

    // Start the connection
    //$.connection.hub.start()
    //    .pipe(function () {
    //        return qualification.server.getQualification(id);
    //    })
    //    .done(function (myClient) {

    //        var html = '<div class="panel panel-info" style="width:500px"><div class="panel-heading"<h3 class="panel-title">Client Quality Information</h3></div>';
    //        html += '<div class="panel-body">';
    //        html += 'Quality Rating: ' + myClient.QualityRating + '<br>';
    //        html += 'Best Time To Call: ' + myClient.BestCallTime + '<br>';
    //        html += 'Predictive Credit Score: ' + myClient.PredictiveCreditScore + '<br>';
    //        html += 'Today\'s Mood: ' + myClient.TodaysMood;
    //        html += '</div></div>';
    //        $("#qualification").show().html(html);
    //    });

    $.connection.hub.start()
    .done(function (state) {
    });
});