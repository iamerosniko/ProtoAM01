"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var noaccess_component_1 = require("./noaccess/noaccess.component");
var login_component_1 = require("./login/login.component");
var logout_component_1 = require("./logout/logout.component");
var redirecting_component_1 = require("./redirecting/redirecting.component");
var OthersModule = /** @class */ (function () {
    function OthersModule() {
    }
    OthersModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule
            ],
            declarations: [noaccess_component_1.NoaccessComponent, login_component_1.LoginComponent, logout_component_1.LogoutComponent, redirecting_component_1.RedirectingComponent]
        })
    ], OthersModule);
    return OthersModule;
}());
exports.OthersModule = OthersModule;
//# sourceMappingURL=others.module.js.map