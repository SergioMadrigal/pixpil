var fish1 : GameObject;
var fish2 : GameObject;
var fish3 : GameObject;
var fish4 : GameObject;
var fish5 : GameObject;
var fish6 : GameObject;
var fish7 : GameObject;
var fish8 : GameObject;
var fish9 : GameObject;
var fish10 : GameObject;

private var empty : boolean;
function OnMouseDown () {
if(PlayerPrefs.GetInt("SoundBoolean") == 0){
//play sounds when it is switched on.
gameObject.GetComponent.<AudioSource>().Play();
}
//button color becomes darkened
gameObject.GetComponent(SpriteRenderer).color = Color(0.8,0.8,0.8,1);
empty = true;
}
function OnMouseUp () {
//button becomes a standard color
gameObject.GetComponent(SpriteRenderer).color = Color(1,1,1,1);
//if the object name LeftSlider
if(gameObject.name == "LeftSlider"){
//if the fish1 included
if(fish1.activeSelf == true && empty == true){
//turn off fish1
fish1.SetActive(false);
//turn on fish4
fish10.SetActive(true);
empty = false;
}
//if the fish2 included
if(fish2.activeSelf == true && empty == true){
//turn off fish2
fish2.SetActive(false);
//turn on fish1
fish1.SetActive(true);
empty = false;
}
//if the fish3 included
if(fish3.activeSelf == true && empty == true){
//turn off fish3
fish3.SetActive(false);
//turn on fish2
fish2.SetActive(true);
empty = false;
}

//if the fish4 included
if(fish4.activeSelf == true && empty == true){
//turn off fish3
fish4.SetActive(false);
//turn on fish2
fish3.SetActive(true);
empty = false;
}

//if the fish5 included
if(fish5.activeSelf == true && empty == true){
//turn off fish3
fish5.SetActive(false);
//turn on fish2
fish4.SetActive(true);
empty = false;
}

//if the fish6 included
if(fish6.activeSelf == true && empty == true){
//turn off fish3
fish6.SetActive(false);
//turn on fish2
fish5.SetActive(true);
empty = false;
}

//if the fish7 included
if(fish7.activeSelf == true && empty == true){
//turn off fish3
fish7.SetActive(false);
//turn on fish2
fish6.SetActive(true);
empty = false;
}

//if the fish8 included
if(fish8.activeSelf == true && empty == true){
//turn off fish3
fish8.SetActive(false);
//turn on fish2
fish7.SetActive(true);
empty = false;
}

//if the fish9 included
if(fish9.activeSelf == true && empty == true){
//turn off fish3
fish9.SetActive(false);
//turn on fish2
fish8.SetActive(true);
empty = false;
}

//if the fish10 included
if(fish10.activeSelf == true && empty == true){
//turn off fish3
fish10.SetActive(false);
//turn on fish2
fish9.SetActive(true);
empty = false;
}
}
//if the object name LeftSlider
if(gameObject.name == "RightSlider"){
//if the fish1 included
if(fish1.activeSelf == true && empty == true){
//turn off fish1
fish1.SetActive(false);
//turn on fish2
fish2.SetActive(true);
empty = false;
}
//if the fish2 included
if(fish2.activeSelf == true && empty == true){
//turn off fish2
fish2.SetActive(false);
//turn on fish3
fish3.SetActive(true);
empty = false;
}
//if the fish3 included
if(fish3.activeSelf == true && empty == true){
//turn off fish3
fish3.SetActive(false);
//turn on fish1
fish4.SetActive(true);
empty = false;
}

//if the fish4 included
if(fish4.activeSelf == true && empty == true){
//turn off fish3
fish4.SetActive(false);
//turn on fish1
fish5.SetActive(true);
empty = false;
}

//if the fish5 included
if(fish5.activeSelf == true && empty == true){
//turn off fish3
fish5.SetActive(false);
//turn on fish1
fish6.SetActive(true);
empty = false;
}

//if the fish6 included
if(fish6.activeSelf == true && empty == true){
//turn off fish3
fish6.SetActive(false);
//turn on fish1
fish7.SetActive(true);
empty = false;
}

//if the fish7 included
if(fish7.activeSelf == true && empty == true){
//turn off fish3
fish7.SetActive(false);
//turn on fish1
fish8.SetActive(true);
empty = false;
}

//if the fish8 included
if(fish8.activeSelf == true && empty == true){
//turn off fish3
fish8.SetActive(false);
//turn on fish1
fish9.SetActive(true);
empty = false;
}

//if the fish9 included
if(fish9.activeSelf == true && empty == true){
//turn off fish3
fish9.SetActive(false);
//turn on fish1
fish10.SetActive(true);
empty = false;
}

//if the fish10 included
if(fish10.activeSelf == true && empty == true){
//turn off fish3
fish10.SetActive(false);
//turn on fish1
fish1.SetActive(true);
empty = false;
}

}
}