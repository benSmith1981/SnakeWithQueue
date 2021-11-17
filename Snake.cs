using System;
using System.Threading;
class Snake {
  public bool alive = true;
  static int width = 10;
  static int height = 10;

  int [] food = new int[2];
  int[] direction = new int[2];
  string[,] grid = new string[width, height];
  Queue snakeQ;
  public Snake() {
    snakeQ = new Queue();
    snakeQ.add(new int[]{4,1});
    snakeQ.add(new int[]{4,2});
    snakeQ.add(new int[]{4,3});
    snakeQ.add(new int[]{4,4});
    placeFood();
  }

  public void placeFood() {
    Random rnd = new Random();
    food[0] = rnd.Next(0, 9);
    food[1] = rnd.Next(0, 9);
  }
  public void draw() {
    //Using 2 nested for loops, looping around the grid 2d array, draw a grid...use Console.WriteLine to draw a character ontot the screen
    grid = new string[10,10];


    Queue.Node head = snakeQ.head; //get the head of the snake

    //This code is traversing the queue by following the next node, until we get to the back of the queue where the next node is null
    //For each node, we get the data (the 2d Point) then we use this to place our snake body at that point on the 2D grid array
    do{
      int[] data = head.data;
      grid[data[0],data[1]] = "🐸 ";
      head = head.next;
    }while(head != null);

    grid[food[0], food[1]] = "🍎 ";

    //This is drawing the grid onto the screen...
    for(int i = 0 ; i < 10; i++){
      for(int j = 0; j < 10; j++){
        if(grid[i,j] == null) {
          //if the grid array is empty, draw the grid
          Console.Write(" | ");
        } else {
          //if it contains something it is the snake body, so draw the grid
          Console.Write(grid[i,j]);
        }
        
      }
      Console.WriteLine();
    }
    
  }

  public void logic(char key){

    int[] snakeHead = snakeQ.tail.data;
    //this is a switch statement that does something different for each controller key
    switch(key) {
      case 'w':
        direction[0] = -1; //this is x
        direction[1] = 0; // this is y
        break;
      case 's':
        direction[0] = 1;
        direction[1] = 0;
        break;
      case 'a':
        direction[0] = 0;
        direction[1] = -1;
        break;
      case 'd':
        direction[0] = 0;
        direction[1] = 1;
        break;
    }

    if(snakeHead[0] + direction[0] < 0){
      snakeHead[0] = 9;
    } else if (snakeHead[0] + direction[0] > 9){
      snakeHead[0] = 0;
    } else if(snakeHead[1] + direction[1] < 0){
      snakeHead[1] = 9;
    } else if (snakeHead[1] + direction[1] > 9){
      snakeHead[1] = 0;
    }

    int[] newHeadPosition = new int[]{snakeHead[0] + direction[0],snakeHead[1]+direction[1]};

    snakeQ.add(newHeadPosition);

    if(newHeadPosition[0] == food[0] && newHeadPosition[1] == food[1]){
      placeFood();
    } else {
      snakeQ.remove();
    }
    
    
    Console.WriteLine(newHeadPosition[0]+" "+ newHeadPosition[1]);

  }
}