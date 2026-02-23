import { Component, OnDestroy, OnInit } from '@angular/core';
import { ICandidate } from '../../services/interfaces';
import { CandidateService } from '../../services/candidate.service';
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
    selector: 'candidate-edit',
    templateUrl: 'candidate-edit.component.html'  
})

export class CandidateEditComponent implements OnInit, OnDestroy {

     public ngUnsubscribe: Subject<void> = new Subject<void>();
     public candidateEditForm: FormGroup;
     public candidate: ICandidate;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private candidateService: CandidateService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.candidateService.getCandidatesById(Number.parseInt(params['Id']))
                .subscribe(candidate => {
                    this.candidate = candidate;
					console.log(this.candidate);
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
		console.log('in build form');
		console.log(this.candidate);
		console.log(this.candidate.politicalParty);
		console.log(this.candidate.age);
        this.candidateEditForm = this.fb.group({
            Id: this.candidate.candidateProfileId,
            phone1: this.candidate.phone1,

            name: [this.candidate.name, [Validators.required, Validators.minLength(3)]],
    age: this.candidate.age,
    gender: this.candidate.gender==true?"Male":"female",
    address: this.candidate.address,
    
    phone2: this.candidate.phone2,
    email: this.candidate.email,
    whatsapp: this.candidate.whatsapp,
    facebookUrl: this.candidate.facebookUrl,
    twitterUrl: this.candidate.twitterUrl,
    mediaPresence: this.candidate.mediaPresence,
    picture: this.candidate.picture,
    constituency: this.candidate.constituency,
    politicalParty: this.candidate.politicalParty,
    profileType: this.candidate.profileType,

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
        
        const formModel = this.candidateEditForm.value;
        this.candidateService.updateCandidate(formModel as ICandidate).subscribe(candidate =>
        {
            this.candidate = candidate;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}