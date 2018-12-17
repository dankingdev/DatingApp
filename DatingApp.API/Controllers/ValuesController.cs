using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // http://localhost:5000/api/values - Kestrel web server listens on port 5000
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // We need to inject the data context into our controller
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        // We want to make this an asyncronous method in order to facilitate many users calling values from the db simultaneously
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // Go get a list of values from our database
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET api/values/5
        // We want to make this an asyncronous method in order to facilitate many users calling values from the db simultaneously
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
