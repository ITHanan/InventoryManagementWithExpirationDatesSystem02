using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DomainLayer.Models;
using infrastructureLayer.Database;

[TestFixture]
public class GetSupplierByIdTest
{
    private AppDbContext _dbContext;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("GetSupplierByIdTestDb")
            .Options;

        _dbContext = new AppDbContext(options);

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task ShouldReturnCorrectSupplierById()
    {
        // Arrange
        var supplier = new Supplier
        {
            SupplierName = "Test Supplier",
            Email = "test@supplier.com"
        };

        _dbContext.Suppliers.Add(supplier);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _dbContext.Suppliers.FindAsync(supplier.SupplierId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test Supplier", result.SupplierName);
        Assert.AreEqual("test@supplier.com", result.Email);
    }
}
 