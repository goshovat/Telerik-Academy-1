using System;
using System.IO;
using System.Text.RegularExpressions;

// Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

class DeleteWordsWithPrefixStart
{
    static void Main(string[] args)
    {

        
		//Consolerintln("n = ");
		int n = int.Parse(Console.ReadLine());
		//System.out.println("x = ");
		int x =  int.Parse(Console.ReadLine());
		int sum = 1;
		int chislitel = 1;
		int znamenatel = 1;
		for (int i = 1; i <= n; i++) {
			for (int j = 1; j <= i; j++) {
				chislitel *= j;
				znamenatel *= x;
			}
			sum = sum + chislitel / znamenatel;
			znamenatel = 1;
			chislitel = 1;
		}
		Console.WriteLine(sum);
    }
}