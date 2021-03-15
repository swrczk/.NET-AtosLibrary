namespace AtosLibrary.Application.Infrastructure
{
    public interface ICommandHandler<in T> where T : class
    {
        void Handle(T command);
    }
}
