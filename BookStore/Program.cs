using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Program
    {
        /// <summary>
        /// Method Name: Main
        /// Purpose    : Main method to calculate order cost and tax.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                List<BookDetails> bookDetails = null;// = new List<BookDetails>();

                bookDetails = AddBooks(bookDetails);

                Console.WriteLine($"Discount for {Category.Crime} Category : 5%");

                Console.WriteLine();
                Console.WriteLine($"-----------------------------------------------------------------");
                Console.WriteLine($"|   Book Name               |   Category        |   Total Cost  |");
                Console.WriteLine($"-----------------------------------------------------------------");
                double costBeforeTax = 0;
                double crimeDiscountRate = 5;

                foreach (var bookDetail in bookDetails)
                {
                    costBeforeTax = (bookDetail.Genre == Category.Crime) ?
                        costBeforeTax + CalculateDiscount(crimeDiscountRate, bookDetail.TotalCost) :
                        costBeforeTax + bookDetail.TotalCost;

                    Console.WriteLine(bookDetail);
                }

                Console.WriteLine($"\n\n Total Order Cost (Without Tax) : {Math.Round(costBeforeTax, 2)}");
                Console.WriteLine("\n\n Total Tax : 10%");

                double taxRate = costBeforeTax * 10 / 100;
                double taxAmount = costBeforeTax + taxRate;

                Console.WriteLine($" Total Order Cost (With Tax)    : {Math.Round(taxAmount, 2)}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method Name : AddBookDetails
        /// Purpose     : Add books to the BookDetails Object.
        /// </summary>
        /// <param name="bookDetails"></param>
        static List<BookDetails> AddBooks(List<BookDetails> bookDetails)
        {
            bookDetails = new List<BookDetails>
            {
                new BookDetails { BookName = "Unsolved crimes", Genre = Category.Crime,TotalCost = 10.99 },
                new BookDetails { BookName = "A Little Love Story", Genre = Category.Romance,TotalCost = 2.40 },
                new BookDetails { BookName = "Heresy", Genre = Category.Fantasy,TotalCost = 6.80},
                new BookDetails { BookName = "Jack the Ripper", Genre = Category.Crime,TotalCost = 16.00},
                new BookDetails { BookName = "The Tolkien Years", Genre = Category.Fantasy,TotalCost = 22.90 },
            };

            //bookDetails.Add(AddBookDetails("Unsolved crimes", Category.Crime, 10.99));
            //bookDetails.Add(AddBookDetails("A Little Love Story", Category.Romance, 2.40));
            //bookDetails.Add(AddBookDetails("Heresy", Category.Fantasy, 6.80));
            //bookDetails.Add(AddBookDetails("Jack the Ripper", Category.Crime, 16.00));
            //bookDetails.Add(AddBookDetails("The Tolkien Years", Category.Fantasy, 22.90 ));
            return bookDetails;
        }

        ///// <summary>
        ///// Method Name : AddBookDetails
        ///// Purpose     : Add book details to the BookDetails object.
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="genre"></param>
        ///// <param name="cost"></param>
        ///// <returns>BookDetails</returns>
        //static BookDetails AddBookDetails(string name, Category genre, double cost)
        //{
        //    return new BookDetails
        //    {
        //        BookName = name,
        //        Genre = genre,
        //        TotalCost = cost
        //    };
        //}

        /// <summary>
        /// Method Name : CalculateDiscount
        /// Purpose     : Calculates discount
        /// </summary>
        /// <param name="discountRate"></param>
        /// <param name="totalAmount"></param>
        /// <returns>double</returns>
        static double CalculateDiscount(double discountRate, double totalAmount)
        {
            try
            {
                var discountedAmount = totalAmount * discountRate / 100;
                return totalAmount - discountedAmount;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
    
    
}
