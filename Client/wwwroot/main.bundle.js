webpackJsonp(["main"],{

/***/ "../../../../../angular/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../angular/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../../../../../angular/app/app-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__views_others_noaccess_noaccess_component__ = __webpack_require__("../../../../../angular/app/views/others/noaccess/noaccess.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__views_others_login_login_component__ = __webpack_require__("../../../../../angular/app/views/others/login/login.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__views_others_logout_logout_component__ = __webpack_require__("../../../../../angular/app/views/others/logout/logout.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__views_others_redirecting_redirecting_component__ = __webpack_require__("../../../../../angular/app/views/others/redirecting/redirecting.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var routes = [
    // { path: '', redirectTo:'/Survey', pathMatch:"full" },
    // { path: 'Reports', component : ReportsComponent },
    // { path: 'Survey', component : SurveysComponent},
    { path: '', redirectTo: '/Login', pathMatch: "full" },
    { path: 'Login', component: __WEBPACK_IMPORTED_MODULE_3__views_others_login_login_component__["a" /* LoginComponent */] },
    { path: 'Redirecting', component: __WEBPACK_IMPORTED_MODULE_5__views_others_redirecting_redirecting_component__["a" /* RedirectingComponent */] },
    { path: 'Logout', component: __WEBPACK_IMPORTED_MODULE_4__views_others_logout_logout_component__["a" /* LogoutComponent */] },
    { path: 'Noaccess', component: __WEBPACK_IMPORTED_MODULE_2__views_others_noaccess_noaccess_component__["a" /* NoaccessComponent */] },
    { path: '**', redirectTo: '/Survey' },
    // { path: 'Survey', component : SurveysComponent, canActivate:[AuthGuard] },
    // { path: 'Reports', component : ReportsComponent, canActivate:[AuthGuard] },
    { path: '**', redirectTo: '/Login' },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["I" /* NgModule */])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */].forRoot(routes, { useHash: true })],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "../../../../../angular/app/app.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "body {\r\n    background-color:inherit;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<app-top-nav></app-top-nav>\r\n<router-outlet>\r\n</router-outlet>"

/***/ }),

/***/ "../../../../../angular/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
    }
    AppComponent.prototype.ngOnInit = function () {
        //   this.get();
    };
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-root',
            template: __webpack_require__("../../../../../angular/app/app.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../angular/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_routing_module__ = __webpack_require__("../../../../../angular/app/app-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__app_component__ = __webpack_require__("../../../../../angular/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__views_others_others_module__ = __webpack_require__("../../../../../angular/app/views/others/others.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__auth_guard_services__ = __webpack_require__("../../../../../angular/app/auth-guard.services.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__services_client_services__ = __webpack_require__("../../../../../angular/app/services/client.services.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__views_main_top_nav_top_nav_component__ = __webpack_require__("../../../../../angular/app/views/main/top-nav/top-nav.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};









var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["I" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_3__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_8__views_main_top_nav_top_nav_component__["a" /* TopNavComponent */]
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_6__angular_http__["c" /* HttpModule */],
                __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_4__views_others_others_module__["a" /* OthersModule */],
                __WEBPACK_IMPORTED_MODULE_2__app_routing_module__["a" /* AppRoutingModule */]
            ],
            providers: [__WEBPACK_IMPORTED_MODULE_5__auth_guard_services__["a" /* AuthGuard */], __WEBPACK_IMPORTED_MODULE_7__services_client_services__["a" /* ClientApiService */], __WEBPACK_IMPORTED_MODULE_7__services_client_services__["b" /* ClientApiSettings */], __WEBPACK_IMPORTED_MODULE_7__services_client_services__["c" /* ClientLoginService */]],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_3__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../angular/app/auth-guard.services.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


// import { UserService } from './user.service';
var AuthGuard = /** @class */ (function () {
    function AuthGuard(router) {
        this.router = router;
    }
    AuthGuard.prototype.canActivate = function () {
        // if (!this.userService.isAuthenticated) {
        //     this.router.navigate(['/signin']);
        // }
        // return this.userService.isAuthenticated;
        var isAllowed = false;
        if (sessionStorage.getItem('Cache0') == null) {
            this.router.navigate(['./Login']);
        }
        else {
            isAllowed = true;
        }
        console.log('authguard activated');
        return isAllowed;
    };
    AuthGuard.prototype.canActivateChild = function () {
        return this.canActivate();
    };
    AuthGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* Router */]])
    ], AuthGuard);
    return AuthGuard;
}());



/***/ }),

/***/ "../../../../../angular/app/entities/aba-entities.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__current_user__ = __webpack_require__("../../../../../angular/app/entities/current-user.ts");
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__current_user__["a"]; });



/***/ }),

/***/ "../../../../../angular/app/entities/current-user.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CurrentUser; });
// export interface CurrentUser {
//     UserID ?:string,
//     FirstName :string,
//     LastName :string,
//     Urls ?:string,
//     IdS ?:string,
//     Name ?:string,
//     Roles ?:string[],
// }
var CurrentUser = /** @class */ (function () {
    function CurrentUser(UserID, FirstName, LastName, Urls, IdS, Name, Roles) {
        this.UserID = UserID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Urls = Urls;
        this.IdS = IdS;
        this.Name = Name;
        this.Roles = Roles;
    }
    return CurrentUser;
}());



/***/ }),

/***/ "../../../../../angular/app/services/client.services.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__clientapi_service__ = __webpack_require__("../../../../../angular/app/services/clientapi.service.ts");
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__clientapi_service__["a"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__clientlogin_service__ = __webpack_require__("../../../../../angular/app/services/clientlogin.service.ts");
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "c", function() { return __WEBPACK_IMPORTED_MODULE_1__clientlogin_service__["a"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__ = __webpack_require__("../../../../../angular/app/services/clientapi.settings.ts");
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "b", function() { return __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__company_profiles_service__ = __webpack_require__("../../../../../angular/app/services/company-profiles.service.ts");
/* unused harmony namespace reexport */






/***/ }),

/***/ "../../../../../angular/app/services/clientapi.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ClientApiService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};


var ClientApiService = /** @class */ (function () {
    function ClientApiService(http) {
        this.http = http;
        this.apiUrl = '';
        this.headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Headers */]({});
    }
    ClientApiService.prototype.authorizedHeader = function () {
        this.headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Headers */]([
            { 'authorization': 'Nearer ' + sessionStorage.getItem('Cache1') },
            { 'Content-Type': 'application/json' }
        ]);
    };
    ClientApiService.prototype.normalHeader = function () {
        this.headers = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Headers */]({ 'Content-Type': 'application/json' });
    };
    ClientApiService.prototype.getAll = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                return [2 /*return*/, this.http
                        .get(this.apiUrl, { headers: this.headers })
                        .toPromise()
                        .then(function (res) { return res.json(); })];
            });
        });
    };
    ClientApiService.prototype.getOne = function (id) {
        return __awaiter(this, void 0, void 0, function () {
            var apiurl;
            return __generator(this, function (_a) {
                apiurl = this.apiUrl + '/' + id;
                return [2 /*return*/, this.http
                        .get(apiurl, { headers: this.headers })
                        .toPromise()
                        .then(function (res) { return res.json(); })];
            });
        });
    };
    ClientApiService.prototype.postData = function (body) {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                return [2 /*return*/, this.http
                        .post(this.apiUrl, body, { headers: this.headers })
                        .toPromise()
                        .then(function (res) { return res.json(); })];
            });
        });
    };
    ClientApiService.prototype.putData = function (body, ID) {
        return __awaiter(this, void 0, void 0, function () {
            var url;
            return __generator(this, function (_a) {
                url = this.apiUrl + "/" + ID;
                return [2 /*return*/, this.http
                        .put(url, body, { headers: this.headers })
                        .toPromise()
                        .then(function (res) { return res.json(); })];
            });
        });
    };
    ClientApiService.prototype.deleteData = function (ID) {
        return __awaiter(this, void 0, void 0, function () {
            var url;
            return __generator(this, function (_a) {
                url = this.apiUrl + "/" + ID;
                return [2 /*return*/, this.http
                        .delete(url, { headers: this.headers })
                        .toPromise()
                        .then(function (res) { return res.json(); })];
            });
        });
    };
    ClientApiService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], ClientApiService);
    return ClientApiService;
}());



/***/ }),

/***/ "../../../../../angular/app/services/clientapi.settings.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ClientApiSettings; });
var ClientApiSettings = /** @class */ (function () {
    function ClientApiSettings() {
    }
    ClientApiSettings.GETAPIURL = function (controller) {
        return this.API_URL + controller;
    };
    ClientApiSettings.GETCLIENTAPIURL = function (controller) {
        return this.CURRENT_URL + controller;
    };
    ClientApiSettings.HANDLEERROR = function (error) {
        console.error('An error occured', error);
        return Promise.reject(error.message || error);
    };
    ClientApiSettings.CURRENT_URL = "http://localhost:50000/api/";
    ClientApiSettings.API_URL = "http://localhost:60000/api/";
    return ClientApiSettings;
}());



/***/ }),

/***/ "../../../../../angular/app/services/clientlogin.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ClientLoginService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__clientapi_service__ = __webpack_require__("../../../../../angular/app/services/clientapi.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__ = __webpack_require__("../../../../../angular/app/services/clientapi.settings.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ClientLoginService = /** @class */ (function () {
    function ClientLoginService(api) {
        this.api = api;
        api.normalHeader();
    }
    ClientLoginService.prototype.getCurrentToken = function () {
        this.api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETCLIENTAPIURL("GetCurrentToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.GetAuthenticationToken = function () {
        this.api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETCLIENTAPIURL("ProvideAuthenticationToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.GetAuthorizationToken = function () {
        this.api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETCLIENTAPIURL("ProvideAuthorizationToken");
        var res = this.api.getAll();
        return res;
    };
    ClientLoginService.prototype.Logout = function () {
        this.api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETCLIENTAPIURL("Logout");
        this.api.getAll();
    };
    ClientLoginService.prototype.GetCurrentUser = function (token) {
        this.api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETCLIENTAPIURL("TokenToDetails");
        var token1 = { 'Token': token };
        var currentUser = this.api.postData(JSON.stringify(token1));
        return (currentUser);
    };
    ClientLoginService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__clientapi_service__["a" /* ClientApiService */]])
    ], ClientLoginService);
    return ClientLoginService;
}());



/***/ }),

/***/ "../../../../../angular/app/services/company-profiles.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export CompanyProfilesService */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__clientapi_service__ = __webpack_require__("../../../../../angular/app/services/clientapi.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__ = __webpack_require__("../../../../../angular/app/services/clientapi.settings.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var CompanyProfilesService = /** @class */ (function () {
    function CompanyProfilesService(api) {
        this.api = api;
        api.authorizedHeader();
        api.apiUrl = __WEBPACK_IMPORTED_MODULE_2__clientapi_settings__["a" /* ClientApiSettings */].GETAPIURL("CompanyProfiles");
    }
    CompanyProfilesService.prototype.getCompanyProfiles = function () {
        return this.api.getAll();
    };
    CompanyProfilesService.prototype.getCompanyProfile = function (companyProfileID) {
        return this.api.getOne(companyProfileID);
    };
    CompanyProfilesService.prototype.postCompanyProfiles = function (companyProfile) {
        var body = JSON.stringify(companyProfile);
        return this.api.postData(body);
    };
    CompanyProfilesService.prototype.putCompanyProfiles = function (companyProfile) {
        var body = JSON.stringify(companyProfile);
        return this.api.putData(body, companyProfile.CompanyProfileID.toString());
    };
    CompanyProfilesService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__clientapi_service__["a" /* ClientApiService */]])
    ], CompanyProfilesService);
    return CompanyProfilesService;
}());



/***/ }),

/***/ "../../../../../angular/app/views/main/top-nav/top-nav.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".navbar-blue {\r\n    background: #0C2C4D; /*002d5b*/\r\n    color: #ffffff;\r\n}\r\n\r\n.navbar-blue .container-fluid {\r\n    background: #0C2C4D; /*002d5b*/\r\n    color: #ffffff;\r\n}\r\n\r\n.navbar-blue a {\r\n    color: #ffffff;\r\n}\r\n\r\n.navbar-blue .navbar-brand {\r\n    font-size: 15px;\r\n}\r\n\r\n.navbar-blue .navbar-brand:hover,\r\n.navbar-blue .navbar-brand:focus {\r\n    -webkit-transition: all 0.3s;\r\n    transition: all 0.3s;\r\n    color: #9f9f9f;\r\n    background-color: transparent;\r\n}\r\n\r\n.navbar-blue .navbar-nav > li > a:hover,\r\n.navbar-blue .navbar-nav > li > a:focus {\r\n    -webkit-transition: all 0.3s;\r\n    transition: all 0.3s;\r\n    color: #fff;\r\n    background-color: #35597D;\r\n}\r\n\r\n.navbar-blue .navbar-nav > .active > a,\r\n.navbar-blue .navbar-nav > .active > a:hover,\r\n.navbar-blue .navbar-nav > .active > a:focus {\r\n    -webkit-transition: all 0.3s ease;\r\n    transition: all 0.3s ease;\r\n    background-color: #35597D; /*124171*/ /*01458D*/\r\n}\r\n\r\n.navbar-blue .navbar-nav > .disabled > a,\r\n.navbar-blue .navbar-nav > .disabled > a:hover,\r\n.navbar-blue .navbar-nav > .disabled > a:focus {\r\n    color: #ffffff;\r\n    background-color: transparent;\r\n}\r\n\r\n.navbar-blue .navbar-toggle:hover,\r\n.navbar-blue .navbar-toggle:focus {\r\n    -webkit-transition: all 0.3s;\r\n    transition: all 0.3s;\r\n    background-color: #35597D; /*002d5b*/\r\n}\r\n\r\n.navbar-blue .navbar-toggle .icon-bar {\r\n    background-color: #fff;\r\n}\r\n\r\n.navbar-blue .navbar-collapse,\r\n.navbar-blue .navbar-form {\r\n    border-color: #fff;\r\n}\r\n\r\n.navbar-blue .navbar-nav > .open > a,\r\n.navbar-blue .navbar-nav > .open > a:hover,\r\n.navbar-blue .navbar-nav > .open > a:focus {\r\n    color: #fff;\r\n    background-color: #35597D;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/views/main/top-nav/top-nav.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"navbar navbar-blue navbar-fixed-top\" role=\"navigation\">\r\n  <div class=\"container-fluid\">\r\n    <div class=\"navbar-header\">\r\n      <a href=\"#\" class=\"navbar-brand\">ABA Model Diversity</a>\r\n    </div>\r\n    <div class=\"navbar-collapse collapse\">\r\n      <ul class=\"nav navbar-nav\">\r\n        <li [routerLinkActive]=\"['active']\" role=\"presentation\"><a [routerLink]=\"['./Survey']\">Survey</a></li>\r\n        <li [routerLinkActive]=\"['active']\" role=\"presentation\"><a [routerLink]=\"['./Reports']\">Reports</a></li>\r\n      </ul>\r\n      <ul class=\"nav navbar-nav navbar-right\">\r\n        <li><a href=\"#\"><i class=\"fa fa-user-circle\"></i>&nbsp;Hello, {{currentUser.FirstName+' '+currentUser.LastName}}</a></li>\r\n      </ul>\r\n    </div>\r\n  </div> \r\n</div>"

/***/ }),

/***/ "../../../../../angular/app/views/main/top-nav/top-nav.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TopNavComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__entities_aba_entities__ = __webpack_require__("../../../../../angular/app/entities/aba-entities.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};


var TopNavComponent = /** @class */ (function () {
    function TopNavComponent() {
        this.currentUser = new __WEBPACK_IMPORTED_MODULE_1__entities_aba_entities__["a" /* CurrentUser */]('', '', '', '', '', '', []);
        var currentUser;
        var interval = setInterval(function () {
            if (sessionStorage.getItem('Cache2') != null) {
                // console.log(sessionStorage.getItem('Cache2'))
                this.currentUser = JSON.parse(window.atob(sessionStorage.getItem('Cache2')));
            }
        }, 100);
    }
    TopNavComponent.prototype.ngOnInit = function () {
    };
    TopNavComponent.prototype.getName = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                return [2 /*return*/];
            });
        });
    };
    TopNavComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-top-nav',
            template: __webpack_require__("../../../../../angular/app/views/main/top-nav/top-nav.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/views/main/top-nav/top-nav.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], TopNavComponent);
    return TopNavComponent;
}());



/***/ }),

/***/ "../../../../../angular/app/views/others/login/login.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/views/others/login/login.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  login works!\n</p>\n"

/***/ }),

/***/ "../../../../../angular/app/views/others/login/login.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_client_services__ = __webpack_require__("../../../../../angular/app/services/client.services.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};



var LoginComponent = /** @class */ (function () {
    function LoginComponent(loginService, router) {
        this.loginService = loginService;
        this.router = router;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.Login();
    };
    LoginComponent.prototype.Login = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            var authenticationToken, authorizationToken, currentUser;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.loginService.GetAuthenticationToken()];
                    case 1:
                        authenticationToken = _a.sent();
                        return [4 /*yield*/, this.loginService.GetAuthorizationToken()];
                    case 2:
                        authorizationToken = _a.sent();
                        return [4 /*yield*/, this.loginService.GetCurrentUser(authenticationToken)];
                    case 3:
                        currentUser = _a.sent();
                        return [4 /*yield*/, sessionStorage.setItem("Cache0", authenticationToken)];
                    case 4:
                        _a.sent();
                        return [4 /*yield*/, sessionStorage.setItem("Cache1", authorizationToken)];
                    case 5:
                        _a.sent();
                        return [4 /*yield*/, sessionStorage.setItem("Cache2", window.btoa(JSON.stringify(currentUser)))];
                    case 6:
                        _a.sent();
                        setTimeout(function () {
                            _this.router.navigate(['./Redirecting']);
                        }, 3000);
                        return [2 /*return*/];
                }
            });
        });
    };
    LoginComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-login',
            template: __webpack_require__("../../../../../angular/app/views/others/login/login.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/views/others/login/login.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_client_services__["c" /* ClientLoginService */], __WEBPACK_IMPORTED_MODULE_2__angular_router__["a" /* Router */]])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "../../../../../angular/app/views/others/logout/logout.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/views/others/logout/logout.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  logout works!\n</p>\n"

/***/ }),

/***/ "../../../../../angular/app/views/others/logout/logout.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LogoutComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var LogoutComponent = /** @class */ (function () {
    function LogoutComponent() {
    }
    LogoutComponent.prototype.ngOnInit = function () {
    };
    LogoutComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-logout',
            template: __webpack_require__("../../../../../angular/app/views/others/logout/logout.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/views/others/logout/logout.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], LogoutComponent);
    return LogoutComponent;
}());



/***/ }),

/***/ "../../../../../angular/app/views/others/noaccess/noaccess.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/views/others/noaccess/noaccess.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  noaccess works!\n</p>\n"

/***/ }),

/***/ "../../../../../angular/app/views/others/noaccess/noaccess.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return NoaccessComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var NoaccessComponent = /** @class */ (function () {
    function NoaccessComponent() {
    }
    NoaccessComponent.prototype.ngOnInit = function () {
    };
    NoaccessComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-noaccess',
            template: __webpack_require__("../../../../../angular/app/views/others/noaccess/noaccess.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/views/others/noaccess/noaccess.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], NoaccessComponent);
    return NoaccessComponent;
}());



/***/ }),

/***/ "../../../../../angular/app/views/others/others.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return OthersModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__noaccess_noaccess_component__ = __webpack_require__("../../../../../angular/app/views/others/noaccess/noaccess.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__login_login_component__ = __webpack_require__("../../../../../angular/app/views/others/login/login.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__logout_logout_component__ = __webpack_require__("../../../../../angular/app/views/others/logout/logout.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__redirecting_redirecting_component__ = __webpack_require__("../../../../../angular/app/views/others/redirecting/redirecting.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var OthersModule = /** @class */ (function () {
    function OthersModule() {
    }
    OthersModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["I" /* NgModule */])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["b" /* CommonModule */]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__noaccess_noaccess_component__["a" /* NoaccessComponent */], __WEBPACK_IMPORTED_MODULE_3__login_login_component__["a" /* LoginComponent */], __WEBPACK_IMPORTED_MODULE_4__logout_logout_component__["a" /* LogoutComponent */], __WEBPACK_IMPORTED_MODULE_5__redirecting_redirecting_component__["a" /* RedirectingComponent */]]
        })
    ], OthersModule);
    return OthersModule;
}());



/***/ }),

/***/ "../../../../../angular/app/views/others/redirecting/redirecting.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../angular/app/views/others/redirecting/redirecting.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  redirecting works!\n</p>\n"

/***/ }),

/***/ "../../../../../angular/app/views/others/redirecting/redirecting.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RedirectingComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


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
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-redirecting',
            template: __webpack_require__("../../../../../angular/app/views/others/redirecting/redirecting.component.html"),
            styles: [__webpack_require__("../../../../../angular/app/views/others/redirecting/redirecting.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* Router */]])
    ], RedirectingComponent);
    return RedirectingComponent;
}());



/***/ }),

/***/ "../../../../../angular/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false
};


/***/ }),

/***/ "../../../../../angular/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../angular/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../angular/environments/environment.ts");




if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["_12" /* enableProdMode */])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../angular/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map