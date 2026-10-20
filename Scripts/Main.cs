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
        CallDeferred("SetEdges");
    }
    public void SetEdges()
    {
        for(int i=1;i<TicTacToe.states.Count;i++)
        {
            State pom = TicTacToe.states[i] as State;
            //GD.Print(pom.next);
            for(int j=0;j<pom.next.Count;j++)
            {
                
                graph.AddEdge(graph.GetNode(pom.GetMoves(),pom.GetState()),graph.GetNode(GetMoves(pom.next[j]),pom.next[j]));
            }
        }
    }
    public int GetMoves(int state)
    {
        int br=0;
        int xs = state % 512;
        int os = (state-xs) / 512;
        for(int i=0;i<9;i++)
        {
            if((xs & TicTacToe.GetBinary(i)) > 0)
            {
                br++;
            }
            if((os & TicTacToe.GetBinary(i)) > 0)
            {
                br++;
            }
        }
        return br;
    }
}
