Shader "Unlit/Blend"
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Color("Color Tint", Color) = (1, 1, 1, 1) // Includes alpha
        _Cutoff("Cutoff", Range(-1, 1)) = -0.05 // Cutoff slider (Change range value if you want a wider or shorter range)
        _Blend("Blend Range", Range(-0.5, 3)) = 1.44  // Blend range slider
    }

        SubShader{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                    float4 color : COLOR; // Pass color for alpha control
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                    float2 texcoord : TEXCOORD0;
                    float4 color : COLOR; // Pass color with alpha
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color; // Color tint, including alpha
                fixed _Cutoff; // Cutoff threshold for transparency
                fixed _Blend;  // Blend range for smooth transitions

                v2f vert(appdata_t v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                    o.color = v.color * _Color; // Apply color tint and alpha
                    return o;
                }

                fixed4 frag(v2f i) : COLOR {
                    fixed4 texColor = tex2D(_MainTex, i.texcoord);

                // Apply the interpolated color and alpha
                texColor *= i.color;

                // Apply the cutoff and blend effect on alpha
                if (texColor.a < _Cutoff) {
                    texColor.a = 0; // Full transparency if below cutoff
                }
                else if (texColor.a < _Cutoff + _Blend) {
                    texColor.a = smoothstep(_Cutoff, _Cutoff + _Blend, texColor.a); // Smooth transition
                }

                // Premultiply alpha for better transparency handling
                texColor.rgb *= texColor.a;

                return texColor;
            }
            ENDCG
        }
        }
}
