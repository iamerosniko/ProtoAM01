"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var app_routing_module_1 = require("./app-routing.module");
var app_component_1 = require("./app.component");
var others_module_1 = require("./views/others/others.module");
var auth_guard_services_1 = require("./auth-guard.services");
var http_1 = require("@angular/http");
var client_services_1 = require("./services/client.services");
var top_nav_component_1 = require("./views/main/top-nav/top-nav.component");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                top_nav_component_1.TopNavComponent
            ],
            imports: [
                http_1.HttpModule,
                platform_browser_1.BrowserModule,
                others_module_1.OthersModule,
                app_routing_module_1.AppRoutingModule
            ],
            providers: [auth_guard_services_1.AuthGuard, client_services_1.ClientApiService, client_services_1.ClientApiSettings, client_services_1.ClientLoginService,
                client_services_1.CompanyProfilesService, client_services_1.ApplicationsService],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map