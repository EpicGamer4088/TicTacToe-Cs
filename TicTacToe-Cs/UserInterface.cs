namespace TicTacToe_Cs;

public class UserInterface
{
    public static void PrintTitleScreen()
    {
        Console.WriteLine("***********************************");
        Console.WriteLine("*                                 *");
        Console.WriteLine("*           Tic Tac Toe           *");
        Console.WriteLine("*                                 *");
        Console.WriteLine("***********************************\n");
    }

    public static int GetMenuOption()
    {
        var selectedOption = 1;

        while (true)
        {
            PrintMenuOptions(selectedOption);

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (selectedOption == 1) ? 3 : selectedOption - 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption == 3) ? 1 : selectedOption + 1;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            Console.Clear();
        }

        return selectedOption;
    }

    public static string GetPlayerName()
    {
        Console.Clear();
        Console.WriteLine("Gib den Namen des Spielers ein: ");
        return Console.ReadLine() ?? "Player";
    }

    public static void PrintLoadingScreen()
    {
        Console.Clear();
        Console.Write("Lade Spiel\n\n[");
        Thread.Sleep(500);

        for (var i = 0; i < 20; i++)
        {
            Console.Write("=");
            Thread.Sleep(500);
        }

        Console.Write("]");
        Thread.Sleep(500);
        Console.Clear();
    }

    private static void PrintMenuOptions(int selectedOption)
    {
        Console.WriteLine("Waehle eine Option:");
        Console.WriteLine($"{(selectedOption == 1 ? ">>" : "  ")}  Gegen einen Spieler spielen");
        Console.WriteLine($"{(selectedOption == 2 ? ">>" : "  ")}  Gegen die KI spielen");
        Console.WriteLine($"{(selectedOption == 3 ? ">>" : "  ")}  Beenden\n");
    }

    public static void PrintBoard(char[,] board, int selectedRow, int selectedCol)
    {
        Console.WriteLine("     a     b     c");
        for (var i = 0; i < TicTacToeGame.GetSize; i++)
        {
            Console.Write($"{(char)('1' + i)} ");
            for (int j = 0; j < TicTacToeGame.GetSize; j++)
            {
                if (i == selectedRow && j == selectedCol)
                    Console.Write($"| [{board[selectedRow, selectedCol]}] ");
                else
                    Console.Write($"|  {board[i, j]}  ");
            }

            Console.WriteLine("|");
            if (i != TicTacToeGame.GetSize - 1)
                Console.WriteLine("   -----+-----+-----");
        }

        Console.WriteLine("\n");
    }
}
