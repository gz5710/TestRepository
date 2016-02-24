using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvmLight.Model
{
    class OracleDataItemService : IDataItemService
    {
        /// <summary>
        /// Get a dataitem from Oracle Database.
        /// </summary>
        /// <returns>An Oracle DataItem</returns>
        public DataItem GetItem()
        {
            return new DataItem("This is an item from Oracle.");
        }
    }
}
