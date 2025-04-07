#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aCol;
layout (location = 2) in vec3 aNorm;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform float aPointSize;

out vec3 Color;
out vec3 Normal;
out vec3 FragPos;

void main()
{
	gl_Position = projection * view * model * vec4(aPos, 1.0);
	Color = aCol;
	Normal = aNorm;
	FragPos = vec3(model * vec4(aPos, 1.0));
	gl_PointSize = aPointSize;
}