using System;
using Model.Infraestrutura.Acesso_ao_banco;
using Model.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Model.Infraestrutura.Cast;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infraestrutura.AcessoEntidades
{
    public class ClienteAcess : BaseDao<Cliente>
    {
        public ClienteAcess() { }
        public ClienteAcess(acesso acesso) : base(acesso) { }

        public override List<Cliente> CastToObject(SqlDataReader Reader)
        {
            List<Cliente> Clientes = new List<Cliente>();
            while (Reader.Read())
            {
                Clientes.Add(DataCast.CastCliente(Reader));
            }
            return Clientes;
        }

        public Cliente Insert(Cliente cliente)
        {
            base.Sql.Append(" INSERT INTO TB_CLIENTE(nome, cpf, cnpj,endereco,telefone) ");
            base.Sql.Append(" OUTPUT inserted.idCliente ");
            base.Sql.Append(" VALUES ('@NOME', '@CPF','@CNPJ','@ENDERECO','@TELEFONE') ");

            base.AddParameter("@NOME", cliente.nome);
            base.AddParameter("@CPFCNPJ", cliente.cpfCnpj);
            base.AddParameter("@ENDERECO", cliente.endereco);
            base.AddParameter("@TELEFONE", cliente.telefone);


            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            base.Sql.Append(" UPDATE TB_CLIENTE SET ");
            base.Sql.Append("  nome = '@NOME', cpf_cnpj = '@CPFCNPJ',endereco ='@ENDERECO',telefone = '@TELEFONE' ");
            base.Sql.Append(" WHERE ID = @ID ");

            base.AddParameter("@NOME", cliente.nome);
            base.AddParameter("@CPFCNPJ", cliente.cpfCnpj);
            base.AddParameter("@ENDERECO", cliente.endereco);
            base.AddParameter("@TELEFONE", cliente.telefone);

            base.ExecuteComand();

            return cliente;
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   idCliente AS CLIENTE_ID, ");
            base.Sql.Append("   nome AS CLIENTE_NOME, ");
            base.Sql.Append("   cpf_cnpj AS CLIENTE_CPF_CNPJ,  ");
            base.Sql.Append("   cnpj AS CLIENTE_CNPJ, ");
            base.Sql.Append("   endereco AS  CLIENTE_ENDERECO, ");
            base.Sql.Append("   telefone AS CLIENTE_TELEFONE ");
            base.Sql.Append(" FROM TB_CLIENTE ");
        }

        public List<Cliente> Select()
        {
            this.SqlBase();
            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }
    }
}
