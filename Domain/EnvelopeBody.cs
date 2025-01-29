namespace Domain
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return bodyField;
            }
            set
            {
                bodyField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private ccgConsGTINResponse ccgConsGTINResponseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin")]
        public ccgConsGTINResponse ccgConsGTINResponse
        {
            get
            {
                return ccgConsGTINResponseField;
            }
            set
            {
                ccgConsGTINResponseField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin", IsNullable = false)]
    public partial class ccgConsGTINResponse
    {

        private ccgConsGTINResponseNfeResultMsg nfeResultMsgField;

        /// <remarks/>
        public ccgConsGTINResponseNfeResultMsg nfeResultMsg
        {
            get
            {
                return nfeResultMsgField;
            }
            set
            {
                nfeResultMsgField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin")]
    public partial class ccgConsGTINResponseNfeResultMsg
    {

        private retConsGTIN retConsGTINField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public retConsGTIN retConsGTIN
        {
            get
            {
                return retConsGTINField;
            }
            set
            {
                retConsGTINField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class retConsGTIN
    {

        private string verAplicField;

        private string cStatField;

        private string xMotivoField;

        private DateTime dhRespField;

        private string gTINField;

        private string tpGTINField;

        private string xProdField;

        private string nCMField;

        private string cESTField;

        private decimal versaoField;

        /// <remarks/>
        public string verAplic
        {
            get
            {
                return verAplicField;
            }
            set
            {
                verAplicField = value;
            }
        }

        /// <remarks/>
        public string cStat
        {
            get
            {
                return cStatField;
            }
            set
            {
                cStatField = value;
            }
        }

        /// <remarks/>
        public string xMotivo
        {
            get
            {
                return xMotivoField;
            }
            set
            {
                xMotivoField = value;
            }
        }

        /// <remarks/>
        public DateTime dhResp
        {
            get
            {
                return dhRespField;
            }
            set
            {
                dhRespField = value;
            }
        }

        /// <remarks/>
        public string GTIN
        {
            get
            {
                return gTINField;
            }
            set
            {
                gTINField = value;
            }
        }

        /// <remarks/>
        public string tpGTIN
        {
            get
            {
                return tpGTINField;
            }
            set
            {
                tpGTINField = value;
            }
        }

        /// <remarks/>
        public string xProd
        {
            get
            {
                return xProdField;
            }
            set
            {
                xProdField = value;
            }
        }

        /// <remarks/>
        public string NCM
        {
            get
            {
                return nCMField;
            }
            set
            {
                nCMField = value;
            }
        }

        /// <remarks/>
        public string CEST
        {
            get
            {
                return cESTField;
            }
            set
            {
                cESTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public decimal versao
        {
            get
            {
                return versaoField;
            }
            set
            {
                versaoField = value;
            }
        }
    }
}
