using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Download_Manger
{
   static class App
    {
        static DataSet1 db;
        
        public static DataSet1 DB
        {

            get
            {
                if (db == null)
                    db = new DataSet1();
                return db;
            }
        }

    }
}
