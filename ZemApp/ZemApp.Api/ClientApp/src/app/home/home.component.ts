import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public posts: Blog_PostDTO[];
  public pending: Blog_PostDTO[];
  modalRef: BsModalRef;
  author ="login";
  role = "";
  constructor(private modalService: BsModalService,public httpClient: HttpClient) {
    this.role =localStorage.getItem("role");
    httpClient.get<Blog_PostDTO[]>("http://localhost:3907/api/BlogPost/queryByState?state=Approve").subscribe(result => {
      this.posts = result;
    }, error => console.error(error));
    httpClient.get<Blog_PostDTO[]>("http://localhost:3907/api/BlogPost/queryByState?state=Pending").subscribe(result => {
      this.pending = result;
    }, error => console.error(error));
    this.author = localStorage.getItem("unique_name") == undefined ?"login":localStorage.getItem("unique_name") ;
  }

  ngOnInit(): void {
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  logOut(): void{
    localStorage.clear();
    location.reload();
  }


}

interface Blog_PostDTO {
  postId: string;
  userName: number;
  title: number;
  post_Content: string;
  state: string;
  update_Date: string;
}

