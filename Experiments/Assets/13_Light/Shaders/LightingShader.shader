Shader "Custom/Lighting_Shader_01" {

	Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader {

		Pass {
			Tags {
				"LightMode" = "ForwardBase"
			}
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "UnityCG.cginc"
			#include "UnityStandardBRDF.cginc"

			float4 _Tint;
			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : TEXCOORD1;
			};

			struct VertexData {
				float4 position : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			Interpolators MyVertexProgram(VertexData p_vertexData) {
				Interpolators i;
				i.position = mul(UNITY_MATRIX_MVP, p_vertexData.position);
				i.normal = UnityObjectToWorldNormal(p_vertexData.normal);
				i.normal = normalize(i.normal);
				p_vertexData.normal;
				i.uv = TRANSFORM_TEX(p_vertexData.uv, _MainTex);
				return i;
			}

			float4 MyFragmentProgram(Interpolators p_interpolator) : SV_TARGET {
				float3 lightDir = _WorldSpaceLightPos0.xyz;
				float3 lightColor = _LightColor0.rgb;
				float3 diffuse = lightColor * DotClamped(lightDir, p_interpolator.normal);

				p_interpolator.normal = normalize(p_interpolator.normal);

				return float4(diffuse, 1);
			}

			ENDCG
		}
	}
}