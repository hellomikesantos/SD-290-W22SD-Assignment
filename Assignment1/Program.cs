Dictionary<int, int> vendingMachine = new Dictionary<int, int>();
vendingMachine.Add(1, 15);
vendingMachine.Add(2, 15);
vendingMachine.Add(5, 15);
vendingMachine.Add(10, 15);
vendingMachine.Add(20, 15);

Dictionary<int, int> Purchase(Dictionary<int, int> vendingMachine, int price, int cashIn)
{
    Dictionary<int, int> changeDenomination = new Dictionary<int, int>();
    int change = 0;
    if (cashIn >= price)
    {
        change = cashIn - price;
        int subtractor = change;
        subtractor = cashIn - price;
        int number = 0;

        for (int i = vendingMachine.Count - 1; i >= 0; i--)
        {
            int floatCoins = vendingMachine.ElementAt(i).Value;
            if (vendingMachine.ElementAt(i).Key <= subtractor && floatCoins > 0)
            {
                int pieces = 0;

                if (cashIn / vendingMachine.ElementAt(i).Key >= 2)
                {
                    number = subtractor / vendingMachine.ElementAt(i).Key;
                    pieces += number;
                }

                subtractor -= vendingMachine.ElementAt(i).Key * pieces;
                changeDenomination.Add(vendingMachine.ElementAt(i).Key, pieces);
                floatCoins -= pieces;
            }
        }

    } else
    {
        Console.WriteLine("Cash entered is not enough");
    }

    Console.WriteLine($"You have entered {cashIn} for an item that costs {price}");
    Console.WriteLine($"You'll have a total change of {change}:");
    foreach(KeyValuePair<int, int> coin in changeDenomination)
    {
        Console.WriteLine($"{coin.Value} pc(s) of ${coin.Key}");
    }

    return changeDenomination;
}

Purchase(vendingMachine, 23, 360);

// 