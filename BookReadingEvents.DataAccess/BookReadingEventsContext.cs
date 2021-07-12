﻿using BookReadingEvents.Domain;
using System.Data.Entity;

namespace BookReadingEvents.DataAccess
{
    public class BookReadingEventsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invitee> Invitees { get; set; }
    }
}
