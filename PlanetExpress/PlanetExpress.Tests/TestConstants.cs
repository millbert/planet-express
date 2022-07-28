using PlanetExpress.Domain;

namespace PlanetExpress.Tests;

public static class TestConstants
{
    public static Parcel SmallParcel = new (1, 1, 1, 1);
    public static Parcel MediumParcel = new (49, 1, 1, 1);
    public static Parcel LargeParcel = new (99, 1, 1, 1);
    public static Parcel XLParcel = new (100, 1, 1, 1);

    public static Parcel SmallParcelOversize = new(1, 1, 1, 10);
    public static Parcel MediumParcelOversize = new(49, 1, 1, 30);
    public static Parcel LargeParcelOversize = new(99, 1, 1, 60);
    public static Parcel XLParcelOversize = new(100, 1, 1, 100);
}