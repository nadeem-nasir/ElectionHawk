import { Component, OnDestroy, OnInit } from '@angular/core';
import { IEvent } from '../../services/interfaces';
import { EventService } from '../../services/event.service';
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
    selector: 'event-create',
    templateUrl: 'event-create.component.html'  
})

export class EventCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    eventForm: FormGroup;
   public event: IEvent;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private eventService: EventService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.eventForm = this.fb.group({
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
        console.log(this.eventForm.value);
        const formModel = this.eventForm.value;
        this.eventService.createEvent(formModel as IEvent).subscribe(event =>
        {
            this.event = event;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}