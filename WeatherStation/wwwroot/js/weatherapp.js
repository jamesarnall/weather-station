/*

icons: clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, or partly-cloudy-night

*/

var ws = ws || {};

ws.tempScale = " &#8457;";

// ws.celsiusToFahrenheit = function(temp) {
//     return Math.round(temp * 1.8 + 32);
// };

// ws.CurrentConditions = function () {
//     return {
//         temperature: {
//             celsius    : 0,
//             fahrenheit : 0
//         }
//     }
// };

// ws.ForecastPeriod = function () { };

/**
 * [fetchApiData description]
 * @param  {[type]} api [description]
 * @param  {[type]} dom [description]
 * @return {[type]}     [description]
 */
ws.fetchApiData = function(api, dom) {
  $("#" + dom.containerId).fadeOut();
  api.getWeather()
    .done(function (result) {
        dom.body.className             = "weather " + result.dayOrNight + " " + result.icon;
        dom.temperature.innerHTML      = result.temperature + ws.tempScale;
        dom.currentTime.textContent    = result.currentTime;
        dom.currentDate.textContent    = result.currentDate;
        dom.conditionsDesc.innerHTML   = result.conditionsDesc;
        dom.feelsLike.innerHTML        = result.feelsLike + ws.tempScale;
        dom.conditionsIcon.className   = "icon";// + result.icon;
        $("#" + dom.containerId).fadeIn();
    })
    .fail(function (result) {
        console.log(result);
        console.log("FAIL API")
    })
  ;
};

/**
 * Loads the view
 */
ws.load = function ($, dom, api) {

    if (!dom) {
        console.log("DOM access didn't load");
        return;
    }

    ws.fetchApiData(api, dom);

    setInterval(function() {
      ws.fetchApiData(api, dom);
    }, 60000);

};
