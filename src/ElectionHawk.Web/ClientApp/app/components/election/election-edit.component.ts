import { Component, OnDestroy, OnInit } from '@angular/core';
import { IElection } from '../../services/interfaces';
import { ElectionService } from '../../services/election.service';
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
    selector: 'election-edit',
    templateUrl: 'election-edit.component.html'  
})

export class ElectionEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private electionEditForm: FormGroup;
    public election: IElection;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private electionService: ElectionService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.electionService.getElectionById(Number.parseInt(params['Id']))
                .subscribe(election => {
                    this.election = election;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.electionEditForm = this.fb.group({
            Id: this.election.ElectionId,

            electionTitle: ['', [Validators.required, Validators.minLength(3)]],
            

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
        
        const formModel = this.electionEditForm.value;
        this.electionService.updateElection(formModel as IElection).subscribe(election =>
        {
            this.election = election;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}