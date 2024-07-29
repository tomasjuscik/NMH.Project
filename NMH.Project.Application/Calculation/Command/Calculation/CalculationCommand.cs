namespace NMH.Project.Application.Calculation.Command.Calculation;

using MediatR;

public sealed record CalculationCommand(int Key, decimal Input) : IRequest<CalculationResponse>;