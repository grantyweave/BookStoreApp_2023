using API_with_EF_2023.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_with_EF_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        //BOARDGAME ADD ENDPOINT

        BoardGameRepository repo = new BoardGameRepository();

        [HttpPost("add")]
        public BoardGame AddBoardGame(string title, string description, int year, int count)
        {
            BoardGame newBoardGame = new BoardGame
            {
                Title = title,
                Description = description,
                YearPublished = year,
                RecommendedPlayerCount = count
            };
            return repo.AddBoardGame(newBoardGame);
        }

        //BOARD GAME LIST ENDPOINT

        [HttpGet()]
        public List<BoardGame> GetAll()
        {
            return repo.GetAllGames();
        }

        // AND REPO METHOD

        public List<BoardGame> GetAllGames()
        {
            return _dbContext.BoardGames.ToList();
        }


        //FIND BY ID METHOD

        public BoardGame FindById(int id)
        {
            // AsNoTracking will not lock the ID allowing updating it after finding it
            return _dbContext.BoardGames.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        //FIND BY ID ENDPOINT

        [HttpGet("{id}")]
        public BoardGame GetById(int id)
        {
            return repo.FindById(id);
        }

        //DELETE METHOD

        public bool DeleteById(int id)
        {
            BoardGame boardGame = FindById(id);
            if (boardGame == null)
            {
                return false;
            }
            _dbContext.BoardGames.Remove(boardGame);
            _dbContext.SaveChanges();
            return true;
        }

        //DELETE ENDPOINT

        [HttpPost("delete/{id}")]
        public HttpResponseMessage DeleteById(int id)
        {
            try
            {
                if (repo.DeleteById(id) == true)
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
    }

}
   