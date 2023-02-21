using API_with_EF_2023.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace API_with_EF_2023.Models.DAL
{
    public class BoardGameRespository
    {
        private GameContext _dbContext = new GameContext();

        public BoardGame AddBoardGame(BoardGame game)
        {
            _dbContext.BoardGames.Add(game);
            _dbContext.SaveChanges();
            return GetLatestBoardGame();
        }
        private BoardGame GetLatestBoardGame()
        {
            return _dbContext.BoardGames.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
