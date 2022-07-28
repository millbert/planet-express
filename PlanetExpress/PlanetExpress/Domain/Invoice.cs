namespace PlanetExpress.Domain;

public class Invoice
{
    public Invoice(List<Parcel> parcels)
    {
        Parcels = parcels;
    }

    #region Properties

    public List<Parcel> Parcels { get; set; }

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
        var prices = Parcels.Select(s => s.Price).ToList();
        return prices.Sum();
    }
}