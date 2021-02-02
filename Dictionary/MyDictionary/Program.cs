using System;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "Bir");
            myDictionary.Add(2, "İki");
            myDictionary.Add(3, "Üç");
            myDictionary.Add(4, "Dört");
            myDictionary.Add(5, "Beş");
            myDictionary.Add(6, "Altı");
        }
    }
}
