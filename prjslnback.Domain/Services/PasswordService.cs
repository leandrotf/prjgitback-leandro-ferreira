using prjslnback.Domain.Interfaces;
using System;
using System.Linq;

namespace prjslnback.Domain.Services
{
    public class PasswordService : IPasswordService
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "1234567890";
        const string SPECIALS = "@#_-!";
        const int SAME_IN_A_ROW = 4;

        public string Generate()
        {
            System.Random random = new Random();
            string charSet = LOWER_CASE + UPPER_CASE + NUMBERS + SPECIALS;
            string password = string.Empty;            

            password += LOWER_CASE[random.Next(LOWER_CASE.Length - 1)];
            password += UPPER_CASE[random.Next(UPPER_CASE.Length - 1)];
            password += SPECIALS[random.Next(SPECIALS.Length - 1)];

            for (var i = 0; i < 12; i++)
            {
                password += charSet[random.Next(charSet.Length - 1)];
            }

            return String.Join(null, password.OrderBy(x => random.Next()));
        }

        public bool Validate(string password)
        {
            int lower = 0;
            int upper = 0;
            int special = 0; 
            bool sameInRow = false;

            if (string.IsNullOrWhiteSpace(password) || password.Length < 15) return false;

            foreach (var c in password)
            {
                if (LOWER_CASE.Contains(c)) lower++;

                if (UPPER_CASE.Contains(c)) upper++;

                if (SPECIALS.Contains(c)) special++;

                if (password.Contains(c.ToString().PadLeft(SAME_IN_A_ROW, c))) sameInRow = true;
            }

            return (lower > 0 && upper > 0 && special > 0 && !sameInRow);
        }
    }
}
