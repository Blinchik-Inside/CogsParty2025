using Godot;

public partial class Player : Node2D
{
    private int score;
    private bool answerGiven;
    private int playerId;

    [Export] private NodePath PlayerScorePath;
    [Signal] public delegate void AnswerChosenEventHandler(int playerId, char button);

    public override void _Ready(){
        GD.Print("Game started.");
        score = 0;
        GetNode<Label>(PlayerScorePath).Text = score.ToString();
        answerGiven = false;

        // TODO: set playerId
        playerId = 1; // Replace with actual logic to set player ID

        GetNode<GameSpace>("/root/GameSpace").AddPoints += addPoints;
        GetNode<GameSpace>("/root/GameSpace").TimerFinished += resetAnswerGiven;
    }

    public override void _Process(double delta) {
		if (Input.IsActionPressed("pressY") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer Y chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, playerId, 'Y');
        }
        
        if (Input.IsActionPressed("pressX") && !answerGiven){
            // Answer X chosen. 
            GD.Print("Answer X chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, playerId, 'X');
        }

        if (Input.IsActionPressed("pressB") && !answerGiven){
            // Answer B chosen. 
            GD.Print("Answer B chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, playerId, 'B');
        }

        if (Input.IsActionPressed("pressA") && !answerGiven){
            // Answer A chosen. 
            GD.Print("Answer A chosen!");
            answerGiven = true;
            EmitSignal(SignalName.AnswerChosen, playerId, 'A');
        }
	}

    public void addPoints(int playerId, int points){
        if (this.playerId == playerId){
            score += points;
            GetNode<Label>(PlayerScorePath).Text = score.ToString();
        }
    }

    public int getScore(){
        return score;
    }

    public void resetAnswerGiven(){
        answerGiven = false;
    }

    public void setPlayerId(int id){
        playerId = id;
    }
    public int getPlayerId(){
        return playerId;
    }
}
