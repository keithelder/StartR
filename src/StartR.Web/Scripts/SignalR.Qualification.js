$(function () {
    var qualification = $.connection.qualification;
    // Add client-side hub methods that the server will call
    $.extend(qualification.client, {

        // myCilent is of type Domain.ClientQualification
        updateQualification: function (myClient) {
            alert('hello');
            var html = '<div class="panel panel-info" style="width:500px"><div class="panel-heading"<h3 class="panel-title">Client Quality Information</h3></div>';
            html += '<div class="panel-body">';
            html += 'Quality Rating: ' + myClient.QualityRating + '<br>';
            html += 'Best Time To Call: ' + myClient.BestCallTime + '<br>';
            html += 'Predictive Credit Score: ' + myClient.PredictiveCreditScore + '<br>';
            html += 'Today\'s Mood: ' + myClient.TodaysMood;
            html += '</div></div>';
            $("#qualification").show().html(html);
        }
    });

    // Start the connection
    $.connection.hub.start()
        .pipe(init)
    .done(function (state) {
    });
});