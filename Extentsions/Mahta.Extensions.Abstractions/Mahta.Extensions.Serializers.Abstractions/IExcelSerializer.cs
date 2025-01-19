﻿using System.Data;

namespace Mahta.Extensions.Serializers.Abstractions;

public interface IExcelSerializer
{
    byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result");
    DataTable ExcelToDataTable(byte[] bytes);
    List<T> ExcelToList<T>(byte[] bytes);
}
