import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

//1a forma de fazer com que o service seja injetavel
@Injectable(
  //{providedIn: 'root'}
)

//2a forma eh no component.ts em @Component providers: [EventoService]

//3a forma eh app.module.ts em providers: [EventoService]

export class EventoService {

  baseURL = 'https://localhost:7250/eventos';

  constructor(private http: HttpClient) { }

  public getEventos(): Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema: string): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
  }

  public getEventoById(id: number): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
