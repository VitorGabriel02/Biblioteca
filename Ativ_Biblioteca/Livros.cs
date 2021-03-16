using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ativ_Biblioteca
{
    class Livros
    {
        public long NumeroTombo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public DateTime DataPuplicacao { get; set; }




        public override string ToString()
        {
            return "\nNumero de Tombo:" + NumeroTombo + "\nISBN:" + ISBN + "\nTítulo:" + Titulo + "\nGênero:" + Genero + "\nAutor:" + Autor + "\nData de Publicação:" + DataPuplicacao;
        }
    }
}
