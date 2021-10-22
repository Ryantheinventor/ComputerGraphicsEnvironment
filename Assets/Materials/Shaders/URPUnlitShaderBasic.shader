Shader "Unlit/URPUnlitShaderBasic"
{
    Properties
    {
       _Color ("Color", Color) = (0.5,0.5,0.5,1)
       _Direction ("Wind Direction", Vector) = (1,0,0,0)
       _Strength ("Wind Strength", float) = 0.1
       _YOffset ("Height Offset", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalRenderPipeline"}

        Pass
        {
            //Unity SRP uses the HLSL language
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            half4 _Color;
            float4 _Direction;
            float _YOffset;
            float _Strength;

            struct Attributes
            {
                //The positionOS var contains the vertex positions in object space
                float4 positionOS   : POSITION;
            };
            struct Varyings
            {
                //The positions in this stuct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
            };

            Varyings vert (Attributes IN)
            {
                //declaring the output object
                Varyings OUT;

                //custom shade code goes here

                //move around origin
                //IN.positionOS += float4(sin(_Time.y),0,cos(_Time.y),0);

                //warp around origin
                //IN.positionOS *= pow(distance(IN.positionOS, float4(sin(_Time.y), 0, cos(_Time.y), 0)), 2);
    
                //sin wind
                IN.positionOS += float4(_Direction.x * (sin(_Time.y) + 1) * pow(IN.positionOS.y + _YOffset,2)/3 * _Strength, 0,
                                        _Direction.z * (sin(_Time.y) + 1) * pow(IN.positionOS.y + _YOffset,2)/3 * _Strength, 0);
                
                //TransformObjectToHClip transforms vertex positions
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);

                return OUT;
            }

            half4 frag () : SV_Target
            {
                return _Color;
            }
            ENDHLSL
        }
    }
}
