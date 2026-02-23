
import { Component, OnInit} from '@angular/core';

import { IProfile } from '../../services/interfaces';
import { ProfileService } from '../../services/profile.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'profile',
    templateUrl:'./profile.component.html',
})
export class ProfileComponent implements OnInit {

    errorMessage: string;
    profile: IProfile[] = [];

    display: boolean = false;

    constructor( private _profileService: ProfileService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._profileService.getProfileAll()
            .subscribe(profile => {
                this.profile = profile;
                console.log(this.profile);
            },
            error => this.errorMessage = <any>error);
    }
}








