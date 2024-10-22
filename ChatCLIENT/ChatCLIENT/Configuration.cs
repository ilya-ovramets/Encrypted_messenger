﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT
{
    public static class Configuration
    {
        public static Dictionary<char, string> letterCodeValues { get; private set; } = new Dictionary<char, string>();


        public static string Language { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя1234567890!?,.";

        public static string host { get; set; } = "127.0.0.9";
        public static string port { get; set; } = "444";


        public static void SetValueLCV(Dictionary<char,string> dict)
        {
            letterCodeValues = dict;
        }
    }
}
