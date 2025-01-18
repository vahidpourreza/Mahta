using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mahta.Core.Domain.Toolkits.ValueObjects;

namespace Mahta.Infra.Data.Sql.Commands.ValueConversions
{
    public class NationalCodeConversion : ValueConverter<NationalCode, string>
    {
        public NationalCodeConversion() : base(c => c.Value, c => NationalCode.FromString(c))
        {

        }
    }
}
