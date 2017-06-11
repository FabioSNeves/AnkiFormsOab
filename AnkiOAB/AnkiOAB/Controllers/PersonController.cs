using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using AnkiOAB.Models;
using System.Web.Script.Serialization;

namespace AnkiOAB.Controllers
{
    public class PersonController : ApiController
    {
        private Conexao con;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;
        
        public PersonController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }
        // GET: api/Person
        //public IEnumerable<Usuario> GetAll()
        //{
            
        //}

        // GET: api/Person/string
        public string Get(string id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Usuario WHERE Email=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                Usuario u = null;

                if (Dr.Read())
                {
                    u = new Usuario();
                    u.CodUsuario = Convert.ToInt32(Dr["CodUsuario"]);
                    u.NomeUsuario = Convert.ToString(Dr["NomeUsuario"]);
                    u.Email = Convert.ToString(Dr["Email"]);
                    u.Senha = Convert.ToString(Dr["Senha"]);
                }

               var json = new JavaScriptSerializer().Serialize(u);
               return json;

            }
            catch (Exception ex)
            {

                throw new Exception("" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Usuario value)
        {
            try
            {
                Cmd = new SqlCommand("insert into Usuario (NomeUsuario, Email, Senha) values(@v1, @v2, @v3)", Con);
                Cmd.Parameters.AddWithValue("@v1", value.NomeUsuario);
                Cmd.Parameters.AddWithValue("@v2", value.Email);
                Cmd.Parameters.AddWithValue("@v3", value.Senha);
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);
                //return base.Created(new Uri(Request.RequestUri + id), content);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Usuário: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // PUT: api/Person/5
        public HttpResponseMessage Put(int id, [FromBody]Usuario u)
        {
            try
            {
                Cmd = new SqlCommand("update Usuario set NomeUsuario=@v1, Email=@v2, Senha=@v3 where CodUsuario=@v4", Con);
                Cmd.Parameters.AddWithValue("@v1", u.NomeUsuario);
                Cmd.Parameters.AddWithValue("@v2", u.Email);
                Cmd.Parameters.AddWithValue("@v3", u.Senha);
                Cmd.Parameters.AddWithValue("@v4", u.CodUsuario);
                Cmd.ExecuteNonQuery();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Usuário: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            try
            {
                Cmd = new SqlCommand("delete from Usuario where CodUsuario=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Usuário" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
