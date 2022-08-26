using studentcrudapi.BaseFactories;
using studentcrudapi.BaseInterfaces;
using studentcrudapi.Interfaces;
using studentcrudapi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentcrudapi.Factories
{
    public class ItemUnit: iItemUnit
    {
        private iGenericFactory<Item> genericobj = null;

        public string saveItemUnit(Item it)
        {
            genericobj = new GenericFactory<scDBEntities, Item>();
            string spQuery = "";
            string result = "";
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", it.id);
                ht.Add("firstName", it.firstName);
                ht.Add("lastName", it.lastName);
                ht.Add("dob", it.dob);
                ht.Add("sub1", it.sub1);
                ht.Add("num1", it.num1);
                ht.Add("sub2", it.sub2);
                ht.Add("num2", it.num2);
                ht.Add("sub3", it.sub3);
                ht.Add("num3", it.num3);
                ht.Add("sub4", it.sub4);
                ht.Add("num4", it.num4);
                int iid = it.id;
                spQuery = "[InsertData]";
                result = genericobj.ExecuteCommandString(spQuery, ht, iid);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return result;
        }

        //public string delItemUnit(Item it)
        //{
        //    genericobj = new GenericFactory<scDBEntities, Item>();
        //    string spQuery = "";
        //    string result = "";
        //    try
        //    {
        //        Hashtable ht = new Hashtable();
        //        ht.Add("id", it.id);
        //        spQuery = "[DeleteData]";
        //        result = genericobj.ExecuteCommandString1(spQuery, ht);
        //    }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //    }
        //    return result;
        //}


        public List<Item> GetItem()
        {
            genericobj = new GenericFactory<scDBEntities, Item>();
            List<Item> lst = genericobj.ExecuteQuery();
            return lst;
        }
    }
}