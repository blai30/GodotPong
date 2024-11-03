using System;
using Godot;

namespace GodotPong;

public partial class Enemy : Area2D, IHasScore
{
    [Export]
    private float _difficulty = 0.2f;

    [Export]
    private Area2D _follow;

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
        Position = Position with
        {
            Y = Math.Clamp(Position.Lerp(_follow.Position, _difficulty / 10f).Y, 16, GetViewportRect().Size.Y - 16)
        };
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        var direction = new Vector2(Vector2.Left.X, (float)Random.Shared.NextDouble() * 2 - 1).Normalized();
        ball.Bounce(direction);
    }
}
