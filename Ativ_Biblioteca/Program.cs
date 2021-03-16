using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Ativ_Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> listCliente = new List<Cliente>();
            List<Livros> listLivros = new List<Livros>();
            List<Empre_livro> emprestarLivro = new List<Empre_livro>();

            ArquivoCSV.LerCliente(listCliente);
            ArquivoCSV.LerLivro(listLivros);
            ArquivoCSV.VerEmprestimo(emprestarLivro);

            string op;

            do
            {
                Console.WriteLine(">>>> BEM VINDOS A BIBLIOTECA <<<<\n" +
                             "\n1- Cadastrar Cliente\n" +
                             "2- Cadastrar um Livro\n" +
                             "3- Emprestar um Livro\n" +
                             "4- Devolver um Livro\n" +
                             "5- Relatório de Empréstimos e Devoluções\n" +
                             "6- Para Sair");

                Console.Write("\n>>>> ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":

                        Console.Clear();

                        Console.WriteLine("\n>>>> NOVO CLIENTE <<<<\n");
                        listCliente = CadastroDeClientes(listCliente);
                        ArquivoCSV.SalvaCliente(listCliente);//salvar arquivo

                        break;

                    case "2":

                        Console.Clear();

                        Console.WriteLine("\n>>>> NOVO LIVRO <<<<\n");
                        listLivros = CadastroDeLivros(listLivros);
                        ArquivoCSV.SalvaLivro(listLivros);//salvar arquivo

                        break;

                    case "3":

                        Console.Clear();

                        Console.WriteLine("\n>>>> NOVO EMPRÉSTIMO <<<<\n");
                        Empre_Livro(listLivros, listCliente, emprestarLivro);

                        break;

                    case "4":

                        Console.Clear();

                        Devo_Livro(emprestarLivro);

                        break;

                    case "5":

                        Console.Clear();

                        ArquivoCSV.SalvaRelatorio(emprestarLivro, listLivros, listCliente);
                        ArquivoCSV.VerRelatorio();

                        break;

                    case "6":

                        Console.WriteLine(">>>> FINALIZANDO <<<<");
                        Console.ReadKey();
                        break;


                    default:

                        Console.WriteLine("\nDIGITE UMA OPÇÃO VÁLIDA DO MENU!!!!\n");
                        break;
                }
            } while (op != "6");

            
        }

        static List <Cliente> CadastroDeClientes(List<Cliente> ListaCliente)
        {
            string cpf, nome, telefone, logradouro, bairro, cep, cidade, estado;
            DateTime datanasc;
            

            Cliente cliente = new Cliente();

            Console.WriteLine("\n>>>> INFOS NOVOS CLIENTES <<<<\n");

            Console.Write("Digite o CPF: ");
            cpf = Console.ReadLine();



            Console.Write("Digite o Nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite a Data de Nascimento: ");
            datanasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Telefone: ");
            telefone = Console.ReadLine();

            Console.WriteLine("\n>>>> ENDEREÇO <<<<\n");

            Console.Write("Digite o Logradouro: ");
            logradouro = Console.ReadLine();

            Console.Write("Digite o Bairro: ");
            bairro = Console.ReadLine();

            Console.Write("Digite o CEP: ");
            cep = Console.ReadLine();

            Console.Write("Digite a Cidade: ");
            cidade = Console.ReadLine();

            Console.Write("Digite o Estado: ");
            estado = Console.ReadLine();

            cliente = new Cliente
            {
                CPF = cpf,
                Nome = nome,
                DataNasc = datanasc,
                Telefone = telefone,
                Endereco = new Endereco_cli
                {
                    Logradouro = logradouro,
                    Bairro = bairro,
                    CEP = cep,
                    Cidade = cidade,
                    Estado = estado,
                }

            };

            ListaCliente.Add(cliente);
            Console.Clear();
            Console.WriteLine("\nCliente Cadastrado!\n");
            

            return ListaCliente;

        }

        static List <Livros> CadastroDeLivros(List<Livros> ListaLivrosCad)
        {
            Livros livro = new Livros();

            string isbn, titulo, genero, autor;
            DateTime datapubli;

            Console.Write("Digite o ISBN do Livro: ");
            isbn = Console.ReadLine();

            Console.Write("Digite o Título do Livro: ");
            titulo = Console.ReadLine();

            Console.Write("Digite o Gênero do Livro: ");
            genero = Console.ReadLine();

            Console.Write("Digite o Autor do Livro: ");
            autor = Console.ReadLine();

            Console.Write("Digite a Data de Publicação: ");
            datapubli = DateTime.Parse(Console.ReadLine());


            livro = new Livros
            {

                NumeroTombo = ListaLivrosCad.Count()+1,
                ISBN = isbn,
                Titulo = titulo,
                Genero = genero,
                Autor = autor,
                DataPuplicacao = datapubli,
            };

            ListaLivrosCad.Add(livro);
            Console.Write("\nO Número de Tombo é: " + livro.NumeroTombo);
            Console.WriteLine("\nLivro Cadastrado!\n");
           

            return ListaLivrosCad;

        }

        static void Empre_Livro(List<Livros>livro, List<Cliente>cliente, List<Empre_livro>emprelivro)
        {

            Cliente achaCliente = new Cliente();
            Livros achaLivro = new Livros();
            Empre_livro livroEmpre = new Empre_livro();

            long numTombo, Id;
            int cont = 0;
            string  cpf;
            DateTime dataDevo;

            if(livro.Count == 0)
            {
                Console.WriteLine("\n Lista de Livros Vazia\nCadastre Um Livro Antes");
            }
            else
            {
                Console.WriteLine("Digite o Numero de Tombo do Livro: ");
                numTombo = long.Parse(Console.ReadLine());

                Console.WriteLine("\nLivro Encontrado No Sistema\n" + achaLivro);
                achaLivro = livro.Find(al => al.NumeroTombo == numTombo);

                if (achaLivro == null)
                {
                    Console.WriteLine("Livro não Encontrado: \n");

                }
                else
                {
                    Console.WriteLine("Livro Localizado\n" + achaLivro.ToString());
                    livroEmpre = emprelivro.Find(le => le.NumeroTombo == numTombo);

                    if (livroEmpre != null && livroEmpre.StatusEmprestimo == 1)//verifica disponibilidade do livro para emprestimo
                    {
                        Console.WriteLine("\nLivro Indispinível (Livro Emprestado Para Outro Cliente No Momento)\n");
                        cont++;
                    }
                    else if (cont == 0)
                    {
                        Console.WriteLine("Digiteo CPF do Cliente Para Emprestar um Livro: ");//acha cliente/ou nao
                        cpf = Console.ReadLine();

                        achaCliente = cliente.Find(ac => ac.CPF == cpf);

                        if(achaCliente == null)
                        {
                            Console.WriteLine("Cliente Não Cadastrado!!!!\n");
                            CadastroDeClientes(cliente);
                        }
                        Console.WriteLine("\nDigite o Id Do Cliente: \n");
                        Id = long.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a Data de Devolução do Livro: ");
                        dataDevo = DateTime.Parse(Console.ReadLine());

                        livroEmpre = new Empre_livro
                        {

                            IdCliente = Id,
                            DataEmprestimo = DateTime.Now,
                            DataDevolucao = dataDevo,
                            NumeroTombo = numTombo,
                            StatusEmprestimo = 1
                        };
                        emprelivro.Add(livroEmpre);
                        ArquivoCSV.SalvaEmprestimo(emprelivro);
                        Console.WriteLine("Livro Emprestado\n");

                    }
                }
            }

        }

        static void Devo_Livro(List<Empre_livro>livroEmpreDev)
        {
            long NumTombo;
            string resp;
            int deve = 0;

            Empre_livro achou;

            if (livroEmpreDev.Count == 0)
            {
                Console.WriteLine("\nNenhum Livro Emprestado Ainda\n");
            }
            else
            {
                Console.WriteLine("Digite o Numero de Tombo do Livro que Deseja Devolver: ");
                NumTombo = long.Parse(Console.ReadLine());

                achou = livroEmpreDev.Find(ldev => ldev.NumeroTombo == NumTombo);
                Console.WriteLine(achou.ToString());

                Console.WriteLine("Devolver Livro? (S) ou (N)");
                resp = Console.ReadLine();

                if (resp.ToUpper() == "S")
                {
                    deve = (int)DateTime.Now.Subtract(achou.DataDevolucao).TotalDays;

                    if (deve > 0)
                    {
                        Console.WriteLine("A Multa Por Atraso Eh: R$" + deve * 0.10);
                    }
                    achou.StatusEmprestimo = 2;

                    ArquivoCSV.SalvaEmprestimo(livroEmpreDev);

                    Console.WriteLine("Livro Devolvido\n");

                    Console.Clear();
                }
            }

        }
    }
}
