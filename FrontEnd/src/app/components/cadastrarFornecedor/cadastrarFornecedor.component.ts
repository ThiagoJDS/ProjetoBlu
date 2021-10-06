import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Empresa } from 'src/app/models/Empresa';
import { Fornecedor } from 'src/app/models/Fornecedor';
import { Telefone } from 'src/app/models/Telefone';
import { EmpresaService } from 'src/app/services/empresa.service';
import { FornecedorService } from 'src/app/services/fornecedor.service';
import { TelefoneService } from 'src/app/services/telefone.service';

@Component({
  selector: 'app-cadastrarFornecedor',
  templateUrl: './cadastrarFornecedor.component.html',
  styleUrls: ['./cadastrarFornecedor.component.css']
})
export class CadastrarFornecedorComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public fornecedor = {} as Fornecedor;
  public empresas: Empresa[] = [];
  public telefones: Telefone[] = [];
  public form = {} as FormGroup;
  public estadoSalvar = 'post';
  public fornecedorId = {} as number;

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private fornecedorService: FornecedorService,
    private empresaService: EmpresaService,
    private telefoneService: TelefoneService,
    private activatedRouter: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.carregarFornecedores();
    this.carregarEmpresas();
    this.carregarTelefones();
    this.validation();
  }

  public carregarFornecedores(): void {

    this.fornecedorId = +this.activatedRouter.snapshot.paramMap.get('id');

    if (this.fornecedorId !== null && this.fornecedorId !== 0) {
      this.spinner.show();

      this.estadoSalvar = 'put';

      this.fornecedorService
        .obterPeloId(this.fornecedorId)
        .subscribe(
          { next: (fornecedores: Fornecedor ) => {
            this.fornecedor = { ...fornecedores };
            this.form.patchValue(this.fornecedor);
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao carregar o fornecedor.', 'Erro!');
          console.error(error);
        },
        complete: () => this.spinner.hide(),
      });
    }
  }

  carregarEmpresas(){
    this.empresaService.obterTodos().subscribe(
      (resultado: Empresa[]) => {
        this.empresas = resultado;
      },
      error => { this.toastr.error(`Erro ao tentar carregar as empresas: ${error}`); }
    );
  }

  carregarTelefones(){
    this.telefoneService.obterTodos().subscribe(
      (resultado: Telefone[]) => {
        this.telefones = resultado;
      },
      error => { this.toastr.error(`Erro ao tentar carregar os telefones: ${error}`); }
    );
  }

  public validation(): void {
    this.form = this.fb.group({
      empresaId: ['', Validators.required],
      nome: ['', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(70),
      ]],
      cpf: ['', Validators.required],
      cnpjId: ['', Validators.required],
      idade: ['', [Validators.required, Validators.max(100)]],
      rg: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      dataCadastro: ['', Validators.required],
      telefoneId: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public salvarFornecedor(): void {
    this.spinner.show();
    if (this.estadoSalvar === 'post') {
      this.fornecedor = {... this.form.value};
      this.resetForm();
      this.fornecedorService.salvar(this.fornecedor).subscribe(
        () => this.toastr.success('Fornecedor cadastrado com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao cadastrar fornecedor', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
    else{
      this.fornecedor = {id: this.fornecedor.id, ... this.form.value};
      this.fornecedorService.editar(this.fornecedor).subscribe(
        () => this.toastr.success('Fornecedor alterado com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao alterar fornecedor', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
  }
}
