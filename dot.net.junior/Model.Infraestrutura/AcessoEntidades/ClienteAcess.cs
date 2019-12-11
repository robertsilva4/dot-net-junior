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

        public Cliente Select(int id)
        {
            this.SqlBase();

            base.Sql.Append(" WHERE CLIENTE.ID_CLIENTE = @ID_CLIENTE ");

            base.AddParameter("@ID_CLIENTE", id);

            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader).FirstOrDefault();
            }
        }

        public Cliente Insert(Cliente cliente)
        {
            base.Sql.Append(" INSERT INTO CLIENTE(NOME, CPF_CNPJ, RUA, NUMERO, BAIRRO, CIDADE, CEP, TIPO_CASA, DDD, NUM_TELEFONE, TIPO_TELEFONE) ");
            base.Sql.Append(" OUTPUT inserted.ID_CLIENTE ");
            base.Sql.Append(" VALUES ('@NOME', '@CPFCNPJ','@RUA','@NUMERO','@BAIRRO','@CIDADE', '@CEP','@TIPO_CASA','@DDD','@NUM_TELEFONE','@TIPO_TELEFONE' ) ");


            base.AddParameter("@NOME", cliente.nome);
            base.AddParameter("@CPFCNPJ", cliente.cpfCnpj);
            base.AddParameter("@RUA", cliente.rua);
            base.AddParameter("@NUMERO", cliente.numero);
            base.AddParameter("@BAIRRO", cliente.bairro);
            base.AddParameter("@CIDADE", cliente.cidade);
            base.AddParameter("@CEP", cliente.cep);
            base.AddParameter("@TIPO_CASA", cliente.tipocasa);
            base.AddParameter("@DDD", cliente.ddd);
            base.AddParameter("@NUM_TELEFONE", cliente.telefone);
            base.AddParameter("@TIPO_TELEFONE", cliente.tipotelefone);

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            base.Sql.Append(" UPDATE CLIENTE SET ");
            base.Sql.Append(" NOME = '@NOME', CPF_CNPJ = '@CPFCNPJ',RUA = '@RUA',NUMERO = '@NUMERO',BAIRRO = '@BAIRRO',CIDADE = '@CIDADE', CEP = '@CEP',TIPO_CASA = '@TIPO_CASA',DDD = '@DDD',NUM_TELEFONE = '@NUM_TELEFONE',TIPO_TELEFONE = '@TIPO_TELEFONE' ");
            base.Sql.Append(" WHERE ID_CLIENTE = @ID ");

            base.AddParameter("@ID", cliente.id);
            base.AddParameter("@NOME", cliente.nome);
            base.AddParameter("@CPFCNPJ", cliente.cpfCnpj);
            base.AddParameter("@RUA", cliente.rua);
            base.AddParameter("@NUMERO", cliente.numero);
            base.AddParameter("@BAIRRO", cliente.bairro);
            base.AddParameter("@CIDADE", cliente.cidade);
            base.AddParameter("@CEP", cliente.cep);
            base.AddParameter("@TIPO_CASA", cliente.tipocasa);
            base.AddParameter("@DDD", cliente.ddd);
            base.AddParameter("@NUM_TELEFONE", cliente.telefone);
            base.AddParameter("@TIPO_TELEFONE", cliente.tipotelefone);

            return cliente;
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   ID_CLIENTE AS CLIENTE_ID, ");
            base.Sql.Append("   NOME AS CLIENTE_NOME, ");
            base.Sql.Append("   CPF_CNPJ AS CLIENTE_CPFCNPJ, ");
            base.Sql.Append("   RUA AS  CLIENTE_RUA, ");
            base.Sql.Append("   NUMERO AS CLIENTE_NUMERO, ");
            base.Sql.Append("   BAIRRO AS CLIENTE_BAIRRO, ");
            base.Sql.Append("   CIDADE AS CLIENTE_CIDADE, ");
            base.Sql.Append("   CEP AS CLIENTE_CEP, ");
            base.Sql.Append("   TIPO_CASA AS CLIENTE_TIPO_CASA, ");
            base.Sql.Append("   DDD AS CLIENTE_DDD, ");
            base.Sql.Append("   NUM_TELEFONE AS CLIENTE_NUM_TELEFONE, ");
            base.Sql.Append("   TIPO_TELEFONE AS CLIENTE_TIPO_TELEFONE ");
            base.Sql.Append(" FROM CLIENTE ");
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
