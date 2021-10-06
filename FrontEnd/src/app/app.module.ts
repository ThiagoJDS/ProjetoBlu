import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { NavComponent } from './shared/nav/nav.component';
import { PrincipalComponent } from './components/principal/principal.component';
import { EmpresaComponent } from './components/empresa/empresa.component';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';
import { EmpresaService } from './services/empresa.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FornecedorService } from './services/fornecedor.service';
import { NgxMaskModule } from 'ngx-mask';
import { CpfPipe } from './helpers/cpf.pipe';
import { CnpjPipe } from './helpers/cnpj.pipe';
import { TelefonePipe } from './helpers/telefone.pipe';
import { RgPipe } from './helpers/rg.pipe';
import { CadastrarEmpresaComponent } from './components/cadastrarEmpresa/cadastrarEmpresa.component';
import { CadastrarFornecedorComponent } from './components/cadastrarFornecedor/cadastrarFornecedor.component';
import { TelefoneService } from './services/telefone.service';
import { TelefoneComponent } from './components/telefone/telefone.component';
import { CadastrarTelefoneComponent } from './components/cadastrarTelefone/cadastrarTelefone.component';

@NgModule({
  declarations: [
    AppComponent,
    TituloComponent,
    NavComponent,
    PrincipalComponent,
    EmpresaComponent,
    FornecedorComponent,
    CadastrarEmpresaComponent,
    CadastrarFornecedorComponent,
    TelefoneComponent,
    CadastrarTelefoneComponent,
    CpfPipe,
    CnpjPipe,
    TelefonePipe,
    RgPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    NgxMaskModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule,
    FormsModule
  ],
  providers: [
    EmpresaService,
    FornecedorService,
    TelefoneService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
