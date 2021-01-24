import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'my-app';
  info: any;
  selectedOwner;
  selectedUnicorn;
  owners = [];
  unicorns: any[] = [];
  userUnicorns = [];

  constructor(private _http: HttpClient) {}
  ngOnInit(): void {
    this.getInfo();
  }

  getInfo() {
    // should use fork join
    this._http
      .get('https://localhost:44302/api/Admin/GetOwners')
      .subscribe((owners: []) => {
        this.owners = owners;
      });
      this._http
        .get('https://localhost:44302/api/Admin/GetAllUnicorns')
        .subscribe((unicorns: []) => {
          this.unicorns = unicorns;
        });
  }
  onChange(id) {
    this._http
      .get('https://localhost:44302/api/Admin/GetOwner?id=' + id)
      .subscribe((owner: any) => {
        this.userUnicorns = owner.unicorns;
      });
  } 


  manageUnicorn() {
    let body = {
      ownerId: +this.selectedOwner,
      unicornId: +this.selectedUnicorn,
    };
    this._http
      .post(
        'https://localhost:44302/api/Admin/ManageUnicorns',
        body
      )
      .subscribe(() => {});
  }
}

