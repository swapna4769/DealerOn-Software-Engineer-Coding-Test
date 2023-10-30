// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Linq;

Console.WriteLine("Please enter number of items");
int n = Convert.ToInt32( Console.In.ReadLine());

ArrayList arrCategoryWithNoST = new ArrayList();
arrCategoryWithNoST.Add("BOOK");
arrCategoryWithNoST.Add("FOOD");
arrCategoryWithNoST.Add("CHOCOLATE");
arrCategoryWithNoST.Add("MEDICAL");

Dictionary<string, decimal> dictItems = new Dictionary<string, decimal>();

for(int i= 1; i<=n; i++)
{
    Console.WriteLine("Please enter item");
    var item = Console.In.ReadLine().ToUpper();
    Console.WriteLine("Please enter item price");
    var itemPrice = Convert.ToDecimal(Console.In.ReadLine());

    if(dictItems.ContainsKey(item.ToUpper()))
    {
        dictItems[item] = dictItems[item] + itemPrice;
    }
    else
        dictItems.Add(item, (decimal)itemPrice);
}
decimal totalAmount=0, totalServiceTax=0, serTax =0 ;


if (dictItems != null)
{
    totalServiceTax = 0;
    foreach (var item in dictItems)
    {
        if (!arrCategoryWithNoST.Contains(item.Key))
        {
            if(item.Key.Contains("IMPORTED"))
                serTax = item.Value * 0.15m;
            else
                serTax = item.Value * 0.1m;

            totalServiceTax =Math.Round(totalServiceTax +serTax);
            dictItems[item.Key] =Math.Round(Convert.ToDecimal(serTax + item.Value));
        }
    }
}

foreach(var item in dictItems)
{
    totalAmount = totalAmount + item.Value;
    Console.WriteLine(item.Key + " at " + item.Value);
}
Console.WriteLine("Total Cost " +  totalAmount);
Console.WriteLine("Total service tax " + totalServiceTax);
