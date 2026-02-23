import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { IAgenda } from '../../services/interfaces';
import { AgendaService } from '../../services/agenda.service';

import { TableModule } from 'primeng/components/table/table.js';

@Component({
    selector:'agenda',
    templateUrl:'./agenda.component.html',
})
export class AgendaComponent implements OnInit {

    errorMessage: string;
    agenda: IAgenda[] = [];

    display: boolean = false;

    constructor(private _agendaService: AgendaService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._agendaService.getAgendaAll()
            .subscribe(agenda => {
                this.agenda = agenda;
                console.log(this.agenda);
            },
            error => this.errorMessage = <any>error);
    }
}








