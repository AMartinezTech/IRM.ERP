using IRM.Application.Organization.Branches; 

namespace IRM.Application.Organization.Companies;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rnc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public List<BranchDto> Branches = [];
}
