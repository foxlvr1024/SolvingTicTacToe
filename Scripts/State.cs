using Godot;
using System;

public partial class State : Node2D
{
    private int state;
    private Godot.Collections.Array<int> previous;
    private Godot.Collections.Array<int> next;

    public State(int state)
    {
        this.state = state;
        previous = new Godot.Collections.Array<int>();
        next = new Godot.Collections.Array<int>();
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
    public override bool Equals(object obj)
    {
        if(!(obj is State state)) return false;

        int xs = state.GetState() % 512;
        int os = (state.GetState()-xs) / 512;
        int xs2 = state.GetState()%512;
        int os2 = (state.GetState()-xs2) / 512;
        int rot1 =0;
        int rot2 =0;
        int rot3 =0;
        Godot.Collections.Array<int> first = [4,32,256,2,16,128,1,8,64];
        Godot.Collections.Array<int> second = [256,128,64,32,16,8,4,2,1];
        Godot.Collections.Array<int> third = [6,3,0,7,4,1,8,5,2];
        
        for(int i=0;i<9;i++)
        {
            if((xs & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=first[i];
                rot2+=second[i];
                rot3+=third[i];
            }
            if((os & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=first[i]*512;
                rot2+=second[i]*512;
                rot3+=third[i]*512;
            }
        }
        if(this.GetState()==state.GetState()) return true;
        if(this.GetState()==rot1) return true;
        if(this.GetState()==rot2) return true;
        if(this.GetState()==rot3) return true;
        
        return false;
    }

}
