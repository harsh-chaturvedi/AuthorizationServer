// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  authIssuerUri: "https://localhost:5001/",
  applicationUri: "http://localhost:4200/",
  authConfig: {
    authority: "https://localhost:5001/",
    client_id: "angular",
    redirect_uri: "http://localhost:4200/signin-oidc",
    response_type: "code",
    scope: "openid profile",
    post_logout_redirect_uri: "http://localhost:4200/signout-oidc",
    extraQueryParams: {
      "TenantUri": "http://localhost:4200/",
    },
    extraTokenParams: {
      "TenantUri": "http://localhost:4200/",
    }
  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
