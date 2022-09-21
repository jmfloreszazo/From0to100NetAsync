using asyncelidingtest;

var service = new Service();
var serviceAsync = new ServiceAsync();
var data = await service.GetDataAsync();
var dataAsync = await serviceAsync.GetDataAsync();
Console.WriteLine(data);
Console.WriteLine(dataAsync);
