namespace IngredientCalculator.Business
{
    public static class Converters
    {
        public static double TeaSpoonToTableSpoon(double teaSpoon)
        {
            return teaSpoon / 3.0;
        }

        public static double TableSpoonToCup(double tableSpoon)
        {
            return tableSpoon / 16.0;
        }

        public static double TableSpoonToOunce(double tableSpoon)
        {
            return tableSpoon / 2.0;
        }

        public static double OunceToCup(double ounce)
        {
            return ounce / 8.0;
        }

        public static double OunceToTableSpoon(double ounce)
        {
            return ounce * 2.0;
        }
       
        // 1 C ~ 8oz dry for simplicity
        public static double CupToOunce(double cup)
        {
            return 8.0 * cup;
        }

        public static double CupToTableSpoon(double cup)
        {
            return cup * 16.0;
        }

        public static double GramToOunce(double gram)
        {
            return gram * 0.035274;
        }
    }
}