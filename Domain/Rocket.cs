namespace Rocket_Simulator.Domain
{
    abstract class Rocket
    {
        public string Name { get; }
        public decimal FuelAmountInKilograms { get; set; }
        public decimal GrossWeight { get; }
        public decimal ThrustVacuum { get; }

        public double VelocityInKilometersPerSeconds { get; }

        //public abstract void EngineBurn(ushort seconds);    
        //{

        //}

        public Rocket(string name, int fuelAmountInKilograms, int grossWeight, int thrustVacuum)
        {
            Name = name;
            FuelAmountInKilograms = fuelAmountInKilograms;
            GrossWeight = grossWeight;
            ThrustVacuum = thrustVacuum;
        }
    }
}
