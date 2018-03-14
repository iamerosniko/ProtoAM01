"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
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
exports.CurrentUser = CurrentUser;
//# sourceMappingURL=current-user.js.map