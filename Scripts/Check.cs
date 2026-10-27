using Godot;
using System;

public interface Check
{
    public abstract bool Pass(State state);
}
