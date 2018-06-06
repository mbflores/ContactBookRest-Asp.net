using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactBookRest.Models;
using Microsoft.Ajax.Utilities;

namespace ContactBookRest.Controllers.Api
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

            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("api/contacts")]
        public List<Contact> GetContacts()
        {

            return _context.Contacts.ToList();
        }

        [HttpGet]
        [Route("api/contacts/{id}")]
        public Contact GetContact(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(x => x.Id == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return contact;

        }

        [HttpPost]
        [Route("api/contacts")]
        public Contact CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        [HttpPut]
        [Route("api/contacts/{id}")]
        public Contact UpdateContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var contactInDb = _context.Contacts.SingleOrDefault(x => x.Id == id);
            if (contactInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            contactInDb.FirstName = contact.FirstName;
            contactInDb.LastName = contact.LastName;
            _context.SaveChanges();

            return contact;
        }

        [HttpDelete]
        [Route("api/contacts/{id}")]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var contactInDb = _context.Contacts.SingleOrDefault(x => x.Id == id);
            if (contactInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
        }
    }
}
