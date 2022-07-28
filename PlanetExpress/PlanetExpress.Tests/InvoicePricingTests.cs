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
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.SmallParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = Constants.ParcelPricingSmall * 2;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(2, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMedium()
    {
        //Arrange
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = Constants.ParcelPricingSmall + Constants.ParcelPricingMedium;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(2, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMediumXL()
    {
        //Arrange
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel,
            TestContants.XLParcel
        };

        //Act
        var invoice = new Invoice(parcelList);

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = Constants.ParcelPricingSmall + Constants.ParcelPricingMedium + Constants.ParcelPricingXL;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(3, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMediumXL_WithSpeedy()
    {
        //Arrange
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel,
            TestContants.XLParcel
        };

        //Act
        var invoice = new Invoice(parcelList);
        invoice.AddSpeedyShipping();

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = (Constants.ParcelPricingSmall + Constants.ParcelPricingMedium + Constants.ParcelPricingXL) * 2;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(4, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMediumXL_WithSpeedyDouble()
    {
        //Arrange
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel,
            TestContants.XLParcel
        };

        //Act
        var invoice = new Invoice(parcelList);
        invoice.AddSpeedyShipping();
        invoice.AddSpeedyShipping();

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = (Constants.ParcelPricingSmall + Constants.ParcelPricingMedium + Constants.ParcelPricingXL) * 2;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(4, count, "Invoice not counting correctly");
    }

    [TestMethod]
    public void Invoice_SmallMediumXL_WithSpeedy_AddSmall()
    {
        //Arrange
        var parcelList = new List<IInvoiceItem>
        {
            TestContants.SmallParcel,
            TestContants.MediumParcel,
            TestContants.XLParcel
        };

        //Act
        var invoice = new Invoice(parcelList);
        invoice.AddSpeedyShipping();

        invoice.InvoiceItems.Add(TestContants.SmallParcel);

        invoice.AddSpeedyShipping();

        //Assert
        var total = invoice.ParcelTotal;
        var count = invoice.InvoiceItems.Count;
        var expected = (Constants.ParcelPricingSmall + Constants.ParcelPricingSmall + Constants.ParcelPricingMedium + Constants.ParcelPricingXL) * 2;
        Assert.AreEqual(expected, total, "Invoice not priced correctly");
        Assert.AreEqual(5, count, "Invoice not counting correctly");
    }
}