using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.BLL.Services
{
    public class BercodeService
    {
       public void Get(string barcode)
        {
            var url = $"http://www.barcodeid.com/{barcode}";
        }
    }
}
