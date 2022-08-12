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

           
        }
    }
}