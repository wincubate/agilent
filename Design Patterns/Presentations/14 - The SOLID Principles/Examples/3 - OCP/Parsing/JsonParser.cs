using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class JsonParser : Parser
    {
        public override IEnumerable<StockPosition> Parse(string dataAsString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString);
        }
    }
}
