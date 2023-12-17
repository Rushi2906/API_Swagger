using APIDemo1.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using Unity.Interception.PolicyInjection.MatchingRules;

namespace APIDemo1.DAL
{
    public class Person_DAL : DAL_Helper
    {
        public List<PersonModel> API_Person_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("API_Person_SelectAll");
                List<PersonModel> list = new List<PersonModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        PersonModel pm = new PersonModel();
                        pm.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                        pm.Name = dr["Name"].ToString();
                        pm.Contact = dr["Contact"].ToString();
                        pm.Email = dr["Email"].ToString();
                        list.Add(pm);
                        Console.WriteLine(list);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------------Error--------------------------------");
                return null;
            }
        }

        public PersonModel API_Person_SelectByPK(int PersonID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                PersonModel personModel = new PersonModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    personModel.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                    personModel.Name = dr["Name"].ToString();
                    personModel.Email = dr["Email"].ToString();
                    personModel.Contact = dr["Contact"].ToString();
                }
                return personModel;
            }
            catch(Exception ex) {
                return null;
            }  
        }

        public int API_Person_Delete(int PersonID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase (ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                var person = sqlDatabase.ExecuteNonQuery(dbCommand);
                return person;
            }
            catch(Exception ex )
            {
                return 0;
            }
        }

        public int API_Person_Insert(string Name, string Contact, string Email)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, Email);
                int person = sqlDatabase.ExecuteNonQuery(dbCommand);
                return person;
            }
            catch( Exception ex )
            {
                return 0;
            }
        }

        public int API_Person_Update(int PersonID, string Name, string Contact, string Email)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_Update");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, Email);
                int person = sqlDatabase.ExecuteNonQuery(dbCommand);
                return person;
            }
            catch(Exception ex) 
            {
                return 0;
            }
        }
    }
}
