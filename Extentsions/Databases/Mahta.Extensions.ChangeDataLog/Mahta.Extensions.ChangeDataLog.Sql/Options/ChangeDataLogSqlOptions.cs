﻿namespace Mahta.Extensions.ChangeDataLog.Sql.Options;

public sealed record ChangeDataLogSqlOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public bool AutoCreateSqlTable { get; set; } = true;
    public string EntityTableName { get; set; } = "EntityChangeDataLogs";
    public string PropertyTableName { get; set; } = "PropertyChangeDataLogs";
    public string SchemaName { get; set; } = "dbo";
}
