/**
 * API.JS
 * @description Service object that deals with the web API
 * @description Depends on jQuery
 */

var ws = ws || {};

// TODO: Does this acutally make sense?
// ws.weather = function(data) {
//     conditionsDesc  : data.conditionsDesc,
//     conditionsLabel : data.conditionsLabel,
//     currentDate     : data.currentDate,
//     currentTime     : data.currentTime,
//     dayOrNight      : data.dayOrNight,
//     feelsLike       : data.feelsLike,
//     temperature     : data.temperature,
//     icon            : data.icon
// };

ws.weatherMock = {
    conditionsDesc  : "conditionsDesc",
    conditionsLabel : "conditionsLabel",
    currentDate     : "7/9/1972",
    currentTime     : "11:59 PM",
    dayOrNight      : "night",
    feelsLike       : "90",
    temperature     : "70",
    icon            : ""
};

// ---

/**
 * A mock we can use for testing
 * @return {object}
 */
ws.apiMock = function() {

    this.getWeather = function () {

        var ajaxMock = $.Deferred();

        // conditionsDesc
        // conditionsLabel
        // currentDate
        // currentTime
        // dayOrNight
        // feelsLike
        // temperature
        // icon

        ajaxMock.resolve(ws.weatherMock);

        //
        return ajaxMock.promise();        
    };
    
    return this;
};

/**
 * Service for calling the api
 */

ws.api = function (apiUrl) {    
    this.apiUrl = apiUrl;
    return this;
};

ws.api.prototype.getWeather = function () {
    
    return $.ajax({
        contentType : "application/json",
        crossDomain : !0,
        type        : "get",
        url         : this.apiUrl
    });    
};