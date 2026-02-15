using CRMCorporativo.Domain.Validation;

namespace CRMCorporativo.Domain.Entities;

public sealed class Cliente : Entity
{
    public string Nome { get; private set; }
    public string CPFCNPJ { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }

    public Cliente(string Nome, string cpfcnpj, DateTime DataNascimento, string telefone, string email)
    {
        ValidateDomain(Nome, cpfcnpj, DataNascimento, telefone, email);
    }

    public Cliente(int id, string Nome, string cpfcnpj, DateTime DataNascimento, string telefone, string email)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(Nome, cpfcnpj, DataNascimento, telefone, email);
    }

    public void Update(string Nome, string cpfcnpj, DateTime DataNascimento, string telefone, string email, int enderecoId)
    {
        ValidateDomain(Nome, cpfcnpj, DataNascimento, telefone, email);
        EnderecoId = enderecoId;
    }

    private void ValidateDomain(string nome, string cpfcnpj, DateTime datanascimento, string telefone, string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Nome),
            "Invalid name. Name is required");

        DomainExceptionValidation.When(Nome.Length < 3,
            "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(cpfcnpj),
            "Invalid description. Description is required");

        DomainExceptionValidation.When(cpfcnpj.Length < 5,
            "Invalid description, too short, minimum 5 characters");

        DomainExceptionValidation.When(email?.Length > 250,
            "Invalid image name, too long, maximum 250 characters");

        Nome   = nome;
        CPFCNPJ = cpfcnpj;
        DataNascimento = datanascimento;
        Telefone = telefone;
        Email = email;

    }
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
}
