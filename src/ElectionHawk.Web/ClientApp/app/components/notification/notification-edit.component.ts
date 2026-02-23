import { Component, OnDestroy, OnInit } from '@angular/core';
import { INotification } from '../../services/interfaces';
import { NotificationService } from '../../services/notification.service';
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
    selector: 'notification-edit',
    templateUrl: 'notification-edit.component.html'  
})

export class NotificationEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private notificationEditForm: FormGroup;
    public notification: INotification;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private notificationService: NotificationService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.notificationService.getNotificationById(Number.parseInt(params['Id']))
                .subscribe(notification => {
                    this.notification = notification;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.notificationEditForm = this.fb.group({
            Id: this.notification.NotificationId,

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
        
        const formModel = this.notificationEditForm.value;
        this.notificationService.updateNotification(formModel as INotification).subscribe(notification =>
        {
            this.notification = notification;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}