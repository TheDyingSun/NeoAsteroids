using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour{

    Dictionary<string, MapPath> paths = new Dictionary<string, MapPath>(); 
    MapPath originPath = new MapPath("origin", 1, new string[] {"temp"});

    //On init,
    //Open JSON
    //take first path and load into paths
    //Add levels into the path

    //Pass in the JSON
    private class MapPath{
        string pathName = "";
        string[] nextPathsName;
        MapNode[] nodes;


        public MapPath(string name, int levels, string[] nextPaths){
            
            nodes = new MapNode[levels];



        }

        public class MapNode{
            LevelType levelType = LevelType.StaticLevel;
            IconType iconType = IconType.Dot;
            Completion completion = Completion.Avaialble;

            string enemies = "A";

            public MapNode(LevelType levelType, IconType iconType, Completion completion){
                this.levelType = levelType;
                this.iconType = iconType;
                this.completion = completion;

            }



        }



    }
    
    private void OnEnable(){
        //Bring Data into local variables.
        //Load data


    }


    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}


public enum LevelType{
    StaticLevel = 0,
    SideScrolling = 1,
    CutScene = 2

}

public enum IconType{
    None = 0,
    Planet = 1,
    Dot = 2


}

public enum Completion{
    Unavailable = -1,
    Avaialble = 0,
    Complete = 1


}

