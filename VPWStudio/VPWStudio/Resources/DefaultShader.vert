#version 330

layout(location = 0) in vec3 position;
layout(location = 1) in vec2 uvCoords;
layout(location = 2) in vec3 colorData;

out vec2 texCoords;
out vec3 vertexColor;

void main(void)
{
    gl_Position = vec4(position, 1.0);
    texCoords = uvCoords;
    vertexColor = colorData;
}
