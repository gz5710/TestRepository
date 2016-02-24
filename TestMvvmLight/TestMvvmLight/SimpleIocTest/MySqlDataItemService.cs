using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmLight.Model
{
    class MySqlDataItemService : IDataItemService
    {
        /// <summary>
        /// Get a dataitem from MySQL database.
        /// </summary>
        /// <returns>A MySQL DataItem</returns>
        public DataItem GetItem()
        {
            return new DataItem("This is an item from MySQL.");
        }
    }
}
