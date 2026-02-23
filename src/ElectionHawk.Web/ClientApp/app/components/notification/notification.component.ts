import { Component, OnInit} from '@angular/core';

import { INotification } from '../../services/interfaces';
import { NotificationService } from '../../services/notification.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'notification',
    templateUrl:'./notification.component.html',
})
export class NotificationComponent implements OnInit {

    errorMessage: string;
    notification: INotification[] = [];

    display: boolean = false;

    constructor( private _notificationService: NotificationService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._notificationService.getNotificationAll()
            .subscribe(notification => {
                this.notification = notification;
                console.log(this.notification);
            },
            error => this.errorMessage = <any>error);
    }
}








