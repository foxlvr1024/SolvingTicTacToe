using Godot;
using System;

public partial class TicTacToe : Node
{
    private Godot.Collections.Array<int> binary;



    public override void _Ready()
    {
        binary.Add(1);
        for(int i=1;i<10;i++)
        {
            binary.Add(binary[i-1]*2);
        }
    }


    public bool IsValid(int state)
    {
        int xs = state % 1024;
        int os = (state-xs) / 1024;
        int x =0;
        int o =0;
        for(int i=0;i<10;i++)
        {
            if(IsBinTrue(xs,i))
            {
                x++;
            }
            if(IsBinTrue(os,i))
            {
                o++;
            }
        }
        bool xwin = false;
        bool owin = false;




        if(x+o>9) return false;
        if(x-o>1 || x-o<0) return false;

        return true;
    }
    public bool IsBinTrue(int num,int index)
    {
        if((num & binary[index])>0) return true;
        return false;
    }


}
