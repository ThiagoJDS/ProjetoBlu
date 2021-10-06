import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Empresa } from 'src/app/models/Empresa';
import { EmpresaService } from 'src/app/services/empresa.service';


@Component({
  selector: 'app-cadastrarEmpresa',
  templateUrl: './cadastrarEmpresa.component.html',
  styleUrls: ['./cadastrarEmpresa.component.css']
})
export class CadastrarEmpresaComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public empresa = {} as Empresa;
  public form = {} as FormGroup;
  public estadoSalvar = 'post';
  public empresaId = {} as number;

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private empresaService: EmpresaService,
    private activatedRouter: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.carregarEmpresas();
    this.validation();
  }

  public carregarEmpresas(): void {

    this.empresaId = +this.activatedRouter.snapshot.paramMap.get('id');

    if (this.empresaId !== null && this.empresaId !== 0) {
      this.spinner.show();

      this.estadoSalvar = 'put';

      this.empresaService
        .obterPeloId(this.empresaId)
        .subscribe(
          { next: (empresas: Empresa ) => {
            this.empresa = { ...empresas };
            this.form.patchValue(this.empresa);
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao carregar a empresa.', 'Erro!');
          console.error(error);
        },
        complete: () => this.spinner.hide(),
      });
    }
  }

  public validation(): void {
    this.form = this.fb.group({
      unidadeFederacao: ['',[
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
      ],
      nome: ['', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(70),
      ]],
      cnpj: ['', Validators.required],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public salvarEmpresa(): void {
    this.spinner.show();
    if (this.estadoSalvar === 'post') {
      this.empresa = {... this.form.value};
      this.resetForm();
      this.empresaService.salvar(this.empresa).subscribe(
        () => this.toastr.success('Empresa salvo com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao salvar empresa', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
    else{
      this.empresa = {id: this.empresa.id, ... this.form.value};
      this.empresaService.editar(this.empresa).subscribe(
        () => this.toastr.success('Empresa Alterado com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao alterar empresa', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
  }
}
