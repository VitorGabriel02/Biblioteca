using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Biblioteca
{
    class Endereco_cli
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public override string ToString()
        {
            return ">>>>ENDEREÇO<<<<\nLogradouro:" + Logradouro + "\nBairro:" + Bairro + "\nCEP:" + CEP + "\nCidade:" + Cidade  + "\nEstado:" + Estado; 
        }


    }
}
