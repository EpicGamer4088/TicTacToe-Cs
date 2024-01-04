namespace TicTacToe_Cs;

using System;
using System.Threading;

public class TicTacToeGame
{
    private const int Size = 3;
    private readonly char[,] _board;
    private int _currentPlayer;
    private int _moves;

    public TicTacToeGame()
    {
        _board = new char[Size, Size] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        _currentPlayer = 1;
        _moves = 0;
    }

    public static int GetSize => Size;

    public void StartGame()
    {
        var selectedOption = UserInterface.GetMenuOption();

        switch (selectedOption)
        {
            case 1:
                UserInterface.PrintLoadingScreen();
                var player1 = UserInterface.GetPlayerName();
                var player2 = UserInterface.GetPlayerName();
                GameWithPlayer(player1, player2);
                break;
            case 2:
                UserInterface.PrintLoadingScreen();
                var playerName = UserInterface.GetPlayerName();
                GameWithAi(playerName);
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Das Programm wird beendet. Auf Wiedersehen!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("\nUngültige Option. Bitte eine gültige Option wählen.\n\n");
                break;
        }
    }

    private void GameWithPlayer(string player1, string player2)
    {
        var selectedRow = 0;
        var selectedCol = 0;

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        while (true)
        {
            var currentPlayerName = (_currentPlayer == 1) ? player1 : player2;

            Console.Clear();
            Console.WriteLine(
                $"{currentPlayerName}, bitte wählen Sie die Koordinaten Ihres Zuges mit den Pfeiltasten und bestätigen Sie mit ENTER:\n");
            UserInterface.PrintBoard(_board, selectedRow, selectedCol);

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedRow > 0)
                        selectedRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedRow < GetSize - 1)
                        selectedRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (selectedCol > 0)
                        selectedCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (selectedCol < GetSize - 1)
                        selectedCol++;
                    break;
                case ConsoleKey.Enter:
                    if (_board[selectedRow, selectedCol] != ' ')
                        continue;

                    _board[selectedRow, selectedCol] = (_currentPlayer == 1) ? 'X' : 'O';

                    Console.Clear();
                    UserInterface.PrintBoard(_board, selectedRow, selectedCol);
                    _moves++;

                    if (CheckWin((_currentPlayer == 1) ? 'X' : 'O'))
                    {
                        Console.Clear();
                        selectedRow = -1;
                        selectedCol = -1;
                        UserInterface.PrintBoard(_board, selectedRow, selectedCol);
                        Thread.Sleep(500);
                        Console.WriteLine($"{currentPlayerName} hat gewonnen!\n");
                        Thread.Sleep(3000);
                        StartGame();
                    }
                    else if (_moves == GetSize * GetSize)
                    {
                        Console.Clear();
                        selectedRow = -1;
                        selectedCol = -1;
                        UserInterface.PrintBoard(_board, selectedRow, selectedCol);
                        Thread.Sleep(500);
                        Console.WriteLine("Unentschieden!\n");
                        Thread.Sleep(3000);
                        StartGame();
                    }

                    _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
                    break;
            }

            UserInterface.PrintBoard(_board, selectedRow, selectedCol);
        }
    }

    private void GameWithAi(string player1)
    {
        const string player2 = "KI";
        var selectedRow = 0;
        var selectedCol = 0;

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        while (true)
        {
            var currentPlayerName = (_currentPlayer == 1) ? player1 : player2;

            Console.Clear();
            Console.WriteLine(
                $"{currentPlayerName}, bitte wählen Sie die Koordinaten Ihres Zuges mit den Pfeiltasten und bestätigen Sie mit ENTER:\n");
            UserInterface.PrintBoard(_board, selectedRow, selectedCol);

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedRow > 0)
                        selectedRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedRow < GetSize - 1)
                        selectedRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (selectedCol > 0)
                        selectedCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (selectedCol < GetSize - 1)
                        selectedCol++;
                    break;
                case ConsoleKey.Enter:
                    if (_board[selectedRow, selectedCol] != ' ')
                        continue;

                    _board[selectedRow, selectedCol] = (_currentPlayer == 1) ? 'X' : 'O';

                    Console.Clear();
                    UserInterface.PrintBoard(_board, selectedRow, selectedCol);
                    _moves++;

                    if (CheckWin((_currentPlayer == 1) ? 'X' : 'O'))
                    {
                        Console.Clear();
                        UserInterface.PrintBoard(_board, -1, -1);
                        Thread.Sleep(500);
                        Console.WriteLine($"{currentPlayerName} hat gewonnen!\n");
                        Thread.Sleep(3000);
                        StartGame();
                    }
                    else if (_moves == GetSize * GetSize)
                    {
                        Console.Clear();
                        UserInterface.PrintBoard(_board, -1, -1);
                        Thread.Sleep(500);
                        Console.WriteLine("Unentschieden!\n");
                        Thread.Sleep(3000);
                        StartGame();
                    }

                    _currentPlayer = (_currentPlayer == 1) ? 2 : 1;

                    Console.Write("KI ist am Zug");
                    for (var i = 0; i < 3; i++)
                    {
                        Thread.Sleep(1000);
                        Console.Write(".");
                    }

                    Thread.Sleep(1000);
                    Console.WriteLine();

                    var random = new Random();
                    do
                    {
                        selectedRow = random.Next(GetSize);
                        selectedCol = random.Next(GetSize);
                    } while (_board[selectedRow, selectedCol] != ' ');

                    _board[selectedRow, selectedCol] = (_currentPlayer == 1) ? 'X' : 'O';

                    Console.Clear();
                    UserInterface.PrintBoard(_board, selectedRow, selectedCol);
                    _moves++;

                    if (CheckWin((_currentPlayer == 1) ? 'X' : 'O'))
                    {
                        Console.Clear();
                        UserInterface.PrintBoard(_board, -1, -1);
                        Thread.Sleep(500);
                        Console.WriteLine("Die KI gewinnt!\n");
                        Thread.Sleep(500);
                        StartGame();
                    }
                    else if (_moves == GetSize * GetSize)
                    {
                        Console.Clear();
                        UserInterface.PrintBoard(_board, -1, -1);
                        Thread.Sleep(500);
                        Console.WriteLine("Unentschieden!\n");
                        Thread.Sleep(500);
                        StartGame();
                    }

                    _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
                    break;
            }

            UserInterface.PrintBoard(_board, selectedRow, selectedCol);
        }
    }

    private bool CheckWin(char player)
    {
        for (var i = 0; i < GetSize; i++)
        {
            if (_board[i, 0] == player && _board[i, 1] == player && _board[i, 2] == player ||
                _board[0, i] == player && _board[1, i] == player && _board[2, i] == player)
                return true;
        }

        return _board[0, 0] == player && _board[1, 1] == player && _board[2, 2] == player ||
               _board[2, 0] == player && _board[1, 1] == player && _board[0, 2] == player;
    }
}