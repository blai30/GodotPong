using System;
using Godot;

namespace GodotPong;

public partial class Player : Area2D, IHasScore
{
    [Export]
    private int _moveSpeed = 200;

    public int Score { get; set; }

    [Export]
    public Label ScoreLabel { get; set; }

    public AudioStreamPlayer ScoreSound { get; set; }

    public override void _Ready()
    {
        ScoreSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        ScoreLabel.Text = "0";
    }

    public override void _EnterTree()
    {
        AreaEntered += OnAreaEntered;
    }

    public override void _ExitTree()
    {
        AreaEntered += OnAreaEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        float input = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
        var position = Position;
        position += new Vector2(0, (float)(input * _moveSpeed * delta));
        position.Y = Mathf.Clamp(position.Y, 16, GetViewportRect().Size.Y - 16);
        Position = position;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        var direction = new Vector2(Vector2.Right.X, (float)Random.Shared.NextDouble() * 2 - 1).Normalized();
        ball.Bounce(direction);
    }
}
