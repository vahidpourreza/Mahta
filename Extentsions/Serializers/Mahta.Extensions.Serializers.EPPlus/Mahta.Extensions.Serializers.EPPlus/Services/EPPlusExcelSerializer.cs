using Mahta.Extensions.Serializers.Abstractions;
using Mahta.Extensions.Serializers.EPPlus.Extensions;
using Mahta.Extensions.Translations.Abstractions;
using System.Data;

namespace Mahta.Extensions.Serializers.EPPlus.Services;


public class EPPlusExcelSerializer : IExcelSerializer
{
    private readonly ITranslator _translator;

    #region Constructor
    public EPPlusExcelSerializer(ITranslator translator)
    {
        _translator = translator;
    }
    #endregion


    #region Methods

    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(_translator, sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>(_translator);

    #endregion

}
