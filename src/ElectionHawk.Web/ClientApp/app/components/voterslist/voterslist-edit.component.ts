import { Component, OnDestroy, OnInit } from '@angular/core';
import { IVotersList } from '../../services/interfaces';
import { VoterslistService } from '../../services/voterslist.service';
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
    selector: 'voterslist-edit',
    templateUrl: 'voterslist-edit.component.html'  
})

export class VoterslistEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public voterslistEditForm: FormGroup;
    public voterslist: IVotersList;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private voterslistService: VoterslistService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.voterslistService.getVotersListById(Number.parseInt(params['Id']))
                .subscribe(voterslist => {
                    this.voterslist = voterslist;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.voterslistEditForm = this.fb.group({
            Id: this.voterslist.VoterListId,

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
        
        const formModel = this.voterslistEditForm.value;
        this.voterslistService.updateVotersList(formModel as IVotersList).subscribe(voterslist =>
        {
            this.voterslist = voterslist;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}