using akbank_homeworkone.Model;
using Microsoft.AspNetCore.Mvc;


namespace akbank_homeworkone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOperationsController : ControllerBase
    {
        List<User> userList = new List<User>();
        Result result = new Result();
        Logger logger = new Logger();
        [HttpGet]
        public List<User> GetUser()
        {
            userList = AddUser().OrderBy(x=>x.Name).ToList();
            return userList;
        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            List<User> userList = new List<User>();
            userList = AddUser();
            User resultObject = userList.FirstOrDefault(x => x.Id == id);
            return resultObject;     
        }

        public List<User> AddUser()
        {
            List<User> list = new List<User>();
            list.Add(new Model.User { Id = 1, Name = "nurkki", IdentityNumber = "54789563456", Age = 21, email = "nurhayatktnn8@gmail.com" });
            list.Add(new Model.User { Id = 2, Name = "rümeysa", IdentityNumber = "54789563456", Age = 21, email = "rumeysa@gmail.com" });
            list.Add(new Model.User { Id = 3, Name = "yonca", IdentityNumber = "54789563456", Age = 21, email = "yonca@gmail.com" });
            list.Add(new Model.User { Id = 4, Name = "fatma", IdentityNumber = "54789563456", Age = 21, email = "fatma@gmail.com" });
            return list;
        }
        [HttpPost]
        public Result Post(User user)
        {
           
            userList = AddUser();
            bool userCheck=userList.Select(x => x.Id == user.Id || x.Name == user.Name).FirstOrDefault();
            if (userCheck==false)
            {
                userList.Add(user);
                result.Message = "Yeni elemean listeye eklendi";
                result.Status = 1;
             
            }
            else
            {
                result.Message = "Bu eleman listede zaten var";
                result.Status = 1;
            }
            return result;
        }

        [HttpPut("{Id}")]
        public Result Update(int Id, User newValue)
        {
         userList = AddUser();
         User? oldValue= userList.Find(x=>x.Id==Id);
            if (oldValue != null)
            {
                oldValue = newValue;
                userList.Add(newValue);
                userList.Remove(oldValue);
                result.Status = 1;
                result.Message = "Baþarýyla güncellendi";
                result.UserList = userList;
            }
            else
            {
                result.Status = 0;
                result.Message = "güncellenemedi";
            }
            return result;

        }

        [HttpDelete("{Id}")]
        public Result Delete(int Id)
        {
            userList= AddUser();
            User? value = userList.Find(x => x.Id == Id);
            if (value != null)
            {
                userList.Remove(value);
                result.Status = 1;
                result.Message = "baþarýyla silindi";
                result.UserList= userList;
                logger.createLog(Id.ToString()+" Id li "+ result.Message);
            }
            else
            {
                result.Status = 0;
                result.Message = "silinemedi";
            }
            return result;
        }
    }
}