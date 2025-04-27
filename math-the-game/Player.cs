using Godot;

public partial class Player : Node2D
{
    private int score;
    private bool answerGiven;

    [Export] private NodePath PlayerScorePath;

    [Signal] public delegate void AnswerChosenEventHandler(char button);
    
    public override void _Ready(){
        GD.Print("Game started.");
        score = 0;
        GetNode<Label>(PlayerScorePath).Text = score.ToString();
        answerGiven = false;
    }

    public override void _Process(double delta) {
		if (Input.IsActionPressed("pressY") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer Y chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, 'Y');
        }
        
        if (Input.IsActionPressed("pressX") && !answerGiven){
            // Answer X chosen. 
            GD.Print("Answer X chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, 'X');
        }

        if (Input.IsActionPressed("pressB") && !answerGiven){
            // Answer B chosen. 
            GD.Print("Answer B chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, 'B');
        }

        if (Input.IsActionPressed("pressA") && !answerGiven){
            // Answer A chosen. 
            GD.Print("Answer A chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, 'A');
        }
	}

    public void addPoints(){
        score += 10;
    }

    public int getScore(){
        return score;
    }

    public void resetAnswerGiven(){
        answerGiven = false;
    }
}
