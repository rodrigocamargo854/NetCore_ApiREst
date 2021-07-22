using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.application.Controllers
{

    //?http://localhost:5000/api/users

    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _services;

        public UsersController(IUserService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 bad request
            }

            try
            {
                return Ok(await _services.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);//mensagem de erro
            }

        }
        //? estes endpoint espera um guid especifico
        //localhost:5000/api/users/54564646545654654
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 bad request
            }
            try
            {
                return Ok(await _services.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);//mensagem de erro
            }
        }
        //? Inserir informação para dar um insert dentro do Bd
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntities user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 bad request
            }
            try
            {
                var result = await _services.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.id })), result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);//mensagem de erro
            }
        }

        [HttpPut]
        //? Update  itens, recebe id
        public async Task<ActionResult> Put([FromBody] UserEntities user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 bad request
            }
            try
            {
                var result = await _services.Put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);//mensagem de erro
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 bad request
            }
            try
            {
                return Ok(await _services.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);//mensagem de erro
            }
        }
    }
}



