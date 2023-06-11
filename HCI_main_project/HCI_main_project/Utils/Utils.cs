using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Utils
{
    public class Utils
    {
        public static string GetImagePath(string filename, string className)
        {
            return Path.Combine("Images", className, filename);
        }
    }
}
