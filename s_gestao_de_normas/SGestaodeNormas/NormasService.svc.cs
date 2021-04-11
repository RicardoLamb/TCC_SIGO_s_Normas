using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SGestaodeNormas
{
    public class NormasService : INormasService
    {
        public Normas FiltrarNorma(string Sigla, string Codigo)
        {
            Normas norma = new Normas().FiltrarNorma(Sigla, Codigo);
            return norma;
        }

        public List<Normas> ListarNormas()
        {
            Normas normas = new Normas();
            return normas.ListarNormas();
        }

        public bool AdicionarNorma(string Sigla, string Codigo, string Descricao, string DataDefinicao, string DataVigencia, string Origem, string Categoria)
        {
            try {
                bool saved = new Normas() { Ukey = "UKEY2" }.AdicionarNorma(Sigla, Codigo, Descricao, DataDefinicao, DataVigencia, Origem, Categoria);
                return saved;
            }
            catch {
                return false;
            }
        }
    }
}
