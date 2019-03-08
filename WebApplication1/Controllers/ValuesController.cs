using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILibRepository _librepository;
        private IMapper _mapper;

        public ValuesController(ILibRepository librepository,
            IMapper mapper)
        {
            _librepository = librepository;
            _mapper = mapper;
        }

        // GET api/values    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var ans = await _librepository.GetProductsAsync();
            
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(ans));
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var ans = await _librepository.GetProductAsync(id);

            if (ans != null) return Ok(_mapper.Map<ProductModel>(ans));
            else return NotFound("Product Id not exist");
        }

        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product p)
        {
            if(_librepository.GetProductAsync(p.Id)!= null)
            {
                return BadRequest("Product already Exists");
            }

            var ans = await _librepository.AddProductAsync(p);
            if (ans)
                return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
            else 
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
        }
        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product p)
        {
            if((await _librepository.GetProductAsync(id))==null) return NotFound($"Could not find Product with Id: {id}");

            
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
