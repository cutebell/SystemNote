using PasswordMaker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordMaker.Service
{
    public class PasswordMakeService
    {
        public int Length { get; set; }
        private List<String> letters;
        private Random random;


        public PasswordMakeService(int length, bool uppercase, bool lowercase, bool numbers, bool symbol)
        {
            this.Length = length;
            this.letters = new List<string>();
            if (uppercase)
            {
                this.letters.Add(Settings.Default.Uppercase);
            }

            if (lowercase)
            {
                this.letters.Add(Settings.Default.Lowercase);
            }

            if (numbers)
            {
                this.letters.Add(Settings.Default.Numbers);
            }

            if (symbol)
            {
                this.letters.Add(Settings.Default.Symbol);
            }

            this.random = new Random(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
        }

        public String GetPassWord()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
            {
                // 使用する文字種をランダムで決定
                String letter = this.letters[this.random.Next(0, this.letters.Count)];

                // 追加する文字をランダムで決定
                stringBuilder.Append(letter[random.Next(0, letter.Length)]);
            }

            return stringBuilder.ToString();
        }
    }
}
