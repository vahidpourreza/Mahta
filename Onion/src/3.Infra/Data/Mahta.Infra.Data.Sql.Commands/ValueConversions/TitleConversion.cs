using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mahta.Core.Domain.Toolkits.ValueObjects;

namespace Mahta.Infra.Data.Sql.Commands.ValueConversions
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {

        }
    }
}
