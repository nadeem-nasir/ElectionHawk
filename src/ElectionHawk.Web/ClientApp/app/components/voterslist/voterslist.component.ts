
import { Component, OnInit} from '@angular/core';

import { IVotersList } from '../../services/interfaces';
import { VoterslistService } from '../../services/voterslist.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'voterslist',
    templateUrl:'./voterslist.component.html',
})
export class VoterslistComponent implements OnInit {

    errorMessage: string;
    voterslist: IVotersList[] = [];

    display: boolean = false;

    constructor( private _voterslistService: VoterslistService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._voterslistService.getVotersListAll()
            .subscribe(voterslist => {
                this.voterslist = voterslist;
                console.log(this.voterslist);
            },
            error => this.errorMessage = <any>error);
    }
}








