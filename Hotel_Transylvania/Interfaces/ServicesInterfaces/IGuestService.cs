using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IGuestService
    {
        public void AddGuest(IGuest guest);
        public IEnumerable<IGuest> GetAllGuests();
        public void DisplayActiveGuests(int x, int y);
        public void DisplayInctiveGuests(int x, int y);

        public int CountAllGuests();
        public void RemoveGuest(int guestToDelete);
        public void ReActivateGuest(int guestToReactivate);


    }
}
