import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Produto } from './models/produto.model';
import { ProdutosService } from './services/produtos';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  // Lista que vai guardar todos os produtos carregados da API
  produtos: Produto[] = [];

  // Objeto para controlar o formulário de criação/edição
  produtoForm = { id: 0, nome: '', preco: 0 };

  // Variáveis para a funcionalidade de busca por ID
  idBusca: number | null = null;
  produtoEncontrado: Produto | null = null;

  constructor(private produtosService: ProdutosService) {}

  ngOnInit(): void {
    // Carrega a lista de produtos assim que o componente é iniciado
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.produtosService.listarTodos().subscribe({
      next: (dados) => this.produtos = dados,
      error: (erro) => console.error('Erro ao carregar produtos', erro)
    });
  }

  buscarProduto(): void {
    if (this.idBusca) {
      this.produtosService.buscarPorId(this.idBusca).subscribe({
        next: (dados) => this.produtoEncontrado = dados,
        error: (erro) => {
          console.error('Produto não encontrado', erro);
          this.produtoEncontrado = null;
          alert('Produto não encontrado!');
        }
      });
    }
  }

  adicionarOuAtualizar(): void {
    if (this.produtoForm.id === 0) {
      // Se o ID for 0, é um produto novo (POST)
      const novoProduto = { nome: this.produtoForm.nome, preco: this.produtoForm.preco };
      this.produtosService.criar(novoProduto).subscribe({
        next: () => {
          this.carregarProdutos(); // Recarrega a tabela
          this.limparFormulario(); // Limpa os campos
        },
        error: (erro) => console.error('Erro ao criar', erro)
      });
    } else {
      // Se já tem ID, estamos a editar um produto existente (PUT)
      const produtoAtualizado = { nome: this.produtoForm.nome, preco: this.produtoForm.preco };
      this.produtosService.atualizar(this.produtoForm.id, produtoAtualizado).subscribe({
        next: () => {
          this.carregarProdutos();
          this.limparFormulario();
        },
        error: (erro) => console.error('Erro ao atualizar', erro)
      });
    }
  }

  editar(produto: Produto): void {
    // Copia os dados do produto clicado na tabela para o formulário
    this.produtoForm = { ...produto };
  }

  remover(id: number): void {
    this.produtosService.remover(id).subscribe({
      next: () => this.carregarProdutos(),
      error: (erro) => console.error('Erro ao remover', erro)
    });
  }

  limparFormulario(): void {
    this.produtoForm = { id: 0, nome: '', preco: 0 };
  }
}