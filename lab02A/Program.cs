using System;

namespace lab02A
{
  class Program
  {
    static void Main(string[] args)
    {
      // needs to call StartSequence()
      try
      {
        StartSequence();
      }
      catch (Exception e)
      {
        Console.WriteLine("I'm sorry, there's been an error in Main");
        Console.WriteLine(e.Message);
      }
      finally
      {
        Console.WriteLine("*****Game Over*****\n***Thanks for playing!***");
      }
    }

    static void StartSequence()
    {
      Console.WriteLine("*****Welcome to my Game! Let's Do Some Math!*****");

      //prompt the user to "Enter a number greater than zero".
      Console.WriteLine("***Enter a number greater than 0: ***");
      int userNum = Convert.ToInt32(Console.ReadLine());
      int[] userNumbers = new int[userNum];

      //Call the Populate method. arguments: integer array
      userNumbers = Populate(userNum, userNumbers);

      //Capture the sum by calling the GetSum method. arguments: integer array
      int sum = GetSum(userNumbers);

      //Capture the product by calling the GetProduct method. integer array and integer sum
      int[] product = GetProduct(userNumbers, sum);

      //Capture the quotient by calling the GetQuotient method. arguments: integer product
      decimal[] quotient = GetQuotient(product[0]);

      Console.WriteLine($@"Your array size is: {userNumbers.Length}
The numbers in the array are: {String.Join(",", userNumbers)}
The sum of the array is {sum}
{sum} * {userNumbers[product[1] - 1]} = {product[0]}
{product[0]} / {quotient[1]} = {quotient[0]}");

    }

    static int[] Populate(int userNum, int[] userNumbers)
    {
      // Iterate through the array and prompt the user to enter a specific number. Example: "Please enter a number 1/6" (indicate to the user what number they are inputting)

      for (int i = 0; i < userNum; i++)
      {
        Console.WriteLine($"Please enter number {i + 1} of {userNum}");
        int newNum = Convert.ToInt32(Console.ReadLine());
        userNumbers[i] = newNum;
      }
      return userNumbers;
    }

    static int GetSum(int[] userNumbers)
    {
      int sum = 0;

      //Iterate through the array and populate the sum variable with the sum of all the numbers together.
      foreach (int num in userNumbers)
      {
        sum += num;
      }
      if (sum < 20)
      {
        throw new Exception($"Value of {sum} is too low");
      }
      return sum;
    }

    static int[] GetProduct(int[] userNumbers, int sum)
    {
      try
      {
        //Ask the user the select a random number between 1 and the length of the integer array
        Console.WriteLine($"Select a random number between 1 and {userNumbers.Length}");

        int randomNum = Convert.ToInt32(Console.ReadLine());

        int product = (sum * userNumbers[randomNum - 1]);
        int[] productAndRando = { product, randomNum };
        return productAndRando;
      }
      catch (IndexOutOfRangeException e)
      {
        Console.WriteLine(e.Message);
        throw new IndexOutOfRangeException();
      }
    }

    static decimal[] GetQuotient(int product)
    {
      //Prompt the user to enter a number to divide the product by. Display the current product to the user during this prompt.
      Console.WriteLine($"Please enter a number to divide your product {product} by: ");
      int divideBy = Convert.ToInt32(Console.ReadLine());
      while (divideBy == 0)
      {
        Console.WriteLine($"Please enter a number to divide your product {product} by: ");
        divideBy = Convert.ToInt32(Console.ReadLine());
      }

      decimal quotient = Decimal.Divide((decimal)product, (decimal)divideBy);
      decimal[] quotientAndDivideBy = { quotient, divideBy };
      return quotientAndDivideBy;
    }
  }
}
