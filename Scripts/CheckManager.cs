using Godot;
using System;

public partial class CheckManager : Node
{
    private static CheckManager instance;

    public static CheckManager GetInstance()
    {
        if(instance == null) instance = new CheckManager();
        return instance;
    }

    private AnyWinCheck anyWinCheck;

    private CheckManager()
    {
        anyWinCheck = new AnyWinCheck();
    }


    public AnyWinCheck GetAnyWinCheck()
    {
        return anyWinCheck;
    }
}
