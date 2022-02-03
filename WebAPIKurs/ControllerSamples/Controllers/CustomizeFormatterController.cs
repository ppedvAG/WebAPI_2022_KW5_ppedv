using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomizeFormatterController : ControllerBase
    {
        // GET -> Intern wird ein CustomizeFormatter verwendet 
        [HttpGet]
        public Contact GetContact() //OutputFormatter
        {
            Contact contact = new Contact();
            contact.ID = "1";
            contact.FirstName = "Otto";
            contact.LastName = "Walkes";

            return contact;
        }

        [HttpPost]
        public IActionResult Insert(Contact contacT)
        {
            return Ok();
        }

        //Post -> Intern wird ein CustomizeFormatter verwendet 
    }
}
