/*

icons: clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, or partly-cloudy-night

*/

var ws = {};

ws.celsiusToFahrenheit = function(temp) {
    return Math.round(temp * 1.8 + 32);
},

ws.CurrentConditions = function () {
    return {
        temperature: {
            celsius    : 0,
            fahrenheit : 0
        }
    }
},

ws.ForecastPeriod = function () { },

ws.api = function (apiUrl) {
    return $.ajax({
        contentType : "application/json",
        crossDomain : !0,
        type        : "get",
        url         : apiUrl
    });
},

ws.load = function ($, dom, apiUrl) {

    if (!dom) {
        console.log("DOM access didn't load");
        return;
    }

    ws.api(apiUrl)
        .done(function (result) {
            console.log(result);
            dom.temperature.textContent = result.temperature;
            dom.datetimeTime.textContent = result.datetimeTime + " " + result.datetimeAmPm;
            dom.datetimeDate.textContent = result.datetimeDate;
            dom.conditionsDesc.textContent = result.conditionsDesc;
            dom.conditionsIcon.className = "icon " + result.conditionsIcon;
        })
        .fail(function (result) {
            console.log(result);
            console.log("FAIKL API")
        })
        
};
