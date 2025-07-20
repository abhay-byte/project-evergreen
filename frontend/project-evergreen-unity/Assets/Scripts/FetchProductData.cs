using UnityEngine;
using System.Collections.Generic;
using Evergreen.Models;
public class FetchProductData : MonoBehaviour
{
    private List<Product> products { get; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var sofa = new Product
        {
            Id = 1,
            Name = "Sofa Chair",
            Description = "Comfortable modern sofa chair.",
            Price = 24999.99m,
            GreenScore = 85,
            GreenScoreDetails = new Dictionary<string, object>
            {
                { "material", "Bamboo & Recycled Foam" },
                { "eco_certified", true },
                { "emissions", "Low VOC" }
            },
            Model3DUrl =
                "https://raw.githubusercontent.com/abhay-byte/project-evergreen/refs/heads/abhay/frontend-unity/src/abcd-1234/abcd-1234-obj.prefab",
            Category = "Chair",
            InventoryQuantity = 10
        };

        var teaTable = new Product
        {
            Id = 2,
            Name = "Tea Table",
            Description = "Minimalist wooden tea table.",
            Price = 7999.50m,
            ImageUrl =
                "https://github.com/abhay-byte/project-evergreen/blob/abhay/frontend-unity/src/efgh-1234/efgh-1234-img.png",
            GreenScore = 78,
            GreenScoreDetails = new Dictionary<string, object>
            {
                { "material", "Reclaimed Teak" },
                { "coating", "Water-based lacquer" }
            },
            Model3DUrl =
                "https://raw.githubusercontent.com/abhay-byte/project-evergreen/refs/heads/abhay/frontend-unity/src/efgh-1234/efgh-1234-obj.prefab",
            Category = "Table",
            InventoryQuantity = 5
        };

        var cabinet = new Product
        {
            Id = 3,
            Name = "Wooden Cabinet",
            Description = "Spacious cabinet for storage (Almirah style).",
            Price = 13999.00m,
            ImageUrl =
                "https://github.com/abhay-byte/project-evergreen/blob/abhay/frontend-unity/src/kmnl-1234/kmnl-1234-img.png",
            GreenScore = 92,
            GreenScoreDetails = new Dictionary<string, object>
            {
                { "material", "Mango Wood" },
                { "assembly_required", false }
            },
            Model3DUrl =
                "https://raw.githubusercontent.com/abhay-byte/project-evergreen/refs/heads/abhay/frontend-unity/src/kmnl-1234/kmnl-1234-obj.prefab",
            Category = "Almirah",
            InventoryQuantity = 3,
            ExpiryDate = null // no expiry
        };
        
        products.Add(sofa);
        products.Add(teaTable);
        products.Add(cabinet);

    }
    
}
