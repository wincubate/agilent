using System;
using System.Runtime.Serialization;

namespace Client.Contract
{
    [DataContract]
    public class ReagentItem
    {
        [DataMember]
        public int Serial { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public double Quantity { get; set; }

        //[DataMember]
        //public string Note { get; set; }
    }
}
