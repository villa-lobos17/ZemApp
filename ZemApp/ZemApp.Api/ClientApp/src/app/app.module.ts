import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AddPostComponent } from './add-post/add-post.component';
import { BlogPostComponent } from './blog-post/blog-post.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { HttpClientModule  } from '@angular/common/http';
import { PostContentComponent } from './post-content/post-content.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AddPostComponent,
    BlogPostComponent,
    PostContentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CKEditorModule,
    ModalModule.forRoot()
  ],
  exports: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
