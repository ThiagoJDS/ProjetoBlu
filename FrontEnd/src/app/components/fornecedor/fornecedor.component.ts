import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Fornecedor } from 'src/app/models/Fornecedor';
import { FornecedorService } from 'src/app/services/fornecedor.service';

@Component({
  selector: 'app-fornecedor',
  templateUrl: './fornecedor.component.html',
  styleUrls: ['./fornecedor.component.css']
})
export class FornecedorComponent implements OnInit {

  public modalRef = {} as BsModalRef
  public fornecedores: Fornecedor[] = [];
  public fornecedoresFiltrados: Fornecedor[] = [];
  private filtroListado = '';
  public fornecedorId = 0;

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.fornecedoresFiltrados = this.filtroLista
      ? this.filtrarFornecedores(this.filtroLista)
      : this.fornecedores;
  }

  public filtrarFornecedores(filtrarPor: string): Fornecedor[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.fornecedores.filter(
      (fornecedor) =>
        fornecedor.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        fornecedor.empresa.cnpj.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        fornecedor.cpf.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        fornecedor.dataCadastro.toLocaleString().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private fornecedorService: FornecedorService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.carregarFornecedores();
  }

  public carregarFornecedores(): void {
    this.fornecedorService.obterTodos().subscribe({
      next: (fornecedores: Fornecedor[]) => {
        this.fornecedores = fornecedores;
        this.fornecedoresFiltrados = this.fornecedores;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os fornecedores.', 'Erro!');
        console.error(error);
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(fornecedor: any, template: TemplateRef<any>, fornecedorId: number): void {
    fornecedor.stopPropagation();
    this.fornecedorId = fornecedorId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();

    this.fornecedorService
      .remover(this.fornecedorId)
      .subscribe(
        { next: () => {
            this.toastr.success('Fornecedor(a) removido com sucesso!', 'Sucesso!');
            this.carregarFornecedores()
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao remover o fornecedor(a).', 'Erro!');
            console.error(error);
          },
          complete: () => this.spinner.hide(),
        });
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheFornecedor(id: number): void {
    this.router.navigate([`cadastrarFornecedor/detalhe/${id}`]);
  }
}
