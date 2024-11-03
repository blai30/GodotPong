using Godot;

namespace GodotPong;

public partial class Ball : Area2D
{
    private static readonly Vector2 StartingPoint = new() { X = 640, Y = 360 };

    private AudioStreamPlayer _bounceSound;

    [Export]
    public Vector2 Direction = Vector2.Left;

    [Export]
    public double MoveSpeed = 400;

    public override void _Ready()
    {
        _bounceSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Position = Position with
        {
            X = (float)(Position.X + MoveSpeed * delta * Direction.X),
            Y = (float)(Position.Y + MoveSpeed * delta * Direction.Y)
        };
    }

    public void Reset(Vector2 direction)
    {
        Direction = direction;
        Position = StartingPoint;
    }

    public void Bounce(Vector2 direction)
    {
        Direction = direction;
        _bounceSound.Play();
    }
}