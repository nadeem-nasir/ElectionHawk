import { Component, OnInit} from '@angular/core';

import { IConstituency } from '../../services/interfaces';
import { ConstituencyService } from '../../services/constituency.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'constituency',
    templateUrl:'./constituency.component.html',
})
export class ConstituencyComponent implements OnInit {

    errorMessage: string;
    constituency: IConstituency[] = [];

    display: boolean = false;

    constructor( private _constituencyService: ConstituencyService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._constituencyService.getConstituencyAll()
            .subscribe(constituency => {
                this.constituency = constituency;
                console.log(this.constituency);
            },
            error => this.errorMessage = <any>error);
    }
}








