using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client.Ver1.Resource
{
    public class DBProvider
    {
        static private string _dBFolderPath = ".\\Database";

        public static string DBFolderPath
        {
            get
            {
                if(!Directory.Exists(_dBFolderPath))
                    Directory.CreateDirectory(_dBFolderPath);
                return _dBFolderPath;
            }

            set
            {
                _dBFolderPath = value;
            }
        }
    }
}
