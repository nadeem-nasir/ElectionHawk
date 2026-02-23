
import { Component, OnInit} from '@angular/core';

import { IEvent } from '../../services/interfaces';
import { EventService } from '../../services/event.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'event',
    templateUrl:'./event.component.html',
})
export class EventComponent implements OnInit {

    errorMessage: string;
    event: IEvent[] = [];

    display: boolean = false;

    constructor( private _eventService: EventService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._eventService.getEventAll()
            .subscribe(event => {
                this.event = event;
                console.log(this.event);
            },
            error => this.errorMessage = <any>error);
    }
}








