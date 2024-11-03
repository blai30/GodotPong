using Godot;

namespace GodotPong;

public interface IHasScore
{
    StringName Name { get; }
    int Score { get; set; }
    Label ScoreLabel { get; set; }
    AudioStreamPlayer ScoreSound { get; }

    void IncrementScore()
    {
        Score++;
        if (ScoreLabel is not null)
        {
            ScoreLabel.Text = Score.ToString();
            GD.Print($"{Name} scored. Current score: {Score}.");
        }

        ScoreSound.Play();
    }
}
