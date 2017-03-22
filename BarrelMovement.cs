using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BarrelMovement : MonoBehaviour {

	public int[] availableChoice = new  int[16];
	public int randomizer;  //A random int to randomly choose next position
	public string barrelType; //Either "left" or "right"


	NavMeshAgent agent; //The navmesh agent


	public ArrayLayout barrelCheckpoints; //2-D array showing in inspector you can get its values by typing {ArrayLayoutName}.row[x].column[y]
	public List<ArrayPosition> futureDestination = new List<ArrayPosition>(); //List of potential next destinations for the barrel
	
	//Struct gathering x,y and the transform of each checkpoint of a barrel
	public struct ArrayPosition{
		[SerializeField]
		public 	int x;
		public int y;
		public Transform checkpointTransform;
		public ArrayPosition(int r, int c, ArrayLayout barrelCP){
			this.x = r;
			this.y = c;
			this.checkpointTransform = barrelCP.rows[r].column[c].transform;
		}

	}

	public ArrayPosition previousBarrelCoord;
	public ArrayPosition destBarrelCoord;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>(); 

		agent.autoBraking = false;
		if (barrelType == "left"){ //TODO:  Right now barrel is set on right by inspector make it change depending on place respawning
			previousBarrelCoord = new ArrayPosition(0,0, barrelCheckpoints);
			destBarrelCoord = new ArrayPosition(1,0 , barrelCheckpoints);
			agent.destination = destBarrelCoord.checkpointTransform.position;
		}
		else{
			previousBarrelCoord = new ArrayPosition(0,3 , barrelCheckpoints);
			destBarrelCoord = new ArrayPosition(1,3 , barrelCheckpoints);
			agent.destination = destBarrelCoord.checkpointTransform.position;
		}

		
	}
	
	void FirstAppearence(){
		//TODO: When the barrel first appears occasion

	}
	// Update is called once per frame
	void Update () {
		
		//Update destination when agent goes near to the checkpoint
		if(agent.remainingDistance < 0.15f){
			ChooseNewPoint(previousBarrelCoord , destBarrelCoord);
			previousBarrelCoord = destBarrelCoord; 
			destBarrelCoord = futureDestination[Random.Range(0,futureDestination.Count)];
			agent.destination = destBarrelCoord.checkpointTransform.position;  //Set new destination
		}
		
	}

	//Choose a new destination excluding the previous one
	void ChooseNewPoint(ArrayPosition previousBarrelPos , ArrayPosition currentBarrelPos){
		futureDestination.Clear(); //Empty destination list every time it goes to a new location
		AddChoicesToList(currentBarrelPos , previousBarrelPos); //Add available choices tot destination list based on current point

	}

	void AddChoicesToList(ArrayPosition pos , ArrayPosition posBefore){
		int x = pos.x;
		int y = pos.y;
		ArrayPosition arrPosToRemove = new ArrayPosition();
		if(x+1<=3){
			futureDestination.Add(new ArrayPosition(x+1 , y , barrelCheckpoints));
		}
		if(x-1>=0){
			futureDestination.Add(new ArrayPosition(x-1 , y , barrelCheckpoints));
		}
		if(y+1<=3){
			futureDestination.Add(new ArrayPosition(x , y+1 , barrelCheckpoints));
		}
		if(y-1>=0){
			futureDestination.Add(new ArrayPosition(x , y-1 , barrelCheckpoints));
		}
		foreach (ArrayPosition posit in futureDestination){
			if (posit.x == posBefore.x && posit.y == posBefore.y){
				arrPosToRemove = posit;
			}
		}
		futureDestination.Remove(arrPosToRemove);//Remove the previousdestination from potential places to go to
	}


}
