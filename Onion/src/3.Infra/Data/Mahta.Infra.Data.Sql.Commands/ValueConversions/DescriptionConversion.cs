using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mahta.Core.Domain.Toolkits.ValueObjects;

namespace Mahta.Infra.Data.Sql.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {

        }
    }
}
