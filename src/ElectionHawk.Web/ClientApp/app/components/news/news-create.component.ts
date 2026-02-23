import { Component, OnDestroy, OnInit } from '@angular/core';
import { INews } from '../../services/interfaces';
import { NewsService } from '../../services/news.service';
import { FormGroup, ReactiveFormsModule, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray  } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/delay';
import "rxjs/add/operator/takeUntil";
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common'; 

import { CalendarModule } from 'primeng/primeng';

@Component({
    selector: 'news-create',
    templateUrl: 'news-create.component.html'  
})

export class NewsCreateComponent implements OnInit, OnDestroy {

    
    private sub: any; // pointer to subscription on Route
    newsForm: FormGroup;
   public news: INews;
   errorMessage: string;
   private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private newsService: NewsService, private location: Location)
    {

    }

    ngOnInit()
    {
        this.newsForm = this.fb.group({
           heading: ['', [Validators.required, Validators.minLength(3)]],
            description: '',
            status: 'true',
            createdDate: '',
            publishedDate: '',
            source: '',
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
        console.log(this.newsForm.value);
        const formModel = this.newsForm.value;
        this.newsService.createNews(formModel as INews).subscribe(news =>
        {
            this.news = news;
        },
            error => this.errorMessage = <any>error);
    }


    goBack(): void {
        this.location.back();
    }
}