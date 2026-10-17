using Godot;
using System;

public partial class Main : Node2D
{
    private Graph graph;

    public override void _Ready()
    {
        graph = GetNode<Graph>("Graph");
        //graph._Ready();
        for(int i=1;i<TicTacToe.states.Count;i++)
        {
            State pom = TicTacToe.states[i] as State;
            graph.AddState(pom.GetMoves(),pom.GetState());
        }
    }
}
