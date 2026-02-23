import { Component, OnDestroy, OnInit } from '@angular/core';
import { IElection } from '../../services/interfaces';
import { ElectionService } from '../../services/election.service';
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
    selector: 'election-create',
    templateUrl: 'election-create.component.html'  
})

export class ElectionCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    electionForm: FormGroup;
   public election: IElection;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private electionService: ElectionService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.electionForm = this.fb.group({
           electionName: ['', [Validators.required, Validators.minLength(3)]],
           
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
        console.log(this.electionForm.value);
        const formModel = this.electionForm.value;
        this.electionService.createElection(formModel as IElection).subscribe(election =>
        {
            this.election = election;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}