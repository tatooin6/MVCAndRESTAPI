using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entities;

namespace WebAPIAutores.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors
                .Include(author => author.Books)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            context.Add(author);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] // * api/authors/1
        public async Task<ActionResult> Put(Author author, int id)
        {
            if (author.Id != id)
            {
                return BadRequest("Request author id doesn't match URL id.");
            }
            
            context.Update(author);
            // TODO: try catch this
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] // * api/authors/2
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Authors.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            context.Remove(new Author() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}