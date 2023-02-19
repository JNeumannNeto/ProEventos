import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  public getEventos(): void{
    this.eventos = this.http.get('https://localhost:7250/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }
}
