

import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";

import { CalendarModule } from 'primeng/primeng';

import { INews } from '../../services/interfaces';
import { NewsService } from '../../services/news.service';

import { Observable } from 'rxjs/Observable';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 
import { Paginator, PaginatorModule } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent} from 'primeng/components/common/lazyloadevent';
import { ButtonModule, DialogModule, Dialog } from 'primeng/primeng';
import { TableModule } from 'primeng/table';

@Component({
    selector: 'news-list',
    templateUrl: './news-list.component.html',
})
export class NewsListComponent implements OnInit
{
    errorMessage: string;
    news: INews[] = [];
    
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    display: boolean = false;

    constructor(private route: ActivatedRoute,
        private router: Router, elementRef: ElementRef, private _newsService: NewsService, private location: Location)
    {
        //debugger;
    }
    ngOnInit(): void
    {
           this._newsService.getNewsAll()
            .subscribe(news =>
            {
                this.news = news;
                console.log(this.news);
            },
            error => this.errorMessage = <any>error);
    }

    ngOnDelete(id: any): void {
        this._newsService.deleteNews(id);
       
    }

    ngOnDestroy() {
       
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    goBack(): void {
        this.location.back();
    }
    showDialog() {
        this.display = true;
    }
}







