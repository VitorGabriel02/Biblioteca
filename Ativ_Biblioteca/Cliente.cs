using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Biblioteca
{
    class Cliente
    {
        public long IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public Endereco_cli Endereco { get; set; }


        public override string ToString()
        {
            return ">>>>CLIENTE:<<<<\nIdCliente:" + IdCliente + "\nCPF:" + CPF + "\nNome:" + Nome + "\nTelefone:" + Telefone + "Data de Nascimento:" + DataNasc + "Endereço:" + Endereco;
        }


    }
}
