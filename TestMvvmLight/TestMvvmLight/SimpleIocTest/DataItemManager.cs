using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMvvmLight.Model;

namespace TestMvvmLight.SimpleIocTest
{
    public class DataItemManager
    {
        private readonly IDataItemService _dataItemService;
        public DataItemManager(IDataItemService dataItemService)
        {
            this._dataItemService = dataItemService;
        }
        public void DisplayItem()
        {
            var item = this._dataItemService.GetItem();
            Console.WriteLine(item);
            Debug.WriteLine(item);
        }
    }
}
