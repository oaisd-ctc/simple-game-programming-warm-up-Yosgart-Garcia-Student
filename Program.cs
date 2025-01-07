using System;
public class Program
{
    //Some public variables.
    public static int round = 1;
    public static int turn,
    playerScore, 
    rivalScore,
    diceValue, 
    diceValue2;

    public static void Main(string[] args)
    {
        //Write the intro and await input.
        Intro();
        Read();

        while (round <= 10)
        {
            //While the round is 10 & below continue the dice rolling loop and write results upon completion of second turn.
            if(turn == 0) Console.WriteLine($"\nRound {round}");
            turn++;
            Round();

            if (turn == 2) TurnEnd();
        }

        //End the game after 10th round.
        EndGame();
    }

    static void Intro()
    {
        //Text intro with instructions, perhaps too much for only two lines...
        Console.Clear();
        Console.WriteLine("Dice Game\n\nIn this game you and a computer rival will play 10 rounds\nwhere you will each roll a 6-sided dice, and the player");
        Console.WriteLine("with the highest dice value will win the round. The player\nwho wins the most rounds wins the game. Good luck!\n\nPress any key to start...");
    }

    static void Round()
    {
        //Get a random number for dice roll.
        int dice = new Random().Next(1, 6);
        string name = "";

        //Check turn to know what name to write. Rival always goes first.
        if (turn == 1) name = "Rival";
        else name = "You";
        Console.WriteLine($"{name} rolled a {dice}");

        //Check turn again to decide what to write next and who the dice roll belongs to... not too efficient but oh well.
        if (turn == 1)
        {
            diceValue2 = dice;
            Console.WriteLine("Press any key to roll the dice...");
            Read();
        }
        else diceValue = dice;
    }

    static void TurnEnd()
    {
        //Check who won and if it was a tie for the round.
        if (diceValue > diceValue2)
        {
            playerScore++;
            Console.WriteLine("You won this round.");
        }
        else if (diceValue2 > diceValue)
        {
            rivalScore++;
            Console.WriteLine("The Rival won this round.");
        }
        else Console.WriteLine("This round is a draw!");

        //Display score, await input, and update variables.
        ScoreUpdate();
        Console.WriteLine("Press any key to continue...");
        round++;
        turn = 0;
        Read();
    }

    static void EndGame()
    {
        //Display results and mark the end of the game.
        Console.WriteLine("\nGame over.");
        ScoreUpdate();

        if (playerScore > rivalScore) Console.WriteLine("You won!");
        else if (rivalScore > playerScore) Console.WriteLine("Rival won!");
        else Console.WriteLine("You tied!");

        Console.WriteLine("Press any key to exit...");
        Read();
    }

    static void ScoreUpdate()
    {
        //For totally cleaner code :D
        Console.WriteLine($"The score is now - You : {playerScore}. Rival : {rivalScore}.");
    }

    static void Read()
    {
        //Also for totally cleaner code :DD
        Console.ReadKey();
        Console.Write("\b");
    }
}
