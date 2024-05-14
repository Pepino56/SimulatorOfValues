using vosplzen.sem2._2023k.Data.Model;

namespace vosplzen.sem2._2023k.Services
{
    public interface IStationService
    {
        IEnumerable<Station> GetAllStations();

        Station GetStationById(int id);

        void AddStation(Station station);

        void UpdateStation(Station station);

        void DeleteStation(int id);
    }
}
