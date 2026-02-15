using CRMCorporativo.Domain.Validation;

namespace CRMCorporativo.Domain.Entities;

public sealed class Endereco : Entity
{
    public string Name { get; private set; }

    public Endereco(string name)
    {
        ValidateDomain(name);
    }

    public Endereco(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }
    public ICollection<Cliente> Clientes { get; set; }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name.Name is required");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        Name = name;
    }
}
