using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 
using System; 

public class ClockDigital : MonoBehaviour { 
  private Text textClock; 
	public float time_acc=1.0f;
  void Awake (){ 
    textClock = GetComponent<Text>(); 
  } 

  void Update (){ 
    float second = Time.time*time_acc+4*60;
	TimeSpan time = TimeSpan.FromSeconds(second*60);

//here backslash is must to tell that colon is
//not the part of format, it just a character that we want in output
string str = time .ToString(@"hh\:mm\:ss\:fff"); 

    textClock.text = str;
  } 


}