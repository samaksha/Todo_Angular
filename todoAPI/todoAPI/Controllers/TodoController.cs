using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoAPI.Data;
using todoAPI.Models;

namespace todoAPI.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class TodoController : Controller
    {
        private readonly todoAPIDbContext dbContext;
        public TodoController(todoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContactById(long id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                return Ok(contact);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {

                Title = addContactRequest.Title,
                IsComplete = addContactRequest.IsComplete
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> CompleteTodo(long id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.IsComplete = true ;
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbContext.Remove(contact);
                dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
