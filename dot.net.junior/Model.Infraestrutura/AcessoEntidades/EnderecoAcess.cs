using System;
using System.Collections.Generic;
using Model.Entidades;
using System.Data.SqlClient;
using Model.Infraestrutura.Acesso_ao_banco;
using Model.Infraestrutura.Cast;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infraestrutura.AcessoEntidades
{
    public class EnderecoAcess : BaseDao<Endereco>
    {
        public EnderecoAcess() { }
        public EnderecoAcess( acesso acesso) : base( acesso) { }

        public override List<Endereco> CastToObject(SqlDataReader Reader)
        {
            List<Endereco> enderecos = new List<Endereco>();
            while (Reader.Read())
            {
                enderecos.Add(DataCast.CastEndereco(Reader));
            }
            return enderecos;
        }

        public Endereco Insert(Endereco endereco)
        {
            base.Sql.Append(" INSERT INTO TB_ENDERECO(rua, numero, bairro,cidade,cep, tipo) ");
            base.Sql.Append(" OUTPUT inserted.idEndereco ");
            base.Sql.Append(" VALUES ('@RUA', '@NUMERO','@BAIRRO','@CIDADE','@CEP','@TIPO') ");

            base.AddParameter("@RUA", endereco.rua);
            base.AddParameter("@NUMERO", endereco.numero);
            base.AddParameter("@BAIRRO", endereco.bairro);
            base.AddParameter("@CIDADE", endereco.cidade);
            base.AddParameter("@CEP", endereco.cep);
            base.AddParameter("@TIPO", endereco.tipo);


            return endereco;
        }

        public Endereco Update(Endereco endereco)
        {
            base.Sql.Append(" UPDATE TB_ENDERECO SET ");
            base.Sql.Append(" idEndereco = @ID_ENDERECO,rua = @RUA,numero = @NUMERO,bairro = @BAIRRO, cidade = @CIDADE,cep = @CEP,tipo = @TIPO) ");
            base.Sql.Append(" WHERE idEndereco = @ID_ENDERECO ");

            base.AddParameter("@RUA", endereco.rua);
            base.AddParameter("@NUMERO", endereco.numero);
            base.AddParameter("@BAIRRO", endereco.bairro);
            base.AddParameter("@CIDADE", endereco.cidade);
            base.AddParameter("@CEP", endereco.cep);
            base.AddParameter("@TIPO", endereco.tipo);

            base.ExecuteComand();

            return endereco;
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   idEndereco AS ID_ENDERECO, ");
            base.Sql.Append("   rua AS RUA, ");
            base.Sql.Append("   numero AS NUMERO,  ");
            base.Sql.Append("   bairro AS BAIRRO, ");
            base.Sql.Append("   cidade AS  CIDADE, ");
            base.Sql.Append("   cep AS CEP, ");
            base.Sql.Append("   tipo AS TIPO ");
            base.Sql.Append(" FROM TB_ENDERECO ");
        }

        public List<Endereco> Select()
        {
            this.SqlBase();
            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }
    }
}
