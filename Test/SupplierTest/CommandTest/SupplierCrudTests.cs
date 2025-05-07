using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DomainLayer.Models;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore.InMemory;


[TestFixture]
public class SupplierCrudTests
{
    private AppDbContext _dbContext;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "SupplierTestDb")
            .Options;

        _dbContext = new AppDbContext(options);

        // Ensure database is clean
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext?.Dispose(); // This resolves NUnit1032
    }

    [Test]
    public async Task CreateSupplier_ShouldAddSupplier()
    {

        // Arrange: create a new Supplier object

        var supplier = new Supplier { SupplierName = "Supplier A", Email = "a@supplier.com" };

        // Act: add and save it to the in-memory DB

        _dbContext.Suppliers.Add(supplier);
        await _dbContext.SaveChangesAsync();

        // Assert: check if one supplier exists in the DB
        Assert.AreEqual(1, await _dbContext.Suppliers.CountAsync());
    }

    [Test]
    public async Task GetSupplierById_ShouldReturnCorrectSupplier()
    {
        // Arrange

        var supplier = new Supplier { SupplierName = "Supplier B", Email = "b@supplier.com" };
        _dbContext.Suppliers.Add(supplier);
        await _dbContext.SaveChangesAsync();

        // Act: retrieve supplier by ID
        var result = await _dbContext.Suppliers.FindAsync(supplier.SupplierId);

    
        // Assert: confirm the correct supplier was fetched
        Assert.IsNotNull(result);
        Assert.AreEqual("Supplier B", result.SupplierName);
    }
    // Tests retrieving all suppliers from the database

    [Test]
    public async Task GetAllSuppliers_ShouldReturnAll()
    {
        // Arrange: add multiple suppliers
        _dbContext.Suppliers.AddRange(
            new Supplier { SupplierName = "S1", Email = "s1@s.com" },
            new Supplier { SupplierName = "S2", Email = "s2@s.com" }
        );
        await _dbContext.SaveChangesAsync();

        // Act: retrieve all suppliers
        var all = await _dbContext.Suppliers.ToListAsync();

        // Assert: check count
        Assert.AreEqual(2, all.Count);
    }



    // Tests updating an existing supplier
    [Test]
    public async Task UpdateSupplier_ShouldModifySupplier()
    {
        var supplier = new Supplier { SupplierName = "Supplier C", Email = "c@supplier.com" };
        _dbContext.Suppliers.Add(supplier);
        await _dbContext.SaveChangesAsync();
        
        // Act: modify the name and update
        supplier.SupplierName = "Supplier C Updated";
        _dbContext.Suppliers.Update(supplier);
        await _dbContext.SaveChangesAsync();

        // Assert: verify change persisted
        var updated = await _dbContext.Suppliers.FindAsync(supplier.SupplierId);
        Assert.AreEqual("Supplier C Updated", updated.SupplierName);
    }

    [Test]
    public async Task DeleteSupplier_ShouldRemoveSupplier()
    {

        // Arrange
        var supplier = new Supplier { SupplierName = "Supplier D", Email = "d@supplier.com" };
        _dbContext.Suppliers.Add(supplier);
        await _dbContext.SaveChangesAsync();

        // Act: remove supplier
        _dbContext.Suppliers.Remove(supplier);
        await _dbContext.SaveChangesAsync();

        // Assert: check it's gone
        var deleted = await _dbContext.Suppliers.FindAsync(supplier.SupplierId);
        Assert.IsNull(deleted);
    }
}
