using Godot;
using System;

public partial class NodeState : ColorRect
{
	private int state;
	private Color clr;
	
    public override void _Ready()
    {
		clr = new Color("ffffff");
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
	public void _on_gui_input(InputEvent e)
	{
		if(e is InputEventMouseButton mb)
		{
			if(mb.ButtonIndex == MouseButton.Right && mb.Pressed)
			{
				if(mb.ShiftPressed)
				{
					GD.Print("held");
				}
				else
				{
					if(Color==clr)
					{
						Color = new Color("ff0000");
						SetLines(1);
					}
					else
					{
						Color = clr;
						SetLines(-1);
					}
				}
			}
		}
	}
	public void SetLines(int z)
	{
		foreach(Line2D line in GetChildren())
		{
			line.ZIndex=z;
			line.DefaultColor = z>0 ? new Color("00ff00") : new Color("000000");
		}
	}
}
