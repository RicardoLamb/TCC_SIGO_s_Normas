﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SGestaodeNormas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INormasService" in both code and config file together.
    [ServiceContract]
    public interface INormasService
    {
        [OperationContract]
        Normas FiltrarNorma(string Sigla, string Codigo);

        [OperationContract]
        List<Normas> ListarNormas();

        [OperationContract]
        bool AdicionarNorma(string Sigla, string Codigo, string Descricao, string DataDefinicao, string DataVigencia, string Origem, string Categoria);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
