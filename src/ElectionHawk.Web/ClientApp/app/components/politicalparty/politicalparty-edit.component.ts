import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPoliticalParty } from '../../services/interfaces';
import { PoliticalPartyService } from '../../services/politicalparty.service';
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
    selector: 'politicalparty-edit',
    templateUrl: 'politicalparty-edit.component.html'  
})

export class PoliticalPartyEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public politicalPartyEditForm: FormGroup;
    public politicalParty: IPoliticalParty;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private politicalPartyService: PoliticalPartyService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.politicalPartyService.getPoliticalPartyById(Number.parseInt(params['Id']))
                .subscribe(politicalParty => {
                    this.politicalParty = politicalParty;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.politicalPartyEditForm = this.fb.group({
            Id: this.politicalParty.PoliticalPartyId,

            name: ['', [Validators.required, Validators.minLength(3)]],
                abbr: '',
    description: '',
    leadername: '',
    designation: '',
    address: '',
    website: '',
    facebookurl: '',
    twitterurl: '',
    whatsapp: '',
    youtube: ''

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
        
        const formModel = this.politicalPartyEditForm.value;
        this.politicalPartyService.updatePoliticalParty(formModel as IPoliticalParty).subscribe(politicalParty =>
        {
            this.politicalParty = politicalParty;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}