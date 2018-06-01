using CardGame.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Game
    {
        private int _countPlayers;
        public List<Player> players;
        private List<Card> cards;

        public int CompareCards(List<Card> list)
        {
            List<int> numArray = new List<int>();

            foreach (var item in list)
            {
                if (item.Type == "jack")
                {
                    numArray.Add(11);
                }
                else if (item.Type == "queen")
                {
                    numArray.Add(12);
                }
                else if (item.Type == "king")
                {
                    numArray.Add(13);
                }
                else if (item.Type == "ace")
                {
                    numArray.Add(14);
                }
                else
                {
                    numArray.Add(int.Parse(item.Type));
                }
            }

            int max = numArray.Max();
            int indexMax = 0;

            for (int i = 0; i < numArray.Count; i++)
            {
                if (numArray[i] == max)
                {
                    indexMax = i;
                }
            }
            return indexMax;
        }

        public void Start()
        {
            int _countPlayers = 4;

            players = new List<Player>()
            {
                new Player(){ Name = "Alex", cards = new Queue<Card>() },
                new Player(){ Name = "Sergey", cards = new Queue<Card>() },
                new Player(){ Name = "Max", cards = new Queue<Card>() },
                new Player(){ Name = "Alfar", cards = new Queue<Card>() }
            };

            //jack(валет), queen, king, ace(туз), diamond(буби), spade(пика), club(крести), heart
            cards = new List<Card>()
            { 
                #region создание колоды
                new Card() { Type = "6", Suit = "diamond" },
                new Card() { Type = "6", Suit = "spade" },
                new Card() { Type = "6", Suit = "club" },
                new Card() { Type = "6", Suit = "heart" },
                new Card() { Type = "7", Suit = "diamond" },
                new Card() { Type = "7", Suit = "spade" },
                new Card() { Type = "7", Suit = "club" },
                new Card() { Type = "7", Suit = "heart" },
                new Card() { Type = "8", Suit = "diamond" },
                new Card() { Type = "8", Suit = "spade" },
                new Card() { Type = "8", Suit = "club" },
                new Card() { Type = "8", Suit = "heart" },
                new Card() { Type = "9", Suit = "diamond" },
                new Card() { Type = "9", Suit = "spade" },
                new Card() { Type = "9", Suit = "club" },
                new Card() { Type = "9", Suit = "heart" },
                new Card() { Type = "10", Suit = "diamond" },
                new Card() { Type = "10", Suit = "spade" },
                new Card() { Type = "10", Suit = "club" },
                new Card() { Type = "10", Suit = "heart" },
                new Card() { Type = "jack", Suit = "diamond" },
                new Card() { Type = "jack", Suit = "spade" },
                new Card() { Type = "jack", Suit = "club" },
                new Card() { Type = "jack", Suit = "heart" } ,
                new Card() { Type = "queen", Suit = "diamond" },
                new Card() { Type = "queen", Suit = "spade" },
                new Card() { Type = "queen", Suit = "club" },
                new Card() { Type = "queen", Suit = "heart" } ,
                new Card() { Type = "king", Suit = "diamond" },
                new Card() { Type = "king", Suit = "spade" },
                new Card() { Type = "king", Suit = "club" },
                new Card() { Type = "king", Suit = "heart" } ,
                new Card() { Type = "ace", Suit = "diamond" },
                new Card() { Type = "ace", Suit = "spade" },
                new Card() { Type = "ace", Suit = "club" },
                new Card() { Type = "ace", Suit = "heart" }
                #endregion
            };

            //перетасовка колоды
           
                
            cards.Shuffle();

            //раздача карт
            int j = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (j >= _countPlayers)
                {
                    j = 0;
                }

                players[j++].cards.Enqueue(cards[i]);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Игрок1\t\tИгрок2\t\tИгрок3\t\tИгрок4");
            Console.ResetColor();

            List<Card> kon = new List<Card>();

            while (true)
            {
                if (players[0].cards.Count == 36 || players[1].cards.Count == 36 || players[2].cards.Count == 36 || players[3].cards.Count == 36)
                {
                    break;
                }

                //Формируем кон
                if (players[0].cards.Count > 0)
                    kon.Add(players[0].cards.Dequeue());
                else
                    kon.Add(new Card { Type = "-1", Suit = "-1" });

                if (players[1].cards.Count > 0)
                    kon.Add(players[1].cards.Dequeue());
                else
                    kon.Add(new Card { Type = "-1", Suit = "-1" });

                if (players[2].cards.Count > 0)
                    kon.Add(players[2].cards.Dequeue());
                else
                    kon.Add(new Card { Type = "-1", Suit = "-1" });

                if (players[3].cards.Count > 0)
                    kon.Add(players[3].cards.Dequeue());
                else
                    kon.Add(new Card { Type = "-1", Suit = "-1" });

                //Определил номер победителя
                int indexMax = CompareCards(kon) + 1;

                //Победитель забирает кон
                foreach (var item in kon)
                {
                    if (item.Type != "-1")
                    {
                        players[indexMax - 1].cards.Enqueue(item);
                    }
                }

                //Вывод на консоль
                Console.WriteLine("{0,5}-{1,7}\t{2,5}-{3,7}\t{4,5}-{5,7}\t{6,5}-{7,7}", (kon[0].Type != "-1" ? kon[0].Type : "проиграл"), (kon[0].Type != "-1" ? kon[0].Suit : ""), (kon[1].Type != "-1" ? kon[1].Type : "проиграл"), (kon[1].Type != "-1" ? kon[1].Suit : ""), (kon[2].Type != "-1" ? kon[2].Type : "проиграл"), (kon[2].Type != "-1" ? kon[0].Suit : ""), (kon[3].Type != "-1" ? kon[3].Type : "проиграл"), (kon[3].Type != "-1" ? kon[3].Suit : ""));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Победил {0} игрок", indexMax);
                Console.ResetColor();

                //очищаем кон
                kon.Clear();
            }
        }
    }
}
