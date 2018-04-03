
$(document).ready(function () {

		var city = $("#city").html();
		var state = $("#state").html();
		var key = "ef5a156e62f050d2";
        var urlString = "http://api.wunderground.com/api/" + key + "/forecast10day/q/" + state + "/" + city + ".json"
		$.ajax({
		  url: urlString,
		  dataType: "json"
		}).done(function(url) {
			console.log(url);
			
                for (var i = 0; i < 5; i++) {

                    if ($("#tempvalue").text()=="0") {
                        var highf = url.forecast.simpleforecast.forecastday[i].high.fahrenheit;
                        var lowf = url.forecast.simpleforecast.forecastday[i].low.fahrenheit;
                        $("#temphigh" + i).html(highf + "\xB0F");
                        $("#templow" + i).html(lowf + "\xB0F");
                        console.log(url.forecast.simpleforecast.forecastday[i].high.fahrenheit);
                        console.log(url.forecast.simpleforecast.forecastday[i].low.fahrenheit);
                    }
                    else if ($("#tempvalue").text() == "1") {
                        var highc = url.forecast.simpleforecast.forecastday[i].high.celsius;
                        var lowc = url.forecast.simpleforecast.forecastday[i].low.celsius;
                        $("#temphigh" + i).html(highc + "\xB0C");
                        $("#templow" + i).html(lowc + "\xB0C");
                        console.log(url.forecast.simpleforecast.forecastday[i].high.celsius);
                        console.log(url.forecast.simpleforecast.forecastday[i].low.celsius);

                    } 
                }
        });
});
