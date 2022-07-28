namespace PlanetExpress.Domain;

/// <summary>
/// Interface for all invoice product types
/// </summary>
public interface IInvoiceItem
{
    /// <summary>
    /// Price is shared across all implementations
    /// </summary>
    public decimal Price { get; set; }
}