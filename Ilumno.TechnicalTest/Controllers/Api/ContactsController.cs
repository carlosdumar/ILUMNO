using Ilumno.TechnicalTest.Models;
using System.Web.Http;
using System.Linq;
using Ilumno.TechnicalTest.DTOs;
using System;
using AutoMapper;

namespace Ilumno.TechnicalTest.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/contacts
        [HttpGet]
        public IHttpActionResult GetContacts(string query = null)
        {
            var contacts = from c in _context.Contacts
                           select new ContactDto()
                           {
                               Id = c.Id,
                               Name = c.Name,
                               LastName = c.LastName,
                               Email = c.Email,
                               PhoneNumber = c.PhoneNumber,
                               CellPhoneNumber = c.CellPhoneNumber
                           };

            return Ok(contacts);
        }

        // GET /api/contact/1
        [HttpGet]
        public IHttpActionResult GetContact(int id)
        {
            var contact = _context.Contacts
                .SingleOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST /api/contacts
        [Authorize(Roles = RoleName.CanManageContacts)]
        [HttpPost]
        public IHttpActionResult CreateContact(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = Mapper.Map<ContactDto, Contact>(contactDto);
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            contactDto.Id = contact.Id;

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contactDto);
        }

        // PUT /api/contacts/1
        [Authorize(Roles = RoleName.CanManageContacts)]
        [HttpPut]
        public IHttpActionResult UpdateContactr(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                return NotFound();

            Mapper.Map(contactDto, contactInDb);

            _context.SaveChanges();

            return Ok();

        }

        //  DELETE /api/contacts/1
        [Authorize(Roles = RoleName.CanManageContacts)]
        [HttpDelete]
        public IHttpActionResult DeleteContactr(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
    
}
