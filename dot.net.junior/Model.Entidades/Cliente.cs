using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Cliente
    {
        public int id { get; set;}
        public string nome { get; set; }
        public Int32 cpfCnpj { get; set; }
        public Int32 endereco { get; set; }
        public Int32 telefone { get; set; }
    }
}
