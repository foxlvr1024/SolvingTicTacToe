using Godot;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;

public partial class TicTacToe : Node
{
    public static Godot.Collections.Array<int> first = [4,32,256,2,16,128,1,8,64];
    public static Godot.Collections.Array<int> second = [256,128,64,32,16,8,4,2,1];
    public static Godot.Collections.Array<int> third = [64,8,1,128,16,2,256,32,4];
    private static Godot.Collections.Array<int> binary;
    private static System.Collections.ArrayList states;
    public static int GetBinary(int index)
    {
        return binary[index];
    }

    public override void _Ready()
    {
        binary = new Godot.Collections.Array<int>();
        binary.Add(1);
        for(int i=1;i<9;i++)
        {
            binary.Add(binary[i-1]*2);
        }
        states = new System.Collections.ArrayList();
        //int br=0;
        for(int x=0;x<512;x++)
        {
            for(int o=0;o<512;o++)
            {
                State state = new State(x+o*512);
                if(IsValid(state))
                {
                    if(!states.Contains(state))
                    {
                        states.Add(state);
                        //br++;
                        //GD.Print(br);
                    }
                }
            }
        }
        for(int i=0;i<states.Count;i++)
        {
            State state = states[i] as State;
            int xs = state.GetState() % 512;
            int os = (state.GetState()-xs) / 512;
            for(int j=0;j<9;j++)
            {
                if(!((xs & binary[j]) > 0))
                {
                    State pom = new State(state.GetState()+binary[j]);
                    int index = states.IndexOf(pom);
                    if(index>-1)
                    {
                        (states[index] as State).AddToPrevious(state.GetState());
                        (states[i] as State).AddToNext(state.GetState()+binary[j]);
                    }
                }
                if(!((os & binary[j]) > 0))
                {
                    State pom = new State(state.GetState()+binary[j]*512);
                    int index = states.IndexOf(pom);
                    if(index>-1)
                    {
                        (states[index] as State).AddToPrevious(state.GetState());
                        (states[i] as State).AddToNext(state.GetState()+binary[j]*512);
                    }
                }
            }
        }
        GD.Print(states.Count);
        
    }


    public bool IsValid(State state)
    {
        int xs = state.GetState() % 512;
        int os = (state.GetState()-xs) / 512;
        int x =0;
        int o =0;
        for(int i=0;i<9;i++)
        {
            if(IsBinTrue(xs,i))
            {
                x++;
            }
            if(IsBinTrue(os,i))
            {
                o++;
            }
            if(IsBinTrue(xs,i) && IsBinTrue(os,i)) return false;
        }
        




        if(x+o>9) return false;
        if(x-o>1 || x-o<0) return false;
        if(HasWon(xs) && HasWon(os)) return false;
        
        //GD.Print(state + " " + xs + " " + os + " " + x + " " + o);
        return true;
    }
    public bool IsBinTrue(int num,int index)
    {
        if((num & binary[index])>0) return true;
        return false;
    }
    public bool HasWon(int state)
    {
        if(IsBinTrue(state,0) && IsBinTrue(state,1) && IsBinTrue(state,2)) return true;
        if(IsBinTrue(state,3) && IsBinTrue(state,4) && IsBinTrue(state,5)) return true;
        if(IsBinTrue(state,6) && IsBinTrue(state,7) && IsBinTrue(state,8)) return true;
        if(IsBinTrue(state,0) && IsBinTrue(state,3) && IsBinTrue(state,6)) return true;
        if(IsBinTrue(state,1) && IsBinTrue(state,4) && IsBinTrue(state,7)) return true;
        if(IsBinTrue(state,2) && IsBinTrue(state,5) && IsBinTrue(state,8)) return true;
        if(IsBinTrue(state,0) && IsBinTrue(state,4) && IsBinTrue(state,8)) return true;
        if(IsBinTrue(state,2) && IsBinTrue(state,4) && IsBinTrue(state,6)) return true;


        return false;
    }
    
}
