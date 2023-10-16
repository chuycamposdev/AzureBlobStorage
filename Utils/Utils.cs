using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorage.Utils
{
    public static class Utils
    {
        public static Stream GetStreamFromContentBase64(string contentBase64)
        {
            byte[] bytes = Convert.FromBase64String(contentBase64);
            using MemoryStream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
