module App
open System
open System.Drawing
open System.Windows.Forms
open LifeForms

type Canvas(width : int, height : int, multiplier : int) = 
    inherit PictureBox(Width = width, Height = height)
    member this.Draw cells =
        use gfx = this.CreateGraphics()
        use pen = new Pen(Color.Black, 1.0 |> float32)
        cells |> List.iter (fun cell -> this.Draw(gfx, pen, cell))

    member this.Draw(g, pen, cell) = 
        let x, y = (multiplier * fst cell), (multiplier * snd cell)
        
        // draw rectangle
        g.DrawRectangle(pen, x, y, multiplier, multiplier)        

type Window (width : int, height : int, text : string) =
    inherit Form(Width = width, Height = height, Text = text, Visible = true)

    member this.Add control : Window = 
        base.Controls.Add(control)
        this

let window = 
    let canvas = new Canvas(400, 400, 10)
    let window = (new Window(400, 400, "Game of Life")).Add(canvas)
    
    let tick = async {
            let board = ref ((blinker (5, 30)) @ (toad (12, 30)) @ (beacon (20, 30)) @ (pulsar (25, 12)) @ (glider (10, 10)) @ (lwss (1, 1)))
            while true do
                board := GameOfLife.Run.next(!board)
                canvas.Invoke(new MethodInvoker(fun () ->
                        canvas.Refresh()
                        canvas.Draw(!board)
                    )) |> ignore
                do! Async.Sleep(500)
        }

    Async.StartAsTask(tick) |> ignore
    window


[<EntryPoint>]
let main argv = 
    Application.Run(window);
    0 // return an integer exit code
