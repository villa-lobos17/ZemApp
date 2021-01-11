import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
@Component({
  selector: 'app-post-content',
  templateUrl: './post-content.component.html',
  styleUrls: ['./post-content.component.css']
})
export class PostContentComponent implements OnInit {
 @Input() model:any;
  public Editor = ClassicEditor;
  role ='';
  constructor(public httpClient: HttpClient) {
    this.Editor.isReadOnly = true
    this.role =localStorage.getItem("role");
   }

  ngOnInit(): void {
  }

  ChangeState(state){
    const bearer = 'Bearer '+ localStorage.getItem("token").replace('"', '');
    console.log(bearer);
    const headers = { 'Authorization': bearer};
    this.httpClient.put<any>('http://localhost:3907/api/BlogPost/updateState?id='+this.model.postId, {"State":state}, { headers }).subscribe(data => {
      location.reload();
    });
  }

}
