import { Component, OnDestroy, OnInit } from '@angular/core';
import { ICampaign, IAgenda } from '../../services/interfaces';
import { CampaignService } from '../../services/campaign.service';
import { AgendaService } from '../../services/agenda.service';
import { FormGroup, ReactiveFormsModule, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 

import { CalendarModule } from 'primeng/primeng';

@Component({
    selector: 'campaign-create',
    templateUrl: 'campaign-create.component.html'  
})

export class CampaignCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    campaignForm: FormGroup;
   public campaign: ICampaign;
   agenda: IAgenda[];
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        public fb: FormBuilder,
        private campaignService: CampaignService, 
        private agendaService: AgendaService, 
		private location: Location)
    {
			this.agendaService.getAgendaAll()
            .subscribe(agenda => {
                this.agenda = agenda;
                console.log(this.agenda);
            },
            error => this.errorMessage = <any>error);
    }

    ngOnInit()
    {
        this.campaignForm = this.fb.group({
           title: ['', [Validators.required, Validators.minLength(3)]],
            media: '',
			mediumofpropagation: '',
            forum: '',
			agendaId:''
        });
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
        console.log(this.campaignForm.value);
        const formModel = this.campaignForm.value;
        this.campaignService.createCampaign(formModel as ICampaign).subscribe(campaign =>
        {
            this.campaign = campaign;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}