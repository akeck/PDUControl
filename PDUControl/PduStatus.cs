using System.Xml.Serialization;

namespace PDUControl
{
    [XmlRoot(ElementName="response")]
    public class PduStatus { 
/*
        [XmlElement(ElementName="cur0")] 
        public decimal Cur0 { get; set; } 

        [XmlElement(ElementName="stat0")] 
        public string Stat0 { get; set; } 
*/
        [XmlElement(ElementName="curBan")] 
        public decimal Current { get; set; } 

        [XmlElement(ElementName="tempBan")] 
        public int Temperature { get; set; } 

        [XmlElement(ElementName="humBan")] 
        public int Humidity { get; set; } 

        [XmlElement(ElementName="statBan")] 
        public string AlertState { get; set; } 

        [XmlElement(ElementName="outletStat0")] 
        public string OutletStat0 { get; set; } 

        [XmlElement(ElementName="outletStat1")] 
        public string OutletStat1 { get; set; } 

        [XmlElement(ElementName="outletStat2")] 
        public string OutletStat2 { get; set; } 

        [XmlElement(ElementName="outletStat3")] 
        public string OutletStat3 { get; set; } 

        [XmlElement(ElementName="outletStat4")] 
        public string OutletStat4 { get; set; } 

        [XmlElement(ElementName="outletStat5")] 
        public string OutletStat5 { get; set; } 

        [XmlElement(ElementName="outletStat6")] 
        public string OutletStat6 { get; set; } 

        [XmlElement(ElementName="outletStat7")] 
        public string OutletStat7 { get; set; } 

        [XmlElement(ElementName="userVerifyRes")] 
        public int UserVerifyRes { get; set; }

        public bool Outlet0Power => OutletStat0 == "on";
        public bool Outlet1Power => OutletStat1 == "on";
        public bool Outlet2Power => OutletStat2 == "on";
        public bool Outlet3Power => OutletStat3 == "on";
        public bool Outlet4Power => OutletStat4 == "on";
        public bool Outlet5Power => OutletStat5 == "on";
        public bool Outlet6Power => OutletStat6 == "on";
        public bool Outlet7Power => OutletStat7 == "on";
    }
}
