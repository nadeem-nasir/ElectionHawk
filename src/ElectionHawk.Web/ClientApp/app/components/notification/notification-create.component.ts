import { Component, OnDestroy, OnInit } from '@angular/core';
import { INotification } from '../../services/interfaces';
import { NotificationService } from '../../services/notification.service';
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
    selector: 'notification-create',
    templateUrl: 'notification-create.component.html'  
})

export class NotificationCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    notificationForm: FormGroup;
   public notification: INotification;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private notificationService: NotificationService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.notificationForm = this.fb.group({
           description: ['', [Validators.required, Validators.minLength(3)]],
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
        console.log(this.notificationForm.value);
        const formModel = this.notificationForm.value;
        this.notificationService.createNotification(formModel as INotification).subscribe(notification =>
        {
            this.notification = notification;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}