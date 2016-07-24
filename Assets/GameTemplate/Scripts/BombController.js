var time1 : float;
var time2 : float = 2;
var bomb : GameObject;
var bomb1 : GameObject;
var bomb2 : GameObject;
var score : GameObject;
var boost : int = 50;
private var coordinateY : float;
private var coordinateY1 : float;
private var coordinateY2 : float;
function Update () {
//reduce the time
time1 -= 1.5 * Time.deltaTime;
//if the time is less than or equal to 0
if(time1 <= 0){
//select at random coordinateY
coordinateY = Random.Range(-0.3, -4.2);
coordinateY1 = Random.Range(-1, -5.2);
coordinateY2 = Random.Range(-0.6, -2.2);
//create a bomb
Instantiate(bomb, Vector2(transform.position.x + 5,coordinateY), Quaternion.identity);
Instantiate(bomb1, Vector2(transform.position.x + 7,coordinateY1), Quaternion.identity);
Instantiate(bomb2, Vector2(transform.position.x + 9,coordinateY2), Quaternion.identity);
// time becomes equal to time2
time1 = time2;
}
//if the Score is less than or equal to boost
if(score.GetComponent(Score).score >= boost){
//the time2 gets smaller
time2 -= 0.2;
//the boost gets bigger
boost += 50;
} 
}