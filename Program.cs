﻿bool Exit = false;
string[] ConsoleOptions = {
    "Choose from the following menu:",
    "1 => Numbers Game",
    "2 => Calculator",
    "3 => Guess the Phrase",
    "4 => Username and Password",
    "5 => Quit"
    };
NumbersGame numbersGame = new();
Calculator calculator = new();
GuessThePhrase guessThePhrase = new();
UsernameAndPassword usernameAndPassword = new();

void PrintWelcome(){
    Console.WriteLine("\n\n");
    string Message = "This is a collection of select Project Based Python projects";
    for(int i = 0; i<Message.Length; i++){
        Console.Write("*");
    }
    Console.WriteLine($"\n{Message}");
    for(int i = 0; i<Message.Length; i++){
        Console.Write("*");
    }
    Console.WriteLine("");
    for(int i = 0; i<ConsoleOptions.Length; i++){
        Console.WriteLine(ConsoleOptions[i]);
    }
    Console.Write(">>");
}

while(!Exit){
    PrintWelcome();
    switch(Console.ReadLine()){
        case "1":
            numbersGame.StartGame();
            break;
        case "2":
            calculator.StartCalculator();
            break;
        case "3":
            guessThePhrase.StartGame();
            break;
        case "4":
            usernameAndPassword.StartUsernameAndPassword();
            break;
        case "5":
            Exit=true;
            break;
        default:
            Console.WriteLine("Please select a valid option");
            break;
    }
}
Console.WriteLine("Closing Program");