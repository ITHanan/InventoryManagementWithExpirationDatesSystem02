using ApplicationLayer.Suppliers.Queries.GerSupplierByID;
using DomainLayer.Models;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;

//[TestFixture]
//public class Tests
//{
//    private GetSupplierByIdQueryHandler _handler;
//    private readonly AppDbContext _appDbContext;

//    [SetUp]
//    public void Setup()
//    {
//        // Use in-memory database for isolation
//        var options = new DbContextOptionsBuilder<AppDbContext>()
//            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // unique per test run
//            .Options;

//        _appDbContext = new AppDbContext(options);

//        // Seed a test supplier
//        _appDbContext.Suppliers.Add(new Supplier
//        {
//            SupplierId = 1,
//            SupplierName = "Hanan",
//            ContactPerson = "Me",
//            PhoneNumber = "07000000"
//        });

//        _appDbContext.SaveChanges();

//        _handler = new GetSupplierByIdQueryHandler(_appDbContext);
//    }

//    [Test]
//    public async Task Handle_ValidId_ReturnsCorrectSupplier()
//    {
//        // Arrange
//        var query = new GetSupplierByIdQuery(1);

//        // Act
//        var result = await _handler.Handle(query, CancellationToken.None);

//        // Assert
//        Assert.NotNull(result);
//        Assert.That(result.SupplierId, Is.EqualTo(1));
//        Assert.That(result.SupplierName, Is.EqualTo("Hanan"));
//    }
//}
