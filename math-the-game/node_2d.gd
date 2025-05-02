extends Node2D

@export var problem = ""
@export var answers = []
@export var correct_button = 0

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

func make_problem() -> void:
	$"../MathDoerReal".make_problems()
	problem = $"../MathDoerReal".get_question()
	answers = $"../MathDoerReal".get_button_values()
	correct_button = $"../MathDoerReal".get_correct_answer()
	pass
