import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IExpense } from './interfaces';
import { Configuration} from './app.constants';
@Injectable()
export class ExpenseService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'expense/';
    }
    getExpense(pageNumber: number, pageSize: number): Observable<IExpense[]>
    {
        return this._http.get<IExpense[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }

getExpenseAll():Observable<IExpense[]>
{
	return this._http.get<IExpense[]>(this.actionUrl).catch(this.handleError);
}

    getExpenseById(Id: any): Observable<IExpense> {

        return this._http.get<IExpense>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchExpense(expenseName:string): Observable<IExpense[]>
        {
            return this._http.get<IExpense[]>(this.actionUrl + expenseName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createExpense(expense: IExpense): Observable<IExpense>
    {
        return this._http.post<IExpense>(this.actionUrl, expense)
             .catch(this.handleError);
    }

    public updateExpense(expense: IExpense): Observable<IExpense> {
        return this._http.put<IExpense>(this.actionUrl, expense)
            .catch(this.handleError);;
    }

    public deleteExpense(id: any): Observable<IExpense[]> {
        return this._http.delete(this.actionUrl + id)
            .catch(this.handleError);
    }
   
    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }
}


