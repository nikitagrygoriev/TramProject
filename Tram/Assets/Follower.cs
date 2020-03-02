
using UnityEngine;
using PathCreation;
public class Follower : MonoBehaviour
{
public PathCreator pc;
public int line_number; //numer linii po której jeździ tramwaj
public int tram_number=1;
 float time_acc=1.0f; //przyspieszenie czasu, domyślnie 1, tym dostosowujemy 
		      //prędkość symulacji
 float sim_time=0.0f; //czas w symulacji, sekunda irl to minuta w symulacji
 static float speed = 0.154f; //tego nie zmieniać, prędkość tramwaju podczas jazdy
 float speed_tmp = speed; //aktualna prędkość (gdy stoi w zajezdni to 0)
 float dst; //pokonana trasa

Vector3 vec1; //wektor akutalnego położenia
//true gdy ma stać na stacji, false gdy ruszyć

bool flag_start_1 = true;
bool flag_start_2 = false;
bool flag_start_3 = true;
bool flag_start_5 = true;
bool flag_start_9 = true;
bool flag_start_10 = true;
bool flag_start_11 = true;
bool flag_start_14 = true;
bool flag_start_16 = true;
bool flag_start_18 = true;
bool flag_start_19 = true;

bool flag_end_1 = true;
bool flag_end_2 = false;
bool flag_end_3 = true;
bool flag_end_5 = true;
bool flag_end_9 = true;
bool flag_end_10 = true;
bool flag_end_11 = true;
bool flag_end_14 = true;
bool flag_end_16 = true;
bool flag_end_18 = true;
bool flag_end_19 = true;

int[] l1t1 = new int[]{4*60+37, 5*60+30, 6*60+35, 7*60+31, 8*60+20, 9*60+15, 10*60+4, 11*60+0, 11*60+49, 12*60+45, 13*60+34, 14*60+31, 15*60+20, 16*60+15, 17*60+5, 18*60+0, 18*60+57, 19*60+53, 20*60+47, 21*60+40, 22*60+40};
int[] l2t2 = new int[]{4*60+59,5*60+55, 6*60+50, 7*60+46, 8*60+35, 9*60+30, 10*60+19, 11*60+15, 12*60+4, 12*60+59, 13*60+49, 14*60+37, 15*60+35, 16*60+30, 17*60+20, 18*60+17, 19*60+12, 10*60+8, 21*60+2, 21*60+56};
int[] l3t3 = new int[]{5*60+15, 6*60+17, 7*60+5, 8*60+0, 8*60+50, 9*60+45, 10*60+34, 11*60+30, 12*60+19, 13*60+14, 14*60+4, 15*60+2, 15*60+50, 16*60+45,17*60+35, 18*60+32, 19*60+27, 20*60+23, 21*60+17, 22*60+11};
int[] l4t4 = new int[]{5*60+29, 6*60+31, 7*60+20, 8*60+15, 9*60+5, 10*60+0, 10*60+49, 11*60+45, 12*60+34, 13*60+30, 14*60+19, 15*60+17, 16*60+5, 17*60+1,17*60+56, 18*60+49, 19*60+42, 20*60+40, 21*60+31, 22*60+26};
int[] l5t5 = new int[]{4*60, 4*60+47, 5*60+41, 6*60+46, 7*60+35, 8*60+30, 9*60+20, 10*60+15, 11*60+4, 12*60+0, 12*60+49, 13*60+46, 14*60+35, 15*60+30, 16*60+20, 17*60+16,18*60+12, 19*60+8, 19*60+58, 20*60+56, 21*60+46, 22*60+41};
int[] l6t6 = new int[]{4*60, 5*60+2, 6*60+1, 7*60+1, 7*60+50, 8*60+45, 9*60+35, 10*60+30, 11*60+19, 12*60+15, 13*60+4, 14*60+1, 14*60+50, 15*60+45, 16*60+35, 17*60+30, 18*60+27, 19*60+23, 20*60+14, 21*60+11, 22*60+1, 22*60+56};
int[] l7t7 = new int[]{4*60, 5*60+16, 6*60+16, 7*60+16, 8*60+5, 9*60+0, 9*60+50, 10*60+45, 11*60+34, 12*60+30, 13*60+19, 14*60+16, 15*60+5, 16*60+0, 16*60+50, 17*60+45, 18*60+43, 19*60+38, 20*60+31, 21*60+25, 22*60+18, 23*60+17};
int[] current;



int i=0;
int j=1;
void Update(){
	//Debug.Log(dst);
	//if(sim_time>24*60)sim_time-=24*60;
	if(tram_number==1) current=l1t1;
	else if (tram_number==2) current=l2t2;
	else if (tram_number==3) current=l3t3;
	else if (tram_number==4) current=l4t4;
	else if (tram_number==5) current=l5t5;
	else if (tram_number==6) current=l6t6;
	else if (tram_number==7) current=l7t7;
	sim_time=Time.time*time_acc+4*60;


	vec1 = pc.path.GetPointAtDistance(dst);
	//if(i<8){
	if ((i%2==0) && current[i]<sim_time){
		flag_start_1=false;
		i+=1;
}
	else if ((i%2==1) && current[i]<sim_time){
		flag_end_1=false;
		i+=1;
}
//}
 	
//linia 1
	if(line_number==1){

	if (vec1.x>7.95){
		flag_start_1=true;
	}
	if (vec1.x<2.5){
		flag_end_1=true;
	}
	if (flag_start_1==false || flag_end_1==false){
		speed_tmp=speed;
	}
	else {
		speed_tmp=0;
	}
}



	/*bool start_line1=(vec1.x<2.5); //"zajezdnia"
	bool end_line1=(vec1.x>7.95);
	if(line_number==1){
//tramwaj automatycznie zatrzymuje się w zajezdni, rusza gdy zmienimy flagę

		if (start_line1){
			flag_end_1=true;
		}
		else if (end_line1) {
			flag_start_1=true;
		}

		if (flag_start_1==false){
			speed_tmp=speed;
		}
		else if (flag_end_1==false){
			speed_tmp=speed;
		}
		if (flag_start_1 && flag_end_1){
			speed_tmp=0;
		}
		
}*/

//linia 2
	bool start_line2=(vec1.x<2.5);
	bool end_line2=(vec1.x>4.1);
	if(line_number==2){
		if (start_line2 && flag_start_2){
			speed_tmp=0;
		}
		else if (end_line2 && flag_end_2){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 3
	bool start_line3=(vec1.x<3.1);
	bool end_line3=(vec1.x>6.2);
	if(line_number==3){
		if (start_line3 && flag_start_3){
			speed_tmp=0;
		}
		else if (end_line3 && flag_end_3){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 5
	bool start_line5=(vec1.x<3.1);
	bool end_line5=(vec1.x>7.95);
	if(line_number==5){
		if (start_line5 && flag_start_5){
			speed_tmp=0;
		}
		else if (end_line5 && flag_end_5){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 9
	bool start_line9=(vec1.x<5.35 && vec1.y>8.15);
	bool end_line9=(vec1.x>6.2 && vec1.y<3.7);
	if(line_number==9){
		if (start_line9 && flag_start_9){
			speed_tmp=0;
		}
		else if (end_line9 && flag_end_9){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 10
	bool start_line10=(vec1.x<3.15);
	bool end_line10=(vec1.x>9.7);
	if(line_number==10){
		if (start_line10 && flag_start_10){
			speed_tmp=0;
		}
		else if (end_line10 && flag_end_10){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 11
	bool start_line11=(vec1.x<1.35);
	bool end_line11=(vec1.x>5.75);
	if(line_number==11){
		if (start_line11 && flag_start_11){
			speed_tmp=0;
		}
		else if (end_line11 && flag_end_11){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 14
	bool start_line14=(vec1.x<2.05);
	bool end_line14=(vec1.x<5.35 && vec1.y>8.1);
	if(line_number==14){
		if (start_line14 && flag_start_14){
			speed_tmp=0;
		}
		else if (end_line14 && flag_end_14){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 16
	bool start_line16=(vec1.x<5.35);
	bool end_line16=(vec1.x>8.05);
	if(line_number==16){
		if (start_line16 && flag_start_16){
			speed_tmp=0;
		}
		else if (end_line16 && flag_end_16){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 18
	bool start_line18=(vec1.y<4.05);
	bool end_line18=(vec1.y>8.0);
	if(line_number==18){
		if (start_line18 && flag_start_18){
			speed_tmp=0;
		}
		else if (end_line18 && flag_end_18){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}

//linia 19
	bool start_line19=(vec1.y>7.25);
	bool end_line19=(vec1.y<3.75);
	if(line_number==19){
		if (start_line19 && flag_start_19){
			speed_tmp=0;
		}
		else if (end_line19 && flag_end_19){
			speed_tmp=0;
		}
		else {
			speed_tmp=speed;
		}
}



	



	dst += speed_tmp * Time.deltaTime *time_acc;
     	transform.position = pc.path.GetPointAtDistance(dst);

 }
	public void Slideer(float costam){
		Time.timeScale=costam;
	}
}