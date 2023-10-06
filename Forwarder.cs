using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    class Forwarder
    {
        string dir;
        public string Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        string dir2;

        public string Dir2
        {
            get { return dir2; }
            set { dir2 = value; }
        }

        int orderOfSort = 1;//jesli 1 - rosnaco, -1 = malejaco
        public int OrderOfSort
        {
            get { return orderOfSort; }
            set { orderOfSort = value; }
        }

        int orderOfSort2 = 1;//jesli 1 - rosnaco, -1 = malejaco
        public int OrderOfSort2
        {
            get { return orderOfSort2; }
            set { orderOfSort2 = value; }
        }

    }
}
