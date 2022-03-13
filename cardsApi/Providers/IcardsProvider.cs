using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cardsApi.Providers
{
    public interface IcardsProvider
    {
        List<string> getCardList();

        List<string> getPlayerCardList(int players);

        List<String> splitCards(List<String> cards);

        List<String> specialCards(List<String> cards);
    }
}
