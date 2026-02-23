import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IEvent } from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class EventService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'event/';
    }
    getEvent(pageNumber: number, pageSize: number): Observable<IEvent[]>
    {
        return this._http.get<IEvent[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getEventAll():Observable<IEvent[]>
{
	return this._http.get<IEvent[]>(this.actionUrl).catch(this.handleError);
}

    getEventById(Id: any): Observable<IEvent> {
        return this._http.get<IEvent>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchEvent(eventName:string): Observable<IEvent[]>
        {
            return this._http.get<IEvent[]>(this.actionUrl + eventName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createEvent(event: IEvent): Observable<IEvent>
    {
        return this._http.post<IEvent>(this.actionUrl, event)
             .catch(this.handleError);
    }

    public updateEvent(event: IEvent): Observable<IEvent> {
        return this._http.put<IEvent>(this.actionUrl, event)
            .catch(this.handleError);;
    }

    public deleteEvent(id: any): Observable<IEvent[]> {
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


