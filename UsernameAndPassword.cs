class UsernameAndPassword{
    List<string> Users = new(){"Sam", "Frank", "Jane"};
    char[] SpecialCharacters = {'!', '@', '#', '$'};
    bool NameCheck;
    string Username;
    string Password;
    public UsernameAndPassword(){
        Console.WriteLine("Loading Username and Password");
    }

    public void StartUsernameAndPassword(){
        Username = "";
        Password = "";
        NameCheck = false;
        Console.WriteLine("Starting Username and Password");
        Console.WriteLine("To start press any key");
        Console.ReadLine();

        while(true){
            if(!NameCheck){
                Console.Write("Enter a username: ");
                Username = Console.ReadLine();
                if(Username==null){
                    Console.WriteLine("\nUsername must be between 3 and 14 characters long");
                    continue;
                }
                if(!NameIsAvailable(Username) || ContainsNumbers(Username, true) || !LengthIsValid(Username, true)){
                    continue;
                }else{
                    Console.WriteLine("\nUsername created");
                    NameCheck=true;
                }
            }else{
                Console.Write("Enter a password: ");
                Password = Console.ReadLine();
                if(Password==null){
                    Console.WriteLine("\nPassword must be at least 8 characters");
                    continue;
                }
                if(!ContainsCaps(Password) || !ContainsNumbers(Password) || !LengthIsValid(Password) || !ContainsSpecialChar(Password)){
                    continue;
                }else{
                    Console.WriteLine("\nPassword created");
                    Console.WriteLine($"\nUser '{Username}' with password '{Password}' has been added");
                    Users.Add(Username);
                    break;
                }
            }
        }

        Console.WriteLine("\nThis is the full users list:");
        for(int i = 0; i < Users.Count; i++){
            Console.WriteLine($"{i+1}: {Users[i]}");
        }
        Console.WriteLine("\nUsername and Password Creation Finished\nType 'y' to crate another username and password or press any other key to quit.");
        string PlayAgain = Console.ReadLine();
        if(PlayAgain.ToLower()=="y"){
            StartUsernameAndPassword();
        }else{
            Console.WriteLine("Shutting Down Username and Password");
        }
    }

    private bool NameIsAvailable(string Name){
        for(int i = 0; i<Users.Count; i++){
            if(Name.ToLower()==Users[i].ToLower()){
                Console.WriteLine("\nPlease choose another username");
                return false;
            }
        }
        return true;
    }

    private bool ContainsNumbers(string UserInput, bool isUsername=false){
        for(int i = 0; i<UserInput.Length; i++){
            if(Char.IsDigit(UserInput[i])){
                if(isUsername){
                    Console.WriteLine("\nUsername must not contain numbers");
                }
                return true;
            }
        }
        if(!isUsername){
            Console.WriteLine("\nPassword must contain a number");
        }
        return false;
    }

    private bool LengthIsValid(string UserInput, bool isUsername=false){
        if(isUsername){
            if(UserInput.Length<3 || UserInput.Length>14){
                Console.WriteLine("\nUsername must be between 3 and 14 characters long");
                return false;
            }
        }else{
            if(UserInput.Length<8){
                Console.WriteLine("\nPassword must be at least 8 characters");
                return false;
            }
        }
        return true;
    }

    private bool ContainsCaps(string UserInput){
        for(int i = 0; i<UserInput.Length; i++){
            if(Char.IsUpper(UserInput, i)){
                return true;
            }
        }
        Console.WriteLine("\nPassword must contain a capital letter");
        return false;
    }

    private bool ContainsSpecialChar(string UserInput){
        for(int i = 0; i<UserInput.Length; i++){
            if(SpecialCharacters.Contains(UserInput[i])){
                return true;
            }
        }
        Console.WriteLine("\nPassword must contain a special character ('!', '@', '#', '$')");
        return false;
    }
}