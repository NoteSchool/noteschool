using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using LocalAreaNetwork;
using LocalStorage;

namespace MulticastTester
{
    class Program
    {
        private static string _path = @"data.ns";
        private static IRepository _repo = new BinaryFileRepository(_path);
        private static ILocalAreaNetwork _lan = new LAN();
        private static NSContext c;
        private static NSContextServices cs = new NSContextServices(_repo, _lan);

        static void Main(string[] args)
        {
            c = new NSContext();

            c.Initialize(cs);


        }
    }
}
