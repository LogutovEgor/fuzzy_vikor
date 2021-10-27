using System;

bool testData = true;

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

string[,,] alternativesEstimates = new string[experts, criterias, alternatives];
if (testData)
{
    // expert 1
    // alternative 1
    alternativesEstimates[0, 0, 0] = LinguisticTerms.VERY_POOR; // criterion 1
    alternativesEstimates[0, 0, 1] = LinguisticTerms.POOR; // criterion 2
    alternativesEstimates[0, 0, 2] = LinguisticTerms.VERY_POOR; // criterion 3
    // alternative 2
    alternativesEstimates[0, 1, 0] = LinguisticTerms.POOR; // criterion 1
    alternativesEstimates[0, 1, 1] = LinguisticTerms.FAIR; // criterion 2
    alternativesEstimates[0, 1, 2] = LinguisticTerms.POOR; // criterion 3
    // alternative 3
    alternativesEstimates[0, 2, 0] = LinguisticTerms.FAIR; // criterion 1
    alternativesEstimates[0, 2, 1] = LinguisticTerms.POOR; // criterion 2
    alternativesEstimates[0, 2, 2] = LinguisticTerms.FAIR; // criterion 3

    // expert 2
    // alternative 1
    alternativesEstimates[1, 0, 0] = LinguisticTerms.GOOD; // criterion 1
    alternativesEstimates[1, 0, 1] = LinguisticTerms.FAIR; // criterion 2
    alternativesEstimates[1, 0, 2] = LinguisticTerms.GOOD; // criterion 3
    // alternative 2
    alternativesEstimates[1, 1, 0] = LinguisticTerms.FAIR; // criterion 1
    alternativesEstimates[1, 1, 1] = LinguisticTerms.FAIR; // criterion 2
    alternativesEstimates[1, 1, 2] = LinguisticTerms.GOOD; // criterion 3
    // alternative 3
    alternativesEstimates[1, 2, 0] = LinguisticTerms.EXCELLENT; // criterion 1
    alternativesEstimates[1, 2, 1] = LinguisticTerms.GOOD; // criterion 2
    alternativesEstimates[1, 2, 2] = LinguisticTerms.GOOD; // criterion 3

    // expert 3
    // alternative 1
    alternativesEstimates[2, 0, 0] = LinguisticTerms.POOR; // criterion 1
    alternativesEstimates[2, 0, 1] = LinguisticTerms.GOOD; // criterion 2
    alternativesEstimates[2, 0, 2] = LinguisticTerms.FAIR; // criterion 3
    // alternative 2
    alternativesEstimates[2, 1, 0] = LinguisticTerms.EXCELLENT; // criterion 1
    alternativesEstimates[2, 1, 1] = LinguisticTerms.GOOD; // criterion 2
    alternativesEstimates[2, 1, 2] = LinguisticTerms.EXCELLENT; // criterion 3
    // alternative 3
    alternativesEstimates[2, 2, 0] = LinguisticTerms.FAIR; // criterion 1
    alternativesEstimates[2, 2, 1] = LinguisticTerms.FAIR; // criterion 2
    alternativesEstimates[2, 2, 2] = LinguisticTerms.GOOD; // criterion 3
}
else
{
    Console.WriteLine("\nEnter estimates of alternatives.");
    for (int expert = 0; expert < experts; expert++)
        for (int criteria = 0; criteria < criterias; criteria++)
            for (int alternative = 0; alternative < alternatives; alternative++)
            {
                Console.WriteLine($"Expert {expert + 1}, criteria {criteria + 1}, alternative {alternative + 1}, :");
                alternativesEstimates[expert, criteria, alternative] = ConsoleInput.ChooseFrom(LinguisticTerms.GetLinguisticScaleOfAlternative);
            }
}
Console.WriteLine("\nEstimates of alternatives:");
for (int i = 0; i < experts; i++)
{
    Console.WriteLine($"Expert #{i + 1}");
    for (int j = 0; j <= criterias; j++)
    {
        for (int k = 0; k <= alternatives; k++)
            if (j == 0 && k == 0)
                Console.Write(String.Format("{0,16}|", ""));
            else if (j == 0 && k > 0)
                Console.Write(String.Format("{0,16}|", $"Alternative {k}"));
            else if (j > 0 && k == 0)
                Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
            else
                Console.Write(String.Format("{0,16}|", $"{alternativesEstimates[i, j - 1, k - 1]}"));
        Console.WriteLine();
    }
}


