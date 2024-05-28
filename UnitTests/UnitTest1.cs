using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WebUI.Controllers;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using WebUI.Models;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void Can_Paginate()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game
                {
                    Name = "Assassin's",
                    Price = 4999
                },
                new Game
                {
                    Name = "Call of Duty",
                    Price = 5699
                },
                new Game
                {
                    Name = "The Last of Us 2",
                    Price = 4599
                },
                new Game
                {
                    Name = "Call of Duty 2",
                    Price = 4999
                }
            });
            
            GameController controller = 
                new GameController(mock.Object);

            controller.pageSize = 3;

            GamesListViewModel gamesListViewModel
               = (GamesListViewModel)controller.List(2).Model;

            List<Game> games = gamesListViewModel.Games.ToList();

            Assert.IsTrue(games.Count == 1);
            Assert.AreEqual(games[0].Name, "Call of Duty 2");
            //Assert.AreEqual(games[1].Name, "Call of Duty");
        }*/

        /* [TestMethod]
       public void Can_Send_Pagination_View_Model()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game
                {
                    Name = "Assassin's",
                    Price = 4999
                },
                new Game
                {
                    Name = "Call of Duty",
                    Price = 5699
                },
                new Game
                {
                    Name = "The Last of Us 2",
                    Price = 4599
                },
                new Game
                {
                    Name = "Call of Duty 2",
                    Price = 4999
                }
            });

            GameController controller =
                new GameController(mock.Object);

            controller.pageSize = 3;

            GamesListViewModel gamesListViewModel
                = (GamesListViewModel)controller.List(2).Model;

            PagingInfo pagingInfo = gamesListViewModel.PagingInfo;

            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 4);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }*/

        [TestMethod]
        public void Can_Create_Categories()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game
                {
                    Name = "Assassin's",
                    Price = 4999,
                    Category = new Category
                    {
                        Name = "rpg"
                    }
                },
                new Game
                {
                    Name = "Call of Duty",
                    Price = 5699,
                    Category = new Category
                    {
                        Name = "шутер"
                    }
                },
                new Game
                {
                    Name = "The Last of Us 2",
                    Price = 4599,
                    Category = new Category
                    {
                        Name = "шутер"
                    }
                },
                new Game
                {
                    Name = "Call of Duty 2",
                    Price = 4999,
                    Category = new Category
                    {
                        Name = "симулятор"
                    }
                }
            });

            NavController navController = new NavController(mock.Object);

            List<string> results = ((IEnumerable<string>)navController
                .Menu().Model).ToList();

            Assert.AreEqual(results.Count(), 3);
            Assert.AreEqual(results[0], "rpg");
            Assert.AreEqual(results[1], "симулятор");
            Assert.AreEqual(results[2], "шутер");
        }

        [TestMethod]
        public void Can_Filter_Games()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game
                {
                    Name = "Assassin's",
                    Price = 4999,
                    Category = new Category
                    {
                        Name = "rpg"
                    }
                },
                new Game
                {
                    Name = "Call of Duty",
                    Price = 5699,
                    Category = new Category
                    {
                        Name = "шутер"
                    }
                },
                new Game
                {
                    Name = "The Last of Us 2",
                    Price = 4599,
                    Category = new Category
                    {
                        Name = "шутер"
                    }
                },
                new Game
                {
                    Name = "Call of Duty 2",
                    Price = 4999,
                    Category = new Category
                    {
                        Name = "симулятор"
                    }
                }
            });

            GameController gameController = new GameController(mock.Object);
            gameController.pageSize = 3;

            List<Game> result = ((GamesListViewModel)gameController
                .List("симулятор", 1).Model).Games.ToList();
            Assert.AreEqual(result.Count(), 1);
            Assert.IsTrue(result[0].Name == "Call of Duty 2"
                && result[0].Category.Name == "симулятор");
        }
    }
}
