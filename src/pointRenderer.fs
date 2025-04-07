#version 330 core

uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

in vec3 Color;
in vec3 Normal;
in vec3 FragPos; 

void main()
{
    vec2 t = gl_PointCoord * 2.0 - vec2(1.0,1.0);
    if (length(t) > 1.0) 
        discard;

    float ambientFactor = 0.2;

    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);  

    float diff = max(dot(norm, lightDir), 0.0);

    float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);

    vec3 result = (ambientFactor + diff + specularStrength * spec) * lightColor * Color;

    gl_FragColor = vec4(result, 1.0); 
}