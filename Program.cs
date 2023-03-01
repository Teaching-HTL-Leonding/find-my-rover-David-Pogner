string Movement;
double HorizontalMove = 0;
double VerticalMove = 0;
bool validInput = true;
double LinearDistance;

AskForMovement();
CheckMovement();
PrintMovement();

void AskForMovement()
{
    do
    {
        Console.Write("Please enter your Movement: ");
        Movement = Console.ReadLine()!;
        Movement = Movement.Replace(" ", "");
        Movement = Movement.ToUpper();

        string validCharacters = "<>^V0123456789";

        foreach (char c in Movement)
        {
            if (!validCharacters.Contains(c))
            {
                validInput = false;
                break;
            }
        }

        if (!validInput)
        {
            Console.WriteLine("Your input is not valid! Please try again...");
        }

    } while (!validInput);
}

void CheckMovement()
{
    for (int i = 0; i < Movement.Length; i++)
    {
        char c = Movement[i];
        int moveValue;

        if (int.TryParse(c.ToString(), out moveValue))
        {
            switch (Movement[i - 1])
            {
                case 'V': HorizontalMove -= moveValue + 1; break;
                case '^': HorizontalMove += moveValue + 1; break;
                case '<': VerticalMove += moveValue + 1; break;
                case '>': VerticalMove -= moveValue + 1; break;
            }
        }

        switch (c)
        {
            case 'V': HorizontalMove--; break;
            case '^': HorizontalMove++; break;
            case '<': VerticalMove++; break;
            case '>': VerticalMove--; break;
        }
    }


    #region Linear Distance

    double Linear = (HorizontalMove * HorizontalMove) + (VerticalMove * VerticalMove);
    LinearDistance = Math.Sqrt(Linear);

    #endregion
}

void PrintMovement()
{
    if (HorizontalMove > 0) { Console.WriteLine($"You moved {HorizontalMove} North"); }
    if (HorizontalMove < 0) { Console.WriteLine($"You moved {(HorizontalMove * -1)} South"); }
    if (VerticalMove < 0) { Console.WriteLine($"You moved {(VerticalMove * -1)}  East"); }
    if (VerticalMove > 0) { Console.WriteLine($"You moved {VerticalMove} West"); }
    if (VerticalMove == 0 && HorizontalMove == 0) { Console.WriteLine($"The Rover is at the base "); }

    Console.WriteLine($"Linear distance = {LinearDistance}");
    if (HorizontalMove <= 0) { Console.WriteLine($"Manhatan Distance = {(HorizontalMove + VerticalMove) * -1} "); }
    else { Console.WriteLine($"Manhatan Distance = {(HorizontalMove + VerticalMove)} "); }
}