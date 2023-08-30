using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class SingletonDatabase
    {
        private static KpopZtationEntities db = null;

        private SingletonDatabase()
        {

        }

        public static KpopZtationEntities getInstance()
        {
            if (db == null)
            {
                db = new KpopZtationEntities();
            }
            return db;
        }
    }
}