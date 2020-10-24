using System;

namespace InstrumentApp
{
    class ReagentState
    {
        public int Serial { get; }
        public string ProductName { get; }
        public double Quantity { get; set; }

        public ReagentState( int serial, string productName, double quantity )
        {
            Serial = serial;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
