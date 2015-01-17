namespace Hstar.Core.Ioc
{
    public interface IContainerProvider
    {
        T GetInstance<T>();
    }
}
