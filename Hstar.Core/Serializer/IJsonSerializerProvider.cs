namespace Hstar.Core.Serializer
{
    public interface IJsonSerializerProvider
    {
        string Serialize(object obj,string datetimeFormat=null);

        T Deserialize<T>(string jsonString);
    }
}
