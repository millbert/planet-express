using PlanetExpress.Core;
using PlanetExpress.Domain;

namespace PlanetExpress.Tests;

[TestClass]
public class InvoicePricingTests
{
    [TestMethod]
    public void Invoice_TwoSmall()
    {
        //Arrange
        var parcelList = new List<Parcel>
        {
            TestContants.SmallParcel,
            TestContants.SmallParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.Parcels.Count;
        var expected = Constants.ParcelPricingSmall * 2;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(2, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMedium()
    {
        //Arrange
        var parcelList = new List<Parcel>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.Parcels.Count;
        var expected = Constants.ParcelPricingSmall + Constants.ParcelPricingMedium;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(2, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMediumXL()
    {
        //Arrange
        var parcelList = new List<Parcel>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel,
            TestContants.XLParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.Parcels.Count;
        var expected = Constants.ParcelPricingSmall + Constants.ParcelPricingMedium + Constants.ParcelPricingXL;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(3, count, "Invoice not counting correctly");
    }
}