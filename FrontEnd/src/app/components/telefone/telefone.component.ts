import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Telefone } from 'src/app/models/Telefone';
import { TelefoneService } from 'src/app/services/telefone.service';

@Component({
  selector: 'app-telefone',
  templateUrl: './telefone.component.html',
  styleUrls: ['./telefone.component.css']
})
export class TelefoneComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public telefones: Telefone[] = [];
  public telefonesFiltrados: Telefone[] = [];
  public filtroListado = '';
  public telefoneId = 0;

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.telefonesFiltrados = this.filtroLista
      ? this.filtrarTelefones(this.filtroLista)
      : this.telefones;
  }

  public filtrarTelefones(filtrarPor: string): Telefone[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.telefones.filter(
      (telefone) =>
        telefone.numeroTelefone.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        telefone.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private telefoneService: TelefoneService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private router: Router
  ) { }

  ngOnInit() : void {
    this.spinner.show();
    this.carregarTelefones();
  }

  public carregarTelefones(): void {
    this.telefoneService.obterTodos().subscribe({
      next: (telefones: Telefone[]) => {
        this.telefones = telefones;
        this.telefonesFiltrados = this.telefones;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os telefones.', 'Erro!');
        console.error(error);
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(telefone: any, template: TemplateRef<any>, telefoneId: number): void {
    telefone.stopPropagation();
    this.telefoneId = telefoneId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();

    this.telefoneService
      .remover(this.telefoneId)
      .subscribe(
        { next: () => {
            this.toastr.success('Telefone removido com sucesso!', 'Sucesso!');
            this.carregarTelefones()
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar os telefones.', 'Erro!');
            console.error(error);
          },
          complete: () => this.spinner.hide(),
        });
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheTelefone(id: number): void {
    this.router.navigate([`cadastrarTelefone/detalhe/${id}`]);
  }
}
