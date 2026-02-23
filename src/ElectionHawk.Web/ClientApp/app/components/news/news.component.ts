import { Component, OnInit} from '@angular/core';

import { INews } from '../../services/interfaces';
import { NewsService } from '../../services/news.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'news',
    templateUrl:'./news.component.html',
})
export class NewsComponent {

    errorMessage: string;
    news: INews[] = [];

    display: boolean = false;

    constructor( private _newsService: NewsService) {
        //debugger;
        this._newsService.getNewsAll()
            .subscribe(news => {
                this.news = news;
                console.log(this.news);
            },
            error => this.errorMessage = <any>error);
    
    }
    
       
        
}








