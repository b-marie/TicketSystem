using System;
using System.Collections.Generic;
using TicketSystem.Data;
using TicketSystem.Entities;

namespace TicketSystem.Business
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<Ticket> GetAllTickets()
        {
           return _ticketRepository.GetTickets();
        }

        public Ticket GetTicketById(int id)
        {
            //TODO security..
           return _ticketRepository.GetTicketById(id);
        }

        public Ticket CloseTicket(Ticket ticket, DateTimeOffset closeTime)
        {
            var currentTicket = GetTicketById(ticket.Id);
            if (currentTicket == null)
            {
                //Doesn't exist, probably create your own exception
                throw new Exception("Ticket not found");
            }

            if (currentTicket.ClosedAt != null)
            {
                throw new Exception("Ticket Already Closed");
            }

            currentTicket.ClosedAt = closeTime;
            _ticketRepository.UpdateTicket(ticket);
            return currentTicket; 
        }
    }
}
