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
        Highlight(CheckManager.GetInstance().GetAnyWinCheck());
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

    public void Highlight(Check check)
    {
        for(int i=9;i>0;i--)
        {
            for(int j=0;j<graph.GetCount(i);j++)
            {
                State pom = new State(graph.GetState(i,j));
                pom = TicTacToe.states[TicTacToe.states.IndexOf(pom)] as State;
                if(check.Pass(pom))
                {
                    graph.GetNode(i,pom.GetState()).SetDefaultColor(new Color("00ff00"));
                }
                else
                {
                    graph.GetNode(i,pom.GetState()).SetDefaultColor(new Color("ffffff"));
                }
            }
        }
    }

}
