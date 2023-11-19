namespace BLL.Services
{
    public static class ISBNGenerator
    {
        public static string CreateISBN()
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 10; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
