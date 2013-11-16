$(function () {
    var qualification = $.connection.qualification;
    // Add client-side hub methods that the server will call
    $.extend(qualification.client, {

        // myCilent is of type Domain.ClientQualification
        updateQualification: function (myClient) {
            var html = '<div class="panel panel-info" style="width:500px"><div class="panel-heading"<h3 class="panel-title">Client Qualification Information</h3></div>';
            html += '<div class="panel-body">';
            html += '<strong>Quality Rating:</strong> ' + myClient.QualityRating + '<br>';
            html += '<strong>Best Time To Call:</strong> ' + myClient.BestCallTime + '<br>';
            html += '<strong>Predictive Credit Score:</strong> ' + myClient.PredictiveCreditScore + '<br>';
            html += '<strong>Today\'s Mood:</strong> ' + myClient.TodaysMood;
            html += '</div></div>';
            $("#qualification").show().html(html);
        }
    });

    $.connection.hub.start({ transport: 'longPolling' } ) // can only get long polling working on window 8 right now
    .done(function (state) {
    });
});