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

    }
}




