import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Fornecedor } from '../models/Fornecedor';

@Injectable()
export class FornecedorService {

  baseURL = environment.apiURL + 'fornecedor';

  constructor(private http: HttpClient) { }

  public obterTodos() : Observable<Fornecedor[]>{
    return this.http.get<Fornecedor[]>(this.baseURL).pipe(take(1));
  }

  public obterPeloId(id: number) : Observable<Fornecedor>{
    return this.http.get<Fornecedor>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public salvar(fornecedor: Fornecedor) : Observable<Fornecedor>{
    return this.http.post<Fornecedor>(this.baseURL, fornecedor).pipe(take(1));
  }

  public editar(fornecedor: Fornecedor) : Observable<Fornecedor>{
    return this.http.put<Fornecedor>(`${this.baseURL}/${fornecedor.id}`, fornecedor).pipe(take(1));
  }

  public remover(id: number) : Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
