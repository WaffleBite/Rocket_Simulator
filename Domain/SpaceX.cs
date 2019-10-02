namespace Rocket_Simulator.Domain
{
    class SpaceX : Rocket
    {
        public SpaceX(string name, int fuelAmountInKilograms, int grossWeight, int thrustVacuum)
                      : base(name, fuelAmountInKilograms, grossWeight, thrustVacuum)
        {

        }
    }
}
