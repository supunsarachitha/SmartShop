using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Services
{
    public interface IQrSaveService
    {
        bool SaveImage(string txtInputvalue);

    }
}
