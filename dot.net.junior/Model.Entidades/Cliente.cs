﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Cliente
    {
        public int idClliente { get; set;}
        public string nome { get; set; }
        public int cpf { get; set; }
        public int cnpj { get; set; }
        public int endereco { get; set; }
        public int telefone { get; set; }
    }
}
