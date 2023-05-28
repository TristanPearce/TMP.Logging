using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Logs
{
    public class ConsoleLogger : ILogger
    {
        public ColorPair ResetColors { get; set; }  = new ColorPair() { Foreground = ConsoleColor.White, Background = ConsoleColor.Black };
        public ColorPair InfoColors { get; set; }   = new ColorPair() { Foreground = ConsoleColor.White, Background = ConsoleColor.Black };
        public ColorPair WarnColors { get; set; }   = new ColorPair() { Foreground = ConsoleColor.Yellow, Background = ConsoleColor.Black };
        public ColorPair ErrorColors { get; set; }  = new ColorPair() { Foreground = ConsoleColor.Red, Background = ConsoleColor.Black };
        public ColorPair FatalColors { get; set; }  = new ColorPair() { Foreground = ConsoleColor.White, Background = ConsoleColor.Red };

        private StringBuilder _stringBuilder { get; init; } = new StringBuilder();

        public ConsoleLogger() { }

        void ILogger.Error<T>(T value)
        {
            this.SetConsoleColours(ErrorColors);
            this.WriteStringsToConsoleLine(GetDateTimeString(), " <error> ", value!);
            this.ResetColours();
        }

        void ILogger.Fatal<T>(T value)
        {
            this.SetConsoleColours(FatalColors);
            this.WriteStringsToConsoleLine(GetDateTimeString(), " <FATAL> ", value!);
            this.ResetColours();
        }

        void ILogger.Info<T>(T value)
        {
            this.SetConsoleColours(InfoColors);
            this.WriteStringsToConsoleLine(GetDateTimeString(), " <info> ", value!);
            this.ResetColours();
        }

        void ILogger.Warn<T>(T value)
        {
            this.SetConsoleColours(WarnColors);
            this.WriteStringsToConsoleLine(GetDateTimeString(), " <warning> ",value!);
            this.ResetColours();
        }

        private void SetConsoleColours(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        private void SetConsoleColours(ColorPair colors)
        {
            this.SetConsoleColours(colors.Foreground, colors.Background);
        }

        private void ResetColours()
        {
            SetConsoleColours(ResetColors);
        }

        private void WriteToConsole<T>(T value)
        {
            Console.Write(value);
        }

        private void WriteStringsToConsoleLine(params object[] values)
        {

            foreach (string value in values)
            {
                _stringBuilder.Append(value.ToString());
            }

            _stringBuilder.Append(Environment.NewLine);

            this.WriteToConsole(_stringBuilder.ToString());

            _stringBuilder.Clear();
        }

        private string GetDateTimeString()
        {
            return (DateTime.Now.ToString());
        }
        public class ColorPair
        {
            public ConsoleColor Foreground { get; init; } = ConsoleColor.White;
            public ConsoleColor Background { get; init; } = ConsoleColor.Black;
        }
    }
}
