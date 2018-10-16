using System;

namespace ConsoleApp
{
    public class Car
    {
        public int CurrSpeed { get; set; }
        public int maxSpeed { get; set; }

        public string Name { get; set; }

        public bool carIsDead { get; set; }

        public Car() { this.maxSpeed = 100; }

        public delegate void CarEngineHandler(string msgForCaller);

        private CarEngineHandler listOfhandlers;

        public void RegisterCarEngine(CarEngineHandler methodToCall)
        {
            this.listOfhandlers += methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead && listOfhandlers != null)
                listOfhandlers("sorry, the car is dead");

            if (carIsDead)
                return;

            CurrSpeed += delta;
            if (listOfhandlers != null && (maxSpeed - CurrSpeed) == 10)
                listOfhandlers("Careful, now speed is 90");
            if (CurrSpeed < maxSpeed)
                Console.WriteLine("current speed is {0}", CurrSpeed);
            else
                carIsDead = true;
        }

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AbouttoBlow;

        public delegate void CarEngineHandlerEvent(object sender, CarEventArgs e);
        public event CarEngineHandlerEvent ExplodedEvent;

        public void AccelerateEvent(int delta)
        {
            if (carIsDead)
                ExplodedEvent(this, new CarEventArgs("sorry, the car is dead"));

            if (carIsDead)
                return;

            CurrSpeed += delta;
            if (listOfhandlers != null && (maxSpeed - CurrSpeed) == 10)
                AbouttoBlow("Careful, now speed is 90");
            if (CurrSpeed < maxSpeed)
                Console.WriteLine("current speed is {0}", CurrSpeed);
            else
                carIsDead = true;
        }

    }


    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        { msg = message; }
    }
}