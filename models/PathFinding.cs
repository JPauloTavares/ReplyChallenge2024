// public static void ProcessGrid(string[,] matrix, List<Point> goldenPoints, List<Point> silverPoints, List<TileType> availableTiles)
//     {
//         foreach (var goldenPoint in goldenPoints)
//         {
//             // Reset the visited status of all points
//             bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

//             // Initialize the DFS stack with the golden point
//             Stack<Point> stack = new Stack<Point>();
//             stack.Push(goldenPoint);

//             while (stack.Count > 0)
//             {
//                 Point currentPoint = stack.Pop();

//                 // Check if the current point is a silver point
//                 foreach (var silverPoint in silverPoints)
//                 {
//                     if (currentPoint.x == silverPoint.x && currentPoint.y == silverPoint.y)
//                     {
//                         currentPoint.score += silverPoint.score;
//                         break;
//                     }
//                 }

//                 // Update the matrix with the current point and its score
//                 matrix[currentPoint.x, currentPoint.y] = currentPoint.score.ToString();

//                 // Mark the current point as visited
//                 visited[currentPoint.x, currentPoint.y] = true;

//                 // Check adjacent points and add them to the stack if they are valid
//                 foreach (var tile in availableTiles)
//                 {
//                     // Check each direction of the tile
//                     for (int i = 0; i < tile.directionCount; i++)
//                     {
//                         int newX = currentPoint.x;
//                         int newY = currentPoint.y;

//                         // Adjust coordinates based on the tile direction
//                         switch (tile.type)
//                         {
//                             case "3":
//                                 newX -= 1;
//                                 break;
//                             case "5":
//                                 newY += 1;
//                                 break;
//                             case "6":
//                                 newX -= 1;
//                                 newY += 1;
//                                 break;
//                             case "7":
//                                 if (i == 0)
//                                     newX -= 1;
//                                 else if (i == 1)
//                                     newY += 1;
//                                 else if (i == 2)
//                                     newX += 1;
//                                 break;
//                             // Add cases for other tile types
//                             // Adjust coordinates based on the direction
//                         }

//                         // Check if the new coordinates are within the grid bounds and not visited
//                         if (newX >= 0 && newX < matrix.GetLength(0) && newY >= 0 && newY < matrix.GetLength(1) && !visited[newX, newY])
//                         {
//                             // Adjust the score based on the tile
//                             currentPoint.score -= tile.scoreReduction;

//                             // Add the new point to the stack
//                             stack.Push(new Point(newX, newY, currentPoint.score));
//                         }
//                     }
//                 }
//             }
//         }
//     }