using IRM.Core.Exceptions; 

namespace IRM.Core.Organization.Branches;

public class Branch
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public Guid CompanyId { get; private set; }         
    public bool IsActive { get; private set; } = true;


    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "NOMBRE")}  - {nameof(Name)}");
        if (string.IsNullOrWhiteSpace(Address))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "DIRECCIÓN")}  - {nameof(Address)}");
    }
    private Branch(string name, string address, string email, string phone, Guid companyId)
    {

        if (companyId == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "COMPAÑÍA")}  - {nameof(CompanyId)}");
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        CompanyId = companyId;
        Validate();
    }

    public static Branch Create(string name, string address, string email, string phone, Guid companyId)
    {
        return new Branch(name, address, email, phone, companyId);
    }
    public void Update(string name, string address, string email, string phone)
    { 
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        Validate(); 
    }
    public void MarkAsActive() => IsActive = true;
    public void MarkAsInactive() => IsActive = false;
}
