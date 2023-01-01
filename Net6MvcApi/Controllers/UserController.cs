using Microsoft.AspNetCore.Mvc;

namespace Net6MvcApi.Controllers;

[ApiController]
// Endpoint api/User
//[Route(template:"api/[controller]")]
[Route(template:"api/user")]

public class UserController: ControllerBase {
    // GET: api/<UserController>
    [HttpGet]
    public IEnumerable<string> Get() {
        return new string[] {"u1","u2"};
    }

    // GET api/<UserController>/1
    [HttpGet(template:"{id}")]
    public string Get(int id) {
        return $"value {id}";
    }

    // POST api/<UserController>
    [HttpPost]
    public void Post([FromBody] string value) {
        
    }

    // PUT api/<UserController>/1
    [HttpPut(template:"{id}")]
    public void Put(int id, [FromBody] string value) {

    }

    [HttpDelete(template:"{id}")]
    public void Delete(int id) {

    }
}