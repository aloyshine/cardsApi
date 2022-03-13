using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace cardsApi.Providers
{
    public class cardsProvider : IcardsProvider
    {
        private readonly string[] totalCards = new string[57] { "4T", "2T", "ST", "PT", "RT",
            "2D", "3D", "4D" ,"5D", "6D","7D", "8D","9D","10D","JD","QD","KD","AD",
            "2S", "3S", "4S" ,"5S", "6S","7S", "8S","9S","10S","JS","QS","KS","AS",
            "2C", "3C", "4C" ,"5C", "6C","7C", "8C","9C","10C","JC","QC","KC","AC",
            "2H", "3H", "4H" ,"5H", "6H","7H", "8H","9H","10H","JH","QH","KH","AH"};
     
        public List<String> getCardList()
        {
            List<String> cards = new List<String>();
            return totalCards.ToList();
        }

        public List<String> getPlayerCardList(int players)
        {
            List<String> selectedCards = new List<String>();

            int myCards = totalCards.Length / players;

            int i = 0;
            while(i < myCards)
            {
                Random r = new Random();
                int index = r.Next(0, 56);
                if(!selectedCards.Contains(totalCards[index]))
                {
                    selectedCards.Add(totalCards[index]);
                    i++;
                }
            }
            return selectedCards.ToList();
        }

        //rework needed get a proper sorting algo
        public List<String> splitCards(List<String> cards)
        {
           
           int k = 0;
           string[] sortPriority = {"D", "S", "C", "H" };
           List<String> sortedList = new List<String>();
           List<String> special = specialCards(cards);

           if(special.Count!=0)
           {
                sortedList.AddRange(special);
            }
          
           while(k < sortPriority.Length)
           {
                int i = 0;
                SortedList<int, String> TempList = new SortedList<int, String>();
                while ((i < cards.Count))
                {
                              
                    if ((cards[i].Contains(sortPriority[k])) && (totalCards.Contains(cards[i])) && (!cards[i].Contains("T")))
                    {

                        int key = 0;
                        if (cards[i].Contains("10"))
                        {
                            key = 10;
                        }
                        else if (cards[i].Contains("J"))
                        {
                            key = 11;
                        }
                        else if (cards[i].Contains("Q"))
                        {
                            key = 12;
                        }
                        else if (cards[i].Contains("K"))
                        {
                            key = 13;
                        }
                        else if (cards[i].Contains("A"))
                        {
                            key = 14;
                        }
                        else
                        {
                            
                            
                        string newCard = cards[i].Substring(0, 1);
                        key = Convert.ToInt32(newCard);
                            
                           
                        }
                        TempList.Add(key, cards[i]);
                    }
                  
                    i++;
                }
                if (TempList.Values.Count != 0)
                {
                    sortedList.AddRange(TempList.Values);
                    k++;
                } 
           }
           
            return sortedList;
        }

        public List<String> specialCards(List<String> cards)
        {
            int i = 0;
            List<String> specialList = new List<String>();
            SortedList<int, String> TempList = new SortedList<int, String>();
            while ((i < cards.Count))
            {
                if ((cards[i].Contains("T")) && (totalCards.Contains(cards[i])))
                {
                    int key = 0;
                    if (cards[i].Contains("4"))
                    {
                        key = 1;
                    }
                    else if (cards[i].Contains("S"))
                    {
                        key = 3;
                    }
                    else if (cards[i].Contains("P"))
                    {
                        key = 4;
                    }
                    else if (cards[i].Contains("R"))
                    {
                        key = 5;
                    }
                    else
                    {
                        string newCard = cards[i].Substring(0, 1);
                        key = Convert.ToInt32(newCard);
                    }
                    TempList.Add(key, cards[i]);
                }
                i++;
            }
            specialList.AddRange(TempList.Values);
            return specialList;
        }

    }
}

