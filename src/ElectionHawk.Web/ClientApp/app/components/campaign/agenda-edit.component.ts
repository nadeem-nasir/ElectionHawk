import { Component, OnDestroy, OnInit } from '@angular/core';
import { IAgenda } from '../../services/interfaces';
import { AgendaService } from '../../services/agenda.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray, ReactiveFormsModule  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 
import { Observable } from "rxjs/Observable";
import { Message } from 'primeng/components/common/api';

@Component({
    selector: 'agenda-edit',
    templateUrl: 'agenda-edit.component.html'  
})

export class AgendaEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private agendaEditForm: FormGroup;
    public agenda: IAgenda;
    errorMessage: string;
    ItemId: number;
msgs: Message[] = [];
    constructor(private route: ActivatedRoute,
        private router: Router,
        public fb: FormBuilder,
        private location: Location,
        private agendaService: AgendaService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.agendaService.getAgendaById(Number.parseInt(params['ItemId']))
                .subscribe(agenda => {
                    this.agenda = agenda;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.agendaEditForm = this.fb.group({
            ItemId: this.agenda.itemId,

            description: [this.agenda.description, [Validators.required, Validators.minLength(3)]],

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
        
        const formModel = this.agendaEditForm.value;
        this.agendaService.updateAgenda(formModel as IAgenda).subscribe(agenda =>{
            this.msgs = [];
            this.msgs.push({ severity: 'success', summary: 'Agenda:', detail: 'Your data has been successfully saved' });
            //clear
            //this.cityEditForm.reset();
        },
            error => {
                this.errorMessage = <any>error

                this.msgs = [];
                this.msgs.push({ severity: 'error', summary: 'Agenda:', detail: this.errorMessage });
            });
    }


    goBack(): void {
        this.location.back();
    }
}