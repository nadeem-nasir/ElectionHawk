import { Injectable, Inject , PLATFORM_ID } from '@angular/core';
@Injectable()
export class Configuration
{
    
    public Server = 'http://localhost:56888/';
    public ApiUrl = 'api/';
    public ServerWithApiUrl = this.Server + this.ApiUrl;
    public ApiVersion = 'V1';
    
    /* Production*/
    //public Server = 'http://electionhawk.com/';
    //public ApiUrl = 'api/';
    //public ServerWithApiUrl = this.Server + this.ApiUrl;
    //public ApiVersion = 'V1';
    
}
