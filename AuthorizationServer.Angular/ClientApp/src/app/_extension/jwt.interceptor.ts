import { HttpRequest, HttpHandler, HttpInterceptor, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { AuthenticationService } from "../_services/authentication.service";

export class JWTInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var user = this.authenticationService.getUser().then();
        // var token = user.
        var isApiRequest = request.url.startsWith(environment.authIssuerUri);
        if (isApiRequest) {
            request = request.clone({
                setHeaders: {
                    "TenantUri": environment.applicationUri
                }
            });
        }
        return next.handle(request);
    }
}