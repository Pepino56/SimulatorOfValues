using vosplzen.sem2._2023k.Data;
using vosplzen.sem2._2023k.Data.Model;

namespace vosplzen.sem2._2023k.Services
{
    public class StationService : IStationService
    {
        private readonly ApplicationDbContext _context;

        public StationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Station> GetAllStations()
        {
            return _context.Stations.ToList();
        }

        public Station GetStationById(int id)
        {
            return _context.Stations.FirstOrDefault(s => s.Id == id);
        }

        public void AddStation(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
        }

        public void UpdateStation(Station station)
        {
            var existingStation = _context.Stations.Find(station.Id);
            if (existingStation != null)
            {
                existingStation.Title = station.Title;
                existingStation.FloodLevel = station.FloodLevel;
                existingStation.DroughtLevel = station.DroughtLevel;
                existingStation.TimeOutInMinutes = station.TimeOutInMinutes;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Station not found");
            }
        }

        public void DeleteStation(int id)
        {
            var stationToDelete = _context.Stations.Find(id);
            if (stationToDelete != null)
            {
                _context.Stations.Remove(stationToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Station not found");
            }
        }
    }
}
