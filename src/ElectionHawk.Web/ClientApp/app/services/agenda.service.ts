import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IAgenda } from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class AgendaService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'agenda/';
    }
    getAgenda(pageNumber: number, pageSize: number): Observable<IAgenda[]>
    {

       
       
        return this._http.get<IAgenda[]>(this.actionUrl + pageNumber + '/' + pageSize)
            //.do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
getAgendaAll(): Observable<IAgenda[]> {
        return this._http.get<IAgenda[]>(this.actionUrl )
            .catch(this.handleError);
    }
    getAgendaById(Id: any): Observable<IAgenda> {


        return this._http.get<IAgenda>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchAgenda(agend:string): Observable<IAgenda[]>
        {
            return this._http.get<IAgenda[]>(this.actionUrl + agend)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createAgenda(agend: IAgenda): Observable<IAgenda>
    {
        return this._http.post<IAgenda>(this.actionUrl, agend)
             .catch(this.handleError);
    }

    public updateAgenda(agend: IAgenda): Observable<IAgenda> {
        return this._http.put<IAgenda>(this.actionUrl, agend)
            .catch(this.handleError);
    }

    public deleteAgenda(id: any): Observable<IAgenda[]> {
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


