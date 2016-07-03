var time1 : float;
var time2 : float = 2;
var bomb : GameObject;
var enemy : GameObject;
var enemyGreen : GameObject;
var plankton : GameObject;
var score : GameObject;
var boost : int = 50;
private var coordinateY : float;
private var coordinatey1 : float;
private var coordinatey2 : float;
private var coordinatey3 : float;

function Update () {
//reduce the time
time1 -= 1.5 * Time.deltaTime;
//if the time is less than or equal to 0
if(time1 <= 0){
//select at random coordinateY
coordinateY = Random.Range(-0.3, -4.2);
coordinatey1 = Random.Range(-2, -6.2);
coordinatey2 = Random.Range(0,-5);
coordinatey3 = Random.Range(-0.6,-4);
//create a bomb
Instantiate(bomb, Vector2(transform.position.x + 5,coordinateY), Quaternion.identity);
Instantiate(enemy, Vector2(transform.position.x + 7,coordinatey1),Quaternion.identity);
Instantiate(enemyGreen, Vector2(transform.position.x + 9,coordinatey2),Quaternion.identity);
Instantiate(plankton, Vector2(transform.position.x + 11,coordinatey3),Quaternion.identity);

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