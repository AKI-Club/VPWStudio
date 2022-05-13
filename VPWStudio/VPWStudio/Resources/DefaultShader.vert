#version 330

in vec3 position;
in vec2 uvCoords;
in vec3 colorData;

uniform mat4 modelView;

out vec2 texCoords;
out vec3 vertexColor;

void main(void)
{
    gl_Position = modelView * vec4(position, 1.0);
    texCoords = uvCoords;
    vertexColor = colorData;
}
