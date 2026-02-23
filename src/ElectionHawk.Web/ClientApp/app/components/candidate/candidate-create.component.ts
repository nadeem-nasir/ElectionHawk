import { Component, OnDestroy, OnInit } from '@angular/core';
import { ICandidate, IProfileType, IConstituency, IPoliticalParty } from '../../services/interfaces';
import { CandidateService } from '../../services/candidate.service';
import { ConstituencyService } from '../../services/constituency.service';
import { ProfileTypeService } from '../../services/profiletype.service';
import { PoliticalPartyService } from '../../services/politicalparty.service';
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
    selector: 'candidate-create',
    templateUrl: 'candidate-create.component.html'  
})

export class CandidateCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    candidateForm: FormGroup;
   public candidate: ICandidate;
   constituency: IConstituency[];
   profiletype:IProfileType[];
   politicalparty:IPoliticalParty[];
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private constituencyService: ConstituencyService,
        private politicalpartyService: PoliticalPartyService,
        private profiletypeService: ProfileTypeService,
		private candidateService: CandidateService,
		private location: Location)
    {
this.constituencyService.getConstituencyAll()
            .subscribe(constituency => {
                this.constituency = constituency;
                console.log(this.constituency);
            },
            error => this.errorMessage = <any>error);
    
this.profiletypeService.getProfileTypeAll()
            .subscribe(profiletype => {
                this.profiletype = profiletype;
                console.log(this.profiletype);
            },
            error => this.errorMessage = <any>error);
    
this.politicalpartyService.getPoliticalPartyAll()
            .subscribe(politicalparty => {
                this.politicalparty = politicalparty;
                console.log(this.politicalparty);
            },
            error => this.errorMessage = <any>error);
    }

    ngOnInit()
    {
        this.candidateForm = this.fb.group({
           name: ['', [Validators.required, Validators.minLength(3)]],
    age: '',
    gender: '',
    address: '',
    picture: '',
    constituencyId: '', 
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
        console.log(this.candidateForm.value);
        const formModel = this.candidateForm.value;
        this.candidateService.createCandidate(formModel as ICandidate).subscribe(cand =>
        {
            this.candidate = cand;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}