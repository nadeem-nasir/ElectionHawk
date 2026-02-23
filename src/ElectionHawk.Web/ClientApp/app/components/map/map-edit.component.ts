import { Component, OnDestroy, OnInit } from '@angular/core';
import { IMap } from '../../services/interfaces';
import { MapService } from '../../services/map.service';
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
    selector: 'map-edit',
    templateUrl: 'map-edit.component.html'  
})

export class MapEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public mapEditForm: FormGroup;
    public map: IMap;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private mapService: MapService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.mapService.getMapById(Number.parseInt(params['Id']))
                .subscribe(map => {
                    this.map = map;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.mapEditForm = this.fb.group({
            Id: this.map.mapId,

            title: ['', [Validators.required, Validators.minLength(3)]],
            points: '',

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
        
        const formModel = this.mapEditForm.value;
        this.mapService.updateMap(formModel as IMap).subscribe(map =>
        {
            this.map = map;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}