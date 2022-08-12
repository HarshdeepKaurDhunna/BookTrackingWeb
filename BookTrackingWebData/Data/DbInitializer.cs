using BookTrackingWebLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrackingWebData.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookTrackingWebContext context)
        {
            context.Database.EnsureCreated();


            //Seed Data for CategoryType to intialize default values
            var CategoryTypies = new CategoryType[]
            {
                new CategoryType{CategoryTypeName="Fiction"},
                new CategoryType{CategoryTypeName="Non-Fiction"},

            };
            foreach (CategoryType c in CategoryTypies)
            {
                context.CategoryTypies.Add(c);
            }
            context.SaveChanges();
            //-----------------------------------//

            //Seed Data for Category to intialize default values
            foreach (Category c in new Category[]
            {

                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                             CategoryName="Romance Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Action-Adventure Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Science Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Fantasy Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Suspense Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Thriller Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="Horror Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 1).CategoryTypeId,
                            CategoryName="History Fiction"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Biographies and Autobiographies"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Memoirs"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Travel Writing"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Philosophy"},
                new Category{CategoryTypeId=context.Categories.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Religion and Spirituality"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Self-Help"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Science"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Medical"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Psychology"},
                new Category{CategoryTypeId=context.CategoryTypies.FirstOrDefault(x => x.CategoryTypeId == 2).CategoryTypeId,
                            CategoryName="Art"},


            })
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
            //-----------------------------------//

            //Seed Data for Category to intialize default values
            var Books = new Book[]
            {
              new Book{BookISBN="8765",BookTitle="The Other Planet",BookAuthor="Carson",BookAddedDate = DateTime.Now,
              CategoryId=context.Categories.FirstOrDefault(predicate: x => x.CategoryId == 2).CategoryId},
              new Book{BookISBN="8764",BookTitle="Harry Potter", BookAuthor="Alexander",BookAddedDate = DateTime.Now,
              CategoryId=context.Categories.FirstOrDefault(predicate: x => x.CategoryId == 2).CategoryId},
              new Book{BookISBN="8763",BookTitle="A Play",BookAuthor="Peter Sheffer",BookAddedDate = DateTime.Now,
              CategoryId=context.Categories.FirstOrDefault(predicate: x => x.CategoryId == 2).CategoryId},
              new Book{BookISBN="8762",BookTitle="Applied Numeric Analysis",BookAuthor="Curtis F Gerald",BookAddedDate = DateTime.Now,
              CategoryId=context.Categories.FirstOrDefault(predicate: x => x.CategoryId == 2).CategoryId},
            };
            foreach (Book b in Books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
            //-----------------------------------//
        }
    }
}