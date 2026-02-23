import { Component, OnInit, Inject} from '@angular/core';
//import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import { Params, ActivatedRoute, Router } from '@angular/router';
//import { TranslateService } from '@ngx-translate/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from '../../auth.config';
//import { routerTransition } from './router.animations';
import { ExternalLoginStatus } from '../../app.models';
import { AccountService } from '@app/core/services/account.service';
//import { NgxRolesService } from 'ngx-permissions'
//import { NgxPermissionsService } from 'ngx-permissions';

@Component({
    selector:'AppElectionHawk',
    templateUrl:'./app.component.html',
    styleUrls: ['app.component.css'],
})
export class AppComponent implements OnInit
{
    constructor(
        //public translate: TranslateService,
        private router: Router,
        @Inject(DOCUMENT) private document: Document,
        private route: ActivatedRoute,
        private oauthService: OAuthService,
        public accountService: AccountService,
        //private roleService: NgxRolesService,
        //private permissionsService: NgxPermissionsService
        ) {
            

        this.configureOidc();

    }

    public ngOnInit() {
        this.route.queryParams.subscribe((params: Params) => {
            const param = params['externalLoginStatus'];
            if (param) {
                const status = <ExternalLoginStatus>+param;
                switch (status) {
                    case ExternalLoginStatus.CreateAccount:
                        this.router.navigate(['createaccount']);
                        break;
                    default:
                        break;
                }
            }
        });


        
    }

    public getState(outlet: any) {
        return outlet.activatedRouteData.state;
    }

    private configureOidc() {
        const url = `${this.document.location.protocol}//${this.document.location.host}`;
        this.oauthService.configure(authConfig(url));
        this.oauthService.setStorage(localStorage);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        this.oauthService.loadDiscoveryDocumentAndTryLogin();
    }

    public get isLoggedIn(): boolean
    {
        //console.log(this.accountService.isLoggedIn);
        return this.accountService.isLoggedIn;
    }
}
