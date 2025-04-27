using Godot;
using System;

public partial class GameSpace : CanvasLayer
{
	private int secondsLeft;
	private int problemsSolved;
	private float timeAccumulator = 0;
	private char correctAnswer;

	[Export] private NodePath ProblemContPath;
	[Export] private NodePath TimerLabelPath;
	[Export] private NodePath TimerNodePath;

	[Export] private NodePath Player1NodePath;
	[Export] private NodePath Player2NodePath;
	[Export] private NodePath Player3NodePath;
	[Export] private NodePath Player4NodePath;

	[Export] private NodePath ProblemLabelPath;
	[Export] private NodePath AnswerYPath;
	[Export] private NodePath AnswerXPath;
	[Export] private NodePath AnswerBPath;
	[Export] private NodePath AnswerAPath;
	

	[Signal] public delegate void TimerFinishedEventHandler();
	[Signal] public delegate void AddPointsEventHandler(int playerId, int points);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		var texturePath= "res://problems/1.png"; // TODO: Set the texture path for each respective problem
		var texture2d = (Texture2D) GD.Load(texturePath);
		GetNode<TextureRect>(ProblemContPath).Texture = texture2d;

		correctAnswer = 'Y'; // TODO: Set the correct answer for each respective problem
		problemsSolved = 0;

		secondsLeft = 15;
		GetNode<Label>(TimerLabelPath).Text = timerToString();
		setProblemLabel("Game Test Problem"); // TODO: Set the problem type for each respective problem

		GetNode<Timer>(TimerNodePath).Connect("timeout", new Callable(this, nameof(_on_Timer_timeout)));
		GetNode<Timer>(TimerNodePath).Start();

        GetNode<Player>(Player1NodePath).AnswerChosen += acceptAnswer;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}

	private void _on_Timer_timeout() {
		if (secondsLeft > 0) {
			secondsLeft--;
			GetNode<Label>(TimerLabelPath).Text = timerToString();
		} else {
			ResetTimer(10);
			problemsSolved++;
			setProblemLabel("Game Test Problem"); // TODO: Set the problem type for each respective problem
			EmitSignal(SignalName.TimerFinished);
		}
	}

	public void ResetTimer(int newTime = 15) {
		GetNode<Timer>(TimerNodePath).Stop();
		secondsLeft = newTime;
		GetNode<Label>(TimerLabelPath).Text = timerToString();
		GetNode<Timer>(TimerNodePath).Start();
	}

	private string timerToString() {
		return $"{00}:{secondsLeft:D2}";
	}

	private void acceptAnswer(int playerId, char button){
		if (button == correctAnswer){
			EmitSignal(SignalName.AddPoints, playerId, 15);
		}
	}

	private void setProblemLabel(string problemType){
        string problemLabel = (problemsSolved + 1).ToString() + ". " + problemType;
		GetNode<Label>(ProblemLabelPath).Text = problemLabel;
	}
}