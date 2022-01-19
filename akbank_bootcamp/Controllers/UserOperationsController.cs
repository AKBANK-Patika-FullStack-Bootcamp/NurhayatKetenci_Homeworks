using akbank_bootcamp.Logs;
using DAL.Model;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static akbank_bootcamp.Controllers.DbOperations;

namespace akbank_bootcamp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersOperationsController : ControllerBase
    {
        List<User> userList = new List<User>();
        Result _result = new Result();

        DBOperations dbOperation = new DBOperations();
      

        [Authorize]
        [HttpGet]
        public List<User> GetUser()
        {

            return dbOperation.GetUsers();
        }

        [HttpGet("/UsersOperations/GetUserPaging")]
        public IActionResult GetUserPaging([FromQuery] OwnerParameters ownerParameters)
        {
            var owners = dbOperation.GetUsers() .Skip(ownerParameters.PageNumber) .Take(ownerParameters.PageSize) .ToList();


            return Ok(owners);
        }


        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            List<User> userList = new List<User>();

            User? resultObject = new User();
            resultObject = userList.Find(x => x.Id == id);
            return resultObject;

        }


        [HttpPost]
        public Result Post(User user)
        {
            User usr = dbOperation.FindUser(user.Name, user.UserName);
            bool userCheck = (usr != null) ? true : false;

            if (userCheck == false)
            {
                if (dbOperation.AddModel(user) == true)
                {
                    _result.status = 1;
                    _result.Message = "eklendi.";
                }
                else
                {
                    _result.status = 0;
                    _result.Message = " eklenemedi.";
                }

            }
            else
            {
                _result.status = 0;
                _result.Message = "Bu eleman listede zaten var.";
            }

            return _result;
        }

        [HttpPut("{UserId}")]
        public Result Update(int UserId, User newValue)
        {

            User? _oldValue = userList.Find(o => o.Id == UserId);
            if (_oldValue != null)
            {
                userList.Add(newValue);
                userList.Remove(_oldValue);

                _result.status = 1;
                _result.Message = "güncellendi";
                _result.UserList = userList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Bulunamadý.";
            }
            return _result;

        }

        [HttpDelete("{UserId}")]
        public Result Delete(int UserId)
        {
            if (dbOperation.DeleteModel(UserId))
            {
                _result.status = 1;
                _result.Message = "Kullanici silindi";
                _result.UserList = userList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Kullanici zaten silinmisti.";
            }
            return _result;
        }

    }
}