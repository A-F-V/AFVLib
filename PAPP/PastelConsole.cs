using Pastel;
using System;

namespace AFVLib.PAPP
{
    internal class PastelConsole
    {
        private readonly ColourPalette palette;

        public PastelConsole(ColourPalette palette)
        {
            this.palette = palette;
        }

        public string Format(string literal, params object[] bindings)
        {
            string output = "";
            string[] temp = literal.Split('{', '}');
            for (int pos = 0; pos < temp.Length; pos++)
                if (pos % 2 == 0)
                    output += temp[pos].Pastel(palette.Body);
                else
                    output += bindings[(pos - 1) / 2].ToString().Pastel(palette[int.Parse(temp[pos])]);

            return output;
        }

        public void FormatWriteLine(string literal, params object[] bindings)
        {
            Console.WriteLine(Format(literal, bindings));
        }

        public void FormatWrite(string literal, params object[] bindings)
        {
            Console.Write(Format(literal, bindings));
        }

        public void WriteLine(string literal)
        {
            Console.WriteLine(literal.Pastel(palette.Body));
        }

        public void WriteLine(string literal, int bindingNum)
        {
            Console.WriteLine(literal.Pastel(palette[bindingNum]));
        }
    }
}