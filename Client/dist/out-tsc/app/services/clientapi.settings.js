"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ClientApiSettings = /** @class */ (function () {
    function ClientApiSettings() {
    }
    //Use this Method when calling an business_workflow apis
    ClientApiSettings.GETAPIURL = function (controller) {
        return this.API_URL + controller;
    };
    //use this method when callin an client apis
    ClientApiSettings.GETCLIENTAPIURL = function (controller) {
        return this.CURRENT_URL + controller;
    };
    ClientApiSettings.HANDLEERROR = function (error) {
        console.error('An error occured', error);
        return Promise.reject(error.message || error);
    };
    //change the url according to client's url
    ClientApiSettings.CURRENT_URL = "http://localhost:50000/api/";
    //change the url according for business workflow urls
    ClientApiSettings.API_URL = "http://localhost:49475/api/";
    return ClientApiSettings;
}());
exports.ClientApiSettings = ClientApiSettings;
//# sourceMappingURL=clientapi.settings.js.map