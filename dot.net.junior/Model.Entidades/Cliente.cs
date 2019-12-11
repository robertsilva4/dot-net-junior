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
        public string cpfCnpj { get; set; }
        public string rua { get; set; }
        public string numero{ get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string tipocasa { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public string tipotelefone { get; set; }
    }
}
