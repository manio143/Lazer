﻿using System;
using System.Threading;

namespace Lazer.Runtime.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new Tester().ExecTests();
            // var t = new Thread(() => new Tester().ExecTests(), (int)(3.06*1024*1024));
            // t.Start();
            // t.Join();
            // it take 3.06MB stack size to perform
            // 100 000 non-tail recursive calls 
            // with one variable saved on stack
        }
    }
}
