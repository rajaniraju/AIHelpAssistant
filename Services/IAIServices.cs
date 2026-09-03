namespace AISupport.Services
{
    public interface IAIServices
    {
        Guid Id { get; }
        string Ask(string question, Guid serviceId);
        string Answer(string answer);
    }
}
