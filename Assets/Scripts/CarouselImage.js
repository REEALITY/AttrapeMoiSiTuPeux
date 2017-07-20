// ---------------------------------------------------------------
// Code copyright by Hedgehog Team, Creepy Cat, Barking Dog (2017)
// ---------------------------------------------------------------

var fadeDuration = 0.17;
var framesPerSecond = 10.0;
var frames : Texture2D[];

private var indice:int = 0;
private var pingpong:int=1;

function FixedUpdate () {
    var lerp:float = Mathf.PingPong (Time.time, fadeDuration) / fadeDuration;
	indice = Time.time * framesPerSecond;
	indice = indice % frames.Length;

	if (lerp>0.999 && pingpong==1){
		GetComponent.<Renderer>().material.SetTexture( "_TexMat1",frames[indice]);
		pingpong=2;
	}
	
	if (lerp<0.001 && pingpong==2){
		GetComponent.<Renderer>().material.SetTexture( "_TexMat2",frames[indice]);
		pingpong=1;
	}
	
    GetComponent.<Renderer>().material.SetFloat( "_Blend", lerp );	
}

