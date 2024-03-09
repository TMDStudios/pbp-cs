class GuessThePhrase{
    private string[] PhrasePool = {"this is the secret phrase", "she sells seashells", "this is the way", "fun with flags", "may the force be with you"};
    string Answer;
    string GuessedLetters;
    int Count;
    bool GuessLetter;
    string UserAnswer;
    Dictionary<int, char> UserAnswerDict = new();
    string UserInput;
    public GuessThePhrase(){
        Console.WriteLine("Loading Guess the Phrase");
    }

    private void GameSetup(){
        Answer = PhrasePool[new Random().Next(0,PhrasePool.Length)];
        GuessedLetters = "";
        Count = 0;
        GuessLetter = true;
        UserAnswer = "";
        UserAnswerDict = new();

        for(int i = 0; i<Answer.Length; i++){
            if(Answer[i]==' '){
                UserAnswerDict.Add(i, ' ');
                UserAnswer += ' ';
            }else{
                UserAnswerDict.Add(i, '*');
                UserAnswer += '*';
            }
        }

        Console.WriteLine("Can you decipher the text?\n");
        Console.WriteLine(UserAnswer);
    }

    public void StartGame(){
        Console.WriteLine("Starting Guess the Phrase\nType 'exit' at any time to return to the main menu");
        Console.WriteLine("To start press any key");
        Console.ReadLine();
        GameSetup();
        while(Count<10){
            if(GuessLetter){
                if(Count>0){
                    Console.WriteLine($"\nYour guess history: {GuessedLetters}");
                }
                Console.Write("\nGuess a letter: ");
                
                UserInput = Console.ReadLine();
                if(UserInput=="exit"){
                    Console.WriteLine($"\nThank you for playing.\nThe answer was: {Answer}\n");
                    break;
                }
                if(ValidateInput(UserInput)){
                    if(Count==1){
                        GuessedLetters += UserInput[0];
                    }else{
                        GuessedLetters += $", {UserInput[0]}";
                    }
                    for(int i = 0; i<Answer.Length; i++){
                        if(UserInput[0]==Answer[i]){
                            UserAnswerDict[i] = Answer[i];
                        }
                    }
                    UserAnswer = "";
                    foreach(KeyValuePair<int,char> entry in UserAnswerDict){
                        UserAnswer+=entry.Value;
                    }
                    Console.WriteLine($"\nPhrase: {UserAnswer}");
                    if(UserAnswer==Answer){
                        Console.WriteLine("\nYou Win!\n");
                        Console.WriteLine($"The answer was: {Answer}\nYou guessed {Count} time(s)");
                        break;
                    }
                    GuessLetter=false;
                }else{
                    Console.WriteLine("Please enter one letter");
                }
            }else{
                Count++;
                Console.Write("\nGuess the full text: ");
                UserInput = Console.ReadLine();
                if(UserInput=="exit"){
                    Console.WriteLine($"\nThank you for playing.\nThe answer was: {Answer}\n");
                    break;
                }
                if(UserInput==Answer){
                    Console.WriteLine("\nYou Win!\n");
                    Console.WriteLine($"The answer was: {Answer}\nYou guessed {Count} time(s)");
                    break;
                }else{
                    Console.WriteLine("Incorrect guess");
                }
                if(Count==10){
                    Console.WriteLine("You Lose!");
                    Console.WriteLine($"The answer was: {Answer}");
                    break;
                }
                GuessLetter=true;
            }
        }

        Console.WriteLine("Game Finished\nType 'y' to play again or press any other key to quit.");
        string PlayAgain = Console.ReadLine();
        if(PlayAgain.ToLower()=="y"){
            StartGame();
        }else{
            Console.WriteLine("Shutting Down Guess the Phrase");
        }
    }

    private bool ValidateInput(string Input){
        if(Input!=null){
            if(Input.Length==1){
                return true;
            }
        }
        return false;
    }
}