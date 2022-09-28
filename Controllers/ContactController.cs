using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCrudOp.data;
using WebApiCrudOp.model;

namespace WebApiCrudOp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly InforamtionDbContext dbcontext;

        public ContactController(InforamtionDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]

        public async Task<IActionResult> GetInformation()
        {
            return Ok(await dbcontext.Informations.ToListAsync());
            
        }
        [HttpPost]
        public async Task<IActionResult> AddInformatio(AddInformation addInformation)
        {
            var info = new Information()
            {
                Id = Guid.NewGuid(),
                FullName = addInformation.FullName,
                Email = addInformation.Email,
                Address = addInformation.Address,
            };
            await dbcontext.Informations.AddAsync(info);
            await dbcontext.SaveChangesAsync();
            return Ok(info);
        }
    }
}
