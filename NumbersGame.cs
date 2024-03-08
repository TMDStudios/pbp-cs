class NumbersGame{
    int Answer;
    int Count;
    public NumbersGame(){
        Console.WriteLine("Loading Numbers Game");
    }

    void GameSetup(){
        Answer=new Random().Next(0,11);
        Count=0;
    }

    public void StartGame(){
        GameSetup();
        Console.WriteLine("Starting Numbers Game");
        Console.WriteLine("To start press any key");
        Console.ReadLine();
        while(Count<3){
            Console.WriteLine("Guess a number between 0 and 10:");
            string UserInput = Console.ReadLine();
            try{
                int Guess = Int32.Parse(UserInput);
                if(Guess<0 || Guess>10){
                    Console.WriteLine("You can only guess numbers between 0 and 10.");
                    continue;
                }
                Count++;
                if(Guess==Answer){
                    Console.WriteLine($"You got it! The number was {Answer}. You guessed {Count} times.");
                    break;
                }else{
                    if(Count>=3){
                        Console.WriteLine("You lose.");
                    }else{
                        Console.WriteLine($"Try again.\nYou have guessed {Count} time(s).");
                    }
                }
            }catch{
                Console.WriteLine("You can only guess a number.");
            }
        }

        Console.WriteLine("Game Finished\nType 'y' to play again or press any other key to quit.");
        string PlayAgain = Console.ReadLine();
        if(PlayAgain.ToLower()=="y"){
            StartGame();
        }else{
            Console.WriteLine("Shutting Down Numbers Game");
        }
    }
}