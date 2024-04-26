using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleInventoryManagementSystem.Domain;

public class Product
{
    [BsonId] public ObjectId Id { get; set; }

    public required string Name { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public required decimal Price { get; set; }

    public required int Quantity { get; set; }

    public override string ToString() => $"Product: {Name}, {Price} dollar(s), {Quantity} item(s)";
}