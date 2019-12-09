using System;
using Model.Infraestrutura.AcessoEntidades;
using Model.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LogicaNegocio
{
    public class ClienteLogico : ICliente
    {
        private ClienteAcess _clienteAcess;

        public ClienteLogico()
        {
            this._clienteAcess = new ClienteAcess();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return this._clienteAcess.Update(cliente);
        }


        public Cliente Consultar(int idCliente)
        {
            return this._clienteAcess.Select(idCliente);
        }

        public Cliente Inserir(Cliente cliente)
        {
            return this._clienteAcess.Insert(cliente);
        }

        public List<Cliente> Listar()
        {
            return this._clienteAcess.Select();
        }
        public void Dispose()
        {
            this._clienteAcess.Dispose();
        }

        public object Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
