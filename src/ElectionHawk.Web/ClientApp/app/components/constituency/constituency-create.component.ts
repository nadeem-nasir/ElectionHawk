import { Component, OnDestroy, OnInit } from '@angular/core';
import { IConstituency } from '../../services/interfaces';
import { ConstituencyService } from '../../services/constituency.service';
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
    selector: 'constituency-create',
    templateUrl: 'constituency-create.component.html'  
})

export class ConstituencyCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    constituencyForm: FormGroup;
   public constituency: IConstituency;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private constituencyService: ConstituencyService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.constituencyForm = this.fb.group({
           constituencyId: '',
    constituencyTypeId: '',
    title: '',
    constituencyName: '',
    map: '',
    area: '',
    city: '',
    district: '',
    province: '',
    ecpconstcode: '',
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
        console.log(this.constituencyForm.value);
        const formModel = this.constituencyForm.value;
        this.constituencyService.createConstituency(formModel as IConstituency).subscribe(constituency =>
        {
            this.constituency = constituency;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}