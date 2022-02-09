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
    public class AdvogadoRepository : IAdvogadoRepository
    {
        private string strConn;

        public AdvogadoRepository(string strConn)
        {
            this.strConn = strConn;
        }

        public void Insert(Advogado obj)
        {
            var query = "insert into Advogado (Nome, InscricaoOAB, CodSegurancaOAB, ExpedicaoOAB, Foto, DataCadastro,CEP,Bairro,Logradouro,Cidade,UF,Biografia,Complemento,Especializacao) " +
                "values (@Nome, @InscricaoOAB, @CodSegurancaOAB, @ExpedicaoOAB, @Foto, @DataCadastro, @CEP,@Bairro,@Logradouro,@Cidade,@UF,@Biografia,@Complemento,@Especializacao)";
            using(var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Advogado obj)
        {
            var query = "update Advogado set CEP= @CEP,Bairro=@Bairro,Logradouro=@Logradouro,Cidade=@Cidade,UF=@UF,Biografia=@Biografia,Complemento=@Complemento,Especializacao=@Especializacao, Nome = @Nome, InscricaoOAB = @InscricaoOAB, CodSegurancaOAB = @CodSegurancaOAB, ExpedicaoOAB = @ExpedicaoOAB, Foto = @Foto where IdAdvogado = @IdAdvogado";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }
        public void Delete(int Id)
        {
            var query = "delete from Advogado where IdAdvogado = @IdAdvogado";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, new { IdAdvogado = Id });
            }
        }

        public List<Advogado> GetAll()
        {
            var query = "select * from Advogado";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Advogado>(query).ToList();
            }
        }

        public Advogado GetById(int Id)
        {
            var query = "select * from Advogado where IdAdvogado = @IdAdvogado";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Advogado>(query, new { IdAdvogado = Id}).SingleOrDefault();
            }
        }
    }
}
