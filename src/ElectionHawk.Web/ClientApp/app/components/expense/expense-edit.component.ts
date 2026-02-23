import { Component, OnDestroy, OnInit } from '@angular/core';
import { IExpense } from '../../services/interfaces';
import { ExpenseService } from '../../services/expense.service';
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
    selector: 'expense-edit',
    templateUrl: 'expense-edit.component.html'  
})

export class ExpenseEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    public expenseEditForm: FormGroup;
    public expense: IExpense;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private expenseService: ExpenseService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.expenseService.getExpenseById(Number.parseInt(params['Id']))
                .subscribe(expense => {
                    this.expense = expense;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.expenseEditForm = this.fb.group({
            Id: this.expense.ExpenseId,

             event: ['', [Validators.required, Validators.minLength(3)]],
            description: '',
            amountUtilized: '',
            totalBudget: '',
            balance: '',
            expenseType: '',
            managerProfileId: '',

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
        
        const formModel = this.expenseEditForm.value;
        this.expenseService.updateExpense(formModel as IExpense).subscribe(expense =>
        {
            this.expense = expense;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}