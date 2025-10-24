using ServiceContracts;

namespace Services;

public class CitiesService:ICitiesService,IDisposable
{
    private List<string> _cities = [];
    private Guid _serviceInstanceId;

    public CitiesService()
    {
        _cities = new List<string>()
        {
            "London",
            "Paris",
            "Tokyo",
            "Australia",
        };
        _serviceInstanceId = Guid.NewGuid();
        //TODO :Add logic to read cities from database
    }

    public List<string> GetCountries()
    {
        return new List<string>()
        {
            "UK",
            "France",
            "Japan",
            "Australia",
        };
    }

    public List<string> GetCities()
    {
        return _cities;
    }

    public Guid ServiceInstanceId
    {
        get
        {
            return _serviceInstanceId;
        }
    }

    public void Dispose()
    {
        //TODO :Add logic to release resources
    }
}