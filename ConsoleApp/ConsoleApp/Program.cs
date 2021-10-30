using System;

bool testData = false;

int criterias;
int alternatives;
int experts;

if (testData)
{
    criterias = 6;
    alternatives = 8;
    experts = 4;
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
    criteriasEstimates = new string[6, 4]
    {
        { LinguisticTerms.LOW, LinguisticTerms.MEDIUM, LinguisticTerms.VERY_LOW, LinguisticTerms.MEDIUM },
        { LinguisticTerms.LOW, LinguisticTerms.HIGH, LinguisticTerms.VERY_HIGH, LinguisticTerms.LOW },
        { LinguisticTerms.VERY_LOW, LinguisticTerms.MEDIUM, LinguisticTerms.HIGH, LinguisticTerms.VERY_HIGH },
        { LinguisticTerms.VERY_LOW, LinguisticTerms.LOW, LinguisticTerms.HIGH, LinguisticTerms.MEDIUM },
        { LinguisticTerms.LOW, LinguisticTerms.MEDIUM, LinguisticTerms.VERY_LOW, LinguisticTerms.MEDIUM },
        { LinguisticTerms.HIGH, LinguisticTerms.VERY_HIGH, LinguisticTerms.LOW, LinguisticTerms.MEDIUM }
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
    criteriasBenefit = new bool[6]
    {
        false,
        true,
        false,
        false,
        true,
        true
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
    // criterion 1
    alternativesEstimates[0, 0, 0] = LinguisticTerms.FAIR; // alternative 1
    alternativesEstimates[0, 0, 1] = LinguisticTerms.POOR; // alternative 2
    alternativesEstimates[0, 0, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[0, 0, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[0, 0, 4] = LinguisticTerms.VERY_POOR; // alternative 5
    alternativesEstimates[0, 0, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[0, 0, 6] = LinguisticTerms.POOR; // alternative 7
    alternativesEstimates[0, 0, 7] = LinguisticTerms.FAIR; // alternative 8
    // criterion 2
    alternativesEstimates[0, 1, 0] = LinguisticTerms.POOR; // alternative 1
    alternativesEstimates[0, 1, 1] = LinguisticTerms.VERY_POOR; // alternative 2
    alternativesEstimates[0, 1, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[0, 1, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[0, 1, 4] = LinguisticTerms.EXCELLENT; // alternative 5
    alternativesEstimates[0, 1, 5] = LinguisticTerms.VERY_GOOD; // alternative 6
    alternativesEstimates[0, 1, 6] = LinguisticTerms.POOR; // alternative 7
    alternativesEstimates[0, 1, 7] = LinguisticTerms.POOR; // alternative 8
    // criterion 3
    alternativesEstimates[0, 2, 0] = LinguisticTerms.FAIR; // alternative 1
    alternativesEstimates[0, 2, 1] = LinguisticTerms.EXCELLENT; // alternative 2
    alternativesEstimates[0, 2, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[0, 2, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[0, 2, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[0, 2, 5] = LinguisticTerms.POOR; // alternative 6
    alternativesEstimates[0, 2, 6] = LinguisticTerms.GOOD; // alternative 7
    alternativesEstimates[0, 2, 7] = LinguisticTerms.POOR; // alternative 8
    // criterion 4
    alternativesEstimates[0, 3, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[0, 3, 1] = LinguisticTerms.POOR; // alternative 2
    alternativesEstimates[0, 3, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[0, 3, 3] = LinguisticTerms.VERY_GOOD; // alternative 4
    alternativesEstimates[0, 3, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[0, 3, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[0, 3, 6] = LinguisticTerms.FAIR; // alternative 7
    alternativesEstimates[0, 3, 7] = LinguisticTerms.GOOD; // alternative 8
    // criterion 5
    alternativesEstimates[0, 4, 0] = LinguisticTerms.EXCELLENT; // alternative 1
    alternativesEstimates[0, 4, 1] = LinguisticTerms.GOOD; // alternative 2
    alternativesEstimates[0, 4, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[0, 4, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[0, 4, 4] = LinguisticTerms.VERY_POOR; // alternative 5
    alternativesEstimates[0, 4, 5] = LinguisticTerms.FAIR; // alternative 6
    alternativesEstimates[0, 4, 6] = LinguisticTerms.POOR; // alternative 7
    alternativesEstimates[0, 4, 7] = LinguisticTerms.FAIR; // alternative 8
    // criterion 6
    alternativesEstimates[0, 5, 0] = LinguisticTerms.VERY_POOR; // alternative 1
    alternativesEstimates[0, 5, 1] = LinguisticTerms.VERY_POOR; // alternative 2
    alternativesEstimates[0, 5, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[0, 5, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[0, 5, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[0, 5, 5] = LinguisticTerms.POOR; // alternative 6
    alternativesEstimates[0, 5, 6] = LinguisticTerms.POOR; // alternative 7
    alternativesEstimates[0, 5, 7] = LinguisticTerms.FAIR; // alternative 8

    // expert 2
    // criterion 1
    alternativesEstimates[1, 0, 0] = LinguisticTerms.FAIR; // alternative 1
    alternativesEstimates[1, 0, 1] = LinguisticTerms.FAIR; // alternative 2
    alternativesEstimates[1, 0, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[1, 0, 3] = LinguisticTerms.VERY_GOOD; // alternative 4
    alternativesEstimates[1, 0, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[1, 0, 5] = LinguisticTerms.VERY_GOOD; // alternative 6
    alternativesEstimates[1, 0, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[1, 0, 7] = LinguisticTerms.GOOD; // alternative 8
    // criterion 2
    alternativesEstimates[1, 1, 0] = LinguisticTerms.EXCELLENT; // alternative 1
    alternativesEstimates[1, 1, 1] = LinguisticTerms.POOR; // alternative 2
    alternativesEstimates[1, 1, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[1, 1, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[1, 1, 4] = LinguisticTerms.VERY_POOR; // alternative 5
    alternativesEstimates[1, 1, 5] = LinguisticTerms.FAIR; // alternative 6
    alternativesEstimates[1, 1, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[1, 1, 7] = LinguisticTerms.POOR; // alternative 8
    // criterion 3
    alternativesEstimates[1, 2, 0] = LinguisticTerms.VERY_POOR; // alternative 1
    alternativesEstimates[1, 2, 1] = LinguisticTerms.EXCELLENT; // alternative 2
    alternativesEstimates[1, 2, 2] = LinguisticTerms.VERY_POOR; // alternative 3
    alternativesEstimates[1, 2, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[1, 2, 4] = LinguisticTerms.POOR; // alternative 5
    alternativesEstimates[1, 2, 5] = LinguisticTerms.FAIR; // alternative 6
    alternativesEstimates[1, 2, 6] = LinguisticTerms.VERY_POOR; // alternative 7
    alternativesEstimates[1, 2, 7] = LinguisticTerms.FAIR; // alternative 8
    // criterion 4
    alternativesEstimates[1, 3, 0] = LinguisticTerms.VERY_GOOD; // alternative 1
    alternativesEstimates[1, 3, 1] = LinguisticTerms.FAIR; // alternative 2
    alternativesEstimates[1, 3, 2] = LinguisticTerms.VERY_GOOD; // alternative 3
    alternativesEstimates[1, 3, 3] = LinguisticTerms.VERY_GOOD; // alternative 4
    alternativesEstimates[1, 3, 4] = LinguisticTerms.VERY_GOOD; // alternative 5
    alternativesEstimates[1, 3, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[1, 3, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[1, 3, 7] = LinguisticTerms.EXCELLENT; // alternative 8
    // criterion 5
    alternativesEstimates[1, 4, 0] = LinguisticTerms.VERY_GOOD; // alternative 1
    alternativesEstimates[1, 4, 1] = LinguisticTerms.VERY_GOOD; // alternative 2
    alternativesEstimates[1, 4, 2] = LinguisticTerms.VERY_GOOD; // alternative 3
    alternativesEstimates[1, 4, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[1, 4, 4] = LinguisticTerms.POOR; // alternative 5
    alternativesEstimates[1, 4, 5] = LinguisticTerms.FAIR; // alternative 6
    alternativesEstimates[1, 4, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[1, 4, 7] = LinguisticTerms.POOR; // alternative 8
    // criterion 6
    alternativesEstimates[1, 5, 0] = LinguisticTerms.FAIR; // alternative 1
    alternativesEstimates[1, 5, 1] = LinguisticTerms.EXCELLENT; // alternative 2
    alternativesEstimates[1, 5, 2] = LinguisticTerms.VERY_GOOD; // alternative 3
    alternativesEstimates[1, 5, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[1, 5, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[1, 5, 5] = LinguisticTerms.VERY_GOOD; // alternative 6
    alternativesEstimates[1, 5, 6] = LinguisticTerms.VERY_GOOD; // alternative 7
    alternativesEstimates[1, 5, 7] = LinguisticTerms.EXCELLENT; // alternative 8

    // expert 3
    // criterion 1
    alternativesEstimates[2, 0, 0] = LinguisticTerms.EXCELLENT; // alternative 1
    alternativesEstimates[2, 0, 1] = LinguisticTerms.EXCELLENT; // alternative 2
    alternativesEstimates[2, 0, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[2, 0, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[2, 0, 4] = LinguisticTerms.VERY_GOOD; // alternative 5
    alternativesEstimates[2, 0, 5] = LinguisticTerms.EXCELLENT; // alternative 6
    alternativesEstimates[2, 0, 6] = LinguisticTerms.VERY_POOR; // alternative 7
    alternativesEstimates[2, 0, 7] = LinguisticTerms.VERY_POOR; // alternative 8
    // criterion 2
    alternativesEstimates[2, 1, 0] = LinguisticTerms.POOR; // alternative 1
    alternativesEstimates[2, 1, 1] = LinguisticTerms.POOR; // alternative 2
    alternativesEstimates[2, 1, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[2, 1, 3] = LinguisticTerms.VERY_GOOD; // alternative 4
    alternativesEstimates[2, 1, 4] = LinguisticTerms.VERY_GOOD; // alternative 5
    alternativesEstimates[2, 1, 5] = LinguisticTerms.VERY_GOOD; // alternative 6
    alternativesEstimates[2, 1, 6] = LinguisticTerms.FAIR; // alternative 7
    alternativesEstimates[2, 1, 7] = LinguisticTerms.FAIR; // alternative 8
    // criterion 3
    alternativesEstimates[2, 2, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[2, 2, 1] = LinguisticTerms.VERY_GOOD; // alternative 2
    alternativesEstimates[2, 2, 2] = LinguisticTerms.VERY_POOR; // alternative 3
    alternativesEstimates[2, 2, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[2, 2, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[2, 2, 5] = LinguisticTerms.POOR; // alternative 6
    alternativesEstimates[2, 2, 6] = LinguisticTerms.POOR; // alternative 7
    alternativesEstimates[2, 2, 7] = LinguisticTerms.VERY_POOR; // alternative 8
    // criterion 4
    alternativesEstimates[2, 3, 0] = LinguisticTerms.VERY_GOOD; // alternative 1
    alternativesEstimates[2, 3, 1] = LinguisticTerms.VERY_GOOD; // alternative 2
    alternativesEstimates[2, 3, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[2, 3, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[2, 3, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[2, 3, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[2, 3, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[2, 3, 7] = LinguisticTerms.EXCELLENT; // alternative 8
    // criterion 5
    alternativesEstimates[2, 4, 0] = LinguisticTerms.FAIR; // alternative 1
    alternativesEstimates[2, 4, 1] = LinguisticTerms.GOOD; // alternative 2
    alternativesEstimates[2, 4, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[2, 4, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[2, 4, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[2, 4, 5] = LinguisticTerms.VERY_GOOD; // alternative 6
    alternativesEstimates[2, 4, 6] = LinguisticTerms.VERY_GOOD; // alternative 7
    alternativesEstimates[2, 4, 7] = LinguisticTerms.FAIR; // alternative 8
    // criterion 6
    alternativesEstimates[2, 5, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[2, 5, 1] = LinguisticTerms.VERY_GOOD; // alternative 2
    alternativesEstimates[2, 5, 2] = LinguisticTerms.POOR; // alternative 3
    alternativesEstimates[2, 5, 3] = LinguisticTerms.EXCELLENT; // alternative 4
    alternativesEstimates[2, 5, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[2, 5, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[2, 5, 6] = LinguisticTerms.FAIR; // alternative 7
    alternativesEstimates[2, 5, 7] = LinguisticTerms.POOR; // alternative 8

    // expert 4
    // criterion 1
    alternativesEstimates[3, 0, 0] = LinguisticTerms.EXCELLENT; // alternative 1
    alternativesEstimates[3, 0, 1] = LinguisticTerms.FAIR; // alternative 2
    alternativesEstimates[3, 0, 2] = LinguisticTerms.EXCELLENT; // alternative 3
    alternativesEstimates[3, 0, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[3, 0, 4] = LinguisticTerms.VERY_GOOD; // alternative 5
    alternativesEstimates[3, 0, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[3, 0, 6] = LinguisticTerms.VERY_POOR; // alternative 7
    alternativesEstimates[3, 0, 7] = LinguisticTerms.POOR; // alternative 8
    // criterion 2
    alternativesEstimates[3, 1, 0] = LinguisticTerms.POOR; // alternative 1
    alternativesEstimates[3, 1, 1] = LinguisticTerms.VERY_POOR; // alternative 2
    alternativesEstimates[3, 1, 2] = LinguisticTerms.FAIR; // alternative 3
    alternativesEstimates[3, 1, 3] = LinguisticTerms.FAIR; // alternative 4
    alternativesEstimates[3, 1, 4] = LinguisticTerms.VERY_GOOD; // alternative 5
    alternativesEstimates[3, 1, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[3, 1, 6] = LinguisticTerms.VERY_GOOD; // alternative 7
    alternativesEstimates[3, 1, 7] = LinguisticTerms.VERY_GOOD; // alternative 8
    // criterion 3
    alternativesEstimates[3, 2, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[3, 2, 1] = LinguisticTerms.GOOD; // alternative 2
    alternativesEstimates[3, 2, 2] = LinguisticTerms.EXCELLENT; // alternative 3
    alternativesEstimates[3, 2, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[3, 2, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[3, 2, 5] = LinguisticTerms.EXCELLENT; // alternative 6
    alternativesEstimates[3, 2, 6] = LinguisticTerms.VERY_GOOD; // alternative 7
    alternativesEstimates[3, 2, 7] = LinguisticTerms.VERY_GOOD; // alternative 8
    // criterion 4
    alternativesEstimates[3, 3, 0] = LinguisticTerms.POOR; // alternative 1
    alternativesEstimates[3, 3, 1] = LinguisticTerms.VERY_POOR; // alternative 2
    alternativesEstimates[3, 3, 2] = LinguisticTerms.VERY_POOR; // alternative 3
    alternativesEstimates[3, 3, 3] = LinguisticTerms.POOR; // alternative 4
    alternativesEstimates[3, 3, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[3, 3, 5] = LinguisticTerms.VERY_POOR; // alternative 6
    alternativesEstimates[3, 3, 6] = LinguisticTerms.EXCELLENT; // alternative 7
    alternativesEstimates[3, 3, 7] = LinguisticTerms.VERY_GOOD; // alternative 8
    // criterion 5
    alternativesEstimates[3, 4, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[3, 4, 1] = LinguisticTerms.EXCELLENT; // alternative 2
    alternativesEstimates[3, 4, 2] = LinguisticTerms.GOOD; // alternative 3
    alternativesEstimates[3, 4, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[3, 4, 4] = LinguisticTerms.FAIR; // alternative 5
    alternativesEstimates[3, 4, 5] = LinguisticTerms.FAIR; // alternative 6
    alternativesEstimates[3, 4, 6] = LinguisticTerms.GOOD; // alternative 7
    alternativesEstimates[3, 4, 7] = LinguisticTerms.VERY_GOOD; // alternative 8
    // criterion 6
    alternativesEstimates[3, 5, 0] = LinguisticTerms.GOOD; // alternative 1
    alternativesEstimates[3, 5, 1] = LinguisticTerms.FAIR; // alternative 2
    alternativesEstimates[3, 5, 2] = LinguisticTerms.VERY_GOOD; // alternative 3
    alternativesEstimates[3, 5, 3] = LinguisticTerms.GOOD; // alternative 4
    alternativesEstimates[3, 5, 4] = LinguisticTerms.GOOD; // alternative 5
    alternativesEstimates[3, 5, 5] = LinguisticTerms.GOOD; // alternative 6
    alternativesEstimates[3, 5, 6] = LinguisticTerms.FAIR; // alternative 7
    alternativesEstimates[3, 5, 7] = LinguisticTerms.FAIR; // alternative 8
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

TriangularNumber[,] criteriasTriangularEstimates = new TriangularNumber[criterias, experts];

for (int criteria = 0; criteria < criterias; criteria++)
    for (int expert = 0; expert < experts; expert++)
        criteriasTriangularEstimates[criteria, expert] = LinguisticTerms.ConvertToTriangularFromLinguisticCriteria(criteriasEstimates[criteria, expert]);

Console.WriteLine("\nTriangular estimates of criterias:");
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
            Console.Write(String.Format("{0,16}|", $"{criteriasTriangularEstimates[j - 1, k - 1]}"));
    Console.WriteLine();
}

TriangularNumber[] aggregatedCriteriasTriangularEstimates = new TriangularNumber[criterias];

for (int criteria = 0; criteria < criterias; criteria++)
{
    float left = float.MaxValue;
    float middle = 0;
    float right = float.MinValue;
    for (int expert = 0; expert < experts; expert++)
    {
        if (criteriasTriangularEstimates[criteria, expert].Left <= left)
            left = criteriasTriangularEstimates[criteria, expert].Left;
        if (criteriasTriangularEstimates[criteria, expert].Right >= right)
            right = criteriasTriangularEstimates[criteria, expert].Right;
        middle += criteriasTriangularEstimates[criteria, expert].Middle;
    }
    middle /= experts;

    aggregatedCriteriasTriangularEstimates[criteria] = new TriangularNumber(left, middle, right);
}

Console.WriteLine("\nAggregated triangular estimates of criterias:");
Console.WriteLine(String.Format("{0,16}|{1,16}|", "Criterion", "Scales"));
for (int criteria = 0; criteria < criterias; criteria++)
{
    Console.Write(String.Format("{0,16}|{1,16}|", $"Criterion {criteria + 1}", $"{aggregatedCriteriasTriangularEstimates[criteria]}"));
    Console.WriteLine();
}

TriangularNumber[,,] alternativesTriangularEstimates = new TriangularNumber[experts, criterias, alternatives];
for (int expert = 0; expert < experts; expert++)
    for (int criteria = 0; criteria < criterias; criteria++)
        for (int alternative = 0; alternative < alternatives; alternative++)
            alternativesTriangularEstimates[expert, criteria, alternative] = LinguisticTerms.ConvertToTriangularFromLinguisticAlternative(alternativesEstimates[expert, criteria, alternative]);

Console.WriteLine("\nTriangular estimates of alternatives:");
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
                Console.Write(String.Format("{0,16}|", $"{alternativesTriangularEstimates[i, j - 1, k - 1]}"));
        Console.WriteLine();
    }
}

TriangularNumber[,] aggregatedAlternativesTriangularEstimates = new TriangularNumber[criterias, alternatives];
for (int criteria = 0; criteria < criterias; criteria++)
{
    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        float left = float.MaxValue;
        float middle = 0;
        float right = float.MinValue;
        for (int expert = 0; expert < experts; expert++)
        {
            if (alternativesTriangularEstimates[expert, criteria, alternative].Left <= left)
                left = alternativesTriangularEstimates[expert, criteria, alternative].Left;
            if (alternativesTriangularEstimates[expert, criteria, alternative].Right >= right)
                right = alternativesTriangularEstimates[expert, criteria, alternative].Right;
            middle += alternativesTriangularEstimates[expert, criteria, alternative].Middle;
        }
        middle /= experts;

        aggregatedAlternativesTriangularEstimates[criteria, alternative] = new TriangularNumber(left, middle, right);
    }
}

Console.WriteLine("\nAggregated estimates of alternatives:");

for (int criteria = 0; criteria <= criterias; criteria++)
{
    for (int alternative = 0; alternative <= alternatives; alternative++)
        if (criteria == 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", ""));
        else if (criteria == 0 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"Alternative {alternative}"));
        else if (criteria > 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", $"Criterion {criteria}"));
        else
            Console.Write(String.Format("{0,20}|", $"{aggregatedAlternativesTriangularEstimates[criteria - 1, alternative - 1]}"));
    Console.WriteLine();
}

TriangularNumber[] fStar = new TriangularNumber[criterias];
for (int criteria = 0; criteria < criterias; criteria++)
{
    float left = float.MaxValue;
    float middle = float.MaxValue;
    float right = float.MaxValue;

    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Left <= left)
            left = aggregatedAlternativesTriangularEstimates[criteria, alternative].Left;

        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Middle <= middle)
            middle = aggregatedAlternativesTriangularEstimates[criteria, alternative].Middle;

        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Right <= right)
            right = aggregatedAlternativesTriangularEstimates[criteria, alternative].Right;
    }
    fStar[criteria] = new TriangularNumber(left, middle, right);
}

TriangularNumber[] fO = new TriangularNumber[criterias];
for (int criteria = 0; criteria < criterias; criteria++)
{
    float left = float.MinValue;
    float middle = float.MinValue;
    float right = float.MinValue;

    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Left >= left)
            left = aggregatedAlternativesTriangularEstimates[criteria, alternative].Left;

        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Middle >= middle)
            middle = aggregatedAlternativesTriangularEstimates[criteria, alternative].Middle;

        if (aggregatedAlternativesTriangularEstimates[criteria, alternative].Right >= right)
            right = aggregatedAlternativesTriangularEstimates[criteria, alternative].Right;
    }
    fO[criteria] = new TriangularNumber(left, middle, right);
}

Console.WriteLine("\nIdeal and worst values of criterias:");
Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|", "Criterion", "f*", "fo"));
for (int criteria = 0; criteria < criterias; criteria++)
{
    Console.Write(String.Format("{0,20}|{1,20}|{2,20}|", $"Criterion {criteria + 1}", $"{fStar[criteria]}", $"{fO[criteria]}"));
    Console.WriteLine();
}

TriangularNumber[,] d = new TriangularNumber[criterias, alternatives];
for (int criteria = 0; criteria < criterias; criteria++)
{
    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        float divider = fO[criteria].Right - fStar[criteria].Left;

        //triangular number diff
        float left = aggregatedAlternativesTriangularEstimates[criteria, alternative].Left - fStar[criteria].Right;
        float middle = aggregatedAlternativesTriangularEstimates[criteria, alternative].Middle - fStar[criteria].Middle;
        float right = aggregatedAlternativesTriangularEstimates[criteria, alternative].Right - fStar[criteria].Left;

        d[criteria, alternative] = new TriangularNumber(left / divider, middle / divider, right / divider);
    }
}

Console.WriteLine("\n~d:");
for (int criteria = 0; criteria <= criterias; criteria++)
{
    for (int alternative = 0; alternative <= alternatives; alternative++)
        if (criteria == 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", ""));
        else if (criteria == 0 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"Alternative {alternative}"));
        else if (criteria > 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", $"Criterion {criteria}"));
        else
            Console.Write(String.Format("{0,20}|", $"{d[criteria - 1, alternative - 1]}"));
    Console.WriteLine();
}

TriangularNumber[] S = new TriangularNumber[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    TriangularNumber sum = new TriangularNumber();
    for (int criteria = 0; criteria < criterias; criteria++)
        sum += aggregatedCriteriasTriangularEstimates[criteria] * d[criteria, alternative];

    S[alternative] = sum;
}

TriangularNumber[] R = new TriangularNumber[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    float left = float.MinValue;
    float middle = float.MinValue;
    float right = float.MinValue;
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        TriangularNumber mul = aggregatedCriteriasTriangularEstimates[criteria] * d[criteria, alternative];
        if (mul.Left >= left)
            left = mul.Left;
        if (mul.Middle >= middle)
            middle = mul.Middle;
        if (mul.Right >= right)
            right = mul.Right;
    }

    R[alternative] = new TriangularNumber(left, middle, right);
}

TriangularNumber[] Q = new TriangularNumber[alternatives];

TriangularNumber Sstar = new TriangularNumber(float.MaxValue, float.MaxValue, float.MaxValue);
for (int alternative = 0; alternative < alternatives; alternative++)
{
    if (S[alternative].Left <= Sstar.Left)
        Sstar.Left = S[alternative].Left;
    if (S[alternative].Middle <= Sstar.Middle)
        Sstar.Middle = S[alternative].Middle;
    if (S[alternative].Right <= Sstar.Right)
        Sstar.Right = S[alternative].Right;
}

float Sr = float.MinValue;
for (int alternative = 0; alternative < alternatives; alternative++)
    if (S[alternative].Right >= Sr)
        Sr = S[alternative].Right;

TriangularNumber Rstar = new TriangularNumber(float.MaxValue, float.MaxValue, float.MaxValue);
for (int alternative = 0; alternative < alternatives; alternative++)
{
    if (R[alternative].Left <= Rstar.Left)
        Rstar.Left = R[alternative].Left;
    if (R[alternative].Middle <= Rstar.Middle)
        Rstar.Middle = R[alternative].Middle;
    if (R[alternative].Right <= Rstar.Right)
        Rstar.Right = R[alternative].Right;
}

float Rr = float.MinValue;
for (int alternative = 0; alternative < alternatives; alternative++)
    if (R[alternative].Right >= Rr)
        Rr = R[alternative].Right;

float v = 0.5f;

for (int alternative = 0; alternative < alternatives; alternative++)
    Q[alternative] = v * (S[alternative] - Sstar) / (Sr - Sstar.Left) + (1f - v) * (R[alternative] - Rstar) / (Rr - Rstar.Left);

Console.WriteLine("S, R and Q:");
for (int i = 0; i < 4; i++)
{
    for (int alternative = 0; alternative <= alternatives; alternative++)
    {
        if (i == 0 && alternative == 0)
            Console.Write(String.Format("{0,30}|", ""));
        else if (i == 0 && alternative > 0)
            Console.Write(String.Format("{0,30}|", $"A{alternative}"));
        else if (i == 1 && alternative == 0)
            Console.Write(String.Format("{0,30}|", "S"));
        else if (i == 1 && alternative > 0)
            Console.Write(String.Format("{0,30}|", $"{S[alternative - 1]}"));
        else if (i == 2 && alternative == 0)
            Console.Write(String.Format("{0,30}|", "R"));
        else if (i == 2 && alternative > 0)
            Console.Write(String.Format("{0,30}|", $"{R[alternative - 1]}"));
        else if (i == 3 && alternative == 0)
            Console.Write(String.Format("{0,30}|", "Q"));
        else if (i == 3 && alternative > 0)
            Console.Write(String.Format("{0,30}|", $"{Q[alternative - 1]}"));
    }
    Console.WriteLine();
}

float[] defuzzificatedS = new float[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
    defuzzificatedS[alternative] = (S[alternative].Left + 2 * S[alternative].Middle + S[alternative].Right) / 4f;

float[] defuzzificatedR = new float[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
    defuzzificatedR[alternative] = (R[alternative].Left + 2 * R[alternative].Middle + R[alternative].Right) / 4f;

float[] defuzzificatedQ = new float[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
    defuzzificatedQ[alternative] = (Q[alternative].Left + 2 * Q[alternative].Middle + Q[alternative].Right) / 4f;

Console.WriteLine("Defuzzification S, R and Q:");
for (int i = 0; i < 4; i++)
{
    for (int alternative = 0; alternative <= alternatives; alternative++)
    {
        if (i == 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", ""));
        else if (i == 0 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"A{alternative}"));
        else if (i == 1 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "S"));
        else if (i == 1 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{defuzzificatedS[alternative - 1]}"));
        else if (i == 2 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "R"));
        else if (i == 2 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{defuzzificatedR[alternative - 1]}"));
        else if (i == 3 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "Q"));
        else if (i == 3 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{defuzzificatedQ[alternative - 1]}"));
    }
    Console.WriteLine();
}

int[] rankedS = new int[alternatives];
int steps = alternatives;
int rank = 1;
do
{
    float min = float.MaxValue;
    int minIndex = 0;
    for (int alternative = 0; alternative < alternatives; alternative++)
    {
       if (defuzzificatedS[alternative] <= min && rankedS[alternative] == 0)
       {
            min = defuzzificatedS[alternative];
            minIndex = alternative;
       }
    }

    rankedS[minIndex] = rank++;
    steps--;

} while (steps > 0);

int[] rankedR = new int[alternatives];
steps = alternatives;
rank = 1;
do
{
    float min = float.MaxValue;
    int minIndex = 0;
    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        if (defuzzificatedR[alternative] <= min && rankedR[alternative] == 0)
        {
            min = defuzzificatedR[alternative];
            minIndex = alternative;
        }
    }

    rankedR[minIndex] = rank++;
    steps--;

} while (steps > 0);

int[] rankedQ = new int[alternatives];
steps = alternatives;
rank = 1;
do
{
    float min = float.MaxValue;
    int minIndex = 0;
    for (int alternative = 0; alternative < alternatives; alternative++)
    {
        if (defuzzificatedQ[alternative] <= min && rankedQ[alternative] == 0)
        {
            min = defuzzificatedQ[alternative];
            minIndex = alternative;
        }
    }

    rankedQ[minIndex] = rank++;
    steps--;

} while (steps > 0);

Console.WriteLine("Ranking S, R and Q:");
for (int i = 0; i < 4; i++)
{
    for (int alternative = 0; alternative <= alternatives; alternative++)
    {
        if (i == 0 && alternative == 0)
            Console.Write(String.Format("{0,20}|", ""));
        else if (i == 0 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"A{alternative}"));
        else if (i == 1 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "S"));
        else if (i == 1 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{rankedS[alternative - 1]}"));
        else if (i == 2 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "R"));
        else if (i == 2 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{rankedR[alternative - 1]}"));
        else if (i == 3 && alternative == 0)
            Console.Write(String.Format("{0,20}|", "Q"));
        else if (i == 3 && alternative > 0)
            Console.Write(String.Format("{0,20}|", $"{rankedQ[alternative - 1]}"));
    }
    Console.WriteLine();
}

int QA1Index = -1;
int QA2Index = -2;
for (int alternative = 0; alternative < alternatives; alternative++)
{
    if (rankedQ[alternative] == 1)
        QA1Index = alternative;
    else if (rankedQ[alternative] == 2)
        QA2Index = alternative;
}

float Adv = defuzzificatedQ[QA2Index] - defuzzificatedQ[QA1Index];
Console.WriteLine($"Adv: {Adv}.");

float DQ = 1f / (alternatives - 1);
Console.WriteLine($"DQ: {DQ}.");

bool firstConditionMet =
     //Math.Abs(Adv - DQ) <= ((Math.Abs(Adv) < Math.Abs(DQ) ? Math.Abs(DQ) : Math.Abs(Adv)) * float.Epsilon) // ==
     //||
     //(Adv - DQ) > ((Math.Abs(Adv) < Math.Abs(DQ) ? Math.Abs(DQ) : Math.Abs(Adv)) * float.Epsilon);

    Adv >= DQ;
if (firstConditionMet)
{
    Console.WriteLine($"1 condition is met. Adv >= DQ.");
} 
else
{
    Console.WriteLine($"1 condition is not met. Adv < DQ.");
}

bool QA1SRankIsOne = rankedS[QA1Index] == 1;
bool QA1RRankIsOne = rankedR[QA1Index] == 1;
bool secondConditionMet = QA1SRankIsOne || QA1RRankIsOne;

if (secondConditionMet)
{
    Console.Write($"2 condition is met. ");
    if (QA1SRankIsOne)
        Console.Write($"A(1) S rank = 1. ");
    if (QA1RRankIsOne)
        Console.Write($"A(1) R rank = 1. ");
}
else
{
    Console.Write($"2 condition is not met. A(1) S rank != 1 and A(1) R rank != 1.");
}

Console.WriteLine();
if (firstConditionMet && !secondConditionMet)
{
    Console.WriteLine($"Best alternatives: A{QA1Index + 1} A{QA2Index + 1}");
} 
else
{
    Console.Write($"Best alternatives:");
    int m = 0;
    if (alternatives == 2)
        m = 1;
    else
        m = alternatives / 2;

    for (int alternative = 0; alternative < alternatives; alternative++)
    {

        Adv = defuzzificatedQ[alternative] - defuzzificatedQ[QA1Index];
        bool isBest = Adv < DQ;
             //Math.Abs(Adv - DQ) <= ((Math.Abs(Adv) < Math.Abs(DQ) ? Math.Abs(DQ) : Math.Abs(Adv)) * float.Epsilon) // ==
             //||
             //(Adv - DQ) < ((Math.Abs(Adv) < Math.Abs(DQ) ? Math.Abs(DQ) : Math.Abs(Adv)) * float.Epsilon);

        if (isBest && rankedQ[alternative] <= m)
            Console.Write($" A{alternative + 1}");
    }

}

Console.ReadKey();






