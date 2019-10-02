using Rocket_Simulator.Domain;
using System;
using System.Threading;
using System.Text;

namespace Rocket_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Rocket> simulatedRockets = new List<Rocket>(); //lista med raketer användaren har lagt till
            Rocket[] simulatedRockets = new Rocket[2];

            SpaceX falconHeavy = new SpaceX(name: "Falcon Heavy, SpaceX", fuelAmountInKilograms: 130000, grossWeight: 1420788, thrustVacuum: 1672334);
            SpaceX starship = new SpaceX(name: "Starship, SpaceX", fuelAmountInKilograms: 142000, grossWeight: 1335000, thrustVacuum: 1223659);

            StringBuilder sb = new StringBuilder();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("[1] Add rockets");
                Console.WriteLine("[2] List rockets");
                Console.WriteLine("[3] Run simulation");
                Console.WriteLine("[4] Exit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                Console.Clear();


                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1: //add rockets
                        //listar raketer som finns, som användaren kan välja mellan, och de läggs i i en "simulator" lista
                        Console.WriteLine("[1] Falcon Heavy, SpaceX");
                        Console.WriteLine("[2] Starship, SpaceX");

                        ConsoleKeyInfo inputInRocket = Console.ReadKey(true);
                        switch (inputInRocket.Key)
                        {
                            case ConsoleKey.D1: //add Falcon Heavy
                                if (simulatedRockets[0] == null)
                                {
                                    simulatedRockets[0] = falconHeavy;
                                    Console.WriteLine("Rocket added");

                                    Thread.Sleep(2000);
                                    break;
                                }
                                else if (simulatedRockets[0].Name == falconHeavy.Name)
                                {
                                    Console.WriteLine("Rocket already added");
                                    Thread.Sleep(2000);
                                    break; //gå inte vidare till nästa if sats
                                }
                                break;

                            case ConsoleKey.D2: //add Starship
                                if (simulatedRockets[1] == null)
                                {
                                    simulatedRockets[1] = starship;
                                    Console.WriteLine("Rocket added");

                                    Thread.Sleep(2000);
                                    break;
                                }
                                else if (simulatedRockets[1].Name == starship.Name)
                                {
                                    Console.WriteLine("Rocket already added");
                                    Thread.Sleep(2000);
                                    break;
                                }
                                break;
                        }
                        break;

                    case ConsoleKey.D2: //list rockets
                                        //listar raketerna som användaren har valt
                        Console.WriteLine("Simulated rockets");
                        sb.Append('_', Console.WindowWidth);
                        Console.WriteLine(sb);
                        //Console.WriteLine("___________________________________________________________");

                        foreach (var listRockets in simulatedRockets)
                        {
                            if (listRockets == null) continue;
                            Console.WriteLine(listRockets.Name);
                        }

                        Console.WriteLine(">Press any key to continue");
                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3: //run simulation

                        Console.Write("Engine burn period (sec): ");
                        decimal burnPeriod = int.Parse(Console.ReadLine());
                        Console.Clear();

                        decimal burnAmountPerSec = 1800;
                        decimal burnedFuel = 0;
                        decimal fuelLeftInKilograms = 0;
                        
                        Console.Write("Rocket".PadRight(30, ' '));
                        Console.Write("Velocity (km/s)".PadRight(20, ' '));
                        Console.Write("Fuel left (tons)");

                        foreach (var rocket in simulatedRockets)
                        {
                            if (rocket == null) continue;
                            //decimal parentesen = rocket.GrossWeight / rocket.GrossWeight - (burnAmountPerSec * burnPeriod);
                            

                            burnPeriod *= burnAmountPerSec = burnedFuel;
                            fuelLeftInKilograms = rocket.FuelAmountInKilograms - (burnAmountPerSec * burnPeriod);
                            rocket.FuelAmountInKilograms -= (burnAmountPerSec * burnPeriod);

                            string rocketName = rocket.Name;
                            string velocity = string.Format("{0:0.00}", rocket.VelocityInKilometersPerSeconds);

                            decimal log = (decimal)Math.Log((double)(rocket.GrossWeight + rocket.FuelAmountInKilograms / rocket.GrossWeight - burnedFuel));
                            decimal velocityDec = Math.Round((7100 * log),2);
                            velocity = velocityDec.ToString();


                            Console.WriteLine();
                            Console.Write(rocketName.PadRight(30, ' '));
                            Console.Write(velocity.PadRight(20, ' '));
                            Console.Write(fuelLeftInKilograms / 1000);
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D4: //exit

                        isRunning = false;

                        break;
                }
            }
        }
    }
}
