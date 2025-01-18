﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mahta.Core.Domain.Toolkits.ValueObjects;

namespace Mahta.Infra.Data.Sql.Commands.ValueConversions
{
    public class LegalNationalIdConversion : ValueConverter<LegalNationalId, string>
    {
        public LegalNationalIdConversion() : base(c => c.Value, c => LegalNationalId.FromString(c))
        {

        }
    }
}
