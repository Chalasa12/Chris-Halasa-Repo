
$(document).ready(function () {

    $("#detailpage").on("onload", function (event) {
		var city = $("#city").val();
		var state = $("#state").val();
		var key = "ef5a156e62f050d2";
		var urlString = "http://api.wunderground.com/api/" + key + "/forecast/q/" + state + "/" + city + ".json"
		$.ajax({
		  url: urlString,
		  dataType: "json"
		}).done(function(url) {
			console.log(url);
			if (url.simpleforecast != undefined)
			{

				var highf = url.simpleforecast.high;
				var lowf= url.simpleforecast.low
				$("#temphigh").html("highf");
				$("#templow").html("lowf");
			}
		});
	});
});
