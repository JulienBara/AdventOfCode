open System.IO

type Command = 
    { Direction : string
      Unit      : int }

type Position = 
    { Horizontal : int
      Depth      : int }

let initialPosition = {
  Horizontal = 0
  Depth = 0
}

let parseLine (line: string)  = 
  match line.Split(' ') with
    | [| direction; unit; |] -> 
      { 
        Direction = direction
        Unit = unit |> int
      }

let applyCommand (position: Position) (command: Command) = 
  match command with 
  | { Direction = "forward" } -> {  
      Horizontal = position.Horizontal + command.Unit
      Depth = position.Depth
    }
  | { Direction = "down" } -> {  
      Horizontal = position.Horizontal
      Depth = position.Depth + command.Unit
    }
  | { Direction = "up" } -> {  
      Horizontal = position.Horizontal
      Depth = position.Depth - command.Unit
    }

let printResult (position: Position) = printfn "%d" (position.Horizontal * position.Depth)


Path.Combine(".", "input")
|> File.ReadAllLines 
|> Seq.map parseLine
|> Seq.fold applyCommand initialPosition
|> printResult
