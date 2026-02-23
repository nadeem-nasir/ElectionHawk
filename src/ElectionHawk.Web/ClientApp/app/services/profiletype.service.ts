import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IProfileType} from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class ProfileTypeService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'profiletype/';
    }
    getProfileType(pageNumber: number, pageSize: number): Observable<IProfileType[]>
    {

       
        return this._http.get<IProfileType[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getProfileTypeAll():Observable<IProfileType[]>
{
	return this._http.get<IProfileType[]>(this.actionUrl).catch(this.handleError);
}

    getProfileTypeById(Id: any): Observable<IProfileType> {

        return this._http.get<IProfileType>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchProfileType(profiletypeName:string): Observable<IProfileType[]>
        {
            return this._http.get<IProfileType[]>(this.actionUrl + profiletypeName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createProfileType(profile: IProfileType): Observable<IProfileType>
    {
        return this._http.post<IProfileType>(this.actionUrl, profile)
             .catch(this.handleError);
    }

    public updateProfileType(profile: IProfileType): Observable<IProfileType> {
        return this._http.put<IProfileType>(this.actionUrl, profile)
            .catch(this.handleError);;
    }

    public deleteProfileType(id: any): Observable<IProfileType[]> {
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


