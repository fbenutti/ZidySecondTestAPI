using Microsoft.AspNetCore.Mvc;
using Zidy.Domain.Dto;
using Zidy.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zidy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IServiceCustomer _serviceCustomer;
        public CustomerController(IServiceCustomer serviceCustomer)
        {
            _serviceCustomer = serviceCustomer;
        }

        
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _serviceCustomer.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getusersbysector")]
        public async Task<IActionResult> GetUsersBySector()
        {
            try
            {
                List<User> users = await _serviceCustomer.GetUsersBySector();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getuserbyid/{id}")]
        public async Task<IActionResult> GetUsersBySector([FromRoute] long id)
        {
            try
            {
                User user = await _serviceCustomer.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("checksectordiagonal")]
        public async Task<IActionResult> CheckSectorDiagonal()
        {
            try
            {
                bool result = await _serviceCustomer.CheckSectorDiagonal();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
