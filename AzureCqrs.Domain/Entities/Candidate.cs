namespace AzureCqrs.Domain.Entities;

public class Candidate
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly Birthday { get; set; }

    public string City { get; set; }

    public string Skills { get; set; }

    public string Languages { get; set; }

    public string Certificates { get; set; }

}