using System;

// Write a program that prints all the numbers from 1 to N.

class PrintNumberFrom1ToN
{
    static void Main(string[] args)
    {
        int X = int.Parse(Console.ReadLine());
            int width = (X + X) + ((X / 2) + 1) + ((X / 2) + 1) - 3;
            int Hornslenght = X / 2;
            int middledots = width-2*(X / 2) + 1;
 
 
            Console.Write(new string('.', Hornslenght));
            Console.Write('*');
            Console.Write(new string('.', middledots));
            Console.Write('*');
            Console.Write(new string('.', Hornslenght));
 
            middledots-=2;
 
           
            for (int i=1;i<X-1;i++)
            {
                //ad real horns
                if (i < X / 2)
                {
                    int firstHornDots = X / 2-1;
                    int DotAfterHorn = 0;
                    Console.Write(new string('.', firstHornDots);
                    Console.Write('*');
                    Console.Write(new string('.', DotAfterHorn);
                                     
                }
 
 
                  Console.Write(new string('.', Hornslenght));
 
                  Console.Write(new string('.',i));
                  Console.Write('*');
                  Console.Write(new string('.', Hornslenght));
                  Console.Write('*');
 
                 /*    middledots-=2;
                     //ad real horns
                     if (i < X / 2)
                     {
                          Console.Write(new string('.', DotAfterHorn);
                          Console.Write('*');
                          Console.Write(new string('.', firstHornDots);
 
 
                     firstHornDots --;
                     DotAfterHorn ++;
 
                            }
 */
               
                     //Console.Write(new string('.', Hornslenght));                    
                    // Console.Writeline();
            }
         // Console.WriteLine(new string('.', width/2));
         // Console.Write('*');
         // Console.WriteLine(new string('.', width/2));
        //  Console.Writeline();
 
            int leftRightDots= X - 2;
            middledots=1;
 
          for (int i=1;i<X-1;i++)
        {
              //Console.Write(new string('.', Hornslenght));  
              //Console.Write(new string('.', leftRightDots));
              //Console.Write('*');
              //Console.Write(new string('.', middledots));
              //Console.Write('*');
              //Console.Write(new string('.', leftRightDots));
              //Console.Write(new string('.', Hornslenght));  
 
 
              middledots+=2;
              leftRightDots--;
             // Console.Writeline();
 
          }
          middledots -= 4;
        /*  
        for (int i = 1; i < X - 1; i++)
          {
              //Console.Write(new string('.', Hornslenght));
 
             // Console.Write(new string('.', i));
              //Console.Write('*');
             // Console.Write(new string('.', middledots));
             // Console.Write('*');
            //  Console.Write(new string('.', i));
 
 
 
             // Console.Write(new string('.', Hornslenght));
              middledots -= 2;
 
            // Console.Write(new string('.', Hornslenght));
 
            //  Console.Writeline();
 
 
          }*/
         // Console.WriteLine(new string('.', width / 2));
          //Console.Write('*');
         //Console.WriteLine(new string('.', width / 2));
         // Console.Writeline();
 
    }
}