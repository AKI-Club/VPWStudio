#version 330

in vec2 texCoords;
in vec3 vertexColor;

out vec4 outputColor;

uniform sampler2D texture0;

void main(void)
{
    outputColor = texture(texture0, texCoords);
}
