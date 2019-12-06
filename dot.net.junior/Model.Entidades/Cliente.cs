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
        public int cpfCnpj { get; set; }
        public int endereco { get; set; }
        public int telefone { get; set; }
    }
}
