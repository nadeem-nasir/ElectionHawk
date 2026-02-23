import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IPoliticalParty } from './interfaces';
import { Configuration } from './app.constants';

@Injectable()
export class PoliticalPartyService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'politicalparty/';
    }
    getPoliticalParty(pageNumber: number, pageSize: number): Observable<IPoliticalParty[]>
    {
        return this._http.get<IPoliticalParty[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getPoliticalPartyAll():Observable<IPoliticalParty[]>
{
	return this._http.get<IPoliticalParty[]>(this.actionUrl).catch(this.handleError);
}

    getPoliticalPartyById(Id: any): Observable<IPoliticalParty> {

        return this._http.get<IPoliticalParty>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchPoliticalParty(politicalPartyName:string): Observable<IPoliticalParty[]>
        {
            return this._http.get<IPoliticalParty[]>(this.actionUrl + politicalPartyName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createPoliticalParty(politicalParty: IPoliticalParty): Observable<IPoliticalParty>
    {
        return this._http.post<IPoliticalParty>(this.actionUrl, politicalParty)
             .catch(this.handleError);
    }

    public updatePoliticalParty(politicalParty: IPoliticalParty): Observable<IPoliticalParty> {
        return this._http.put<IPoliticalParty>(this.actionUrl, politicalParty)
            .catch(this.handleError);;
    }

    public deletePoliticalParty(id: any): Observable<IPoliticalParty[]> {
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


