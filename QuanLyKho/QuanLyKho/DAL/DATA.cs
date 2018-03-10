using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho.DAL
{
    class DATA
    {
        public static DataTable xuat_DS()
        {
            return DataProvider.GetData("get_DS");

        }
    }
}
