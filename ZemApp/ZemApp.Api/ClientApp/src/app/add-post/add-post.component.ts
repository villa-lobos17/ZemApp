import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  public Editor = ClassicEditor;
  public model = {
    editorData: '<p>Hello, world!</p>'
};
post :Blog_Post ;
  constructor(public httpClient: HttpClient) { 
    this.post =new Blog_Post();
    this.post.authorId = localStorage.getItem('nameid');
   }
  
  ngOnInit(): void {
  }
  addPost() {

    const bearer = 'Bearer '+ localStorage.getItem("token").replace('"', '');
    console.log(bearer);
    const headers = { 'Authorization': bearer};
    this.httpClient.post<any>('http://localhost:3907/api/BlogPost/add', this.post, { headers }).subscribe(data => {
      location.reload();
    });
  }
}
class Blog_Post{
  authorId: string ='';
  title: string ='';
  post_Content: string ='';
}