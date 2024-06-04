using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        EFDbContext _dbContext = new EFDbContext();
        public IEnumerable<Game> Games
        {
            get
            {
                return _dbContext.Games;
            }
        }

        public void SaveGame(Game game)
        {
            if (game.Id == 0)
                _dbContext.Games.Add(game);
            else
            {
                Game dbEntry = _dbContext.Games.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Description = game.Description;
                    dbEntry.Price = game.Price;
                    dbEntry.Category = game.Category;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
