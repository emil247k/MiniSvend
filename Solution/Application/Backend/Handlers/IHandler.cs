namespace SmartLock.Handler
{
    public interface IHandler<returnType,parameterType>
    {
        returnType Handel(parameterType value);
    }
}