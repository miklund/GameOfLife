namespace GameOfLife

module Run =
    // get an area as a tuple array
    // area [-1..1] [-1..1] = [(-1, -1); (-1, 0); (-1, 1); (0, -1); (0, 0); (0, 1); (1, -1); (1, 0); (1, 1)]
    let private area xs ys = xs |> List.collect (fun x -> ys |> List.map (fun y -> x, y))

    // get all neighbour coordinates surrounding a cell
    // neighbours (0, 0) = [(-1, -1); (-1, 0); (-1, 1); (0, -1); (0, 1); (1, -1); (1, 0); (1, 1)]
    let private neighbours cell = 
        let x, y = cell
        // get area around cell
        area [x - 1..x + 1] [y - 1..y + 1] 
        // remove the cell itself
        |> List.filter ((<>) cell)

    // intersection
    // neighbours (0, 0) |> live [0, 0; 0, 1; 1, 0] = [0, 1; 1, 0]
    let private live cells = List.filter (fun cell -> cells |> List.exists ((=) cell))

    // difference
    // neighbours (0, 0) |> dead [0, 0; 0, 1; 1, 0] = [-1, -1; -1, 0; -1, 1; 0, -1; 1, -1; 1, 1]
    let private dead cells = List.filter (fun cell -> not (cells |>  List.exists ((=) cell)))

    // run next iteration of the game
    let next cells =

        // kill or preserve live cells
        let rec weed = function
        | [] -> []
        // 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        | hd :: tl when (neighbours hd |> live cells).Length < 2 -> weed tl
        // 2. Any live cell with two or three live neighbours lives on to the next generation.
        | hd :: tl when (neighbours hd |> live cells).Length < 4 -> hd :: weed tl
        // 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
        | hd :: tl -> weed tl

        // grow new cells where number of live neighbours is 3
        let rec grow = function
        | [] -> []
        // 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        | hd :: tl when (neighbours hd |> live cells).Length = 3 -> hd :: grow tl
        // else recurse
        | hd :: tl -> grow tl

        // get all dead cells surrounding live cells
        let dead cells = List.collect (neighbours >> dead cells) cells |> Set.ofList |> Set.toList

        // grow cells from dead cells, and join with weeding out live cells
        grow (dead cells) @ (weed cells)