using System;
using System.Threading;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Snake s = new Snake();
    char key = 'w'; 
    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
    while(true) {
      if(s.alive) {
        Console.Clear();
        s.draw();

        if(Console.KeyAvailable){
          keyInfo = Console.ReadKey(true);
          key = keyInfo.KeyChar;
        }
        s.logic(key);
        Thread.Sleep(500);
      } else {
        Console.WriteLine("Want to play again?");
        string answer = Console.ReadLine();
        if(answer == "Y"){
          s = new Snake();

        } else {
          Environment.Exit(0);
        }
      }

    }
  }
}