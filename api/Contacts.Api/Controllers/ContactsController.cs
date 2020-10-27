using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts.Api.Data;
using Contacts.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var contacts = _contactRepository.GetAll();
            var result = _mapper.Map<ContactResponse[]>(contacts);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if(contact == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ContactResponse>(contact);
            return Ok(result);
        }
        [HttpPost("")]
        public IActionResult Create([FromBody]ContactRequest request)
        {
            var contact = _mapper.Map<Contact>(request);
            _contactRepository.Save(contact);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ContactRequest request)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            _mapper.Map(request, contact);
            _contactRepository.Save(contact);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            _contactRepository.Delete(id);
            return Ok();
        }
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
