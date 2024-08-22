import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cards } from './cards.model';

@Injectable({
  providedIn: 'root'
})
export class CardsService {
  baseUrl:string = "http://localhost:5172/";

  constructor(private http:HttpClient) { }

  getAllCards():Observable<Cards[]>{
    const url = this.baseUrl+'Card';
    return this.http.get<Cards[]>(url);
  }

  getCardById(id:string):Observable<Cards>{
    const url = this.baseUrl+'card/id/'+id;
    return this.http.get<Cards>(url);
  }
  deleteCardById(id:string):Observable<Cards>{
    const url = this.baseUrl+'card/id/'+id;
    return this.http.delete<Cards>(url);
  }
  editCard(cardEdit:Cards):Observable<Cards>{
    const url = this.baseUrl+'card';
    return this.http.put<Cards>(url, cardEdit)
  }
  addCard(cardAdd:Cards):Observable<Cards>{
    const url = this.baseUrl+'card';
    return this.http.post<Cards>(url, cardAdd);
  }
}
