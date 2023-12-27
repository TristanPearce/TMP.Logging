using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Logs
{
    public interface ILogger
    { 
        void Info<T>(T value);
        void Warn<T>(T value);
        void Error<T>(T value);
        void Fatal<T>(T value);

        async Task InfoAsync<T>(T value) { await Task.Run(() => Info<T>(value)); }
        async Task WarnAsync<T>(T value) { await Task.Run(() => Warn<T>(value)); }
        async Task ErrorAsync<T>(T value) { await Task.Run(() => Error<T>(value)); }
        async Task FatalAsync<T>(T value) { await Task.Run(() => Fatal<T>(value)); }
    }
}