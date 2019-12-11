using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicaNegocio;
using System.Net.Http;
using Model.Entidades;

namespace Site.Controllers
{
    public class BaseControllers<TIBLInjected> : WebController
    {
        protected TIBLInjected BLInjected;

        public BaseControllers(TIBLInjected BLInjectable)
        {
            this.BLInjected = BLInjectable;
        }

        protected Cliente Cliente { get; private set; }

        public void SetCliente(Cliente cliente)
        {
            this.Cliente = cliente;
        }
    }
}