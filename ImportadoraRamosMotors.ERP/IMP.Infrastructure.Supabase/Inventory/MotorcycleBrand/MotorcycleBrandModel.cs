using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;

[Table("brands")]
internal class MotorcycleBrandModel : BaseModel
{
    [PrimaryKey("id")]
    [JsonProperty("id")]
    [Column("id")]
    public Guid Id { get; set; }

    [JsonProperty("is_active")]
    [Column("is_active")]
    public bool IsActive { get; set; }

    [JsonProperty("name")]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
