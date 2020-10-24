using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class ToyotaPrius : Car
    {
        public bool IsEnginePreparedToRun { get; private set; }

        public ToyotaPrius()
        {
            IsEnginePreparedToRun = false;
        }

        public override void TurnIgnitionKey()
        {
            IsEnginePreparedToRun = true;
        }

        public void PressGasPedal()
        {
            if( IsEnginePreparedToRun )
            {
                IsEngineRunning = true;
            }
        }
    }
}
