"use strict";
//this class is for Authentication only
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var clientapi_service_1 = require("./clientapi.service");
var clientapi_settings_1 = require("./clientapi.settings");
var ClientLoginService = /** @class */ (function () {
    function ClientLoginService(api) {
        this.api = api;
        api.normalHeader();
    }
    ClientLoginService.prototype.getCurrentToken = function () {
        this.api.apiUrl = clientapi_settings_1.ClientApiSettings.GETCLIENTAPIURL("GetCurrentToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.GetAuthenticationToken = function () {
        this.api.apiUrl = clientapi_settings_1.ClientApiSettings.GETCLIENTAPIURL("ProvideAuthenticationToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.GetAuthorizationToken = function () {
        this.api.apiUrl = clientapi_settings_1.ClientApiSettings.GETCLIENTAPIURL("ProvideAuthorizationToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.Logout = function () {
        this.api.apiUrl = clientapi_settings_1.ClientApiSettings.GETCLIENTAPIURL("Logout");
        this.api.getAll();
    };
    ClientLoginService.prototype.GetCurrentUser = function (token) {
        this.api.apiUrl = clientapi_settings_1.ClientApiSettings.GETCLIENTAPIURL("TokenToDetails");
        var token1 = { 'Token': token };
        var currentUser = this.api.postData(JSON.stringify(token1));
        return (currentUser);
    };
    ClientLoginService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [clientapi_service_1.ClientApiService])
    ], ClientLoginService);
    return ClientLoginService;
}());
exports.ClientLoginService = ClientLoginService;
//# sourceMappingURL=clientlogin.service.js.map