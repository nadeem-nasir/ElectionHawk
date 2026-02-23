import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IProfile} from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class ProfileService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'profile/';
    }
    getProfile(pageNumber: number, pageSize: number): Observable<IProfile[]>
    {

       
        return this._http.get<IProfile[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getProfileAll():Observable<IProfile[]>
{
	return this._http.get<IProfile[]>(this.actionUrl).catch(this.handleError);
}

    getProfileById(Id: any): Observable<IProfile> {

        return this._http.get<IProfile>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchProfile(profileName:string): Observable<IProfile[]>
        {
            return this._http.get<IProfile[]>(this.actionUrl + profileName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createProfile(profile: IProfile): Observable<IProfile>
    {
        return this._http.post<IProfile>(this.actionUrl, profile)
             .catch(this.handleError);
    }

    public updateProfile(profile: IProfile): Observable<IProfile> {
        return this._http.put<IProfile>(this.actionUrl, profile)
            .catch(this.handleError);;
    }

    public deleteProfile(id: any): Observable<IProfile[]> {
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


