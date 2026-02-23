import { Component, OnInit} from '@angular/core';

import { IPoliticalParty } from '../../services/interfaces';
import { PoliticalPartyService } from '../../services/politicalparty.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'politicalparty',
    templateUrl:'./politicalparty.component.html',
})
export class PoliticalPartyComponent implements OnInit {

    errorMessage: string;
    politicalParty: IPoliticalParty[] = [];

    display: boolean = false;

    constructor( private _politicalPartyService: PoliticalPartyService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._politicalPartyService.getPoliticalPartyAll()
            .subscribe(politicalParty => {
                this.politicalParty = politicalParty;
                console.log(this.politicalParty);
            },
            error => this.errorMessage = <any>error);
    }
}








