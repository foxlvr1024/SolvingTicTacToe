using Godot;
using System;

public partial class TicTacToe : Node
{
    private Godot.Collections.Array<int> binary;



    public override void _Ready()
    {
        binary = new Godot.Collections.Array<int>();
        binary.Add(1);
        for(int i=1;i<9;i++)
        {
            binary.Add(binary[i-1]*2);
        }
        int br=0;
        for(int x=0;x<512;x++)
        {
            for(int o=0;o<512;o++)
            {
                if(IsValid(x+o*512)) br++;
            }
        }
        GD.Print(br);
    }


    public bool IsValid(int state)
    {
        int xs = state % 512;
        int os = (state-xs) / 512;
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
