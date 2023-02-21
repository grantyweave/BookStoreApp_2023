using API_with_EF_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace API_with_EF_2023
{
    public class BoardGameRepository
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