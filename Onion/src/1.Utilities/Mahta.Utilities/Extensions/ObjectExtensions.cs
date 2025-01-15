using System.Collections;

namespace Mahta.Utilities.Extensions;



/// <summary>
/// Example : 
///var filter = new
///{
///    Name = "API Test",
///    Status = "Active",
///    Tags = new[] { "Tag1", "Tag2" }
///};
///string baseUrl = "https://api.example.com/resources";
///string queryString = filter.ToQueryString();

///string fullUrl = $"{baseUrl}?{queryString}";
/// Example Result: "https://api.example.com/resources?Name=API%20Test&Status=Active&Tags=Tag1&Tags=Tag2"

/// </summary>
public static class ObjectExtensions
{
    public static string ToQueryString(this object obj)
    {
        if (obj is null) throw new ArgumentNullException("Object");

        var properties = obj.GetType().GetProperties()
            .Where(x => x.CanWrite)
            .Where(x => x.GetValue(obj, null) is not null)
            .Select(x => KeyValuePair.Create(x.Name, x.GetValue(obj, null))).ToList();

        var propertyNames = properties
            .Where(x => x.Value is not string && x.Value is IEnumerable)
            .Select(x => x.Key)
            .ToList();

        foreach (var key in propertyNames)
        {
            var valueType = properties.FirstOrDefault(x => x.Key == key).Value.GetType();

            var valueElemType = valueType.IsGenericType
                ? valueType.GetGenericArguments()[0]
                : valueType.GetElementType();

            if (valueElemType.IsPrimitive || valueElemType == typeof(string) || valueElemType == typeof(Guid))
            {
                var enumerable = properties.FirstOrDefault(c => c.Key == key).Value as IEnumerable;

                properties.RemoveAll(x => x.Key == key);

                foreach (var item in enumerable)
                {
                    properties.Add(KeyValuePair.Create(key, item));
                }
            }
        }

        return string.Join("&", properties.Where(x => x.Value is not null)
            .Select(x => string.Concat(
                Uri.EscapeDataString(x.Key), "=",
                Uri.EscapeDataString(x.Value.ToString()))));
    }
}