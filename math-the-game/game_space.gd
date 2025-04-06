extends CanvasLayer


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$Node2D/MathDoer.add_buttons(
	$"BoxContainer/Answer options/HBoxContainer/B-Button/Button",
	$"BoxContainer/Answer options/HBoxContainer/X-Button/Button",
	$"BoxContainer/Answer options/Y-Button/Panel/Button",
	$"BoxContainer/Answer options/MarginContainer2/A-Button/Button"
	)
	$Node2D/MathDoer.add_display($"BoxContainer/The problem/Question/Problem goes here/Text of the problem")
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
