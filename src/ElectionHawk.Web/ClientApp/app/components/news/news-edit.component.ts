import { Component, OnDestroy, OnInit } from '@angular/core';
import { INews } from '../../services/interfaces';
import { NewsService } from '../../services/news.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray, ReactiveFormsModule  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'news-edit',
    templateUrl: 'news-edit.component.html'  
})

export class NewsEditComponent implements OnInit, OnDestroy {

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private newsEditForm: FormGroup;
    public news: INews;
    errorMessage: string;
    Id: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private location: Location,
        private newsService: NewsService)
    {

    }

    ngOnInit()
    {

        this.route.queryParams.subscribe(params => {
            this.newsService.getNewsById(Number.parseInt(params['Id']))
                .subscribe(news => {
                    this.news = news;
                    this.buildForm();
                });
          
        });


        
       
    }

    buildForm(): void
    {
        this.newsEditForm = this.fb.group({
            Id: this.news.newsId,

            heading: ['', [Validators.required, Validators.minLength(3)]],
            description: '',
            status: 'true',
            createdDate: '',
            publishedDate: '',
            source: ''

        });
    }
    ngOnDestroy() {
        // If subscribed, we must unsubscribe before Angular destroys the component.
        // Failure to do so could create a memory leak.
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    cancel()
    {
        this.router.navigate(['home']);
    }

    save(): void
    {
        
        const formModel = this.newsEditForm.value;
        this.newsService.updateNews(formModel as INews).subscribe(news =>
        {
            this.news = news;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}