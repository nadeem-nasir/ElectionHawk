import { Component, OnDestroy, OnInit } from '@angular/core';
import { IConstituency } from '../../services/interfaces';
import { ConstituencyService } from '../../services/constituency.service';
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
    selector: 'constituency-edit',
    templateUrl: 'constituency-edit.component.html'  
})

export class ConstituencyEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public constituencyEditForm: FormGroup;
    public constituency: IConstituency;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private constituencyService: ConstituencyService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.constituencyService.getConstituencyById(Number.parseInt(params['Id']))
                .subscribe(constituency => {
                    this.constituency = constituency;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
		console.log(this.constituency.constituencyId);
		
        this.constituencyEditForm = this.fb.group({
            Id: this.constituency.constituencyId,

    constituencyTypeId: this.constituency.constituencyTypeId,
    title: this.constituency.constituencyTitle,
            constituencyName: [this.constituency.constituencyName, [Validators.required, Validators.minLength(3)]],
    map: this.constituency.mapId,
    area: this.constituency.areaId,
    city: this.constituency.cityId,
    district: this.constituency.districtId,
    province: this.constituency.provinceId,
    ecpconstcode: this.constituency.ecpConstCode,

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
        
        const formModel = this.constituencyEditForm.value;
        this.constituencyService.updateConstituency(formModel as IConstituency).subscribe(constituency =>
        {
            this.constituency = constituency;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}