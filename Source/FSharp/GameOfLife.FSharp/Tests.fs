namespace GameOfLife

module TestHelpers =
    open NHamcrest
    let intersects list = CustomMatcher<obj>(sprintf "Intersect %A" list, fun a -> list |> List.forall (fun item -> (unbox a) |> List.exists ((=) item)))

// 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
namespace ``1 Any live cell with fewer than two live neighbours dies as if caused by under-population``
    open Xunit;
    open FsUnit.Xunit;
    open GameOfLife

    type ``Given a cell with no neighbours`` () =
    
        [<Fact>]
        let ``when turn is run, the cell dies`` () =
            Run.next [0, 0] |> should equal List.empty<int * int>

    type ``Given two cells that are each other neighbours`` () =

        [<Fact>]
        let ``when turn is run, the cells dies`` () =
            Run.next [0, 0; 0, 1] |> should equal List.empty<int * int>

    type ``Given two cells that are not each other neighbours`` () =
    
        [<Fact>]
        let ``when turn is run, the cells dies`` () =
            Run.next [0, 0; 0, 2] |> should equal List.empty<int * int>

    type ``Given three cells where two are neighbours and one alone`` () =
        [<Fact>]
        let ``when turn is run, none lives on`` () =
            Run.next [0, 0; 0, 1; 3, 3] |> should equal List.empty<int * int>

// 2. Any live cell with two or three live neighbours lives on to the next generation.
namespace ``2 Any live cell with two or three live neighbours lives on to the next generation``
    open Xunit;
    open FsUnit.Xunit;
    open GameOfLife
    open TestHelpers

    type ``Given three cells that are each others neighbours`` () =
        let row = [0, 0; 0, 1; 1, 0]

        [<Fact>]
        let ``when turn is run, the cells lives on`` () =
            Run.next row |> should intersects row

    type `` Given four cells in a cluster`` () =
        [<Fact>]
        let ``when turn is run, all lives on`` () =
            let cluster = [0, 0; 0, 1; 1, 0; 1, 1]
            Run.next cluster |> should equal cluster

    type ``Given four cells on a row`` () =
        let row = [0, 0; 1, 0; 2, 0; 3, 0]

        [<Fact>]
        let ``when turn is run, two in the middle lives on`` () =
            Run.next row |> should intersects [1, 0; 2, 0]

// 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
namespace ``3 Any live cell with more than three live neighbours dies as if by overcrowding``
    open Xunit;
    open FsUnit.Xunit;
    open GameOfLife
    open TestHelpers

    type ``Given a 3x3 block of cells`` () =
        let row = Run.area [-1..1] [-1..1]

        [<Fact>]
        let ``when first turn is run, the corners will remain`` () =
            Run.next row |> should intersects [-1, -1; -1, 1; 1, -1; 1, 1]

namespace ``4 Any dead cell with exactly three live neighbours becomes a live cell as if by reproduction``
    open Xunit;
    open FsUnit.Xunit;
    open GameOfLife

    type ``Given a dead cell with three (not neighbours) as neighbours`` () =
        [<Fact>]
        let ``when turn is run, the dead cell becomes live and lonely cells dies`` () =
            Run.next [0, 0; -1, -2; 1, -2] |> should equal [0, -1]     