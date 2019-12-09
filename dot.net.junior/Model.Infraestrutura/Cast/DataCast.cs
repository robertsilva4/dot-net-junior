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
        public static Cliente CastCliente(SqlDataReader Reader)
        {
            return new Cliente()
            {
                id = Convert.Toint(Reader["idcliente"]),
                nome = Convert.ToString(Reader["nome"]),
                cpfCnpj = Convert.ToInt32(Reader["cpf_cnpj"]),
                endereco = Convert.ToInt32(Reader["endereco"]),
                telefone = Convert.ToInt32(Reader["telefone"])

            };
        }

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
