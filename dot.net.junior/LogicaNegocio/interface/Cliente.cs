using Model.Entidades;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public interface ICliente : IDisposable
    {
        Cliente Inserir(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        List<Cliente> Listar();
        Cliente Consultar(int idCliente);

    }
}
