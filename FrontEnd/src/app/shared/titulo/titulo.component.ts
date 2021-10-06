import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {

  @Input() titulo: string | any;
  @Input() iconClass = 'fa fa-user';
  @Input() iconClass2 = 'fa fa-plus-circle'
  @Input() subtitulo = 'Desde 2021';
  @Input() botao = false;
  @Input() message = 'Cadastrar';
  @Input() novaRota = '/cadastrarEmpresa';

  constructor(private router: Router) { }

  ngOnInit() {
  }

  buscarRota(rota: string): void {
    this.router.navigate([`${this.novaRota}`]);
  }
}
