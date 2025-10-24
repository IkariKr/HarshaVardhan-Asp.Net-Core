namespace ServiceContracts;

public interface ICitiesService
{
    public List<string> GetCountries();
    public List<string> GetCities();
    Guid ServiceInstanceId { get; }
}