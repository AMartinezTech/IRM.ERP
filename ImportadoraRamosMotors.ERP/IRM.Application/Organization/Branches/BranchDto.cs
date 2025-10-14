namespace IRM.Application.Organization.Branches;

public class BranchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public bool IsActive { get; set; } = true;
}
