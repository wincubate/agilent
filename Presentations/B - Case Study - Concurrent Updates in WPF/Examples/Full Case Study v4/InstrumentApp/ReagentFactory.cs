using System;
using System.Collections.Generic;

namespace InstrumentApp
{
    class ReagentFactory
    {
        private readonly Random _random;
        private static int _nextId;
        private readonly string[] _productNamePool = new string[]
        {
            "Wine",
            "Coke",
            "Water",
            "Milk",
            "Oil",
            "Juice",
            "Beer",
            "Gin"
        };

        public ReagentFactory()
        {
            _random = new Random();
        }

        public ReagentState Create()
        {
            return new ReagentState(
                ++_nextId,
                _productNamePool[_random.Next(0, _productNamePool.Length)],
                _random.Next(2000, 5000)
            );
        }
        public IEnumerable<ReagentState> CreateMany()
        {
            IList<ReagentState> reagentStates = new List<ReagentState>();
            int count = _random.Next(3, 7);
            for (int i = 0; i < count; i++)
            {
                reagentStates.Add(Create());
            }

            return reagentStates;
        }
    }
}
