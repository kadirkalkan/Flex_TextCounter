using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.Constants;

public class ValidatorConstants
{
    private const string PropertyName = "{PropertyName}";
    private const string ComparisonValue = "{ComparisonValue}";

    public const string DefaultGreaterThanMessage = $"{PropertyName} must be greater than {ComparisonValue}";
    public const string DefaultEmptyMessage = $"{PropertyName} can't be empty";
    public const string DefaultNullMessage = $"{PropertyName} can't be null";
}
