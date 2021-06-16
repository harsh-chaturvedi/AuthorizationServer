import { Injectable } from "@angular/core";
import { Router, CanActivate } from "@angular/router";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { User } from "oidc-client";
import { AuthenticationService } from "../_services/authentication.service";

@Injectable({ providedIn: 'root' })
export class AuthenticationGaurd implements CanActivate {

    constructor(private router: Router, private authenticationService: AuthenticationService) { }

    async canActivate(router: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let user = await this.authenticationService.getUser();
        if (user) {
            return true;
        }

        this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
        return false;
    }
}