                                                        Destaques do Projeto
							                            ====================

1 - Separação MVC:

 - Model: Regras de negócio, cálculos (CalcularTotal) e gerenciamento de estruturas fixas (arrays de tamanho 10 e 50).

 - View: Responsável única e exclusivamente por capturar as entradas do console e apresentar mensagens e relatórios formatados para o usuário.

 - Controller: Faz o meio-campo entre o usuário e a lógica, direcionando os dados do View para as operações no Model.

2 - Auto-incremento Sequencial: A propriedade proxPedido na classe Restaurante garante que o Id de cada pedido seja gerado automaticamente de forma sequencial (1, 2, 3...), conforme solicitado.

3 - Gerenciamento sem listas dinâmicas (List<T>): Conforme especificado pelo diagrama (Item[10] e Pedido[50]), foram utilizados arrays de tamanho fixo com controle rigoroso de posições nulas para adição e remoção.
