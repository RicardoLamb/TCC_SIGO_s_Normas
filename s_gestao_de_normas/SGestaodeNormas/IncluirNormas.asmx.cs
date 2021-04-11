using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace SGestaodeNormas
{
    /// <summary>
    /// Summary description for IncluirNormas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class IncluirNormas : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable ListarNormas()
        {
            SqlConnection con = new SqlConnection("data source=.;Integrated Security=Yes;Database=sigonormas");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Normas"); 
            SqlDataAdapter sda = new SqlDataAdapter(); 
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.TableName = "Normas";
            sda.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataTable FiltrarNorma(string Sigla, string Codigo)
        {
            SqlConnection con = new SqlConnection("data source=.;Integrated Security=Yes;Database=sigonormas");
            SqlCommand cmd = new SqlCommand("select * from normas where sigla = @sigla and codigo = @codigo");
            cmd.Parameters.AddWithValue("@Sigla", Sigla);
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.TableName = "Normas";
            sda.Fill(dt);
            return dt;
        }

        [WebMethod]
        public void AdicionarNorma(string Sigla, string Codigo, string Descricao, string DataDefinicao, string DataVigencia, string Origem, string Categoria)
        {
            SqlConnection con = new SqlConnection("data source=.;Integrated Security=Yes;Database=sigonormas");
            SqlCommand cmd = new SqlCommand("insert into normas values(@Sigla, @Codigo, @Descricao, @DataDefinicao, @DataVigencia, @Origem, @Categoria)");
            cmd.Parameters.AddWithValue("@Sigla", Sigla);
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@DataDefinicao", DataDefinicao);
            cmd.Parameters.AddWithValue("@DataVigencia", DataVigencia);
            cmd.Parameters.AddWithValue("@Origem", Origem);
            cmd.Parameters.AddWithValue("@Categoria", Categoria);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            this.InsertSIGO(Sigla, Codigo, Descricao, DataDefinicao, DataVigencia, Origem, Categoria);
            con.Close();
            this.FiltrarNorma(Sigla, Codigo);
        }

        public void InsertSIGO(string Sigla, string Codigo, string Descricao, string DataDefinicao, string DataVigencia, string Origem, string Categoria)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://boo42sr8f6.execute-api.us-west-2.amazonaws.com/abnt/abnt/id?"+Codigo);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream())) {
                string json = new JavaScriptSerializer().Serialize(new {
                    id = Codigo,
                    categoria = Categoria,
                    codigo = Codigo,
                    datadefinicao = DataDefinicao,
                    datavigencia = DataVigencia,
                    descricao = Descricao,
                    origem = Origem,
                    sigla = Sigla
                });

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream())) {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
