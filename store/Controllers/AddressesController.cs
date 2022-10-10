using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Services.Interfaces;
using storeDTO.Account;
using storeDTO.Address;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService=addressService;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> GetAddresses()
        {
            return await _addressService.GetAllAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress([FromRoute] int id, [FromBody] UpdateAddressDTO address)
        {
            address.AddressId = id;
            await _addressService.UpdateAddressAsync(address);
            return Ok();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostAddress(AddressDTO address)
        {
            await _addressService.CreateAddressAsync(address);
            return Ok();
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok();
        }
    }
}
