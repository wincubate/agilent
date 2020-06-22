using System;
using System.Runtime.Serialization;

namespace Instrument.Contract
{
    [DataContract]
    public class ReagentUpdate
    {
        [DataMember]
        public int Serial { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public double Quantity { get; set; }

        public override string ToString() => $"{Serial}\t{ProductName} @ {Location}\t[{Quantity} ml]";
    }
}
