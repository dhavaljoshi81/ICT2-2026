using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS.Indexer
{
    internal class Vehicles
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public Vehicle this[int id]
        {
            get 
            {
                return _vehicles.SingleOrDefault(v => v.ID == id);
            }
            set 
            {
                Vehicle v = _vehicles.SingleOrDefault(v => v.ID == id);
                if (v != null)
                {
                    v = value;
                }
            }
        }


        public Vehicle this[string model]
        {
            get
            {
                return _vehicles.SingleOrDefault(v => v.Model == model);
            }
            set
            {
                Vehicle v = _vehicles.SingleOrDefault(v => v.Model == model);
                if (v != null)
                {
                    v = value;
                }
            }
        }
        public List<Vehicle> GetVehicles 
        { 
            get => _vehicles; 
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllVehiclesOfMaker(string make)
        {
            return _vehicles
                .Where(v => v.Make.ToLower().Contains(make.ToLower()))
                .ToList();
        }
    }
}
