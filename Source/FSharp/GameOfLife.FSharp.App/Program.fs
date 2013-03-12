module App
open System
open System.Drawing
open System.Windows.Forms
open LifeForms
open GameOfLife.CSharp

// a canvas on which we draw to
type Canvas(width : int, height : int, multiplier : int) = 
    inherit PictureBox(Width = width, Height = height)

    // draw all cells
    member this.Draw cells =
        use gfx = this.CreateGraphics()
        use pen = new Pen(Color.Black, 1.0 |> float32)
        cells |> List.iter (fun cell -> this.Draw(gfx, pen, cell))

    // draw one cell
    member this.Draw(g, pen, cell) = 
        let x, y = (multiplier * fst cell), (multiplier * snd cell)
        
        // draw rectangle
        g.DrawRectangle(pen, x, y, multiplier, multiplier)        

// window
type Window (width : int, height : int, text : string) =
    inherit Form(Width = width, Height = height, Text = text, Visible = true)

    // add a control to this window
    member this.Add control : Window = base.Controls.Add(control); this

// fsharp
let play = GameOfLife.Run.next

// csharp
//let play cells =
//    let game = new Game(cells |> List.map (fun (x, y) -> new Cell(x, y)))
//    game.Next()
//    game.Board |> Seq.map (fun cell -> (cell.X), (cell.Y)) |> List.ofSeq

// create window with canvas and paint on it
let window = 
    let canvas = new Canvas(400, 400, 10)
    let window = (new Window(400, 400, "Game of Life")).Add(canvas)
    
    // async loop
    let tick = async {
            // a board of several famous cell formations
            let board = ref ((blinker (5, 30)) @ (toad (12, 30)) @ (beacon (20, 30)) @ (pulsar (25, 12)) @ (glider (10, 10)) @ (lwss (1, 1)))

            while true do
                // get next board
                board := play(!board)
                // paint board on canvas
                canvas.Invoke(new MethodInvoker(fun () ->
                        canvas.Refresh()
                        canvas.Draw(!board)
                    )) |> ignore
                // wait 500ms before iterating
                do! Async.Sleep(500)
        }

    // start tick as background job
    Async.StartAsTask(tick) |> ignore
    window

[<EntryPoint>]
let main argv = 
    Application.Run(window);
    0 // return an integer exit code
