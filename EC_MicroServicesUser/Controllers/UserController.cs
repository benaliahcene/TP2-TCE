using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EC_MicroServicesUser.Controllers
{

    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("controller")]
    [ApiController]

   
    public class UserController : Controller
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;
        public UserController() {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }

       

          List<Models.User> Users = new List<Models.User>
        {
            new Models.User(){Id= 1, LastName="Yacine", FirstName="Yaddaden", Fonction="Vendeur"},
              new Models.User(){Id= 2, LastName = "Ousmen", FirstName = "yado", Fonction="Client"},
                new Models.User(){Id= 3, LastName = "Ahcene", FirstName = "BenAli", Fonction = "Client"}
        };
        [HttpGet]
        [Route("Users")]
        public IActionResult GetUser()
        {
            try
            {
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Users/{Id}")]
        public IActionResult GetUser(int userid)
        {
            try
            {
                Models.User user = Users.Where(t => t.Id == userid).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                    return StatusCode((int)StatusCodes.Status400BadRequest, new { message = "user n,existe pas" });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Users")]
        public IActionResult CreateUser([FromForm] Models.UserForm userform)
        {
            try
            {
                Users.Add(new Models.User()
                {
                    Id = Users.Max(t => t.Id) + 1,
                    LastName = userform.LastName,
                    FirstName = userform.FirstName,
                    Fonction = userform.Fonction,

                });
                return StatusCode(StatusCodes.Status201Created, Users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Users/{Usersid}")]
        public IActionResult UpdateUser(int Userid, [FromForm] Models.UserForm userForm)
        {
            try
            {
                Models.User user = Users.Find(t => t.Id == Userid);
                if (user != null)
                {
                    user.LastName = userForm.LastName;
                    user.FirstName = userForm.FirstName;
                    user.Fonction = userForm.Fonction;

                    // db.save changes
                    return Ok(Users);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "la tache n'existe pas" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("Users/{userId}")]
        public IActionResult RemoveUser(int userId)
        {
            try
            {
                Models.User user = Users.Find(t => t.Id == userId);
                if (user != null)
                {
                    Users.Remove(user);
                    return Ok(Users);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "la tache n'existe pas" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
