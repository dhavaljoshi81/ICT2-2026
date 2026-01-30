using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS.Indexer
{
    internal class IndexerDemo
    {
        public static void Main()
        {
            Vehicles vehicles = new Vehicles();
            vehicles.GetVehicles.Add(new Vehicle
            {
                ID = 1,
                Model = "Tiago",
                Make = "Tata",
                Rate = 700000
            });
            vehicles.GetVehicles.Add(new Vehicle
            {
                ID = 2,
                Model = "Tigor",
                Make = "Tata",
                Rate = 900000
            });
            vehicles.GetVehicles.Add(new Vehicle
            {
                ID = 3,
                Model = "Swift",
                Make = "Maruti",
                Rate = 800000
            });
            vehicles.GetVehicles.Add(new Vehicle
            {
                ID = 4,
                Model = "TUV",
                Make = "Mahindra",
                Rate = 950000
            });

            foreach (var v in vehicles.GetVehicles)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("+++++++++++++++");
            Vehicle v1 = vehicles[2];
            Console.WriteLine(v1);

            Console.WriteLine("+++++++++++++++");
            Vehicle v2 = vehicles["Tiago"];
            Console.WriteLine(v2);
        }
    }
}
