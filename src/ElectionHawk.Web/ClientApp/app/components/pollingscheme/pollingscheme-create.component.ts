import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPollingScheme } from '../../services/interfaces';
import { PollingSchemeService } from '../../services/pollingscheme.service';
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
    selector: 'pollingscheme-create',
    templateUrl: 'pollingscheme-create.component.html'  
})

export class PollingSchemeCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    pollingSchemeForm: FormGroup;
   public pollingScheme: IPollingScheme;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private pollingSchemeService: PollingSchemeService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.pollingSchemeForm = this.fb.group({
           name: ['', [Validators.required, Validators.minLength(3)]],
    malebooths: '',
    femalebooths: '',
    totalbooths: '',
    malevoters: '',
    femalevoters: '',
    totalvoters: '',
    latitude: '',
    longitude: '',
    pollingschemeimageurl: '',
    pollingschememapurl: '',
    ecppsno: '',
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
        console.log(this.pollingSchemeForm.value);
        const formModel = this.pollingSchemeForm.value;
        this.pollingSchemeService.createPollingScheme(formModel as IPollingScheme).subscribe(pollingScheme =>
        {
            this.pollingScheme = pollingScheme;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}