﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Model.Infraestrutura.Acesso_ao_banco
{

                    

        public class acesso : IDisposable
        {
            private readonly SqlConnection _sqlConnection;
            private SqlTransaction _sqltransaction;

            public acesso()
            {

            this._sqlConnection = new SqlConnection(Configurar.Config.ConnectionString) ;
                this._sqlConnection.Open();
            }

            public object Command(StringBuilder Sql, List<SqlParameter> Parameters)
            {
                try
                {
                    SqlCommand command = new SqlCommand(Sql.ToString(), _sqlConnection);
                    command.Parameters.AddRange(Parameters.ToArray());
                    command.Transaction = this._sqltransaction;
                    return command.ExecuteScalar();

                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    Sql.Clear();
                    Parameters.Clear();
                }
            }

            public SqlDataReader Reader(StringBuilder Sql, List<SqlParameter> Parameters)
            {
                try
                {
                    SqlCommand command = new SqlCommand(Sql.ToString(), _sqlConnection);
                    command.Parameters.AddRange(Parameters.ToArray());
                    return command.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    Sql.Clear();
                    Parameters.Clear();
                }
            }

            public void BeginTransaction()
            {
                _sqltransaction = _sqlConnection.BeginTransaction();
            }

            public void Commit()
            {
                _sqltransaction?.Commit();
            }

            public void RollBack()
            {
                _sqltransaction?.Rollback();
            }

            public void Dispose()
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
        }
    }
