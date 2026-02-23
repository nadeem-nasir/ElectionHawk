import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPollingScheme } from '../../services/interfaces';
import { PollingSchemeService } from '../../services/pollingscheme.service';
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
    selector: 'pollingscheme-edit',
    templateUrl: 'pollingscheme-edit.component.html'  
})

export class PollingSchemeEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public pollingSchemeEditForm: FormGroup;
    public pollingScheme: IPollingScheme;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private pollingSchemeService: PollingSchemeService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.pollingSchemeService.getPollingSchemeById(Number.parseInt(params['Id']))
                .subscribe(pollingScheme => {
                    this.pollingScheme = pollingScheme;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.pollingSchemeEditForm = this.fb.group({
            Id: this.pollingScheme.StationId,
	name: ['', [Validators.required, Validators.minLength(3)]],
    malebooths: '',
    femalebooths: '',
    totalbooths: '',
    malevoters: '',
    femalevoters: '',
    totalvoters: '',
    latitude: '',
    longitude: '',
    pollingstationimageurl: '',
    pollingstationmapurl: '',
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
        
        const formModel = this.pollingSchemeEditForm.value;
        this.pollingSchemeService.updatePollingScheme(formModel as IPollingScheme).subscribe(pollingScheme =>
        {
            this.pollingScheme = pollingScheme;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}