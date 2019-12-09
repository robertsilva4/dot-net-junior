using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using Model.Infraestrutura.AcessoEntidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace site.teste.logico
{
    [TestClass]
    public class ClientAcessTest
    {
        [TestMethod]
        public void Select()
        {
            using (var dao = new ClienteAcess())
            {
                var cliente = dao.Select();
            }
        }

        [TestMethod]
        public void SelectbyId()
        {
            using (var dao = new ClienteAcess())
            {
                var clientes = dao.Select();
            }
        }

        [TestMethod]
        public void SelectByCliente()
        {
            using (var dao = new TelefoneAcess())
            {
                //var produtos = dao.SelectByCategoria(1);
            }
        }
    }
}
