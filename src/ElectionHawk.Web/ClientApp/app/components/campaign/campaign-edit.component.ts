import { Component, OnDestroy, OnInit } from '@angular/core';
import { ICampaign, IAgenda } from '../../services/interfaces';
import { CampaignService } from '../../services/campaign.service';
import { AgendaService} from '../../services/agenda.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray, ReactiveFormsModule  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'campaign-edit',
    templateUrl: 'campaign-edit.component.html'  
})

export class CampaignEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private campaignEditForm: FormGroup;
    public campaign: ICampaign;
	public agendas:IAgenda[]; 
	errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private campaignService: CampaignService,
		private agendaService: AgendaService)
    {

    }

    ngOnInit()
    {
		this.agendaService.getAgendaAll()
		.subscribe( ag => {
				this.agendas=ag;
				console.log(this.agendas)
		});
        this.route.queryParams.subscribe(params => {
            this.campaignService.getCampaignById(Number.parseInt(params['Id']))
                .subscribe(campaign => {
                    this.campaign = campaign;
					console.log(this.campaign);
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.campaignEditForm = this.fb.group({
            campaignId: this.campaign.campaignId,

            title: [this.campaign.title, [Validators.required, Validators.minLength(3)]],
            media: this.campaign.media,
            mediumofPropagation: this.campaign.mediumofPropagation,
            agendaId:this.campaign.agendaId,
            forum: this.campaign.forum,

        });
    }
	setSelectedAgenda(optionOne, optionTwo):boolean{
		return optionOne==optionTwo;		
		
	}
    ngOnDestroy() {
        // If subscribed, we must unsubscribe before Angular destroys the component.
        // Failure to do so could create a memory leak.
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    cancel()
    {
        this.router.navigate(['home']);
    }

    save(): void
    {
        
        const formModel = this.campaignEditForm.value;
        this.campaignService.updateCampaign(formModel as ICampaign).subscribe(campaign =>
        {
            this.campaign = campaign;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}