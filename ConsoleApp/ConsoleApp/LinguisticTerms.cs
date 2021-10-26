using System.Text;

public static class LinguisticTerms
{
    public const string VERY_LOW = "VL"; // very low 
    public const string LOW = "L"; // low 
    public const string MEDIUM = "M"; // medium
    public const string HIGH = "H"; // high
    public const string VERY_HIGH = "VH"; // very high

    public const string VERY_POOR = "VP"; // very poor
    public const string POOR = "P"; // poor 
    public const string FAIR = "F"; // fair
    public const string GOOD = "G"; // good
    public const string VERY_GOOD = "VG"; // very good
    public const string EXCELLENT = "E"; // excellent 

    public static string[] GetLinguisticScaleOfCriteria => new string[5] {
            VERY_LOW,
            LOW,
            MEDIUM,
            HIGH,
            VERY_HIGH
        };

    public static string[] GetLinguisticScaleOfAlternative => new string[6] {
            VERY_POOR,
            POOR,
            FAIR,
            GOOD,
            VERY_GOOD,
            EXCELLENT
        };

    public static TriangularNumber ConvertToTriangularFromLinguisticCriteria(string linguisticTerm) =>
        linguisticTerm switch
        {
            VERY_LOW => new TriangularNumber(0f, 0.1f, 0.3f),
            LOW => new TriangularNumber(0.1f, 0.3f, 0.5f),
            MEDIUM => new TriangularNumber(0.3f, 0.5f, 0.7f),
            HIGH => new TriangularNumber(0.5f, 0.7f, 0.9f),
            VERY_HIGH => new TriangularNumber(0.7f, 0.9f, 1f),
            _ => new TriangularNumber()
        };

    public static TriangularNumber ConvertToTriangularFromLinguisticAlternative(string linguisticTerm) =>
        linguisticTerm switch
        {
            VERY_POOR => new TriangularNumber(0f, 0f, 0.2f),
            POOR => new TriangularNumber(0f, 0.2f, 0.4f),
            FAIR => new TriangularNumber(0.2f, 0.4f, 0.6f),
            GOOD => new TriangularNumber(0.4f, 0.6f, 0.8f),
            VERY_GOOD => new TriangularNumber(0.6f, 0.8f, 1f),
            EXCELLENT => new TriangularNumber(0.8f, 0.9f, 1f),
            _ => new TriangularNumber()
        };


    public static string GroupedLingusticTermsToString(string[] groupedLingusticTerms)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[");
        foreach (string term in groupedLingusticTerms)
            stringBuilder.Append($" {term}");
        stringBuilder.Append("]");
        return stringBuilder.ToString();
    }

    public static string GroupedTriangularTermsToString(TriangularNumber[] groupedLingusticTerms)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[");
        foreach (TriangularNumber term in groupedLingusticTerms)
            stringBuilder.Append($" {term}");
        stringBuilder.Append("]");
        return stringBuilder.ToString();
    }
}

