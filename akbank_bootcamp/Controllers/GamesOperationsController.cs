using akbank_bootcamp.Logs;
using akbank_bootcamp.Model;
using Microsoft.AspNetCore.Mvc;

namespace akbank_bootcamp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesOperationsController : ControllerBase
    {
        private List<Game> gameList = new List<Game>();
        private Result result = new Result();
        Logger logger = new Logger();

        [HttpGet]
        public List<Game> GetData()
        {
            gameList = Add().OrderBy(x => x.Char).ToList();
            return gameList;
        }


        [HttpPost]
        public Result Post(Game game)
        {
           
            gameList = Add();
            bool gameCheck=gameList.Select(x => x.Id == game.Id || x.Char == game.Char).FirstOrDefault();
            if (gameCheck==false)
            {
                gameList.Add(game);
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

        [HttpGet("{Id}")]
        public Game GetById(int Id)
        {
            gameList = Add();
            Game resultObject = gameList.FirstOrDefault(x => x.Id == Id);
            return resultObject;
        }


        [HttpDelete("{Id}")]
        public Result Delete(int Id)
        {
            gameList=Add();
            Game? value = gameList.Find(x => x.Id == Id);
            if (value != null)
            {
                gameList.Remove(value);
                result.Status = 1;
                result.Message = "baþarýyla silindi";
                result.GameList = gameList;
                logger.createLog(Id.ToString() + " Id li veri " + result.Message,"deleteLog");
            }
            else
            {
                result.Status = 0;
                result.Message = "silinemedi";
            }
            return result;
        }


        [HttpPut("{Id}")]
        public Result Update(int Id, Game newValue)

        {
            gameList = Add();
            Game? oldValue = gameList.Find(x => x.Id == Id);
            if (oldValue != null)
            {
                oldValue = newValue;
                gameList.Add(newValue);
                gameList.Remove(oldValue);
                result.Status = 1;
                result.Message = "Baþarýyla güncellendi";
                result.GameList = gameList;
                logger.createLog(Id.ToString() + " Id li veri" + result.Message, "updateLog");


            }
            else
            {
                result.Status = 0;
                result.Message = "güncellenemedi";
            }
            return result;

        }

        public List<Game> Add()
        {
            gameList.Add(new Model.Game { Id = 1, Char = "raze", CharSkills = "bomb" });
            gameList.Add(new Model.Game { Id = 2, Char = "sage", CharSkills = "healing" });
            gameList.Add(new Model.Game { Id = 3, Char = "brimstone", CharSkills = "smoke" });
            gameList.Add(new Model.Game { Id = 4, Char = "reyna", CharSkills = "bell" });
            return gameList;
        }
    }
}