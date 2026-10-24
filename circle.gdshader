shader_type canvas_item;

void fragment() {
	vec2 uv = UV;
	
	//uv.x = uv.x/2.0f;
	//uv.y = uv.y/2.0f;
	uv.x -= 0.5f;
	uv.y -= 0.5f;
	float a = 1.0f - step(0.5f,sqrt(uv.x*uv.x+uv.y*uv.y));
	
	COLOR = vec4(COLOR.r,COLOR.g,COLOR.b,a);
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
