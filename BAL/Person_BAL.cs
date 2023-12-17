using APIDemo1.DAL;
using APIDemo1.Models;

namespace APIDemo1.BAL
{
    public class Person_BAL
    {
        // Person Get All
         public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                Person_DAL person_DAL = new Person_DAL();
                List<PersonModel> personModels = person_DAL.API_Person_SelectAll();
                return personModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BAL");
                return null;
            }
        }

        public PersonModel API_Person_SelectByPK(int PersonId)
        {
            try
            {
                Person_DAL person_DAL = new Person_DAL();
                PersonModel personModels = person_DAL.API_Person_SelectByPK(PersonId);
                return personModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BAL");
                return null;
            }
        }

        public int API_Person_Delete(int PersonId)
        {
            try
            {
                Person_DAL person_DAL = new Person_DAL();
                var person = person_DAL.API_Person_Delete(PersonId);
                return person;
            }
            catch
            {
                return 0;
            }
        }

        public int API_Person_Insert(string Name,string Contact,string Email)
        {
            try
            {
                Person_DAL person_DAL = new Person_DAL();
                var person = person_DAL.API_Person_Insert(Name, Contact, Email);
                return person;
            }
            catch
            {
                return 0;
            }
        }

        public int API_Person_Update(int PersonID, string Name, string Contact, string Email)
        {
            try
            {
                Person_DAL person_DAL = new Person_DAL();
                var person = person_DAL.API_Person_Update(PersonID, Name, Contact, Email);
                return person;
            }
            catch
            {
                return 0;
            }
        }
    }
}
