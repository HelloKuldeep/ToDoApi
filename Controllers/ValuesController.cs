using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ICustomerRepo customerRepo;
        public ValuesController(ICustomerRepo _customerRepo){
            this.customerRepo = _customerRepo;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get(){
            List<Customer> cust = customerRepo.GetAll();
            if(cust != null){
                return Ok(cust);
            }
            return Ok("No Customer Found.");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer custId = customerRepo.GetCustomer(id);
            if( custId != null){
                return Ok(custId);
            }
            return NotFound($"Customer with id:{id} not found.");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer cust)
        {
            if(ModelState.IsValid){
                bool val = customerRepo.PostCustomer(cust);
                if(val)
                    return Created("/api/values",cust);
                else
                    return BadRequest("Customer already present.");
            }
            return BadRequest("MODE ERROR.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer cust){
            if(ModelState.IsValid){
                bool val = customerRepo.PutCustomer(id, cust);
                if(val)
                    return Created("/api/values",cust);
                else
                    return BadRequest($"Customer with id:{id} not present.");
            }
            return BadRequest("MODE ERROR.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool temp = customerRepo.DeleteCustomer(id);
            if( temp ){
                List<Customer> cust = customerRepo.GetAll();
                return Created("/api/values",cust);
            }
            return NotFound($"Customer with id:{id} not found.");
        }
    }
}
