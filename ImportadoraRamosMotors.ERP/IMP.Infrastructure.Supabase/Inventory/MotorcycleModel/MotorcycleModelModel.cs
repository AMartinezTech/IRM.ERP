using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleModel;

[Table("models")]
internal class MotorcycleModelModel : BaseModel
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

    [JsonProperty("brand_id")]
    [Column("brand_id")]
    public Guid BrandId { get; set; }  
}
