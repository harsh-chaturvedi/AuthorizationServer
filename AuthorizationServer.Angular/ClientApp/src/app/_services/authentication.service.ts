import { Injectable } from "@angular/core";
import { UserManager } from "oidc-client";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private userMgr: UserManager;
    constructor() {
        this.userMgr = new UserManager(environment.authConfig);
    }

    login() {
        return this.userMgr.signinRedirect();
    }

    logout(args?: any) {
        this.userMgr.clearStaleState()
        this.userMgr.removeUser()
        return this.userMgr.signoutRedirect(args);
    }

    signinRedirectCallback() {
        return this.userMgr.signinRedirectCallback();
    }

    signoutRedirectCallback() {
        this.userMgr.clearStaleState();
        this.userMgr.removeUser();
        return this.userMgr.signoutRedirectCallback();
    }

    async getUser() {
        try {
            let user = await this.userMgr.getUser();;
            return user;
        } catch (e) {
            console.error(`User not found: ${e}`)
        }
    }
}