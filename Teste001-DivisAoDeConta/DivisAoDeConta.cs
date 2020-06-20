using System;
using System.Collections.Generic;

namespace Teste001_DivisAoDeConta
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Produto(string nome, string valor)
        {
            Nome = nome;
            Valor = Convert.ToDouble(valor);
        }
        // para testes de print em tela
        public override string ToString()
        {
            return $"Os Produtos consumidos são: {Nome} no valor de: {Valor}R$";
        }
    }
    class DivisAoDeConta
    {

        public static string processinput(string input)
        {
            Console.WriteLine();

            return input;
        }


        static void Main(string[] args)
        {
            int clientesMesa = 0, itensConsumidos = 0;
            string produtoNomeValor;
            List<Produto> listaProdutos = new List<Produto>(); // lista de objetos do tipo "Produtos"
            string itensDesconsiderar;
            double total = 0, parcela = 0, totalDesconsiderados = 0;


            Console.WriteLine("Digite quantos clientes tem na mesa:");
            // Clientes na mesa:
            clientesMesa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite quantos itens foram consumidos:");
            // Total de itens consumidos
            itensConsumidos = Convert.ToInt32(Console.ReadLine());

            // dinamicos (nome + valor do item)
            for (int i = 0; i < itensConsumidos; i++)
            {
                // primeiro é: ALT + 167 = º
                Console.WriteLine($"Digite o {i + 1}º item e seu valor:");
                produtoNomeValor = Console.ReadLine();
                string[] produtoSplit = produtoNomeValor.Split(' ');
                listaProdutos.Add(new Produto(produtoSplit[0], produtoSplit[1]));
                total += listaProdutos[i].Valor; // total

            }
            // exclusão da divisao:
            Console.WriteLine("Digite os itens separados por espaço:");
            itensDesconsiderar = Console.ReadLine();
            string[] itens = itensDesconsiderar.Split(' ');

            Console.WriteLine("Os itens desconsiderados são: ");
            for (int i = 0; i < itens.Length; i++)
            {
                for (int n = 0; n < listaProdutos.Count; n++)
                {
                    if (listaProdutos[n].Nome == itens[i])
                    {
                        totalDesconsiderados += listaProdutos[n].Valor;
                    }
                }
                Console.WriteLine(itens[i]);
            }
            //
            parcela = (total - totalDesconsiderados) / clientesMesa;
            //
            // condição de divisão
            //

            // Soma todos os valores
            Console.WriteLine($"O total da conta é de: {total}R$.");

            // valor para cada cliente
            Console.WriteLine($"O total para Cada cliente é de: {parcela}R$.");

            // valor não dividito
            Console.WriteLine($"O total não dividido é de: {totalDesconsiderados}R$.");



            Console.WriteLine($"Total na mesa: {clientesMesa}, Total Itens: {itensConsumidos}");
            // exibir todos os itens da lista
            foreach (var item in listaProdutos/*.OrderBy(person => person.Age)*/) Console.WriteLine(item); // print de lista de objeto (precisa de return para funcionar)

        }


        /*
         * vai inserir 2 linhas int
         * depois vai inserir as linhas string sem tamanho definido separado o INT com 1 *espaço*
         * na ultima linha so vai existir string após os *espaços*
         */

    }
}
