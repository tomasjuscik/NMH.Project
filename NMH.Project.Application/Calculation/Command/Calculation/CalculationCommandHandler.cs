namespace NMH.Project.Application.Calculation.Command.Calculation;

using MediatR;
using NMH.Project.Application.Core.Abstraction;

internal sealed class CalculationCommandHandler : IRequestHandler<CalculationCommand, CalculationResponse>
{
    private const decimal ConstValue = 2;
    private readonly IKeyValueStorageService _keyValueStorageService;

    public CalculationCommandHandler(IKeyValueStorageService keyValueStorageService)
    {
        _keyValueStorageService = keyValueStorageService;
    }

    public async Task<CalculationResponse> Handle(CalculationCommand command, CancellationToken cancellationToken)
    {
        var key = command.Key;
        var input = command.Input;
        var res = _keyValueStorageService.TryGetValue(key, out var value);
        if (!res)
        {
            _keyValueStorageService.SetValue(key, ConstValue);
        }
        else if (value.Timestamp < DateTime.UtcNow.AddSeconds(-15))
        {
            _keyValueStorageService.SetValue(key, ConstValue);
        }
        var prev_value = _keyValueStorageService.GetValue(key);
        var computedValue = Calculate(input, prev_value);
        _keyValueStorageService.SetValue(key, computedValue);
        return new CalculationResponse(Computed_Value: computedValue, Input_Value: input, Previous_Value: prev_value);
    }

    private static decimal Calculate(decimal input, decimal globalStorageValue)
    {
        var naturalLog = (decimal)Math.Log((double)(input));
        var dividedValue = naturalLog / globalStorageValue;
        var computedValue = (decimal)Math.Cbrt((double)dividedValue);
        return computedValue;
    }
}