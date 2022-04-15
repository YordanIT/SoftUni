using System;

namespace Theatre.Common
{
    public static class GlobalConst
    {
        //Theatre
        public const int TheatreNameMinLenght = 4;    
        public const int TheatreNameMaxLenght = 30;    
        public const double TheatreNumberOfHallsMinValue = 1;    
        public const double TheatreNumberOfHallsMaxValue = 10;    
        public const int TheatreDirectorMinLenght = 4;    
        public const int TheatreDirectorMaxLenght = 30;

        //Play
        public const int PlayTitleMinlenght = 4;
        public const int PlayTitleMaxlenght = 50;
        public const double PlayRatingMinValue = 0.00;
        public const double PlayRatingMaxValue = 10.00;
        public const int PlayDescriptionMaxLenght = 700;
        public const int PlayScreenwriterMinLenght = 4;
        public const int PlayScreenwriterMaxLenght = 30;

        //Cast
        public const int CastFullNameMinLenght = 4;
        public const int CastFullNameMaxLenght = 30;
        public const string CastPhoneNumberRegex = @"^\+44-\d{2}-\d{3}-\d{4}$";

        //Ticket
        public const double TicketPriceMinValue = 1.00;
        public const double TicketPriceMaxValue = 100.00;
        public const double TicketRowNumberMinValue = 1;
        public const double TicketRowNumberMaxValue = 10;
    }
}



