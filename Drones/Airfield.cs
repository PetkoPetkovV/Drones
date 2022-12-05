using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => drones.Count;

        public string AddDrone(Drone drone) 
        {
            if (drones.Capacity < 0)
            {
                return "Airfield is full.";
            }
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }
            if (drone.Range < 5 && drone.Range > 15)
            {
                return "Invalid drone.";
            }
            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name) 
        {
            var droneToRemove = drones.Where(x => x.Name == name).FirstOrDefault();
            if (droneToRemove != null)
            {
                drones.Remove(droneToRemove);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public int RemoveDroneByBrand(string brand) 
        {
            int counter = 0;
            var droneToRemove = drones.Where(x => x.Brand == brand).ToList();
            foreach (var item in droneToRemove)
            {
                drones.Remove(item);
                counter++;
            }

            return counter;
           
        }

        public Drone FlyDrone(string name) 
        {
            return drones.FirstOrDefault(x => x.Name == name);
        }

        public List<Drone> FlyDronesByRange(int range) 
        {
            List<Drone> dronesToFlyByRange = drones.Where(x => x.Range == range).ToList();
            foreach (var item in dronesToFlyByRange)
            {
                item.Available = false;
            }
            return dronesToFlyByRange;
            

        }

        public string Report() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var item in drones)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
