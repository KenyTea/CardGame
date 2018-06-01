using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Modules
{
    public static class ListExtention
    {
        private static Random r = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            int sizeOfList = list.Count;

            while (list.Count > 1)
            {
                sizeOfList--;
                int randomNumber = r.Next(sizeOfList + 1);
                T buffer = list[randomNumber];
                list[randomNumber] = list[sizeOfList];
                list[sizeOfList] = buffer;
            }
        }
    }
}
