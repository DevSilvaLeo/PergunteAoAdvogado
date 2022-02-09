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
    public class DemandaRepository : IDemandaRepository
    {
        private string strConn;

        public DemandaRepository(string strConn)
        {
            this.strConn = strConn;
        }

        public void Insert(Demanda obj)
        {
            var query = "insert into Demanda (Titulo, Descricao, Anexo, DataCadastro) values (@Titulo, @Descricao, @Anexo, @DataCadastro)";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Demanda obj)
        {
            var query = "update Demanda set Titulo = @Titulo, Descricao = @Descricao, Anexo = @Anexo where IdDemanda = @IdDemanda";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }
        public void Delete(int Id)
        {
            var query = "delete from Demanda where IdDemanda = @IdDemanda";
            using(var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, new { IdDemanda = Id });
            }
        }

        public List<Demanda> GetAll()
        {
            var query = "select * from Demanda";
            using(var conn = new SqlConnection(strConn))
            {
                return conn.Query<Demanda>(query).ToList();
            }
        }

        public Demanda GetById(int Id)
        {
            var query = "select * from Demanda where IdDemanda = @IdDemanda";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Demanda>(query, new { IdDemanda = Id }).SingleOrDefault();
            }
        }
    }
}
