import { Component, OnDestroy, OnInit } from '@angular/core';
import { IExpense } from '../../services/interfaces';
import { ExpenseService } from '../../services/expense.service';
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
    selector: 'expense-create',
    templateUrl: 'expense-create.component.html'  
})

export class ExpenseCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    expenseForm: FormGroup;
   public expense: IExpense;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private expenseService: ExpenseService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.expenseForm = this.fb.group({
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
        console.log(this.expenseForm.value);
        const formModel = this.expenseForm.value;
        this.expenseService.createExpense(formModel as IExpense).subscribe(expense =>
        {
            this.expense = expense;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}