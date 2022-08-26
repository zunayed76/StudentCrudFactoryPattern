using studentcrudapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentcrudapi.Interfaces
{
    interface iItemUnit
    {
        string saveItemUnit(Item it);
        //string delItemUnit(Item it);
        List<Item> GetItem();
    }

}
