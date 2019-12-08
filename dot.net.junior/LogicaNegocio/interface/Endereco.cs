using System;
using Model.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface IEndereco : IDisposable
    {
        Endereco Inserir(Endereco endereco);
        Endereco Atualizar(Endereco endereco);
        List<Endereco> Listar();
        Endereco Consultar(int idEndereco);
    }
}
