using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayo
{
    public class Store
    {
        private const string StorageName = "DayoStore.txt";
        public void StoreMemoryList(string content)
        {
            System.IO.File.WriteAllText(StorageName, content);
        }

        public string ReadMemoryList()
        {
            if (System.IO.File.Exists(StorageName))
            {
                return System.IO.File.ReadAllText(StorageName);
            }

            return string.Empty;
        }
    }
}
