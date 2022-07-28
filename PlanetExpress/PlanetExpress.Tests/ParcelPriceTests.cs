using PlanetExpress.Core;

namespace PlanetExpress.Tests;

[TestClass]
public class ParcelPriceTests
{
    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Small()
    {
        var parcel = TestConstants.SmallParcel;

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingSmall, price, "Small parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Medium()
    {
        var parcel = TestConstants.MediumParcel;

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingMedium, price, "Medium parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_Large()
    {
        var parcel = TestConstants.LargeParcel;

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingLarge, price, "Large parcel not priced correctly");
    }

    [TestMethod]
    public void NewParcelPricing_WithValidDimensions_XL()
    {
        var parcel = TestConstants.XLParcel;

        //Assert
        var price = parcel.Price;
        Assert.AreEqual(Constants.ParcelPricingXL, price, "XL parcel not priced correctly");
    }
}