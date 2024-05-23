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
    }
}
