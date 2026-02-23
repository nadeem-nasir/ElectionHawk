import { Component, OnInit} from '@angular/core';

import { IExpense } from '../../services/interfaces';
import { ExpenseService } from '../../services/expense.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'expense',
    templateUrl:'./expense.component.html',
})
export class ExpenseComponent implements OnInit {

    errorMessage: string;
    expense: IExpense[] = [];

    display: boolean = false;

    constructor( private _expenseService: ExpenseService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._expenseService.getExpenseAll()
            .subscribe(expense => {
                this.expense = expense;
                console.log(this.expense);
            },
            error => this.errorMessage = <any>error);
    }
}








