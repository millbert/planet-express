namespace PlanetExpress.Domain;

/// <summary>
/// Class to contain any shipping extras
/// </summary>
public class ShippingExtra : IInvoiceItem
{
    /// <summary>
    /// Create ShippingExtra type
    /// </summary>
    /// <param name="parcelTotal">Total of parcels contained in order</param>
    /// <param name="shippingExtraType">Type of shipping extra charge</param>
    public ShippingExtra(decimal parcelTotal, ShippingExtraType shippingExtraType)
    {
        Price = parcelTotal;
        ShippingExtraType = shippingExtraType;
    }

    public decimal Price { get; set; }
    /// <summary>
    /// Type of ShippingExtra
    /// </summary>
    public ShippingExtraType ShippingExtraType { get; set; }
}