import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IConstituency } from './interfaces';
import {Configuration} from './app.constants';

@Injectable()
export class ConstituencyService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'constituency/';
    }
    getConstituency(pageNumber: number, pageSize: number): Observable<IConstituency[]>
    {

        return this._http.get<IConstituency[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getConstituencyAll():Observable<IConstituency[]>
{
	return this._http.get<IConstituency[]>(this.actionUrl).catch(this.handleError);
}
    getConstituencyById(Id: any): Observable<IConstituency> {

        return this._http.get<IConstituency>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchConstituency(constituencyName:string): Observable<IConstituency[]>
        {
            return this._http.get<IConstituency[]>(this.actionUrl + constituencyName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createConstituency(constituency: IConstituency): Observable<IConstituency>
    {
        return this._http.post<IConstituency>(this.actionUrl, constituency)
             .catch(this.handleError);
    }

    public updateConstituency(constituency: IConstituency): Observable<IConstituency> {
        return this._http.put<IConstituency>(this.actionUrl, constituency)
            .catch(this.handleError);;
    }

    public deleteConstituency(id: any): Observable<IConstituency[]> {
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


