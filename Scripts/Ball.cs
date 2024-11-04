using Godot;

namespace GodotPong;

public partial class Ball : Area2D
{
    private static readonly Vector2 StartingPoint = new() { X = 640, Y = 360 };

    private int _bounceCount;

    private AudioStreamPlayer _bounceSound;

    [Export]
    public Vector2 Direction = Vector2.Left;

    [Export]
    public double SpeedBuildup = 15;

    [Export]
    public double StartingSpeed = 400;

    public override void _Ready()
    {
        _bounceSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Position = Position with
        {
            X = Position.X + (float)(Direction.X * (StartingSpeed + SpeedBuildup * _bounceCount) * delta),
            Y = Position.Y + (float)(Direction.Y * (StartingSpeed + SpeedBuildup * _bounceCount) * delta)
        };
    }

    public void Reset(Vector2 direction)
    {
        _bounceCount = 0;
        Direction = direction;
        Position = StartingPoint;
    }

    public void Bounce(Vector2 direction)
    {
        _bounceCount++;
        Direction = direction;
        _bounceSound.Play();
    }
}
