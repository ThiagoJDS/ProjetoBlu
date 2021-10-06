import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarEmpresaComponent } from './components/cadastrarEmpresa/cadastrarEmpresa.component';
import { CadastrarFornecedorComponent } from './components/cadastrarFornecedor/cadastrarFornecedor.component';
import { CadastrarTelefoneComponent } from './components/cadastrarTelefone/cadastrarTelefone.component';
import { EmpresaComponent } from './components/empresa/empresa.component';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';
import { PrincipalComponent } from './components/principal/principal.component';
import { TelefoneComponent } from './components/telefone/telefone.component';

const routes: Routes = [
  { path: 'principal', component: PrincipalComponent },
  { path: 'empresa', component: EmpresaComponent },
  { path: 'fornecedor', component: FornecedorComponent},
  { path: 'telefone', component: TelefoneComponent},
  { path: 'cadastrarEmpresa/detalhe/:id', component: CadastrarEmpresaComponent},
  { path: 'cadastrarEmpresa', component: CadastrarEmpresaComponent},
  { path: 'cadastrarFornecedor/detalhe/:id', component: CadastrarFornecedorComponent},
  { path: 'cadastrarFornecedor', component: CadastrarFornecedorComponent},
  { path: 'cadastrarTelefone/detalhe/:id', component: CadastrarTelefoneComponent},
  { path: 'cadastrarTelefone', component: CadastrarTelefoneComponent},
  { path: '', redirectTo: 'principal', pathMatch: 'full' },
  { path: '**', redirectTo: 'principal', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
