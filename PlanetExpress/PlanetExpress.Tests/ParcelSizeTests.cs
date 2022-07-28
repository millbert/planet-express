using PlanetExpress.Domain;

namespace PlanetExpress.Tests;

[TestClass]
public class ParcelSizeTests
{
    [TestMethod]
    public void NewParcel_WithValidDimensions_Small()
    {
        //Arrange
        const int height = 1;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var type = parcel.Type;
        Assert.AreEqual(ParcelType.Small, type, "Parcel not sized correctly");
    }

    [TestMethod]
    public void NewParcel_WithValidDimensions_Medium()
    {
        //Arrange
        const int height = 49;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var type = parcel.Type;
        Assert.AreEqual(ParcelType.Medium, type, "Parcel not sized correctly");
    }

    [TestMethod]
    public void NewParcel_WithValidDimensions_Large()
    {
        //Arrange
        const int height = 99;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var type = parcel.Type;
        Assert.AreEqual(ParcelType.Large, type, "Parcel not sized correctly");
    }

    [TestMethod]
    public void NewParcel_WithValidDimensions_XL()
    {
        //Arrange
        const int height = 100;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var type = parcel.Type;
        Assert.AreEqual(ParcelType.XL, type, "Parcel not sized correctly");
    }


    [TestMethod]
    public void NewParcel_WithInValidDimensions_ShouldThrowArgumentOutOfRange()
    {
        //Arrange
        const int height = -1;
        const int width = 0;
        const int length = 1;

        //Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Parcel(height, width, length), "Invalid parcel dimensions are being accepted");
    }
}