using Godot;
using System;

public partial class State
{
    private int state;
    private int rot1;
    private int rot2;
    private int rot3;
    private int mir1;
    private int mir2;
    private int mir3;
    private int mir4;

    
    
    
    private Godot.Collections.Array<int> previous;
    public Godot.Collections.Array<int> next;

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
         mir1=0;
         mir2=0;
         mir3=0;
         mir4=0;
        
        for(int i=0;i<9;i++)
        {
            if((xs & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=TicTacToe.first[i];
                rot2+=TicTacToe.second[i];
                rot3+=TicTacToe.third[i];
                mir1+=TicTacToe.mirror1[i];
                mir2+=TicTacToe.mirror2[i];
                mir3+=TicTacToe.mirror3[i];
                mir4+=TicTacToe.mirror4[i];
            }
            if((os & TicTacToe.GetBinary(i)) > 0)
            {
                rot1+=TicTacToe.first[i]*512;
                rot2+=TicTacToe.second[i]*512;
                rot3+=TicTacToe.third[i]*512;
                mir1+=TicTacToe.mirror1[i]*512;
                mir2+=TicTacToe.mirror2[i]*512;
                mir3+=TicTacToe.mirror3[i]*512;
                mir4+=TicTacToe.mirror4[i]*512;
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
    public int GetMir1()
    {
        return mir1;
    }
    public int GetMir2()
    {
        return mir2;
    }
    public int GetMir3()
    {
        return mir3;
    }
    public int GetMir4()
    {
        return mir4;
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
        if(this.GetState()==state.GetMir1()) return true;
        if(this.GetState()==state.GetMir2()) return true;
        if(this.GetState()==state.GetMir3()) return true;
        if(this.GetState()==state.GetMir4()) return true;
        

        return false;
    }

}
