using APIDemo1.BAL;
using APIDemo1.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIDemo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        //[HttpGet]
        // Get All Records from Person Table
        //public List<PersonModel> API_Person_SelectAll()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

        [HttpGet]
        public IActionResult Get()
        {
            Person_BAL bal = new Person_BAL();
            List<PersonModel> person = bal.API_Person_SelectAll();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person.Count > 0 && person != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpGet("{PersonID}")]
        public IActionResult Get(int PersonID)
        {
            Person_BAL bal = new Person_BAL();
            PersonModel person = bal.API_Person_SelectByPK(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person.PersonID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpDelete("{PersonID}")]
        public IActionResult Delete(int PersonID)
        {
            Person_BAL person_BAL = new Person_BAL();
            var person = person_BAL.API_Person_Delete(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpPost]
        public IActionResult Post(string Name, string Contact, string Email)
        {
            Person_BAL person_BAL = new Person_BAL();
            var person = person_BAL.API_Person_Insert(Name, Contact, Email);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpPut("{PersonID}")]
        public IActionResult Put(int PersonID, string Name, string Contact, string Email)
        {
            Person_BAL person_BAL = new Person_BAL();
            var person = person_BAL.API_Person_Update(PersonID, Name, Contact, Email);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

    }
}
