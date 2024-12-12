using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;

namespace Hotel_Transylvania.Display
{
    public class DisplayCustomerInformation
    {
        //public static void ShowAllGuests(List<Guest> myGuests)
        //{
        //    foreach (Guest guest in myGuests)
        //    {

        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine(guest.GetFullName());
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        foreach (var order in guest.Reservations)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Ordernummer: " + order.OrderId);
        //            Console.ForegroundColor = ConsoleColor.Gray;
        //            Console.WriteLine("Datum: " + order.OrderDate);

        //            foreach (var product in order.Items)
        //            {
        //                Console.WriteLine("ProduktId: " + product.ProductId);
        //                Console.WriteLine("ProduktId: " + product.ProductName);
        //            }

        //            Console.WriteLine("Total kostnad: " + order.CalculateTotal() + " kr");
        //            Console.WriteLine("Förfallosdatum: " + order.Invoice.DueDate);

        //        }
        //        Console.WriteLine("======================================");
        //    }
        //}

        //    public static void ShowAllCustomersSpectre(List<IGuest> myGuest)
        //    {
        //        var table = new Spectre.Console.Table();
        //        table.Border = Spectre.Console.TableBorder.Double;
        //        table.AddColumn("[bold white on green]Ordernummer[/]");
        //        table.AddColumn("[blue]Namn[/]");
        //        table.AddColumn("[blue]Datum[/]");
        //        table.AddColumn("[blue]Produkter[/]");
        //        table.AddColumn("[blue]Total kostnad[/]");
        //        table.AddColumn("[blue]Förfallodatum[/]");

        //        foreach (var guest in myGuest)
        //        {
        //            foreach (var order in guest.Reservation)
        //            {
        //                var productNames = string
        //                    .Join(", ", order.Items
        //                    .Select(i => i.ProductName));

        //                table.AddRow(
        //                    order.OrderId.ToString(),
        //                    guest.GetFullName(),
        //                    order.OrderDate.ToString("yyyy-MM-dd"),
        //                    productNames,
        //                    $"{order.CalculateTotal()} kr",
        //                    order.Invoice.DueDate.ToString("yyyy-MM-dd")
        //                );
        //            }
        //        }

        //        Spectre.Console.AnsiConsole.Write(table);
        //    }

        //}
    }
}
