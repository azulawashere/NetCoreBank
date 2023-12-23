using Microsoft.EntityFrameworkCore;
using NetCoreBank3169_0.Models.Entities;

namespace NetCoreBank3169_0.Models.Seed
{
    public static class DataSeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            UserCardInfo uInfo = new()
            {
                ID = 1,
                Balance = 10000,
                CardLimit = 10000,
                CardNumber = "1111 1111 1111 1111",
                CardUserName = "Test verisidir",
                CVC="222",
                ExpiryMonth = 12,
                ExpiryYear = 2024

            };

            modelBuilder.Entity<UserCardInfo>().HasData(uInfo);
        }
    }
}
