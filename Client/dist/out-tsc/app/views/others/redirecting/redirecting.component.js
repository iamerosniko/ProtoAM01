"use strict";
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
var router_1 = require("@angular/router");
var RedirectingComponent = /** @class */ (function () {
    function RedirectingComponent(router) {
        this.router = router;
    }
    RedirectingComponent.prototype.ngOnInit = function () {
        this.getValidRoutes();
    };
    RedirectingComponent.prototype.getValidRoutes = function () {
        var _this = this;
        //get all modules of the current user
        //iff null goto noaccess
        setTimeout(function () {
            _this.router.navigate(['./Survey']);
        }, 2000);
    };
    RedirectingComponent = __decorate([
        core_1.Component({
            selector: 'app-redirecting',
            templateUrl: './redirecting.component.html',
            styleUrls: ['./redirecting.component.css']
        }),
        __metadata("design:paramtypes", [router_1.Router])
    ], RedirectingComponent);
    return RedirectingComponent;
}());
exports.RedirectingComponent = RedirectingComponent;
//# sourceMappingURL=redirecting.component.js.map