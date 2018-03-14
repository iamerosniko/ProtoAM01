"use strict";
//this is the sample template that can be used when calling a businessworkflow api
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
var ApplicationsService = /** @class */ (function () {
    function ApplicationsService(api) {
        this.api = api;
        //uncomment api.authorizedHeader() if AD Authentication is enabled.
        //use api.normalHeader() if anonymous authentication is enabled.
        api.normalHeader();
        //api.authorizedHeader();
        api.apiUrl = clientapi_settings_1.ClientApiSettings.GETAPIURL("Applications");
    }
    ApplicationsService.prototype.getCompanyProfiles = function () {
        return this.api.getAll();
    };
    ApplicationsService.prototype.getCompanyProfile = function (companyProfileID) {
        return this.api.getOne(companyProfileID);
    };
    ApplicationsService.prototype.postCompanyProfiles = function (companyProfile) {
        var body = JSON.stringify(companyProfile);
        return this.api.postData(body);
    };
    ApplicationsService.prototype.putCompanyProfiles = function (companyProfile) {
        var body = JSON.stringify(companyProfile);
        return this.api.putData(body, companyProfile.AppID.toString());
    };
    ApplicationsService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [clientapi_service_1.ClientApiService])
    ], ApplicationsService);
    return ApplicationsService;
}());
exports.ApplicationsService = ApplicationsService;
//# sourceMappingURL=applications.service.js.map