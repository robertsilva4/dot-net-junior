using Model.Entidades;
using Model.Infraestrutura.Acesso_ao_banco;
using Model.Infraestrutura.Cast;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Infraestrutura.AcessoEntidades
{
    public class TelefoneAcess : BaseDao<Telefone>
    {
        public TelefoneAcess() { }
        public TelefoneAcess(acesso acesso) : base(acesso) { }

        public override List<Telefone> CastToObject(SqlDataReader Reader)
        {
            List<Telefone> telefones = new List<Telefone>();
            while (Reader.Read())
            {
                telefones.Add(DataCast.CastTelefone(Reader));
            }
            return telefones;
        }

        public Telefone Insert(Telefone telefone)
        {
            base.Sql.Append(" INSERT INTO TB_TELEFONE(ddd, numero, tipo) ");
            base.Sql.Append(" VALUES ('@DDD', '@NUMERO','@TIPO') ");

            base.AddParameter("@DDD", telefone.ddd);
            base.AddParameter("@NUMERO", telefone.telefone);
            base.AddParameter("@TIPO", telefone.tipo);

            return telefone;
        }

        public Telefone Update(Telefone telefone)
        {
            base.Sql.Append(" UPDATE TB_TELEFONE SET ");
            base.Sql.Append(" ddd = @DDD,numero = @NUMERO,tipo = @TIPO) ");
            base.Sql.Append(" WHERE numero = @NUMERO ");

            base.AddParameter("@DDD", telefone.ddd);
            base.AddParameter("@NUMERO", telefone.telefone);
            base.AddParameter("@TIPO", telefone.tipo);

            base.ExecuteComand();

            return telefone;
        }

        protected override void SqlBase()
        {
            base.Sql.Append(" SELECT ");
            base.Sql.Append("   ddd AS DDD, ");
            base.Sql.Append("   numero AS NUMERO,  ");
            base.Sql.Append("   tipo AS TIPO ");
            base.Sql.Append(" FROM TB_TELEFONE ");
        }

        public List<Telefone> Select()
        {
            this.SqlBase();
            using (var Reader = base.ExecuteReader())
            {
                return this.CastToObject(Reader);
            }
        }
    }
}
