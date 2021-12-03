open System.IO


let parseLine (s: string) = Seq.toArray s

let initBalances (lines: seq<char []>) = Array.zeroCreate (Array.length (Seq.head lines))

let computeBalance _ (balance: int) (c: char) = 
    match c with 
    | '0' -> balance - 1
    | '1' -> balance + 1
let computeBalances = Array.mapi2 computeBalance
let convertToMostCommonBit (balance: int) = if balance >= 0 then '1' else '0'
let convertToMostCommonBits = Array.map convertToMostCommonBit

let convertToInt (s: char[]) = System.Convert.ToInt32(s |> System.String, 2)
let mirror = Array.map (fun (x: char) -> if x = '1' then '0' else '1')
let computeResult (mostCommonBytes: char[]) = (convertToInt mostCommonBytes) * (convertToInt (mirror mostCommonBytes))

Path.Combine(".", "input")
|> File.ReadAllLines 
|> Seq.map parseLine
|> (fun lines -> Seq.fold computeBalances (initBalances lines) lines)
|> convertToMostCommonBits
|> computeResult
|> printfn "%d" 
