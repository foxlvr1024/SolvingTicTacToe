using Godot;
using System;
using System.Runtime.Versioning;

public partial class CameraManager : Node2D
{
    private bool IsPressed = false;
    private Camera2D camera;
    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Camera2D");
    }
    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion motion && IsPressed)
        {
            GlobalPosition -= motion.Relative / camera.Zoom.X;
        }
        if(@event is InputEventMouseButton mouse)
        {
            if(mouse.ButtonIndex == MouseButton.Left) IsPressed = mouse.Pressed;
            if(mouse.ButtonIndex == MouseButton.WheelUp && camera.Zoom.X>0.5f) camera.Zoom -= new Vector2(0.01f,0.01f);
            if(mouse.ButtonIndex == MouseButton.WheelDown && camera.Zoom.X<3f) camera.Zoom += new Vector2(0.01f,0.01f);
            //GD.Print(camera.Zoom);
        }
    }
}
