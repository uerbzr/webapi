﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data.Services;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IPersonDataService _service;
        public UsersController(IPersonDataService service)
        {
            _service = service;            
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
           
            try
            {
                return Results.Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("id", Name ="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetUser(int id)
        {
            try
            {
                var person = _service.GetAll().Where(x => x.Id == id).FirstOrDefault();
                if (person == null) return Results.NotFound();
                return Results.Ok(person);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        [HttpDelete("{id}", Name ="DeleteUser")]
        public async Task<IResult> DeleteUser(int id)
        {
            try
            {
                if (_service.DeleteUser(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        
        [Route("")]
        [HttpPost]
        public async Task<IResult> AddUser(Person person)
        {
            try
            {
                if (_service.Add(person)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
