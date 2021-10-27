import { Component, OnInit,ChangeDetectorRef, ElementRef, ViewChild  } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { FormBuilder, FormArray, Validators } from "@angular/forms";
import { Observable, Observer } from "rxjs";

interface authProfile {
  given_name: string;
  family_name: string;
  nickname : string;
  name : string;
  picture : string;
  locale : string;
  updated_at : string;
  email : string;
  email_verified : boolean;
  sub : string;
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  myProfile:authProfile={
    "given_name": "",
    "family_name": "",
    "nickname": "",
    "name": "",
    "picture": "",
    "locale": "",
    "updated_at": "",
    "email": "",
    "email_verified": true,
    "sub": ""
  }


  public editBody = false

  public aboutMeActive = false
  public particularsActive = false
  public extrasActive = false

  submitted=false;
  profileJson:string;
  name = "Mr";
  base64Image: any;


  /*########################## File Upload ########################*/
  @ViewChild('fileInput') el: ElementRef;
  imageUrl: any ;
  editFile: boolean = true;
  removeUpload: boolean = false;
  lat:any;
  lng:any;

  constructor(public auth: AuthService,
    public fb: FormBuilder,
    private cd: ChangeDetectorRef) {
      if (navigator)
      {
      navigator.geolocation.getCurrentPosition( pos => {
          this.lng = +pos.coords.longitude;
          this.lat = +pos.coords.latitude;
        });
      }
     }


  ngOnInit(): void {


    document.body.style.backgroundImage = "url('./../../../assets/background4.jpg')";
    this.auth.user$.subscribe(
      (profile) => (this.profileJson = JSON.stringify(profile, null, 2))
    );
    this.imageUrl=this.name;
  }
  registrationForm = this.fb.group({
    file: [null]
  })


  uploadFile(event: any) {
    let reader = new FileReader(); // HTML5 FileReader API
    let file = event.target.files[0];
    if (event.target.files && event.target.files[0]) {
      reader.readAsDataURL(file);

      // When file uploads set it to file formcontrol
      reader.onload = () => {
        this.imageUrl = reader.result;
        this.registrationForm.patchValue({
          file: reader.result
        });
        this.editFile = false;
        this.removeUpload = true;
      }
      // ChangeDetectorRef since file is loading outside the zone
      this.cd.markForCheck();
    }
  }

  // Function to remove uploaded file
  removeUploadedFile() {
    let newFileList = Array.from(this.el.nativeElement.files);
    this.imageUrl = 'https://i.pinimg.com/236x/d6/27/d9/d627d9cda385317de4812a4f7bd922e9--man--iron-man.jpg';
    this.editFile = true;
    this.removeUpload = false;
    this.registrationForm.patchValue({
      file: [null]
    });
  }

  // Submit Registration Form
  onSubmit() {
    this.submitted = true;
    if(!this.registrationForm.valid) {
      alert('Please fill all the required fields to create a super hero!')
      return false;
    } else {
      console.log(this.registrationForm.value)
      return true;
    }
  }

  public doEditBody(){
    this.editBody = !this.editBody
  }

  downloadImage() {
    let savedimageUrl =this.imageUrl;

    this.getBase64ImageFromURL(savedimageUrl).subscribe((base64data: string) => {
      console.log(base64data);
      this.base64Image = "data:image/jpg;base64," + base64data;
      // save image to disk
      var link = document.createElement("a");

      document.body.appendChild(link); // for Firefox

      link.setAttribute("href", this.base64Image);
      link.setAttribute("download", "image.jpg");
      link.click();
    });
  }

  getBase64ImageFromURL(url: string) {
    return Observable.create((observer: Observer<string>) => {
      const img: HTMLImageElement = new Image();
      img.crossOrigin = "Anonymous";
      img.src = url;
      if (!img.complete) {
        img.onload = () => {
          observer.next(this.getBase64Image(img));
          observer.complete();
        };
        img.onerror = err => {
          observer.error(err);
        };
      } else {
        observer.next(this.getBase64Image(img));
        observer.complete();
      }
    });
  }

  getBase64Image(img: HTMLImageElement) {
    const canvas: HTMLCanvasElement = document.createElement("canvas");
    canvas.width = img.width;
    canvas.height = img.height;
    const ctx: CanvasRenderingContext2D = canvas.getContext("2d");
    ctx.drawImage(img, 0, 0);
    const dataURL: string = canvas.toDataURL("image/png");

    return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
  }

}
