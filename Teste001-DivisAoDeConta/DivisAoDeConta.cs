using System;
using System.Collections.Generic;

namespace Teste001_DivisAoDeConta
{
    public class Produto // Obj 
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Produto(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
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
            string produtoNomeValor;
            List<Produto> listaProdutos = new List<Produto>(); // lista de objetos do tipo "Produtos"
            string itensDesconsiderar, temp;
            double total = 0, totalDesconsiderados = 0;

            // Clientes na mesa:
            do
            {

                Console.WriteLine("Digite quantos clientes tem na mesa:");
                temp = Console.ReadLine();
            } while (!NumeroChek(temp,0));
            int clientesMesa = Convert.ToInt32(temp);

            // Total de itens consumidos
            do
            {
                Console.WriteLine("Digite quantos itens foram consumidos:");
                temp = Console.ReadLine();
            } while (!NumeroChek(temp));
            int itensConsumidos = Convert.ToInt32(temp);

            // dinamicos (nome + valor do item)
            for (int i = 0; i < itensConsumidos; i++)
            {
                // primeiro é: ALT + 167 = º
                Console.WriteLine($"Digite o {i + 1}º item e seu valor:");
                do
                {
                    produtoNomeValor = Console.ReadLine();

                } while (!SpaceChek(produtoNomeValor));
                
                string[] produtoSplit = produtoNomeValor.Split(' ');
                if (produtoSplit.Length>1)
                {
                    if (NumeroChek(produtoSplit[1]))
                    {
                        produtoSplit[1] = produtoSplit[1].Replace(".",","); // converter pontuação
                        listaProdutos.Add(new Produto(produtoSplit[0], Convert.ToDouble(produtoSplit[1])));
                        total += listaProdutos[i].Valor; // total
                    }
                    else
                    {
                        Console.WriteLine($"Nome ou valor invalido para o {i + 1}º item, digite o nome e o valor separados apenas por 1 unico espaço:");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine($"É necessario algum valor para o {i + 1}º item, digite o valor separados apenas por 1 unico espaço:");
                    i--;
                }

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
            double parcela = (total - totalDesconsiderados) / clientesMesa;
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
        private static Boolean SpaceChek(string produtos)
        {
            int Primeiro = produtos.IndexOf(' ');
            int Ultimo = produtos.LastIndexOf(' ');
            if (Primeiro == Ultimo)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Digite o nome do Produto sem espaços e o valor após 1 o espaço.");
                return false;
            }
        }
        private static Boolean NumeroChek(string numero)
        {
            double x = 0;
            if (double.TryParse(numero, out x))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Digite apenas Numeros.");
                return false;
            }
        }
        private static Boolean NumeroChek(string numero, int zero)
        {
            double x = 0;
            if (double.TryParse(numero, out x))
            {
                if (Convert.ToDouble(numero) <= zero)
                {
                    Console.WriteLine($"Digite apenas Numeros (numeros menores que '1' não são permitidos).");
                    return false;
                }else
                    return true;
            }
            else
            {
                Console.WriteLine($"Digite apenas Numeros.");
                return false;
            }
        }

        /*
         * vai inserir 2 linhas int
         * depois vai inserir as linhas string sem tamanho definido separado o INT com 1 *espaço*
         * na ultima linha so vai existir string após os *espaços*
         */

    }
}
