using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookDetails
    {
        public string BookName { get; set; }
        public Category Genre { get; set; }
        public double TotalCost { get; set; }

        public override string ToString()
        {
            return $"|{BookName.PadRight(20)}       | {Genre.ToString().PadRight(18)}|  {TotalCost:00.00}        |";
        }
    }

    public enum Category
    {
        Crime = 1,
        Romance = 2,
        Fantasy = 3,
        thriller = 4
    }
}
