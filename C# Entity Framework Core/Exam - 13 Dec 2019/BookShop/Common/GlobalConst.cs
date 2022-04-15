namespace BookShop.Common
{
    public static class GlobalConst
    {
        //Author
        public const int AuthorNameMinLenght = 3;
        public const int AuthorNameMaxLenght = 30;
        public const string AuthorPhoneRegex = @"^\d{3}-\d{3}-\d{4}$";

        //Book
        public const int BookNameMinLenght = 3;
        public const int BookNameMaxLenght = 30;
        public const double BookPriceMinValue = 0.01;
        public const double BookPriceMaxValue = double.MaxValue;
        public const int BookPagesMinValue = 50;
        public const int BookPagesMaxValue = 5000;

    }
}
