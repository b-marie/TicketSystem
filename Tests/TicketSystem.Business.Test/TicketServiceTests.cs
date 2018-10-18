using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TicketSystem.Data;
using TicketSystem.Entities;

namespace TicketSystem.Business.Test
{
    [TestClass]
    public class TicketServiceTests
    {
        [TestMethod]
        public void CloseTicket_Cannot_Close_Already_Closed_Ticket()
        {
            //arrange
            var ticket = new Ticket
            {
                Id = 1,
                ClosedAt = DateTimeOffset.Now.AddDays(-1)
            };
            //Mock the ticket repo
            var mockTicketRepo = Substitute.For<ITicketRepository>();
            //Need to tell the mock thing what it returns
            mockTicketRepo.GetTicketById(ticket.Id).Returns(ticket);

            var ticketService = new TicketService(mockTicketRepo);
            //act
            try
            {
                var expectedTicket = ticketService.CloseTicket(ticket, DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Ticket Already Closed", ex.Message);
                return;
            }
            //assert
            Assert.Fail("Shouldn't have gotten here");

        }

        [TestMethod]
        public void CloseTicket_Can_Close_Ticket()
        {
            //arrange
            var ticket = new Ticket
            {
                Id = 1,
                ClosedAt = null
            };
            //Mock the ticket repo
            var mockTicketRepo = Substitute.For<ITicketRepository>();
            //Need to tell the mock thing what it returns
            mockTicketRepo.GetTicketById(ticket.Id).Returns(ticket);

            var ticketService = new TicketService(mockTicketRepo);

            //act
            DateTimeOffset now = DateTimeOffset.Now;
            var expectedTicket = ticketService.CloseTicket(ticket, now);
            //assert
            Assert.AreEqual(expectedTicket.ClosedAt, now);

        }
    }
}
