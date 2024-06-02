namespace OTUS.Serializable;

public class SerializableClass
{
    private const string  delimeter = "|";
    public string SerializeObjectToString<T>(T serialazableClass)
    {
        Type typeSerObj = serialazableClass.GetType();
        var result = $"Class_{typeSerObj.FullName}";
        var propertyInfos=typeSerObj.GetProperties();
        foreach (var propertyInfo in propertyInfos)
        {
            result = string.Concat(result, $"{delimeter}Property_{propertyInfo.Name}:{propertyInfo.GetValue(serialazableClass)}");
        }
        var typeSerObjFields=typeSerObj.GetFields();
        foreach (var fieldInfo in typeSerObjFields)
        {
            result = string.Concat(result, $"{delimeter}Field_{fieldInfo.Name}:{fieldInfo.GetValue(serialazableClass)}");
        }
        return result;
    }
}