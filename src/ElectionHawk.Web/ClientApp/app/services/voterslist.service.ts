import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IVotersList} from './interfaces';
import { Configuration } from './app.constants';

@Injectable()
export class VoterslistService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'voterlist/';
    }
    getVotersList(pageNumber: number, pageSize: number): Observable<IVotersList[]>
    {
       
        return this._http.get<IVotersList[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getVotersListAll():Observable<IVotersList[]>
{
	return this._http.get<IVotersList[]>(this.actionUrl).catch(this.handleError);
}

    getVotersListById(Id: any): Observable<IVotersList> {

        return this._http.get<IVotersList>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchVotersList(votersListName:string): Observable<IVotersList[]>
        {
            return this._http.get<IVotersList[]>(this.actionUrl + votersListName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createVotersList(votersList: IVotersList): Observable<IVotersList>
    {
        return this._http.post<IVotersList>(this.actionUrl, votersList)
             .catch(this.handleError);
    }

    public updateVotersList(votersList: IVotersList): Observable<IVotersList> {
        return this._http.put<IVotersList>(this.actionUrl, votersList)
            .catch(this.handleError);;
    }

    public deleteVotersList(id: any): Observable<IVotersList[]> {
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


