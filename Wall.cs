using Godot;

namespace GodotPong;

public partial class Wall : Area2D
{
    [Export]
    public Vector2 BallResetDirection = Vector2.Left;

    [Export]
    public Node2D Scorer { get; set; }

    public override void _EnterTree()
    {
        AreaEntered += OnAreaEntered;
    }

    public override void _ExitTree()
    {
        AreaEntered -= OnAreaEntered;
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        ball.Reset(BallResetDirection);
        var scoring = Scorer as IHasScore;
        scoring?.IncrementScore();
    }
}
