using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infraestrutura.Cast
{
    public static class DataCast
    {
        public static Cliente CastCliente(SqlDataReader Reader) => new Cliente()
        {
            id = Convert.ToInt32(Reader["CLIENTE_ID"]),
            nome = Convert.ToString(Reader["CLIENTE_NOME"]),
            cpfCnpj = Convert.ToString(Reader["CLIENTE_CPFCNPJ"]),
            rua = Convert.ToString(Reader["CLIENTE_RUA"]),
            numero = Convert.ToString(Reader["CLIENTE_NUMERO"]),
            bairro = Convert.ToString(Reader["CLIENTE_BAIRRO"]),
            cidade = Convert.ToString(Reader["CLIENTE_CIDADE"]),
            cep = Convert.ToString(Reader["CLIENTE_CEP"]),
            tipocasa = Convert.ToString(Reader["CLIENTE_TIPO_CASA"]),
            ddd = Convert.ToString(Reader["CLIENTE_DDD"]),
            telefone = Convert.ToString(Reader["CLIENTE_NUM_TELEFONE"]),
            tipotelefone = Convert.ToString(Reader["CLIENTE_TIPO_TELEFONE"]),

        };

        public static Endereco CastEndereco(SqlDataReader Reader)
        {
            return new Endereco()
            {
                idEndereco = Convert.ToInt32(Reader["idEndereco"]),
                rua = Convert.ToString(Reader["rua"]),
                numero = Convert.ToInt32(Reader["numero"]),
                bairro = Convert.ToString(Reader["bairro"]),
                cidade = Convert.ToString(Reader["cidade"]),
                cep = Convert.ToInt32(Reader["cep"]),
                tipo = Convert.ToString(Reader["tipo"])
            };
        }

        public static Telefone CastTelefone(SqlDataReader Reader) 
        {
            return new Telefone()
            {
                ddd = Convert.ToInt32(Reader["ddd"]),
                telefone = Convert.ToInt32(Reader["numero"]),
                tipo = Convert.ToString(Reader["tipo"])
            };
        }
    }
}
