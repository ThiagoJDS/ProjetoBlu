import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Empresa } from 'src/app/models/Empresa';
import { EmpresaService } from 'src/app/services/empresa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css']
})
export class EmpresaComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public empresas: Empresa[] = [];
  public empresasFiltrados: Empresa[] = [];
  private filtroListado = '';
  public empresaId = 0;

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.empresasFiltrados = this.filtroLista
      ? this.filtrarEmpresas(this.filtroLista)
      : this.empresas;
  }

  public filtrarEmpresas(filtrarPor: string): Empresa[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.empresas.filter(
      (empresa) =>
        empresa.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        empresa.cnpj.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private empresaService: EmpresaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.carregarEmpresas();
  }

  public carregarEmpresas(): void {
    this.empresaService.obterTodos().subscribe({
      next: (empresas: Empresa[]) => {
        this.empresas = empresas;
        this.empresasFiltrados = this.empresas;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar as empresas.', 'Erro!');
        console.error(error);
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(empresa: any, template: TemplateRef<any>, empresaId: number): void {
    empresa.stopPropagation();
    this.empresaId = empresaId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();

    this.empresaService
      .remover(this.empresaId)
      .subscribe(
        { next: () => {
            this.toastr.success('Empresa removido com sucesso!', 'Sucesso!');
            this.carregarEmpresas()
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar as empresas.', 'Erro!');
            console.error(error);
          },
          complete: () => this.spinner.hide(),
        });
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheEmpresa(id: number): void {
    this.router.navigate([`cadastrarEmpresa/detalhe/${id}`]);
  }
}
