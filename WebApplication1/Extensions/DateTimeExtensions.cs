namespace WebApplication1.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dOB)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dOB.Year;
            if (dOB > today.AddYears(-age)) age--;

            return age;
        }
    }
}
