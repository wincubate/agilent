using Instrument.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstrumentApp
{
    class Instrument
    {
        private readonly List<ReagentState> _reagentStates;
        private int _nextIndexToDrawFrom;
        private readonly Random _random;

        public string Location { get; }
        public TimeSpan UpdateInterval { get; }

        public Instrument(string location, TimeSpan updateInterval)
        {
            UpdateInterval = updateInterval;
            Location = location;

            var reagentFactory = new ReagentFactory();

            _reagentStates = reagentFactory
                .CreateMany()
                .ToList();
            _nextIndexToDrawFrom = 0;

            _random = new Random();
        }

        public IEnumerable<ReagentUpdate> Draw()
        {
            while (true)
            {
                ReagentState next = _reagentStates[_nextIndexToDrawFrom];

                // Draw small random amount
                double amountToDraw = _random.NextDouble();
                double newQuantity = Math.Max(next.Quantity - amountToDraw, 0);
                next.Quantity = newQuantity;

                // Transmit
                yield return new ReagentUpdate
                { 
                    Serial = next.Serial, 
                    ProductName = next.ProductName, 
                    Location = Location,
                    Quantity = newQuantity };

                _nextIndexToDrawFrom = (_nextIndexToDrawFrom + 1) % _reagentStates.Count;
            }
        }
    }
}
