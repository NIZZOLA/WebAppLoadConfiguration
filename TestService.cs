using Microsoft.Extensions.Options;

namespace WebAppSample;

public class TestService
{
    private readonly MyConfigurationClass config;
    public TestService(IOptions<MyConfigurationClass> options)
    {
        config = options.Value;
    }

    public string Hello()
    {
        switch(config.Language)
        {
            case "PT-BR":
                return "Olá mundo !";
            case "EN-US":
                return "Hello World !";
            default:
                return ":-)";
        }
    }
}
