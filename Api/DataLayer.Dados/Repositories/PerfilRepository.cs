using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer.Dados.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private string strConn;

        public PerfilRepository(string strConn)
        {
            this.strConn = strConn;
        }

        public void Insert(Perfil obj)
        {
            var query = "insert into Perfil (Biografia, Especializacao, Avaliacao, CriadoEm, ModificadoEm) " +
                "values(@Biografia, @Especializacao, @Avaliacao, @CriadoEm, @ModificadoEm)";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Perfil obj)
        {
            var query = "Update Perfil set Biografia = @Biografia, Especializacao = @Especializacao, Avaliacao = @Avaliacao, " +
                "ModificadoEm = @ModificadoEm where IdPerfil = @IdPerfil"; 
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }
        public void Delete(int Id)
        {
            var query = "delete from Perfil where IdPerfil = @IdPerfil";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, new { IdPerfil = Id});
            }
        }

        public List<Perfil> GetAll()
        {
            var query = "select * from Perfil";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Perfil>(query).ToList();
            }

        }

        public Perfil GetById(int Id)
        {
            var query = "select * from Perfil where IdPerfil = @IdPerfil";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Perfil>(query, new { IdPerfil = Id }).SingleOrDefault();
            }
        }
    }
}
