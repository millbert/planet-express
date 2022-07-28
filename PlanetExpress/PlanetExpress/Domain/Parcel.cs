using PlanetExpress.Core;

namespace PlanetExpress.Domain;

/// <summary>
/// Class for the parcels being sent
/// Assuming only whole cm lengths can be used
/// </summary>
public class Parcel : IInvoiceItem
{
    public Parcel(int height, int width, int length, int weight)
    {
        Height = height;
        Width = width;
        Length = length;
        Weight = weight;
    }

    #region Properties

    /// <summary>
    /// Height of the parcel
    /// Must be a positive value
    /// </summary>
    private int _height;
    public int Height
    {
        get => _height;
        set
        {
            if (value > 0) _height = value;
            else throw new ArgumentOutOfRangeException($"{nameof(value)} must be above 0");
        }
    }

    /// <summary>
    /// Width of the parcel
    /// Must be a positive value
    /// </summary>
    private int _width;
    public int Width
    {
        get => _width;
        set
        {
            if (value > 0) _width = value;
            else throw new ArgumentOutOfRangeException($"{nameof(value)} must be above 0");
        }
    }

    /// <summary>
    /// Length of the parcel
    /// Must be a positive value
    /// </summary>
    private int _length;
    public int Length
    {
        get => _length;
        set
        {
            if (value > 0) _length = value;
            else throw new ArgumentOutOfRangeException($"{nameof(value)} must be above 0");
        }
    }

    /// <summary>
    /// Weight of the parcel
    /// Must be a positive value
    /// </summary>
    private int _weight;
    public int Weight
    {
        get => _weight;
        set
        {
            if (value > 0) _weight = value;
            else throw new ArgumentOutOfRangeException($"{nameof(value)} must be above 0");
        }
    }

    /// <summary>
    /// Parcel type pulled from the dimensions entered
    /// </summary>
    private ParcelType _type;
    public ParcelType Type
    {
        get => _type = GetPackageType();
        set => _type = value;
    }

    /// <summary>
    /// Parcel pricing
    /// </summary>
    private decimal _price = 0;
    public decimal Price
    {
        get => _price = GetPrice();
        set => _price = value;
    }

    #endregion

    /// <summary>
    /// Gets the parcel type depending on the dimensions
    /// </summary>
    /// <returns>Parcel type</returns>
    private ParcelType GetPackageType()
    {
        if (Height < 10 && Width < 10 && Length < 10) return ParcelType.Small;
        if (Height < 50 && Width < 50 && Length < 50) return ParcelType.Medium;
        if (Height < 100 && Width < 100 && Length < 100) return ParcelType.Large;
        return ParcelType.XL;
    }

    /// <summary>
    /// Gets the pricing for Parcel types
    /// </summary>
    /// <returns>Pricing for each parcel</returns>
    /// <exception cref="ArgumentOutOfRangeException">If out of range of enum throw exception</exception>
    private decimal GetPrice()
    {
        switch (Type)
        {
            case ParcelType.Small:
                var excess = Excess(Constants.ParcelWeightLimitSmall);
                return excess > 0 ? ExcessPrice(excess, Constants.ParcelPricingSmall) : Constants.ParcelPricingSmall;
            case ParcelType.Medium:
                excess = Excess(Constants.ParcelWeightLimitMedium);
                return excess > 0 ? ExcessPrice(excess, Constants.ParcelPricingMedium) : Constants.ParcelPricingMedium;
            case ParcelType.Large:
                excess = Excess(Constants.ParcelWeightLimitLarge);
                return excess > 0 ? ExcessPrice(excess, Constants.ParcelPricingLarge) : Constants.ParcelPricingLarge;
            case ParcelType.XL:
                excess = Excess(Constants.ParcelWeightLimitXL);
                return excess > 0 ? ExcessPrice(excess, Constants.ParcelPricingXL) : Constants.ParcelPricingXL;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private int Excess(int weightLimit)
    {
        return Weight - weightLimit;
    }

    private static decimal ExcessPrice(int excess, decimal basePrice)
    {
        return (excess * Constants.ParcelWeightLimitExcess) + basePrice;
    }
}