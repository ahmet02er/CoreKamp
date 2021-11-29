﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Context
{
    public class MsSqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RIEN; Database=CoreKampDb; integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>().HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<NewMessage>().HasOne(x => x.SenderUser)
               .WithMany(y => y.WriterSender)
               .HasForeignKey(z => z.MessageSenderId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<NewMessage>().HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.MessageReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter>  NewsLetters { get; set; }
        public DbSet<BlogRayting>  BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<NewMessage> NewMessages { get; set; }
    }
}
