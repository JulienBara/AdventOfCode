open System.IO

let aggregate accu [| x1; x2; |] = if x1 > x2 then accu else accu + 1

Path.Combine(".", "input")
|> File.ReadAllLines 
|> Seq.map (fun line -> line |> int)
|> Seq.map (fun n -> [| n; n |])
|> Seq.concat
|> Seq.skip 1
|> Seq.rev
|> Seq.skip 1
|> Seq.rev
|> Seq.chunkBySize 2
|> Seq.fold aggregate 0
|> printfn "%A"
