using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace WebApi.Services
{
    public class CardsService : ICardsService
    {
        public IEnumerable<Card> GetCards()
        {
            return new List<Card>()
            {
                new Card { Name="Shadow Wraith", Attack = 90, Defense = 50},
            };
        }
    }
}
