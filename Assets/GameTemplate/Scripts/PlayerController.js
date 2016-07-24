var velosityObject : Vector2  = Vector2.zero;
var cam : GameObject;
var bubles : GameObject;
var fishSprite1 : Sprite;
var fishSprite2 : Sprite;
var fishSprite3 : Sprite;
var fishSprite4 : Sprite;
var fishSprite5 : Sprite;
var fishSprite6 : Sprite;
var fishSprite7 : Sprite;
var fishSprite8 : Sprite;
var fishSprite9 : Sprite;
var fishSprite10 : Sprite;
private var empty : boolean = true;
function Start(){
//if the number is 1
if(PlayerPrefs.GetInt("NumberFish") == 1){
//fish sprite changes to the fishSprite1
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite1;
}
//if the number is 2
if(PlayerPrefs.GetInt("NumberFish") == 2){
//fish sprite changes to the fishSprite2
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite2;
}
//if the number is 3
if(PlayerPrefs.GetInt("NumberFish") == 3){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite3;
}
//if the number is 4
if(PlayerPrefs.GetInt("NumberFish") == 4){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite4;
}

//if the number is 5
if(PlayerPrefs.GetInt("NumberFish") == 5){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite5;
}
//if the number is 6
if(PlayerPrefs.GetInt("NumberFish") == 6){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite6;
}

//if the number is 7
if(PlayerPrefs.GetInt("NumberFish") == 7){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite7;
}
//if the number is 8
if(PlayerPrefs.GetInt("NumberFish") == 8){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite8;
}
//if the number is 9
if(PlayerPrefs.GetInt("NumberFish") == 9){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite9;
}
//if the number is 10
if(PlayerPrefs.GetInt("NumberFish") == 10){
//fish sprite changes to the fishSprite3
gameObject.GetComponent(SpriteRenderer).sprite = fishSprite10;
}
}
function Update () {
//if the player is at the bottom of the stage
if(gameObject.transform.position.y < 0 && empty == true){
//turn on ParticleSystem
bubles.GetComponent.<ParticleSystem>().Play();
if(PlayerPrefs.GetInt("SoundBoolean") == 0){
//play sounds when it is switched on
gameObject.GetComponent.<AudioSource>().Play();
}
empty = false;
}
//if the player is in the upper part of the scene
if(gameObject.transform.position.y > 0 && empty == false){
//stop particle bubles
bubles.GetComponent.<ParticleSystem>().Stop();
//stop sound
gameObject.GetComponent.<AudioSource>().Stop();
empty = true;
}
//turn the fish so that it is not overturned
if(gameObject.transform.rotation.z < 0.7 && gameObject.transform.rotation.z > -0.7){
gameObject.transform.rotation.z = velosityObject.y / 10;
}
if(gameObject.transform.rotation.z > 0.7){
gameObject.transform.rotation.z -= 0.1;
}
if(gameObject.transform.rotation.z < -0.7){
gameObject.transform.rotation.z += 0.1;
}
//we get fish speed
velosityObject = gameObject.GetComponent.<Rigidbody2D>().velocity;
//camera monitors the fish
cam.transform.position.x = gameObject.transform.position.x + 1.5;
//asking fish movement along the x-axis
gameObject.transform.position.x += 0.08;
//the lower the fish the greater the buoyancy force
if(gameObject.transform.position.y < 0){
gameObject.GetComponent(Rigidbody2D).AddForce(new Vector2(0,3 * -gameObject.transform.position.y));
}
//if you pressed the up arrow and the fish is at the top of the screen
if(Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y < 0){
//if the speed of the object is less than 10
if(velosityObject.y < 10){
//add force y-axis
gameObject.GetComponent(Rigidbody2D).AddForce(new Vector2(0,25));
}
}
//if you pressed the down arrow
if(Input.GetKey(KeyCode.DownArrow)){
//if the speed of the object is less than 10
if(velosityObject.y > -10){
//add force y-axis
gameObject.GetComponent(Rigidbody2D).AddForce(new Vector2(0,-25));
}
}



for (var touch : Touch in Input.touches) {
//if touch is at the top of the screen and the subject is at the bottom of the screen
if(touch.position.y > cam.GetComponent(Camera).pixelHeight / 2 && gameObject.transform.position.y < 0){
//if the speed of the object is less than 10
if(velosityObject.y < 10){
//add force y-axis
gameObject.GetComponent(Rigidbody2D).AddForce(new Vector2(0,25));
}
}
//If touch is at the bottom of the screen
if(touch.position.y < cam.GetComponent(Camera).pixelHeight / 2){
//if the speed of the object is less than 10
if(velosityObject.y > -10){
//add force y-axis
gameObject.GetComponent(Rigidbody2D).AddForce(new Vector2(0,-25));
}
}
}
}