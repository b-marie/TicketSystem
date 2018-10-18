using System;
using System.Collections.Generic;
using System.Data;
using TicketSystem.Entities;

namespace TicketSystem.Data
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int id);
        List<Ticket> GetTickets();
        void UpdateTicket(Ticket ticket);
    }

    public class TicketRepository : ITicketRepository
    {


        private readonly IDbConnection _db;

        public TicketRepository(IDbConnection db)
        {
            _db = db;
        }

        public void UpdateTicket(Ticket ticket)
        {
            Console.WriteLine("ticket updated");
        }

        public Ticket GetTicketById(int id)
        {
            return new Ticket()
            {
                Id = id,
                Title = $"My Ticket {id}",
                Description = "Ticket Description",
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
            };
        }

        public List<Ticket> GetTickets()
        {
            return new List<Ticket>
            {
                GetTicketById(1),
                GetTicketById(2),
                GetTicketById(3),
            };
        }




    }
}
