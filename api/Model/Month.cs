namespace api.Model
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

        public static List<string> sortedOrderList = new List<string>()
        {
            January.ToString(), February.ToString(), March.ToString(), April.ToString(), May.ToString(), June.ToString(), October.ToString(), November.ToString(), December.ToString()
        };
    }
}
