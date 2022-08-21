using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    internal class TestAsync
    {
        public TestAsync()
        {

        }

        public async Task Method()
        {
            await Task.Delay(1000);
        }

        public async Task<string> MethodWithResult()
        {
            await Task.Delay(1000);
            return "test_async";
        }
    }
}
