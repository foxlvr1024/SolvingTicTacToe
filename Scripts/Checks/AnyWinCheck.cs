using Godot;
using System;

public partial class AnyWinCheck : Check
{
    public bool Pass(State state)
    {
        int xs = state.GetState() % 512;
        int os = (state.GetState()-xs) / 512;
        return TicTacToe.HasWon(xs) || TicTacToe.HasWon(os);
    }
}
