using Godot;
using System;

public partial class NodeState : ColorRect
{
	private int state;
    public override void _Ready()
    {
        state=0;
    }
	public void SetState(int state)
	{
		this.state=state;
	}
	public int GetState()
	{
		return state;
	}
}
