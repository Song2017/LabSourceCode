using GettingStartedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/Service");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                serviceHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(SecurityMode.None), "CalculatorService");

                serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

                serviceHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"an exception is {ce.Message}");
            }
        }
    }
}
