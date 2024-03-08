class Calculator{
    public Calculator(){
        Console.WriteLine("Loading Calculator");
    }

    public void StartCalculator(){
        Console.WriteLine("Starting Calculator");
        Console.WriteLine("To start press any key");
        Console.ReadLine();

        while(true){
            int Num1 = 0;
            int Num2 = 0;
            string Op = "";
            Console.WriteLine("Enter the first number:");
            string UserInput = Console.ReadLine();
            if(IsNumber(UserInput)){
                Num1 = Int32.Parse(UserInput);
                Console.WriteLine("Enter the operator:");
                UserInput = Console.ReadLine();
                if(UserInput=="+"|UserInput=="-"||UserInput=="*"||UserInput=="/"){
                    Op = UserInput;
                    Console.WriteLine("Enter the second number:");
                    UserInput = Console.ReadLine();
                    if(IsNumber(UserInput)){
                        Num2 = Int32.Parse(UserInput);
                        if(Op=="/" && (Num1==0 || Num2==0)){
                            Console.WriteLine("-- Cannot divide by 0 --");
                            continue;
                        }
                        Console.WriteLine(Calculate(Num1, Op, Num2));
                        break;
                    }else{
                        Console.WriteLine("-- You can only enter numbers --");
                        continue;
                    }
                }else{
                    Console.WriteLine("-- Invalid operator --");
                    continue;
                }
            }else{
                Console.WriteLine("-- You can only enter numbers --");
                continue;
            }
        }

        Console.WriteLine("Calculation Complete\nType 'y' to calculate again or press any other key to quit.");
        string PlayAgain = Console.ReadLine();
        if(PlayAgain.ToLower()=="y"){
            StartCalculator();
        }else{
            Console.WriteLine("Shutting Down Calculator");
        }
    }

    public bool IsNumber(string Num){
        try{
            Int32.Parse(Num);
            return true;
        }catch{
            return false;
        }
    }

    public string Calculate(int Num1, string Op, int Num2){
        int output = 0;
        switch(Op){
            case "+":
                output = Num1+Num2;
                break;
            case "-":
                output = Num1-Num2;
                break;
            case "*":
                output = Num1*Num2;
                break;
            default:
                output = Num1/Num2;
                break;
        }
        return $"{Num1} {Op} {Num2} = {output}";
    }
}