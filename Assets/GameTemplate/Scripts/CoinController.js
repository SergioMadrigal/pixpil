var time : float = 3;
var coin : GameObject;
private var coordinateY : float;
private var coordinateX : float;
function Update () {
//reduce the time
time -= 1 * Time.deltaTime;
//if the time is less than or equal to 0
if(time <= 0){
//select at random coordinateY
coordinateY = Random.Range(0.3, 4.6);
//select at random coordinateX
coordinateX = Random.Range(4, 10);
//create a coin
Instantiate(coin, Vector2(transform.position.x + coordinateX,coordinateY), Quaternion.identity);
// time becomes equal to 2
time = 2;
}
}