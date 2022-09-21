namespace asyncelidingtest;

public interface IServiceAsync
{
    Task<string> GetDataAsync();
}
public class ServiceAsync : IServiceAsync
{
    private readonly IRepositoryAsync _repository;
    public ServiceAsync() => _repository = new RepositoryAsync();
    public async Task<string> GetDataAsync() => await _repository.GetDataFromDbAsync();
}
public interface IRepositoryAsync
{
    Task<string> GetDataFromDbAsync();
}
public class RepositoryAsync : IRepositoryAsync
{
    public async Task<string> GetDataFromDbAsync()
    {
        return await Task.FromResult("Result");
    }
}