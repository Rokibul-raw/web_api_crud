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
        //Get All data 
        [HttpGet]

        public async Task<IActionResult> GetInformation()
        {
            return Ok(await dbcontext.Informations.ToListAsync());
            
        }
        //get single data
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetInformation([FromRoute] Guid id)
        {
            var contact = await dbcontext.Informations.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        //add data
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
        //update data
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, Update_Info update_Info)
        {
            var contact = await dbcontext.Informations.FindAsync(id);

           if(contact!= null)
            {
                contact.FullName=update_Info.FullName;
                contact.Email = update_Info.Email;
                contact.Address = update_Info.Address;
                await dbcontext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
           
        }
        //delete data
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteInformation([FromRoute] Guid id)
        {
            var contact=await dbcontext.Informations.FindAsync(id);
            if( contact!= null)
            {
                dbcontext.Remove(contact);
                await dbcontext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
