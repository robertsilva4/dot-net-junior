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
                        id = '1',
                        nome = "ro",
                        cpfCnpj = "1",
                        rua = "r",
                        numero = "1",
                        bairro = "s",
                        cidade = "s",
                        cep = "1",
                        tipocasa = "r",
                        ddd = "1",
                        telefone = "13",
                        tipotelefone = "r"

                    };

                    cliente = bl.Inserir(cliente);
                }
            }

        }
}
