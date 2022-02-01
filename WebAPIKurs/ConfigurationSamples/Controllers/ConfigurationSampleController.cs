using ConfigurationSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationSampleController : ControllerBase
    {
        private IConfiguration _configuration;
        //Wie greifen wir auf unseren IOC Container zu?

        //Konstruktor Injection -> _configuration kann man in jeder Methode verwenden
        public ConfigurationSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/IConfigurationSample")]
        public ContentResult IConfigurationSample ([FromServices] IConfiguration configuration)
        {
            string myKeyValue = configuration["MyKey"];
            string title = configuration["Position:Title"];
            string name = configuration["Position:Name"];
            string defaultLogLevel = configuration["Loggin:LogLevel:Default"];

            return Content($"{myKeyValue} - {title} - {name} - {defaultLogLevel}");
        }

        [HttpGet("/PositionOptionsBindingSample")]
        public ContentResult PositionOptionsBindingSample([FromServices] IOptionsSnapshot<PositionOptions> positionOptionsSnmapshot)
        {
            PositionOptions positionOptions = positionOptionsSnmapshot.Value;
            return Content($"{positionOptions.Title} - {positionOptions.Name}");
        }
    }
}
