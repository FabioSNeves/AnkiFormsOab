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
    public class DeckController : ApiController
    {
        private Conexao con;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;

        public DeckController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }

        // GET: api/Deck
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Deck/5
        public string Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Baralho WHERE CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                Baralho b = null;

                if (Dr.Read())
                {
                    b = new Baralho();
                    b.CodBaralho = Convert.ToInt32(Dr["CodBaralho"]);
                    b.NomeBaralho = Convert.ToString(Dr["NomeBaralho"]);
                }

                var json = new JavaScriptSerializer().Serialize(b);
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

        // POST: api/Deck
        public HttpResponseMessage Post([FromBody]Baralho b)
        {
            try
            {
                Cmd = new SqlCommand("insert into Baralho (NomeBaralho) values(@v1)", Con);
                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);;
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);
                //return base.Created(new Uri(Request.RequestUri + id), content);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Baralho: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // PUT: api/Deck/5
        public HttpResponseMessage Put(int id, [FromBody]Baralho b)
        {
            try
            {
                Cmd = new SqlCommand("update Baralho set NomeBaralho=@v1 where CodBaralho=@v2", Con);
                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);
                Cmd.Parameters.AddWithValue("@v2", b.CodBaralho);
                Cmd.ExecuteNonQuery();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Baralho: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // DELETE: api/Deck/5
        public void Delete(int id)
        {
            try
            {
                Cmd = new SqlCommand("delete from Baralho where CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Baralho" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
