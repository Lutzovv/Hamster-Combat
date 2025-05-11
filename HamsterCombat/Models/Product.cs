using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterCombat.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public float Ratio { get; set; }
    public string IconURL { get; set; }
    public int Level { get; set; }

    public Product(int id, string name, float price, float ratio, string iconURL, int level)
    {
        Id = id;
        Name = name;
        Price = price;
        Ratio = ratio;
        IconURL = iconURL;
        Level = level;
    }
}
