using ArtUp.BankMockServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetcardByNumber(string Nubmer);
    }
}
