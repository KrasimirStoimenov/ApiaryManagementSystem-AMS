namespace ApiaryManagementSystem.Domain.Constants;

public sealed class Models
{
    public class Common
    {
        public const int Zero = 0;
        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;
        public const int EnumerationNameMaxLength = 100;
    }

    public class Apiary
    {
        public const int LocationMinLength = 1;
        public const int LocationMaxLength = 50;
    }
    public class Hive
    {
        public const int NumberMinLength = 1;
        public const int NumberMaxLength = 30;
        public const int TypeMinLength = 3;
        public const int TypeMaxLength = 30;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 30;
        public const int ColorMaxLength = 30;
    }

    public class BeeQueen
    {
        public const int ColorMarkMaxLength = 30;
        public const int YearMinValue = 1900;
        public const int YearMaxValue = 9999;
    }

    public class Harvest
    {
        public const int HarvestedProductMaxLength = 30;
        public const int AmountMaxValue = 100000;
    }
}
