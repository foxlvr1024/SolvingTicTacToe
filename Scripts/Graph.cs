using Godot;
using System;

public partial class Graph : HBoxContainer
{
	private GridContainer[] grids;
	private PackedScene nodestate;
	public override void _Ready()
	{
		nodestate = GD.Load<PackedScene>("res://Scenes/node_state.tscn");
		grids = new GridContainer[9];
		for(int i=0;i<9;i++)
		{
			grids[i] = GetNode<GridContainer>("GridContainer" + (i+1).ToString());
		}
	}
	public void AddState(int place, int state)
	{
		NodeState pom = nodestate.Instantiate<NodeState>();
		pom._Ready();
		pom.SetState(state);
		grids[place-1].AddChild(pom);
	}

	public void AddEdge(NodeState from, NodeState to)
	{
		//GD.Print(from);
		//GD.Print(to);
		//GD.Print(from.GetState() +" "+ to.GetState());
		
		from.AddEdge(new Vector2(15,7.5f),to.GlobalPosition-from.GlobalPosition);
	}

	public NodeState GetNode(int place, int state)
	{
		//GD.Print(state);
		//GD.Print(place);
		foreach(NodeState node in grids[place-1].GetChildren())
		{
			//GD.Print(node.GetState());
			if(node.GetState()==state) return node;
		}
		return null;
	}
}
