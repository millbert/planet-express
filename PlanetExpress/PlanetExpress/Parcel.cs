namespace PlanetExpress;

/// <summary>
/// Class for the parcels being sent
/// Assuming only whole cm lengths can be used
/// </summary>
public class Parcel
{
    public Parcel(int height, int width, int length)
    {
        Height = height;
        Width = width;
        Length = length;
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
    /// Parcel type pulled from the dimensions entered
    /// </summary>
    private ParcelType _type;
    public ParcelType Type
    {
        get => _type = GetPackageType();
        set => _type = value;
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
}