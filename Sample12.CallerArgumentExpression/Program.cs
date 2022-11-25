using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

PackingConfiguration packingConfiguration = new()
{
	BunchesPerPackage = 1,
	LoadCarrierCode = "123",
	PackageTypeCode = "123",
	PiecesPerPackage = 10000,
	TransportHeightInCm = 10,
};

try
{
	packingConfiguration.Validate();
}
catch (ValidationException ex)
{
	Console.WriteLine($"""
		Invalid payload: {packingConfiguration}

		{ex.Message}
		""");
}

public record PackingConfiguration
{
	public required int PiecesPerPackage { get; init; }
	public required string PackageTypeCode { get; init; }
	public required string LoadCarrierCode { get; init; }
	public required int? BunchesPerPackage { get; init; }
	public required int? TransportHeightInCm { get; init; }
	
	public void Validate()
	{
		ThrowHelper.ThrowIf(PiecesPerPackage > 9999);
		ThrowHelper.ThrowIf(BunchesPerPackage is < 1 or > 9999);
		ThrowHelper.ThrowIf(TransportHeightInCm < 1);
		ThrowHelper.ThrowIf(!int.TryParse(PackageTypeCode, out _));
		ThrowHelper.ThrowIf(!int.TryParse(LoadCarrierCode, out _));
	}
}

internal static class ThrowHelper
{
	public static void ThrowIf(bool condition, [CallerArgumentExpression(nameof(condition))] string conditionExpression = "")
	{
		if (condition)
			throw new ValidationException($"Condition failed: {conditionExpression}");
	}
}
