import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Telefone } from '../models/Telefone';

@Injectable()
export class TelefoneService {

  baseURL = environment.apiURL + 'telefone';

  constructor(private http: HttpClient) { }

  public obterTodos() : Observable<Telefone[]>{
    return this.http.get<Telefone[]>(this.baseURL).pipe(take(1));
  }

  public obterPeloId(id: number) : Observable<Telefone>{
    return this.http.get<Telefone>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public salvar(telefone: Telefone): Observable<Telefone>{
    return this.http.post<Telefone>(this.baseURL, telefone).pipe(take(1));
  }

  public editar(telefone: Telefone): Observable<Telefone>{
    return this.http.put<Telefone>(`${this.baseURL}/${telefone.id}`, telefone).pipe(take(1));
  }

  public remover(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
