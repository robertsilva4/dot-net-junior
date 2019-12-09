using System;
using Model.Infraestrutura.AcessoEntidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Model.Entidades;
using LogicaNegocio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace site.teste.acesso
{
    
        [TestClass]
        public class ClienteAcessTest
    {
            [TestMethod]
            public void Inserir()
            {
                using (var bl = new ClienteLogico())
                {
                    var cliente = new Cliente()
                    {
                        nome = "robert richard",
                        cpfCnpj = 12345,
                        endereco = 1,
                        telefone = 112345

                    };

                    cliente = bl.Inserir(cliente);
                }
            }

            [TestMethod]
            public void Atualizar()
            {
                using (var bl = new ClienteLogico())
                {
                    var cliente = bl.Consultar(1);
                    cliente.nome = "robert richard";
                    bl.Atualizar(cliente);
                }
            }

            [TestMethod]
            public void Consultar()
            {
                using (var bl = new ClienteLogico())
                {
                    var cliente = bl.Consultar();
                }
            }

            [TestMethod]
            public void Listar()
            {
                using (var bl = new ClienteLogico())
                {
                    var clientes = bl.Listar();
                }
            }

            [TestMethod]
            public void Logar()
            {
                using (var bl = new ClienteLogico())
                {
                    throw new NotImplementedException();
                }
            }
        }
}
