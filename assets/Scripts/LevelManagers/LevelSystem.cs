using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour{

    // Dictionary<string, MapPath> paths = new Dictionary<string, MapPath>(); 
    // MapPath originPath = new MapPath("origin", 1, new string[] {"temp"});


    //On init,
    //Open JSON
    //take first path and load into paths
    //Add levels into the path


    MapNode origin;
    MapNode secondLevel;
    MapNode thirdLevel; 
    
    private void OnEnable(){
        origin = new MapNode(LevelType.StaticLevel, IconType.Planet, Completion.Avaialble);
        secondLevel = new MapNode(LevelType.SideScrolling, IconType.Dot, Completion.Avaialble);
        thirdLevel = new MapNode(LevelType.CutScene, IconType.Dot, Completion.Avaialble);

        origin.nxtLevelOne = secondLevel;
        secondLevel.nxtLevelOne = thirdLevel;
    }


    public class MapNode{
            LevelType levelType = LevelType.StaticLevel;
            IconType iconType = IconType.Dot;
            Completion completion = Completion.Avaialble;

            Rank rank;

            public MapNode nxtLevelOne;
            public MapNode nxtLevelTwo;

            public string enemies = "A";

            public MapNode(LevelType levelType, IconType iconType, Completion completion){
                this.levelType = levelType;
                this.iconType = iconType;
                this.completion = completion;

            }



        }

    //Pass in the JSON
    private class MapPath{
        string pathName = "";
        string[] nextPathsName;
        MapNode[] nodes;


        public MapPath(string name, int levels, string[] nextPaths){
            
            nodes = new MapNode[levels];




        }

        



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

public enum Rank{
    X = -1,
    D = 0,
    C = 1,
    B = 2,
    A = 3,
    S = 4

}

