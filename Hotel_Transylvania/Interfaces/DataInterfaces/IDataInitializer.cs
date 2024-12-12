using Hotel_Transylvania.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.FakeDatabase
{
    public interface IDataInitializer
    {
        public ApplicationDbContext_FAKE SeedData();
    }
}
