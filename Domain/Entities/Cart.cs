using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> cartLineList
            = new List<CartLine>();

        public void AddItem(Game game, int quantity)
        {
            CartLine line = cartLineList
                .Where(g => g.Game.Id == game.Id)
                .FirstOrDefault();

            if (line == null)
                cartLineList .Add(
                    new CartLine
                    {
                        Game = game,
                        Quantity = quantity
                    });
            else 
                line.Quantity += quantity;
        }
        public void RemoveItem(Game game)
        { 
            cartLineList.RemoveAll(g => 
            g.Game.Id == game.Id);
        }
        public void Clear()
        {
            cartLineList.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return cartLineList; }
        }
        public decimal ComputeTotalPrice()
        {
            return cartLineList
                .Sum(g => g.Game.Price * g.Quantity);
        }
    }
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}
