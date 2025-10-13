using IRM.Core.Exceptions;
using IRM.Core.Organization.Branches;

namespace IRM.Core.Organization.Companies;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Rnc { get; private set; }             
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public bool IsActive { get; private set; } = true;

    private readonly List<Branch> _branches = [];
    public IReadOnlyCollection<Branch> Branches => _branches.AsReadOnly();


    private void Validation()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ValidationException("Company name is required.");
        if (string.IsNullOrWhiteSpace(Rnc))
            throw new ValidationException("TaxId is required.");
        if (string.IsNullOrWhiteSpace(Address))
            throw new ValidationException("Address is required.");
        if (string.IsNullOrWhiteSpace(Email))
            throw new ValidationException("Email is required.");
        if (string.IsNullOrWhiteSpace(Phone))
            throw new ValidationException("Phone is required.");
    }
    private Company(string name, string rnc, string address, string email, string phone)
    {
        Name = name;
        Rnc = rnc;
        Address = address;
        Email = email;
        Phone = phone;
        Validation();
    }

    public static Company Create(string name, string rnc, string address, string email, string phone)
    {
        return new Company(name, rnc, address, email, phone);
    }
    public void Update(string name, string rnc, string address, string email, string phone)
    {
        Name = name;
        Rnc = rnc;
        Address = address;
        Email = email;
        Phone = phone;
        Validation();
    }
    public void AddBranch(Branch branch)
    {
        if (branch == null)
            throw new ValidationException("Branch cannot be null.");

        _branches.Add(branch);
    }
    public void MarkAsActive() => IsActive = true;
    public void MarkAsInactive() => IsActive = false;
}
