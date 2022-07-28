using PlanetExpress.Domain;

namespace PlanetExpress.Tests;

public static class TestContants
{
    public static Parcel SmallParcel = new (1, 1, 1);
    public static Parcel MediumParcel = new (49, 1, 1);
    public static Parcel LargeParcel = new (99, 1, 1);
    public static Parcel XLParcel = new (100, 1, 1);
}