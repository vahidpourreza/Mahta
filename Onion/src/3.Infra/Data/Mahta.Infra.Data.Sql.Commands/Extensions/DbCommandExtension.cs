using System.Data.Common;
using System.Data;
using Mahta.Utilities.Extensions;

namespace Mahta.Infra.Data.Sql.Commands.Extensions;


public static class DbCommandExtension
{
    /// <summary>
    /// این متد، متن دستورات اس کیو ال و پارامترهای متنی یک شیء `دستور` را اصلاح می‌کند 
    /// و حروف "ی" و "ک" عربی را به معادل فارسی آن‌ها "ی" و "ک" تبدیل می‌کند
    /// این روش باعث می‌شود داده‌های متنی در پرس و جوها و پایگاه داده به صورت یکپارچه ذخیره و پردازش شوند.
    /// </summary>
    public static void ApplyCorrectYeKe(this DbCommand command)
    {
        command.CommandText = command.CommandText.ApplyCorrectYeKe();

        foreach (DbParameter parameter in command.Parameters)
        {
            switch (parameter.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    parameter.Value = parameter.Value is DBNull ? parameter.Value : parameter.Value.ApplyCorrectYeKe();
                    break;
            }
        }
    }
}