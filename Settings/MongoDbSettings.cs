namespace BudgetNinjaAPI.Settings
{
  public class MongoDbSettings
  {
    public string Host { get; set; }
    public int Port { get; set; }

    public string ConnectionString
    {
      get
      {
        return $"mongodb://{User}:{Password}@{Host}:{Port}";
      }
    }

    public string User { get; set; }
    public string Password { get; set; }
  }
}