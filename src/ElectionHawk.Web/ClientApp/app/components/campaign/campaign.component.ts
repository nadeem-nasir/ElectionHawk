import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ICampaign } from '../../services/interfaces';
import { CampaignService } from '../../services/campaign.service';

import { TableModule } from 'primeng/components/table/table.js';

@Component({
    selector:'campaign',
    templateUrl:'./campaign.component.html',
})
export class CampaignComponent implements OnInit {

    errorMessage: string;
    campaign: ICampaign[] = [];

    display: boolean = false;

    constructor(private _campaignService: CampaignService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._campaignService.getCampaignsAll()
            .subscribe(campaign => {
                this.campaign = campaign;
                console.log(this.campaign);
            },
            error => this.errorMessage = <any>error);
    }
}








