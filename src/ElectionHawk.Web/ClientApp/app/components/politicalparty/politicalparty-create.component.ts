import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPoliticalParty } from '../../services/interfaces';
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
    selector: 'politicalparty-create',
    templateUrl: 'politicalparty-create.component.html'  
})

export class PoliticalPartyCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    politicalPartyForm: FormGroup;
   public politicalParty: IPoliticalParty;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private politicalPartyService: PoliticalPartyService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.politicalPartyForm = this.fb.group({
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
    youtube: '',
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
        console.log(this.politicalPartyForm.value);
        const formModel = this.politicalPartyForm.value;
        this.politicalPartyService.createPoliticalParty(formModel as IPoliticalParty).subscribe(politicalParty =>
        {
            this.politicalParty = politicalParty;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}