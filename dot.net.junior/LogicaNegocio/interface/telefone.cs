using System;
using Model.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface ITelefone : IDisposable
    {
        Telefone Inserir(Telefone telefone);
        Telefone Atualizar(Telefone telefone);
        List<Telefone> Listar();
        Telefone consultar(Telefone idTelefone);
    }
}