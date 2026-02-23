import { Component, OnDestroy, OnInit } from '@angular/core';
import { IMap } from '../../services/interfaces';
import { MapService } from '../../services/map.service';
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
    selector: 'map-create',
    templateUrl: 'map-create.component.html'  
})

export class MapCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    mapForm: FormGroup;
   public map: IMap;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private mapService: MapService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.mapForm = this.fb.group({
           LocationTitle: ['', [Validators.required, Validators.minLength(3)]],
            LocationPoints: '',
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
        console.log(this.mapForm.value);
        const formModel = this.mapForm.value;
        this.mapService.createMap(formModel as IMap).subscribe(map =>
        {
            this.map = map;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}