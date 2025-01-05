Shader "Unlit/GridSphere"
{
    Properties
    {
        _thick ("Thick", float) = 0.2
        _color ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float3 worldPos : TEXCODE1;
                float4 vertex : SV_POSITION;
            };

            uniform float _thick;
            uniform float4 _color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float PI = 3.1415926539;
                // sample the texture
                fixed4 grid = float4(0, 0, 0, 0);
                fixed4 norm = float4(normalize(float4(i.worldPos, 1)));
                float theta;
                float degrees;

                theta = atan(norm.z / norm.x);
                degrees = abs((180 / PI) * theta);
                grid += step(10 - _thick, degrees % 10) + step(degrees % 10, _thick);

                theta = atan(norm.y / length(float2(norm.x, norm.z)));
                degrees = abs((180 / PI) * theta);
                grid += step(10 - _thick, degrees % 10) + step(degrees % 10, _thick);

                grid.xyz *= (norm / 2) + 0.5;

                return grid * _color;
            }
            ENDCG
        }
    }
}
