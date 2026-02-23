import { Component, OnInit} from '@angular/core';

import { IMap } from '../../services/interfaces';
import { MapService } from '../../services/map.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'map',
    templateUrl:'./map.component.html',
})
export class MapComponent implements OnInit {

    errorMessage: string;
    map: IMap[] = [];

    display: boolean = false;

    constructor( private _mapService: MapService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._mapService.getMapAll()
            .subscribe(map => {
                this.map = map;
                console.log(this.map);
            },
            error => this.errorMessage = <any>error);
    }
}








