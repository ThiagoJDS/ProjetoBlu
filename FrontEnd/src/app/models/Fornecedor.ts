import { Empresa } from "./Empresa";
import { Telefone } from "./Telefone";

export interface Fornecedor {
  id: number;
  empresaId: number;
  empresa: Empresa;
  nome: string;
  cpf: string;
  cnpjId: number;
  cnpj: Empresa;
  idade: number;
  rg: string;
  dataNascimento: Date;
  dataCadastro: Date;
  telefoneId: number;
  telefone: Telefone;
  email: string;
}
