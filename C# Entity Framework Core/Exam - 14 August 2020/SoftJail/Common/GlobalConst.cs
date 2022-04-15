namespace SoftJail.Common
{
    public static class GlobalConst
    {
        //Prisoner
        public const int PrisonerFullNameMinLenght = 3;
        public const int PrisonerFullNameMaxLenght = 20;
        public const double PrisonerAgeMinValue = 18;
        public const double PrisonerAgeMaxValue = 65;
        public const double PrisonerBailMinValue = 0;
        public const string PrisonerNickNameRegrex = @"^The [A-Z]{1}[a-z]+$";
        
        //Officer
        public const int OfficerFullNameMinLenght = 3;
        public const int OfficerFullNameMaxLenght = 30;
        public const double OfficerSalaryMinValue = 0;

        //Cell
        public const double CellNumberMinValue = 1;
        public const double CellNumberMaxValue = 1000;

        //Department
        public const int DepartmentNameMinLenght = 3;
        public const int DepartmentNameMaxLenght = 25;

        //Mail
        public const string MailAddressRegex = @"^[A-Za-z\d ]+ str.$";
    }
}
