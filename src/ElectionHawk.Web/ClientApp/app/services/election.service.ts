import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IElection } from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class ElectionService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'election/';
    }
    getElection(pageNumber: number, pageSize: number): Observable<IElection[]>
    {

        return this._http.get<IElection[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }

    getElectionById(Id: any): Observable<IElection> {

        return this._http.get<IElection>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }
getElectionAll():Observable<IElection[]>
{
	return this._http.get<IElection[]>(this.actionUrl).catch(this.handleError);
}

    searchElection(electionName:string): Observable<IElection[]>
        {
            return this._http.get<IElection[]>(this.actionUrl + electionName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createElection(election: IElection): Observable<IElection>
    {
        return this._http.post<IElection>(this.actionUrl, election)
             .catch(this.handleError);
    }

    public updateElection(election: IElection): Observable<IElection> {
        return this._http.put<IElection>(this.actionUrl, election)
            .catch(this.handleError);;
    }

    public deleteElection(id: any): Observable<IElection[]> {
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


