using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SGestaodeNormas
{
    public class Normas
    {
        public string Ukey { get; set; }
        public string Sigla { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string DataDefinicao { get; set; }
        public string DataVigencia { get; set; }
        public string Origem { get; set; }
        public string Categoria { get; set; }

        public bool AdicionarNorma(string Sigla, string Codigo, string Descricao, string DataDefinicao, string DataVigencia, string Origem, string Categoria)
        {
            return true;
        }

        public Normas FiltrarNorma(string Sigla, string Codigo)
        {
            var norma = new Normas() { Ukey = "UKEY1", Sigla = "ABNT NBR", Codigo = "15527", Descricao = "Água de chuva - Aproveitamento de coberturas em áreas urbanas para fins não potáveis - Requisitos ", DataDefinicao = "2007-09-24 00:00:00", DataVigencia = "2007-10-24 00:00:00", Origem = "http://licenciadorambiental.com.br//wp-content/uploads/2015/01/NBR-15.527-Aproveitamento-%C3%A1gua-da-chuva.pdf", Categoria = "Ambiental" };
            return norma;
        }
        public List<Normas> ListarNormas()
        {
            List<Normas> normas = new List<Normas>();
            normas.Add(new Normas() { Ukey = "UKEY1", Sigla = "ABNT NBR", Codigo = "15527", Descricao = "Água de chuva - Aproveitamento de coberturas em áreas urbanas para fins não potáveis - Requisitos ", DataDefinicao = "2007-09-24 00:00:00", DataVigencia = "2007-10-24 00:00:00", Origem = "http://licenciadorambiental.com.br//wp-content/uploads/2015/01/NBR-15.527-Aproveitamento-%C3%A1gua-da-chuva.pdf", Categoria = "Ambiental" });
            normas.Add(new Normas() { Ukey = "UKEY2", Sigla = "ABNT NBR", Codigo = "15112", Descricao = "Resíduos da construção civil e resíduos volumosos - Áreas de transbordo e triagem - Diretrizes para projeto, implantação e operação.", DataDefinicao = "2004-06-30 00:00:00", DataVigencia = "2004-07-30 00:00:00", Origem = "http://licenciadorambiental.com.br//wp-content/uploads/2015/01/NBR-15.112-RCC-e-Res%C3%ADduos-Volumosos.pdf", Categoria = "Ambiental" });
            normas.Add(new Normas() { Ukey = "UKEY3", Sigla = "ABNT NBR", Codigo = "15575-5_2013", Descricao = "Edificações habitacionais — Desempenho - Parte 5: Requisitos para sistemas de coberturas", DataDefinicao = "2007-09-28 00:00:00", DataVigencia = "2007-11-27 00:00:00", Origem = "http://licenciadorambiental.com.br//wp-content/uploads/2015/01/NBR-15.575-5-Sistemas-de-Cobertura.pdf", Categoria = "Ambiental" });
            return normas;
        }
    }
}