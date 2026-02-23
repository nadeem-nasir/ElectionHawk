import { Component, OnDestroy, OnInit } from '@angular/core';
import { IProfile } from '../../services/interfaces';
import { ProfileService } from '../../services/profile.service';
import { FormGroup, ReactiveFormsModule, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 

import { CalendarModule } from 'primeng/primeng';

@Component({
    selector: 'profile-create',
    templateUrl: 'profile-create.component.html'  
})

export class ProfileCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    profileForm: FormGroup;
   public profile: IProfile;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private profileService: ProfileService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.profileForm = this.fb.group({
           name: ['', [Validators.required, Validators.minLength(3)]],
    age: '',
    gender: '',
    fathername: '',
    spousename: '', 
    guardianName: '',
    address: '',
    picture: '',
    constituency: '', 
    affiliatedPoliticalPartyId: '',
    profileTypeId: '',
    phone1: '',
    phone2: '',
    email: '',
    whatsapp: '',
    facebookurl: '',
    twitterurl: '',
    media: '',
            
        });
    }
    ngOnDestroy() {
        // If subscribed, we must unsubscribe before Angular destroys the component.
        // Failure to do so could create a memory leak.
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    cancel()
    {
        this.router.navigate(['home']);
    }

    save(): void
    {
        console.log(this.profileForm.value);
        const formModel = this.profileForm.value;
        this.profileService.createProfile(formModel as IProfile).subscribe(profile =>
        {
            this.profile = profile;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}