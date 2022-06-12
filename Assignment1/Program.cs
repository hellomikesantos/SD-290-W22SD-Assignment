// Question 1
Dictionary<int, int> vendingMachine = new Dictionary<int, int>();
vendingMachine.Add(1, 15);
vendingMachine.Add(2, 15);
vendingMachine.Add(5, 15);
vendingMachine.Add(10, 15);
vendingMachine.Add(20, 15);



/* This function represents the whole operation of a Purchase in the vending machine, it accepts a vending machine dictionary,
 the price of an item and the money that's been cashed in */
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

// Question 2
/*Example:
String = “RTFFFFYYUPPPEEEUU”
Result = “RTF4YYUP3E3UU”*/


// This function takes a string that compresses repetitive conesecutive characters into numbers
string CompressString(string originalStr)
{
    int letterCounter = 0;
    string newStr = originalStr[0].ToString();
    bool doneCharMatching = false;

    // iterate the original string
    for(int inner = 0; inner < originalStr.Length - 1; inner++)
    {
        letterCounter = 0;
        doneCharMatching = false;
        // iterate the original string
        for(int outer = inner + 1; outer < originalStr.Length; outer++)
        {
            // check if the char next to the current char is the same
            if (originalStr[inner] == originalStr[outer])
            {
                letterCounter++;
            }

            // when similarity comparison ends, do this
            if (doneCharMatching)
            {
                int num = letterCounter + 1;
                newStr += num.ToString();
                inner = outer;
                letterCounter = 0;
            }

            // if they are not matched, still add the next char. 
            else if (originalStr[inner] != originalStr[outer])
            {
                // if they stopped matching,
                if (inner < outer - 2)
                {
                    inner = outer;
                    doneCharMatching = true;
                    int num = letterCounter + 1;
                    newStr += num.ToString();

                } else
                {
                    newStr += originalStr[outer];
                }
                break;
            }
        }
        // this 
        if (letterCounter == 1)
        {
            newStr += originalStr[inner];
        }
    }
    Console.WriteLine(originalStr);
    Console.WriteLine(newStr);
    return newStr;
}

CompressString("RTFFFFYYUPPPEEEUU");


/* This function takes a compressed string and decompresses it by replaceing the n numbers to n number of characters*/
string DecompressString(string stringToDecompress)
{ 
    string newString = "";
    for(int i = 0; i < stringToDecompress.Length; i++)
    {
        

            if(stringToDecompress[i] >= '0' && stringToDecompress[i] <= '9')
            {
                int count = Int32.Parse(stringToDecompress[i].ToString());
                for(int num = 0; num < count - 1; num++)
                {
                    newString += stringToDecompress[i - 1];
                }
            } 
            else
            {
            newString += stringToDecompress[i];
        }
    }
    Console.WriteLine(newString);
    return newString;
}

DecompressString("RTF4YYUP3E3UU");
