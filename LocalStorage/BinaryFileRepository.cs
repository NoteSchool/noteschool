using CoreLibrary;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorage
{
    public class BinaryFileRepository : IRepository
    {
        string _path;

        public BinaryFileRepository( string path )
        {
            _path = path;
        }

        public void Save( NSContext c )
        {
            using (Stream output = new FileStream( _path, FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.SequentialScan ))
            {
                // File.Create(_path);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize( output, c );
            }
        }

        public NSContext LoadUnitializedContext()
        {
            using (Stream input = new FileStream( _path, FileMode.Open, FileAccess.Read, FileShare.None, 1024, FileOptions.SequentialScan ))
            {
                // File.Open(_path);
                BinaryFormatter formatter = new BinaryFormatter();
                return (NSContext)formatter.Deserialize( input );
            }

        }
    }
}
