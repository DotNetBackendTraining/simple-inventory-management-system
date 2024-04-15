db = db.getSiblingDB('Inventory');

// Schema
db.createCollection("Products", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["Name", "Price", "Quantity"],
            properties: {
                Name: {
                    bsonType: "string",
                    maxLength: 100,
                    description: "must be a string with max length 100 and is required"
                },
                Price: {
                    bsonType: "number",
                    minimum: 0.01,
                    exclusiveMinimum: true,
                    description: "must be a decimal greater than 0 and is required"
                },
                Quantity: {
                    bsonType: "int",
                    minimum: 0,
                    description: "must be an integer greater than or equal to 0 and is required"
                }
            }
        }
    },
    validationAction: "error"
});

// Indexes
db.Products.createIndex({ Name: 1 });
