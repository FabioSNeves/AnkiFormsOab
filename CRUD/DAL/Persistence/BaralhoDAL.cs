using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistence
{
    public class BaralhoDAL : Conexao
    {
        // Metodo para gravar dados: Create
        public void GravarBaralho(Baralho b)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Baralho(NomeBaralho) values(@v1, @v2)", Con);

                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Errou ao gravar um Baralho" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        // Metodo para atualizar dados: Update
        public void AtualizarBaralho(Baralho b)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("update Baralho set NomeBaralho=@v1 where CodBaralho=@v2", Con);

                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);
                Cmd.Parameters.AddWithValue("@v2", b.CodBaralho);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar Baralho" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        // Metodo para excluir dados: Delete
        public void ExcluirBaralho(int CodBaralho)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Baralho where CodBaralho=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", CodBaralho);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Baralho" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        // Metodo para obter baralho por ID (chave primária)
        public Baralho PesquisarBaralhoPorCodigo(int CodBaralho)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Baralho where CodBaralho=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", CodBaralho);

                Baralho b = null;

                if (Dr.Read())
                {
                    b = new Baralho();

                    b.CodBaralho = Convert.ToInt32(Dr["CodBaralho"]);
                    b.NomeBaralho = Convert.ToString(Dr["NomeBaralho"]);
                }

                return b;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao pesquisar baralho" + ex.Message);
            }
        }

        // Metodo para listar baralhos
        public List<Baralho> ListarBaralhos()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * Baralho", Con);
                Dr = Cmd.ExecuteReader();

                List<Baralho> lista = new List<Baralho>();

                while (Dr.Read())
                {
                    Baralho b = new Baralho();

                    b.CodBaralho = Convert.ToInt32(Dr["CodBaralho"]);
                    b.NomeBaralho = Convert.ToString(Dr["NomeBaralho"]);

                    lista.Add(b);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possivel listar os baralhos" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
