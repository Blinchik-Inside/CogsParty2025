using Godot;
using System;

public partial class Player : Node2D
{
    // int score;
    bool answerGiven;
    
    public override void _Ready(){
        GD.Print("Game started.");
        answerGiven = false;
    }

    public override void _Process(double delta) {
		if (Input.IsActionPressed("pressY") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer Y chosen!");
            answerGiven = true;
        }
        
        if (Input.IsActionPressed("pressX") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer X chosen!");
            answerGiven = true;
        }

        if (Input.IsActionPressed("pressB") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer B chosen!");
            answerGiven = true;
        }

        if (Input.IsActionPressed("pressA") && !answerGiven){
            // Answer Y chosen. 
            GD.Print("Answer A chosen!");
            answerGiven = true;
        }
	}
}
