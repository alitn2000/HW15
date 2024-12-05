using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Quize2.PasswordCreator;

    public  class PasswordCreator
    {
        private static Random rnd = new Random();
        private static System.Timers.Timer timer;
        public  static string FilePath = @"C:\Users\Ali\Desktop\pass.txt";
        public void Passcreate()
        {
            timer = new System.Timers.Timer(20000);
            timer.Elapsed += FilePass;
            timer.AutoReset = true;
            timer.Enabled = true;
            FilePass(null, null);

        }
        private static void FilePass(object sender, ElapsedEventArgs e)
        {
            int randomPassword = rnd.Next(10000, 100000);

            File.WriteAllText(FilePath, randomPassword.ToString());
        }
    }
