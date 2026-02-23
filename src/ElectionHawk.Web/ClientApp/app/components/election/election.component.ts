import { Component, OnInit} from '@angular/core';

import { IElection } from '../../services/interfaces';
import { ElectionService } from '../../services/election.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'election',
    templateUrl:'./election.component.html',
})
export class ElectionComponent implements OnInit{

    errorMessage: string;
    election: IElection[] = [];

    display: boolean = false;

    constructor( private _electionService: ElectionService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._electionService.getElectionAll()
            .subscribe(election => {
                this.election = election;
                console.log(this.election);
            },
            error => this.errorMessage = <any>error);
    }
}








