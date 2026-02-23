import { Component, OnDestroy, OnInit } from '@angular/core';
import { IProfile } from '../../services/interfaces';
import { ProfileService } from '../../services/profile.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray, ReactiveFormsModule  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'profile-edit',
    templateUrl: 'profile-edit.component.html'  
})

export class ProfileEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public profileEditForm: FormGroup;
    public profile: IProfile;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private profileService: ProfileService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.profileService.getProfileById(Number.parseInt(params['Id']))
                .subscribe(profile => {
                    this.profile = profile;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.profileEditForm = this.fb.group({
            Id: this.profile.ProfileId,

                       name: ['', [Validators.required, Validators.minLength(3)]],
    age: '',
    gender: '',
    fathername: '',
    spousename: '', 
    guardianname: '',
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
        
        const formModel = this.profileEditForm.value;
        this.profileService.updateProfile(formModel as IProfile).subscribe(profile =>
        {
            this.profile = profile;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}