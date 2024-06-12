using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.Entities;

namespace WebAPIAutores.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            return new List<Author>() {
                new Author() { Id = 1, Name = "Tato" },
                new Author() { Id = 2, Name = "Canela" }
            };
        }       
    }
}