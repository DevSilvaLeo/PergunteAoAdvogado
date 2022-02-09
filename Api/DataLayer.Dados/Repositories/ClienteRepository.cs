using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Dapper;
using System.Data.SqlClient;

namespace DataLayer.Dados.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string strConn;

        public ClienteRepository(string strConn)
        {
            this.strConn = strConn;
        }

        public void Insert(Cliente obj)
        {
            var query = "insert into Cliente (Nome, Telefone, Email, DataCadastro) values (@Nome, @Telefone, @Email, @DataCadastro)";
            using(var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Cliente obj)
        {
            var query = "update Cliente set Nome = @Nome, Telefone = @Telefone, Email = @Email where IdCliente = @IdCliente";
            using(var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }
        public void Delete(int Id)
        {
            var query = "delete from Cliente where IdCliente = @IdCliente";
            using(var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, new { IdCliente = Id });
            }
        }

        public List<Cliente> GetAll()
        {
            var query = "select * from Cliente";
            using(var conn = new SqlConnection(strConn))
            {
                return conn.Query<Cliente>(query).ToList();
            }
        }

        public Cliente GetById(int Id)
        {
            var query = "select * from Cliente where IdCliente = @IdCliente";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Cliente>(query, new { IdCliente = Id }).SingleOrDefault();
            }
        }
    }
}
