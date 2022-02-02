using ControllerSamples.Data;
using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ConventionsSampleController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ConventionsSampleController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        //http://localhost:5001/api/ConventionsSample/123
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status406NotAcceptable)]
        public ActionResult<Contact> GetContact(string id) //123
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            Contact currentContact = contactRepository.Get(id);

            if (currentContact == null)
                return NotFound(); //404

            return Ok(currentContact); //200
        }

        [HttpPost] //Hinzufügen von Datensetzten 
        public IActionResult Post(Contact contact)
        {
            contactRepository.Add(contact);

            return CreatedAtAction("GetContact", new { id = contact.ID }, contact); //201
        }


        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))] //Sammlung von ProducesResponseTypes
        public IActionResult Update(string id, Contact contact)
        {
            if (id != contact.ID)
                return BadRequest(); //400

            contactRepository.Update(contact);

            return NoContent(); //204
        }

    }
}
