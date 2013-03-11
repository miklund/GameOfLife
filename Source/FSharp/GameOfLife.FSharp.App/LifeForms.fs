module LifeForms
    let private place position lifeForm = 
        let padx, pady = position
        lifeForm |> List.map (fun (x, y) -> (x + padx), (y + pady))

    // still lifes
    let block position = [0, 0; 1, 0; 1, 1; 0, 1] |> place position
    let beehive position = [0, 0; 1, 1; 2, 1; 3, 0; 2, 1; 1, 1] |> place position
    let loaf position = [1, 0; 2, 0; 3, 1; 3, 2; 2, 3; 1, 2; 0, 1] |> place position
    let boat position = [0, 0; 1, 0; 2, 1; 1, 2; 0, 1] |> place position

    // oscillators
    let blinker position = [0, 0; 1, 0; 2, 0] |> place position
    let toad position = [0, 1; 1, 1; 1, 0; 2, 1; 2, 0; 3, 0] |> place position
    let beacon position = [0, 1; 0, 0; 1, 0; 2, 3; 3, 3; 3, 2] |> place position
    let pulsar position = [2, 0; 3, 0; 4, 0; 8, 0; 9, 0; 10, 0; 0, 2; 5, 2; 7, 2; 12, 2; 0, 3; 5, 3; 7, 3; 12, 3; 0, 4; 5, 4; 7, 4; 12, 4; 2, 5; 3, 5; 4, 5; 8, 5; 9, 5; 10, 5; 2, 7; 3, 7; 4, 7; 8, 7; 9, 7; 10, 7; 0, 8; 5, 8; 7, 8; 12, 8; 0, 9; 5, 9; 7, 9; 12, 9; 0, 10; 5, 10; 7, 10; 12, 10; 2, 12; 3, 12; 4, 12; 8, 12; 9, 12; 10, 12] |> place position

    // spaceships
    let glider position = [0, 2; 1, 2; 1, 0; 2, 2; 2, 1] |> place position
    let lwss position = [0, 2; 0, 0; 1, 3; 2, 3; 3, 3; 3, 0; 4, 3; 4, 2; 4, 1] |> place position
            
