﻿namespace Mahta.Extensions.Logger.Abstractions;

public class MahtaEventId
{
    public const int PerformanceMeasurement = 1001;

    public const int DomainValidationException = 1010;

    public const int CommandValidation = 1011;
    public const int QueryValidation = 1012;
    public const int EventValidation = 1013;
}