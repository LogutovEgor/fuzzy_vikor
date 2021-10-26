using System;

bool testData = false;

int criterias;
int alternatives;
int experts;

if (testData)
{    
    criterias = 3;
    alternatives = 3;
    experts = 3;
} 
else
{
    Console.WriteLine("Enter the number of criteria.");
    criterias = ConsoleInput.ReadIntAboveOrEquals(1);

    Console.WriteLine("Enter the number of alternatives.");
    alternatives = ConsoleInput.ReadIntAboveOrEquals(2);

    Console.WriteLine("Enter the number of experts.");
    experts = ConsoleInput.ReadIntAboveOrEquals(1);
}

string[,] criteriasEstimates = new string[criterias, experts];

if (testData)
    criteriasEstimates = new string[3, 3]
    {
        { LinguisticTerms.VERY_LOW, LinguisticTerms.LOW, LinguisticTerms.VERY_LOW },
        { LinguisticTerms.MEDIUM, LinguisticTerms.LOW, LinguisticTerms.HIGH },
        { LinguisticTerms.VERY_HIGH, LinguisticTerms.MEDIUM, LinguisticTerms.HIGH },
    };
else
{
    Console.WriteLine("\nEnter estimates of criterias.");
    for (int criteria = 0; criteria < criterias; criteria++)
        for (int expert = 0; expert < experts; expert++)
        {
            Console.WriteLine($"Criteria {criteria + 1}, expert {expert + 1}:");
            criteriasEstimates[criteria, expert] = ConsoleInput.ChooseFrom(LinguisticTerms.GetLinguisticScaleOfCriteria);
        }
}

Console.WriteLine("\nEstimates of criterias:");
for (int j = 0; j <= criterias; j++)
{
    for (int k = 0; k <= experts; k++)
        if (j == 0 && k == 0)
            Console.Write(String.Format("{0,16}|", ""));
        else if (j == 0 && k > 0)
            Console.Write(String.Format("{0,16}|", $"Expert {k}"));
        else if (j > 0 && k == 0)
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        else
            Console.Write(String.Format("{0,16}|", $"{criteriasEstimates[j - 1, k - 1]}"));
    Console.WriteLine();
}

bool[] criteriasBenefit = new bool[criterias];

if (testData)
    criteriasBenefit = new bool[3]
    {
        false,
        true,
        false
    };
else
{
    Console.WriteLine("\nEnter criterias benefit.");
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        Console.WriteLine($"Criteria {criteria + 1} (true/false):");
        string input = ConsoleInput.ChooseFrom(new string[2] { "true", "false" });
        criteriasBenefit[criteria] = input.Equals("true");
    }
}

Console.WriteLine("\nCriterias benefit:");
Console.WriteLine(String.Format("{0,16}|{1,16}|", "Criterion", "Benefit"));
for (int j = 0; j < criterias; j++)
{
    Console.Write(String.Format("{0,16}|{1,16}|", $"Criterion {j + 1}", $"{criteriasBenefit[j]}"));
    Console.WriteLine();
}


