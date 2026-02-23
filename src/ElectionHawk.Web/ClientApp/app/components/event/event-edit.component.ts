import { Component, OnDestroy, OnInit } from '@angular/core';
import { IEvent } from '../../services/interfaces';
import { EventService } from '../../services/event.service';
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
    selector: 'event-edit',
    templateUrl: 'event-edit.component.html'  
})

export class EventEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public eventEditForm: FormGroup;
    public event: IEvent;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private eventService: EventService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.eventService.getEventById(Number.parseInt(params['Id']))
                .subscribe(event => {
                    this.event = event;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.eventEditForm = this.fb.group({
            Id: this.event.eventId,

            name: ['', [Validators.required, Validators.minLength(3)]],
						description: '',
						area: '',
						venue: '',
						heldon: '', 
						agenda: '', 
						organizerProfileId: '',
						chiefGuestProfileId: '',

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
        
        const formModel = this.eventEditForm.value;
        this.eventService.updateEvent(formModel as IEvent).subscribe(event =>
        {
            this.event = event;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}