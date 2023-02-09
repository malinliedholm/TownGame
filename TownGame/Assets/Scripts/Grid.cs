using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int numRows;
    private int numColumns;
    private float cellSize;
    private Vector3 bmin;
    private Vector3 bmax;
    private int[] gridArray;

    public int NumRows {
        get { return numRows; }
    }
    public int NumColumns {
        get { return numColumns; }
    }

    public Grid(int numRows, int numColumns, Vector3 bmin, float cellsize = 1f) {
        this.numRows = numRows;
        this.numColumns = numColumns;
        this.cellSize = cellsize;

        this.bmin = bmin;
        bmax = new Vector3(bmin.x + (numColumns * cellsize), bmin.y + (numRows * cellsize), bmin.z);

        gridArray = new int[numRows*numColumns];
        foreach (int i in gridArray) { 
            gridArray[i] = 0;
        }

        Debug.Log("Empty grid created with number of rows: " + numRows + ", and number of columns: " + numColumns);
    }

    public Vector3 GetWorldPositionFromIndex(int x, int y) {
        Vector3 worldPosition = new Vector3(bmin.x + (cellSize/2) + (x * cellSize), bmin.y + (cellSize/2) + (y * cellSize));
        return worldPosition;
    }

    public Vector3 WorldPosToGridPos(Vector3 worldPos) {
        Debug.Log(bmin);
        Debug.Log(bmax);
        Debug.Log(worldPos);

        if(worldPos.x < bmax.x && worldPos.y < bmax.y && worldPos.x > bmin.x && worldPos.y > bmin.y) {
            Debug.Log("Inside grid");
            int xIndex = (int)Mathf.Floor((worldPos.x - bmin.x) / cellSize);
            int yIndex = (int)Mathf.Floor((worldPos.y - bmin.y) / cellSize);

            Vector3 newPos = GetWorldPositionFromIndex(xIndex, yIndex);
            return newPos;
        }

        return Vector3.zero;
    }

    public bool FillGridCell(int x, int y){
        if(x >= 0 && y >= 0 && x < NumColumns && y < numRows) {
            int index = y + x * numRows;
            if(gridArray[index] == 0) { 
                gridArray[index] = 1;
                return true;
            }
            else {
                return false;
            }
        }

        return false;
    }
}
