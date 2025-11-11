using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace IRM.Infrastructure.Supabase.Inventory.Motorcycle.Catalog;

[Table("vehicle_catalogs")]
internal class MotorcycleCatalogModel : BaseModel
{
    [PrimaryKey("id")]
    [JsonProperty("id")]
    [Column("id")]
    public Guid Id { get; set; }

    [JsonProperty("brand_id")]
    [Column("brand_id")]
    public Guid BrandId { get; set; }

    [JsonProperty("model_id")]
    [Column("model_id")]
    public Guid ModelId { get; set; }

    [JsonProperty("color_id")]
    [Column("color_id")]
    public Guid ColorId { get; set; }

    [JsonProperty("year")]
    [Column("year")]
    public int Year { get; set; }

    [JsonProperty("condition")]
    [Column("condition")]
    public string Condition { get; set; } = string.Empty;

    [JsonProperty("engine_displacement")]
    [Column("engine_displacement")]
    public int EngineDisplacement { get; set; }

    [JsonProperty("description")]
    [Column("description")]
    public string? Description { get; set; } = string.Empty;

    [JsonProperty("is_active")]
    [Column("is_active")]
    public bool IsActive { get; set; }

    [JsonProperty("created_at")]
    [Column("created_at", ignoreOnInsert: true, ignoreOnUpdate: true)]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("created_by")]
    [Column("created_by")]
    public Guid CreatedBy { get; set; }
}
