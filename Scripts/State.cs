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

}
