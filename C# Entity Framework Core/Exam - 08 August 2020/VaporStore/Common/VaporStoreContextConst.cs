namespace VaporStore.Common
{
    public static class VaporStoreContextConst
    {
        //Game
        public const double GamePriceMinValue = 0;

        //User
        public const int UserNameMinLenght = 3;
        public const int UserNameMaxLenght = 20;
        public const string UserFullNameValitadion = @"^[A-Z]{1}[a-z]* [A-Z]{1}[a-z]*$";
        public const double UserMinAge = 3;
        public const double UserMaxAge = 103;

        //Card
        public const string CardNumberValidation = @"^[\d]{4} [\d]{4} [\d]{4} [\d]{4}$";
        public const string CardCvcValidation = @"^[\d]{3}$";

        //Purchase
        public const string PurchaseProductKeyValidation = @"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$";
    }
}
