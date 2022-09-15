// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Superplay/UI/ProgressBarFillUIShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        
        [Header(Animation texture)]
        [Space]
        [NoScaleOffset]_AnimatedTex ("Animated Texture", 2D) = "white" {}
        _AnimatedColor ("Animated Texture Tint", Color) = (1,1,1,1)
        _AnimatedTexTiling ("Animated Texture Tiling", Range(0.001, 10.0)) = 0.01
        
        [Header(Animation Speed)]
        [Space]
        _ScrollXSpeed ("Scroll X Speed", Range(0, 100)) = 0
        _ScrollYSpeed ("Scroll Y Speed", Range(0, 100)) = 0
        
        [Header(Stencil)]
        [Space]
        _StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		
		_ColorMask ("Color Mask", Float) = 15
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True" }
        
        Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
			
			FailFront Keep
			ZFailFront Keep
			FailBack Keep
			ZFailBack Keep
		}
		
		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]

        Pass
        {
            Name "Default"            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"
            
            #pragma multi_compile __ UNITY_UI_CLIP_RECT
			#pragma multi_compile __ UNITY_UI_ALPHACLIP
			
			#include "UnityShaderVariables.cginc"

            struct v2f
            {
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            uniform sampler2D _MainTex;
            uniform float4 _Color;
            fixed4 _TextureSampleAdd;
            uniform sampler2D _AnimatedTex;
            uniform fixed4 _AnimatedColor;
            uniform float _AnimatedTexTiling;
            
            uniform float _ScrollXSpeed;
            uniform float _ScrollYSpeed;
            
            float4 _MainTex_ST;
            float4 _AnimatedTex_ST;

            v2f vert (appdata_full v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                
                // Gets the xy position of the vertex in worldspace.
                float2 worldXY = mul(unity_ObjectToWorld, v.vertex).xy;
                
                o.uv1 = TRANSFORM_TEX(worldXY, _AnimatedTex);
                o.color = v.color * _Color;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 main = (tex2D(_MainTex, i.uv) + _TextureSampleAdd) * i.color;
                
                fixed offsetX = _ScrollXSpeed * _Time;
                fixed offsetY = _ScrollYSpeed * _Time;
                fixed2 offsetUV = fixed2(offsetX, offsetY);
                
                fixed4 animated = tex2D(_AnimatedTex, (i.uv1  * _AnimatedTexTiling) + offsetUV);
                animated.rgb *= _AnimatedColor.rgb;
                animated.a = main.a;
                
                // fixed4 clear = fixed4(0,0,0,0);
                // fixed4 smoothed = lerp(_AnimatedColor, _Color, 1 - i.uv.x);
                // fixed4 colorsAndAnimation = lerp(_Color, smoothed, animated);
                
                fixed4 result = fixed4(main.rgb + animated.rgb, main.a);
                
                return result;
            }
            ENDCG
        }
    }
}
