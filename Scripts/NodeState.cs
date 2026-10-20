using Godot;
using System;

public partial class NodeState : ColorRect
{
	private int state;
    public override void _Ready()
    {
        //state=0;
    }
	public void SetState(int state)
	{
		this.state=state;
	}
	public int GetState()
	{
		return state;
	}
	public void AddEdge(Vector2 pos1, Vector2 pos2)
	{
		Line2D line = new Line2D();
		line.AddPoint(pos1);
		line.AddPoint(pos2);
		line.DefaultColor = new Color("000000");
		line.Width = 1.5f;
		line.ShowBehindParent=true;
		line.ZAsRelative=false;
		
		AddChild(line);
	}
}
