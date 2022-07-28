namespace PlanetExpress.Domain;

/// <summary>
/// Class for displaying invoices
/// </summary>
public class Invoice
{
    /// <summary>
    /// Constructor containing list of invoice items
    /// </summary>
    /// <param name="invoiceItems"></param>
    public Invoice(List<IInvoiceItem> invoiceItems)
    {
        InvoiceItems = invoiceItems;
    }

    #region Properties

    public List<IInvoiceItem> InvoiceItems { get; set; }

    private decimal _parcelTotal = 0;
    public decimal ParcelTotal
    {
        get => _parcelTotal = CalculateParcelTotal();
        set => _parcelTotal = value;
    }

    #endregion

    /// <summary>
    /// Calculate the invoice total
    /// </summary>
    /// <returns></returns>
    private decimal CalculateParcelTotal()
    {
        var prices = InvoiceItems.Select(s => s.Price).ToList();
        return prices.Sum();
    }

    /// <summary>
    /// Adds speedy shipping to order
    /// Will only add to order once
    /// If exists remove and recalculate
    /// This feels gross
    /// </summary>
    public void AddSpeedyShipping()
    {
        var speedy = InvoiceItems.OfType<ShippingExtra>().ToList()
            .FirstOrDefault(x => x.ShippingExtraType == ShippingExtraType.Speedy);

        if (speedy != null) InvoiceItems.Remove(speedy);

        InvoiceItems.Add(new ShippingExtra(ParcelTotal, ShippingExtraType.Speedy));
    }
}