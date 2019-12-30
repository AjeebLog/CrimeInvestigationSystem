using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision___Crime_Investigation_System__22_7_2019_
{
    class connectionclass
    {
        private static string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Crime Investigation System\Vision - Crime Investigation System[22 - 7 - 2019]\Vision - Crime Investigation System[22 - 7 - 2019]\DatabaseKarachiPolice.mdf;Integrated Security=True");

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
