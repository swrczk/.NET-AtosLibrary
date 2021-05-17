namespace AtosLibrary.Application.Features.RegistrationBook
{
    public class RegistrationBookCommand
    {
        public RegistrationBookCommand(string name, string description, int number)
        {
            Name = name;
            Description = description;
            Number = number;
        }

        public string Name { get; }
        public string Description { get; }
        public int Number { get; }
    }
}