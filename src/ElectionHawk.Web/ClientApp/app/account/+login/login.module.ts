import { NgModule } from '@angular/core';

import { SharedModule } from '@app/shared';

import { LoginComponent } from './login.component';
import { routing } from './login.routes';

import { NgxPermissionsModule } from 'ngx-permissions';

@NgModule({
    imports: [routing, SharedModule,
        NgxPermissionsModule.forChild({
            permissionsIsolate: true,
            rolesIsolate: true
        })],
    declarations: [LoginComponent]
})
export class LoginModule { }
