using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();

            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.OpenHours = createContactDto.OpenHours;
            contact.MapLocation = createContactDto.MapLocation;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Contact added successfully");

        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _context.Contacts.Remove(value);
                _context.SaveChanges();
                return Ok("Contact removed succesfully");
            }
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = _context.Contacts.Find(updateContactDto.ContactId);

            if (contact == null)
            {
                return NotFound();
            }

            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.MapLocation = updateContactDto.MapLocation;

            _context.SaveChanges();
            return Ok("Contact updated successfully");

        }


    }
}
