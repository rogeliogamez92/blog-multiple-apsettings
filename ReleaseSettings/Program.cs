using Microsoft.Extensions.Configuration;

var configurationBuilder = new ConfigurationBuilder();

configurationBuilder.AddJsonFile("appsettings.json");

#if DEBUG
configurationBuilder.AddJsonFile("appsettings.debug.json");
#elif AZURE
configurationBuilder.AddJsonFile("appsettings.azure.json");
#elif LINUX
configurationBuilder.AddJsonFile("appsettings.linux.json");
#endif

configurationBuilder.AddJsonFile("appsettings.user.json");

var configuration = configurationBuilder.Build();

Console.WriteLine(configuration.GetValue<string>("GlobalSetting"));
Console.WriteLine(configuration.GetValue<string>("PlatformSetting"));
Console.WriteLine(configuration.GetValue<string>("UserSetting"));