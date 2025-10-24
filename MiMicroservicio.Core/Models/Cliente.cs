using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MiMicroservicio.Core.Models;


public class Cliente
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Saldo { get; set; }
}





