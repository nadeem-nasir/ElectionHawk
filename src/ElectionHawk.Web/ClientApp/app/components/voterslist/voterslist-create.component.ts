import { Component, OnDestroy, OnInit } from '@angular/core';
import { IVotersList } from '../../services/interfaces';
import { VoterslistService } from '../../services/voterslist.service';
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
    selector: 'voterslist-create',
    templateUrl: 'voterslist-create.component.html'  
})

export class VoterslistCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    voterslistForm: FormGroup;
   public voterslist: IVotersList;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private voterslistService: VoterslistService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.voterslistForm = this.fb.group({
           title: ['', [Validators.required, Validators.minLength(3)]],
    voterListType: '',
    targetCommunityId: ''
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
        console.log(this.voterslistForm.value);
        const formModel = this.voterslistForm.value;
        this.voterslistService.createVotersList(formModel as IVotersList).subscribe(voterslist =>
        {
            this.voterslist = voterslist;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}