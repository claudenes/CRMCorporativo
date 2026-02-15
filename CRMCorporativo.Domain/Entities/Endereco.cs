using CRMCorporativo.Domain.Validation;

namespace CRMCorporativo.Domain.Entities;

public sealed class Endereco : Entity
{
    public string CEP { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; private set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
        
    public Endereco(string Logradouro)
    {
        ValidateDomain(Logradouro);
    }

    public Endereco(int id, string Logradouro)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(Logradouro);
    }

    public void Update(string Logradouro)
    {
        ValidateDomain(Logradouro);
    }
    public ICollection<Cliente> Clientes { get; set; }

    private void ValidateDomain(string logradouro)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(logradouro),
            "Invalid name.Name is required");

        DomainExceptionValidation.When(logradouro.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        Logradouro = logradouro;
    }
}
