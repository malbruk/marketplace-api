using AutoMapper;
using Marketplace.API.Models;
using Marketplace.Core.DTOs;
using Marketplace.Core.Entities;
using Marketplace.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerPostModel model)
        {
            var newCustomer = await _customerService.AddAsync(_mapper.Map<Customer>(model));
            return Ok(_mapper.Map<CustomerDto>(newCustomer));
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerPostModel model)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }

            _mapper.Map(model, customer);
            await _customerService.UpdateAsync(customer);
            customer = await _customerService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
