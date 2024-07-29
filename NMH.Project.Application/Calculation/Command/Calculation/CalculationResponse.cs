namespace NMH.Project.Application.Calculation.Command.Calculation;

public sealed record CalculationResponse(
    decimal Computed_Value,
    decimal Input_Value,
    decimal Previous_Value);