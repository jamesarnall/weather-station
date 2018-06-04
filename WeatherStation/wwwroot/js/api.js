/**
 * API.JS
 * @description Service object that deals with the web API
 * @description Depends on jQuery
 */

var ws = ws || {};

// ---

/**
 * A mock we can use for testing
 * @return {object}
 */
ws.apiMock = function() {

    this.getWeather = function () {

        var ajaxMock = $.Deferred();
        ajaxMock.resolve({
            conditionsDesc  : "Clear",
            conditionsLabel : "clear-night",
            currentDate     : "December 99, 9999",
            currentTime     : "99:99 PM",
            dayOrNight      : "night",
            feelsLike       : "90",
            temperature     : "70",
            icon            : "clear"
        });

        //
        return ajaxMock.promise();        
    };
    
    //
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