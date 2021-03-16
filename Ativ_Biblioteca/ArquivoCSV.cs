using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Biblioteca
{
    class ArquivoCSV
    {
        public static Cliente Clientes { get; set; }
        public static Livros Livro { get; set; }
        public static Empre_livro Emprestimo { get; set; }
      

        public static void SalvaCliente(List<Cliente> cliente)
        {

            using (StreamWriter SalvaClienteArq = new StreamWriter("Cliente.CSV"))
            {

                foreach (Cliente InfoCli in cliente)
                {

                    SalvaClienteArq.WriteLine(InfoCli.IdCliente + ";" +
                                              InfoCli.CPF + ";" +
                                              InfoCli.Nome + ";" +
                                              InfoCli.Telefone + ";" +
                                              InfoCli.DataNasc + ";" +
                                              InfoCli.Endereco.Logradouro + ";" +
                                              InfoCli.Endereco.CEP + ";" +
                                              InfoCli.Endereco.Bairro + ";" +
                                              InfoCli.Endereco.Cidade + ";" +
                                              InfoCli.Endereco.Estado + ";");
                }

            }
        }

        public static void LerCliente(List<Cliente> cliente)
        {
            if (File.Exists("Cliente.CSV"))
            {

                using (StreamReader lerCli = new StreamReader("Cliente.CSV"))
                {

                    while (!lerCli.EndOfStream)
                    {
                        string[] InfoCli = lerCli.ReadLine().Split(';');
                         Clientes = new Cliente
                        {
                            IdCliente = long.Parse(InfoCli[0]),
                            CPF = InfoCli[1],
                            Nome = InfoCli[2],
                            DataNasc = DateTime.Parse(InfoCli[3]),
                            Telefone = InfoCli[4],

                            Endereco = new Endereco_cli
                            {
                                Logradouro = InfoCli[5],
                                Bairro = InfoCli[6],
                                CEP = InfoCli[7],
                                Cidade = InfoCli[8],
                                Estado = InfoCli[9],
                            }
                        };
                        cliente.Add(Clientes);
                    }
                }
            } 
        }

        public static void SalvaLivro(List<Livros> livros)
        {
            using (StreamWriter SalvaLivroArq = new StreamWriter("Livro.CSV"))
            {

                foreach (Livros InfoLivros in livros)
                {

                    SalvaLivroArq.WriteLine(InfoLivros.NumeroTombo + ";" +
                                            InfoLivros.ISBN + ";" +
                                            InfoLivros.Titulo + ";" +
                                            InfoLivros.Genero + ";" +
                                            InfoLivros.Autor + ";" +
                                            InfoLivros.DataPuplicacao + ";");
                }

            }


        }

        public static void LerLivro(List<Livros> livros)
        {

            if (File.Exists("Livro.CSV"))
            {
                using (StreamReader lerLivro = new StreamReader("Livro.CSV"))
                {

                    while (!lerLivro.EndOfStream)
                    {
                        string[] InfoLivro = lerLivro.ReadLine().Split(';');
                        Livro = new Livros
                        {
                            NumeroTombo = long.Parse(InfoLivro[0]),
                            ISBN = InfoLivro[1],
                            Titulo = InfoLivro[2],
                            Genero = InfoLivro[3],
                            Autor = InfoLivro[4],
                            DataPuplicacao = DateTime.Parse(InfoLivro[5])

                        };
                        livros.Add(Livro);
                    }
                }

            }


        }

        public static void SalvaEmprestimo(List<Empre_livro> ListEmpre)
        {

            using (StreamWriter SalvaEmpreArq = new StreamWriter("Emprestimo.CSV"))
            {

                foreach (Empre_livro InfoEmpre in ListEmpre)
                {

                    SalvaEmpreArq.WriteLine(InfoEmpre.IdCliente + ";" +
                                            InfoEmpre.NumeroTombo + ";" +
                                            
                                            InfoEmpre.DataEmprestimo.ToString("dd/MM/yyyy") + ";" +
                                            InfoEmpre.DataDevolucao.ToString("dd/MM/yyyy") + ";" +
                                            InfoEmpre.StatusEmprestimo + ";");
                                            
                }

            }

        }

        public static void VerEmprestimo(List<Empre_livro> empre_Livros)
        {
            if (File.Exists("Emprestimo.CSV"))
            {
                using (StreamReader verEmprestimo = new StreamReader("Emprestimo.CSV"))
                {

                    while (!verEmprestimo.EndOfStream)
                    {
                        string[] InfoEmpre = verEmprestimo.ReadLine().Split(';');
                        Emprestimo = new Empre_livro
                        {
                            IdCliente = long.Parse(InfoEmpre[0]),
                            NumeroTombo = long.Parse(InfoEmpre[1]),
                            DataEmprestimo = DateTime.Parse(InfoEmpre[2]),
                            DataDevolucao = DateTime.Parse(InfoEmpre[3]),
                            StatusEmprestimo = int.Parse(InfoEmpre[4]),
                        };

                        empre_Livros.Add(Emprestimo);
                    }
                }
            }
            

            

        }

        public static void SalvaRelatorio(List<Empre_livro> empreLivro, List<Livros> livro, List<Cliente> cliente)
        {

            using (StreamWriter salvaRelatorio = new StreamWriter("Relatorio.CSV"))
            {
                foreach (Empre_livro InfoEmprestimo in empreLivro)
                {
                    foreach (Cliente itemCliente in cliente)
                    {
                        if (itemCliente.IdCliente == InfoEmprestimo.IdCliente)
                        {
                            salvaRelatorio.Write(itemCliente.CPF + ";");
                        }
                    }

                    foreach (Livros InfoLivro in livro)
                    {
                        if (InfoLivro.NumeroTombo == InfoEmprestimo.NumeroTombo)
                        {
                            salvaRelatorio.Write(InfoLivro.Titulo + ";");
                        }
                    }

                    salvaRelatorio.WriteLine(InfoEmprestimo.StatusEmprestimo + ";" +
                                           InfoEmprestimo.DataEmprestimo.ToString("dd/MM/yyyy") + ";" +
                                           InfoEmprestimo.DataDevolucao.ToString("dd/MM/yyyy") + ";");
                }

            }
        }

        public static void VerRelatorio()
        {

            if (File.Exists("Emprestimo.CSV"))
            {
                using (StreamReader verRelatorio = new StreamReader("Relatorio.CSV"))
            

                while (!verRelatorio.EndOfStream)
                {
                    string[] InfoEmpre = verRelatorio.ReadLine().Split(';');

                    Console.WriteLine(
                        "CPF Cliente" + InfoEmpre[0],
                        "Título Livro" + InfoEmpre[1],
                        "Status Emprestimo" + InfoEmpre[2],
                        "Data Emprestimo" + InfoEmpre[4],
                        "Data Devolução" + InfoEmpre[3]);
                }
            }
        }
    }
}
