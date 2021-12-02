open System.IO

type Command = 
  { Direction: string
    Unit : int }

type Position = 
  { Horizontal: int
    Depth: int
    Aim: int }

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
      Depth = position.Depth + position.Aim * command.Unit
      Aim = position.Aim
    }
  | { Direction = "down" } -> {  
      Horizontal = position.Horizontal
      Depth = position.Depth 
      Aim = position.Aim + command.Unit 
    }
  | { Direction = "up" } -> {  
      Horizontal = position.Horizontal
      Depth = position.Depth 
      Aim = position.Aim - command.Unit 
    }

let initialPosition = {
  Horizontal = 0
  Depth = 0
  Aim = 0
}

let printResult (position: Position) = printfn "%d" (position.Horizontal * position.Depth)


Path.Combine(".", "input")
|> File.ReadAllLines 
|> Seq.map parseLine
|> Seq.fold applyCommand initialPosition
|> printResult
