namespace PlanetExpress.Tests;

[TestClass]
public class ParcelPriceTests
{
    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Small()
    {
        //Arrange
        const int height = 1;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingSmall, price, "Small parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Medium()
    {
        //Arrange
        const int height = 49;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingMedium, price, "Medium parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Large()
    {
        //Arrange
        const int height = 99;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingLarge, price, "Large parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_XL()
    {
        //Arrange
        const int height = 100;
        const int width = 1;
        const int length = 1;

        //Act
        var parcel = new Parcel(height, width, length);

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingXL, price, "XL parcel not priced correctly");
    }
}