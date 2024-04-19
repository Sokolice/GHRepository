namespace API.Domain
{
    public class Month
    {
        public static string January => "Leden";
        public static string February => "Únor";
        public static string March => "Březen";
        public static string April => "Duben";
        public static string May => "Květen";
        public static string June => "Červen";
        public static string July => "Červenec";
        public static string August => "Srpen";
        public static string September => "Září";
        public static string October => "Říjen";
        public static string November => "Listopad";
        public static string December => "Prosinec";

        public static string getMonthName(int index)
        {
            switch (index)
            {
                case 1:
                    return January;
                case 2:
                    return February;
                case 3:
                    return March;
                case 4:
                    return April;
                case 5:
                    return May;
                case 6:
                    return June;
                case 7:
                    return July;
                case 8:
                    return August;
                case 9:
                    return September;
                case 10:
                    return October;
                case 11:
                    return November;
                case 12:
                    return December;
                default:
                    return January;
            }
        }
    }
}
