using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Biblioteca
{
    class Empre_livro
    {
        public long IdCliente { get; set; }
        public long NumeroTombo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public int StatusEmprestimo { get; set; }



        public override string ToString()
        {
            return ">>>>EMPRESTIMO<<<<\nId Ciente:" + IdCliente + "\nNumero de Tombo:" + NumeroTombo + "\nData de Emprestimo:" + DataEmprestimo + "\nData de Devolução:" + DataDevolucao;
        }
    }        

}
