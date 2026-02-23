import { Component, OnDestroy,OnInit, ViewChild, ElementRef } from '@angular/core';

import { DataService, NotificationsService } from '@app/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Subject } from 'rxjs/Subject';

@Component({
  selector: 'appc-user-photo',
  templateUrl: './user-photo.component.html',
  styleUrls: ['./user-photo.component.scss']
})
export class UserPhotoComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject<void>();
  public URL = 'api/manage/photo';
 public existingImage: any;
 public selectedImage: any;
 public imageToUpload: any;
 @ViewChild('profileImg') img: ElementRef;
  constructor(
    private dataService: DataService,
    private ns: NotificationsService,
    public domSanitizer: DomSanitizer
  ) { }

  ngOnInit() {
    this.getImage();
  }

  fileChange(event: any) {
    if (event.target.files && event.target.files[0]) {
      this.imageToUpload = event.target.files[0];
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.selectedImage = {
          mimetype: e.target.result.split(',')[0].split(':')[1].split(';')[0],
          url: e.target.result
        };
      };
      reader.readAsDataURL(this.imageToUpload);
    }
  }
  upload() {
    const file = new FormData();
    file.append('file', this.imageToUpload);

    this.dataService
      .post(this.URL, file)
      .subscribe(res => {
        this.ns.success('Success', 'Image changed successfully');
        this.existingImage = this.selectedImage.url;
        console.log(this.existingImage);
        this.selectedImage = undefined;
        
      });
  }

  cancel() {
    this.selectedImage = undefined;
  }

  private getImage() {
      this.dataService.getImage(this.URL).takeUntil(this.ngUnsubscribe)
        .subscribe(base64String => {
            console.log(this.domSanitizer.bypassSecurityTrustUrl(base64String));     
            //console.log(window.btoa(base64String))  ;
            this.existingImage = base64String as string ;
            //this._sanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,' 
            //+ toReturnImage.base64string);
          //this.domSanitizer.bypassSecurityTrustResourceUrl
          //this.existingImage = 'data:image/png;base64,' + base64String;
          //domSanitizer.bypassSecurityTrustUrl
            this.img.nativeElement.src = this.domSanitizer.bypassSecurityTrustUrl(base64String) as string;
      });
  }

  ngOnDestroy() {
      // If subscribed, we must unsubscribe before Angular destroys the component.
      // Failure to do so could create a memory leak.
      this.ngUnsubscribe.next();
      this.ngUnsubscribe.complete();
  }
}

//https://stackoverflow.com/questions/47949950/ionic-3-display-base64-image-sanitizing-unsafe-url-value-safevalue-must-use-p?rq=1