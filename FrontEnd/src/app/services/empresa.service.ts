import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Empresa } from '../models/Empresa';

@Injectable()
export class EmpresaService {

  baseURL = environment.apiURL + 'empresa';

  constructor(private http: HttpClient) { }

  public obterTodos() : Observable<Empresa[]>{
    return this.http.get<Empresa[]>(this.baseURL).pipe(take(1));
  }

  public obterPeloId(id: number) : Observable<Empresa>{
    return this.http.get<Empresa>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public salvar(empresa: Empresa): Observable<Empresa>{
    return this.http.post<Empresa>(this.baseURL, empresa).pipe(take(1));
  }

  public editar(empresa: Empresa): Observable<Empresa>{
    return this.http.put<Empresa>(`${this.baseURL}/${empresa.id}`, empresa).pipe(take(1));
  }

  public remover(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
