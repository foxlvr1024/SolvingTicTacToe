using Godot;
using System;

public partial class State
{
    private int state;
    private int rot1;
    private int rot2;
    private int rot3;
    
    private Godot.Collections.Array<int> previous;
    private Godot.Collections.Array<int> next;

    public State(int state)
    {
        this.state = state;
        previous = new Godot.Collections.Array<int>();
        next = new Godot.Collections.Array<int>();
        int xs = state % 512;
        int os = (state-xs) / 512;
         rot1 =0;
         rot2 =0;
         rot3 =0;
        
        
        for(int i=0;i<9;i++)
        {
            if((xs & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=TicTacToe.first[i];
                rot2+=TicTacToe.second[i];
                rot3+=TicTacToe.third[i];
            }
            if((os & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=TicTacToe.first[i]*512;
                rot2+=TicTacToe.second[i]*512;
                rot3+=TicTacToe.third[i]*512;
            }
        }
    }

    public void AddToPrevious(int state)
    {
        if(!previous.Contains(state))
        {
            previous.Add(state);
        }
    }

    public void AddToNext(int state)
    {
        if(!next.Contains(state))
        {
            next.Add(state);
        }
    }
    public int GetState()
    {
        return state;
    }
    public int GetRot1()
    {
        return rot1;
    }
    public int GetRot2()
    {
        return rot2;
    }
    public int GetRot3()
    {
        return rot3;
    }
    public int GetMoves()
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
    public override bool Equals(object obj)
    {
        if(!(obj is State state)) return false;

        
        if(this.GetState()==state.GetState()) return true;
        if(this.GetState()==state.GetRot1()) return true;
        if(this.GetState()==state.GetRot2()) return true;
        if(this.GetState()==state.GetRot3()) return true;
        
        return false;
    }

}
