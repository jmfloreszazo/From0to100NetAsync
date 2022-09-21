namespace asyncelidingtest;

public interface IService
{
    Task<string> GetDataAsync();
}
public class Service : IService
{
    private readonly IRepository _repository;
    public Service() => _repository = new Repository();
    public async Task<string> GetDataAsync() => await _repository.GetDataFromDbAsync();
}
public interface IRepository
{
    Task<string> GetDataFromDbAsync();
}
public class Repository : IRepository
{
    public async Task<string> GetDataFromDbAsync()
    {
        return await Task.FromResult("Result");
    }
}