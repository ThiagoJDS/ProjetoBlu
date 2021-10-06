import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Telefone } from 'src/app/models/Telefone';
import { TelefoneService } from 'src/app/services/telefone.service';

@Component({
  selector: 'app-cadastrarTelefone',
  templateUrl: './cadastrarTelefone.component.html',
  styleUrls: ['./cadastrarTelefone.component.css']
})
export class CadastrarTelefoneComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public telefone = {} as Telefone;
  public form = {} as FormGroup;
  public estadoSalvar = 'post';
  public telefoneId = {} as number;

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private telefoneService: TelefoneService,
    private activatedRouter: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.carregarTelefones();
    this.validation();
  }

  public carregarTelefones(): void {

    this.telefoneId = +this.activatedRouter.snapshot.paramMap.get('id');

    if (this.telefoneId !== null && this.telefoneId !== 0) {
      this.spinner.show();

      this.estadoSalvar = 'put';

      this.telefoneService
        .obterPeloId(this.telefoneId)
        .subscribe(
          { next: (telefones: Telefone ) => {
            this.telefone = { ...telefones };
            this.form.patchValue(this.telefone);
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao carregar o telefone.', 'Erro!');
          console.error(error);
        },
        complete: () => this.spinner.hide(),
      });
    }
  }

  public validation(): void {
    this.form = this.fb.group({
      numeroTelefone: ['', Validators.required],
      nome: ['', Validators.required],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public salvarTelefone(): void {
    this.spinner.show();
    if (this.estadoSalvar === 'post') {
      this.telefone = {... this.form.value};
      this.resetForm();
      this.telefoneService.salvar(this.telefone).subscribe(
        () => this.toastr.success('Telefone salvo com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao salvar telefone', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
    else{
      this.telefone = {id: this.telefone.id, ... this.form.value};
      this.telefoneService.editar(this.telefone).subscribe(
        () => this.toastr.success('Telefone Alterado com sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao alterar telefone', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
  }
}
