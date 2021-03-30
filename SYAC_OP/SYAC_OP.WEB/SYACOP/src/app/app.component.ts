import { Component } from '@angular/core';
import { OrdenesService } from './services/ordenes.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  pedidos: any;
  constructor(private ordenesServices: OrdenesService) {
  }
  title = 'SYACOP';
  ngOnInit() {
    this.ordenesServices.getPedidos().subscribe(response=>    {
      this.pedidos=response;
    }
    );
  }
}
