import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdenesService {
  

  constructor(private http: HttpClient) { }

  getPedidos()
  {    
    return this.http.get<any>(`${environment.apiUrl}ordenpedido`)
  }

  setPedidos(pedidoid: number, arg1: number) {
    return this.http.put<any>(`${environment.apiUrl}ordenpedido`,{'ordenPedidoId':pedidoid,'estadoId':arg1})
  }

}
