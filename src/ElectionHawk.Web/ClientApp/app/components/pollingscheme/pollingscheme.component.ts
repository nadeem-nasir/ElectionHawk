import { Component, OnInit} from '@angular/core';

import { IPollingScheme } from '../../services/interfaces';
import { PollingSchemeService } from '../../services/pollingscheme.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'pollingscheme',
    templateUrl:'./pollingscheme.component.html',
})
export class PollingSchemeComponent implements OnInit {

    errorMessage: string;
    pollingschemestation: IPollingScheme[] = [];

    display: boolean = false;

    constructor( private _pollingschemeService: PollingSchemeService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._pollingschemeService.getPollingSchemeAll()
            .subscribe(pollingscheme => {
                this.pollingschemestation = pollingscheme;
                console.log(this.pollingschemestation);
            },
            error => this.errorMessage = <any>error);
    }
}








