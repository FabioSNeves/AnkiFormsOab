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
    public class CardController : ApiController
    {

        private Conexao con;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;

        public CardController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }

        // GET: api/Card
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Card/5
        public string Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Carta WHERE CodCarta=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                Carta c = null;

                if (Dr.Read())
                {
                    c = new Carta();
                    c.CodCarta = Convert.ToInt32(Dr["CodCarta"]);
                    c.Frente = Convert.ToString(Dr["Frente"]);
                    c.Verso = Convert.ToString(Dr["Verso"]);
                    c.CodBaralho = Convert.ToInt32(Dr["CodBaralho"]);
                }

                var json = new JavaScriptSerializer().Serialize(c);
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

        // POST: api/Card
        public HttpResponseMessage Post([FromBody]Carta c)
        {
            try
            {
                Cmd = new SqlCommand("insert into Carta (Frente, Verso, CodBaralho) values(@v1, @v2, @v3)", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Frente);
                Cmd.Parameters.AddWithValue("@v2", c.Verso);
                Cmd.Parameters.AddWithValue("@v3", c.CodBaralho);
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);
                //return base.Created(new Uri(Request.RequestUri + id), content);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Carta: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // PUT: api/Card/5
        public HttpResponseMessage Put(int id, [FromBody]Carta c)
        {
            try
            {
                Cmd = new SqlCommand("update Carta set Frente=@v1, Verso=@v2, CodBaralho=@v3 where CodCarta=@v4", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Frente);
                Cmd.Parameters.AddWithValue("@v2", c.Verso);
                Cmd.Parameters.AddWithValue("@v3", c.CodBaralho);
                Cmd.Parameters.AddWithValue("@v4", c.CodCarta);
                Cmd.ExecuteNonQuery();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Carta: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // DELETE: api/Card/5
        public void Delete(int id)
        {
            try
            {
                Cmd = new SqlCommand("delete from Carta where CodCarta=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Carta" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
