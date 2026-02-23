import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { INotification } from './interfaces';
import { Configuration } from './app.constants';

@Injectable()
export class NotificationService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'notification/';
    }
    getNotification(pageNumber: number, pageSize: number): Observable<INotification[]>
    {

        //this.authenticationService.login('0763414956', 'tagga1234').subscribe();

        //this.notificationService.printSuccessMessage('loading notifications ....');
       
        return this._http.get<INotification[]>(this.actionUrl + pageNumber + '/' + pageSize)
            //.do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
getNotificationAll():Observable<INotification[]>
{
	return this._http.get<INotification[]>(this.actionUrl).catch(this.handleError);
}

    getNotificationById(Id: any): Observable<INotification> {

        return this._http.get<INotification>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchNotification(notificationName:string): Observable<INotification[]>
        {
            return this._http.get<INotification[]>(this.actionUrl + notificationName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createNotification(notification: INotification): Observable<INotification>
    {
        return this._http.post<INotification>(this.actionUrl, notification)
             .catch(this.handleError);
    }

    public updateNotification(notification: INotification): Observable<INotification> {
        return this._http.put<INotification>(this.actionUrl, notification)
            .catch(this.handleError);;
    }

    public deleteNotification(id: any): Observable<INotification[]> {
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


