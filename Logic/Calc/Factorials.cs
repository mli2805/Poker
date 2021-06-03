namespace Logic
{
    public static class Factorials
    {
        public static int Factorial(this int number)
        {
            var result = 1;
            for (int i = 2; i <= number; i++)
            {
                result = result * i;
            }
            return result;
        }

      
        /// <summary>
        /// n! / (n - k)!
        /// </summary>
        /// <param name="n">n</param>
        /// <param name="k">k</param>
        /// <returns></returns>
        private static int FactorialNinK(this int n, int k)
        {
            var result = 1;
            for (int i = n-k+1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }

        public static int CombinationCount(this int n, int k)
        {
            return n.FactorialNinK(k) / k.Factorial();
        }
    }
}
