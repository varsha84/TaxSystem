using Microsoft.EntityFrameworkCore;
using TaxSystem.Data;
using TaxSystem.Models;
using TaxSystem.Repository;

namespace TaxSystem.Tests
{
    public class TaxRepositoryTest
    {
        private async Task<AppDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            
            databaseContext.TaxRecords.Add(
            new TaxRecord()
            {
                Municipality = "Cph",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 12, 31),
                TaxRate = 0.2,
                TaxType = TaxType.Yearly
            });
            await databaseContext.SaveChangesAsync();

            databaseContext.TaxRecords.Add(
            new TaxRecord()
            {
                Municipality = "Cph",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 5, 31),
                TaxRate = 0.4,
                TaxType = TaxType.Monthly
            });
            await databaseContext.SaveChangesAsync();

            databaseContext.TaxRecords.Add(
            new TaxRecord()
            {
                Municipality = "Cph",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                TaxRate = 0.1,
                TaxType = TaxType.Daily
            });
            await databaseContext.SaveChangesAsync();

            databaseContext.TaxRecords.Add(
            new TaxRecord()
            {
                Municipality = "Cph",
                StartDate = new DateTime(2025, 12, 25),
                EndDate = new DateTime(2025, 12, 25),
                TaxRate = 0.1,
                TaxType = TaxType.Daily
            });
            await databaseContext.SaveChangesAsync();

            /* // Check Weekly tax
             databaseContext.TaxRecords.Add(
            new TaxRecord()
            {
                Municipality = "Cph",
                StartDate = new DateTime(2025, 6, 9),
                EndDate = new DateTime(2025, 6, 15),
                TaxRate = 0.3,
                TaxType = TaxType.Weekly
            });
            await databaseContext.SaveChangesAsync();
           */

            return databaseContext;
        }

        [Fact]
        public async void GetDailyTaxRate()
        {
            //Arrange           
            double expectedResult = 0.1;
            var dbContext = await GetDatabaseContext();
            var taxRepo = new TaxRepository(dbContext);

            //Act
            var result = await taxRepo.GetTaxRecord("Cph", new DateTime(2025, 12, 25));

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void GetDailyTaxRate_2()
        {
            //Arrange           
            double expectedResult = 0.1;
            var dbContext = await GetDatabaseContext();
            var taxRepo = new TaxRepository(dbContext);

            //Act
            var result = await taxRepo.GetTaxRecord("Cph", new DateTime(2025, 01, 01));

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void GetMonthlyTaxRate()
        {
            //Arrange           
            double expectedResult = 0.4;
            var dbContext = await GetDatabaseContext();
            var taxRepo = new TaxRepository(dbContext);

            //Act
            var result = await taxRepo.GetTaxRecord("Cph", new DateTime(2025, 05, 13));

            //Assert
            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public async void GetYearlyTaxRate()
        {
            //Arrange           
            double expectedResult = 0.2;
            var dbContext = await GetDatabaseContext();
            var taxRepo = new TaxRepository(dbContext);

            //Act
            var result = await taxRepo.GetTaxRecord("Cph", new DateTime(2025, 06, 12));

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
