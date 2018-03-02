/*

icons: clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, or partly-cloudy-night

*/

var ws = {};

ws.celsiusToFahrenheit = function(temp) {
    return Math.round(temp * 1.8 + 32);
};

ws.CurrentConditions = function () {
    return {
        temperature: {
            celsius    : 0,
            fahrenheit : 0
        }
    }
};

ws.ForecastPeriod = function () { };

ws.api = function (apiUrl) {
    return $.ajax({
        contentType : "application/json",
        crossDomain : !0,
        type        : "get",
        url         : apiUrl
    });
};

ws.fetchApiData = function(apiUrl, dom) {
  $("#" + dom.containerId).fadeOut();
  ws.api(apiUrl)
    .done(function (result) {
        dom.body.className             = "weather " + result.dayOrNight + " " + result.icon;
        dom.temperature.textContent    = result.temperature;
        dom.currentTime.textContent    = result.currentTime;
        dom.currentDate.textContent    = result.currentDate;
        dom.conditionsDesc.textContent = result.conditionsDesc;
        dom.conditionsIcon.className   = "icon";// + result.icon;
        $("#" + dom.containerId).fadeIn();
    })
    .fail(function (result) {
        console.log(result);
        console.log("FAIL API")
    })
  ;
};

ws.load = function ($, dom, apiUrl) {

    if (!dom) {
        console.log("DOM access didn't load");
        return;
    }

    ws.fetchApiData(apiUrl, dom);

    setInterval(function() {
      ws.fetchApiData(apiUrl, dom);
    }, 60000);

};
