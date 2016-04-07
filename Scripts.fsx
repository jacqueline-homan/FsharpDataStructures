// Record types
let myAccount =
    {
        Number = "12345678"
        Name = "Unemployed Female Developer"
        Balance = 350.22
    }
// %g print format best suited for currency
printfn "Hello, %s. Your balance is: %g" myAccount.Name myAccount.Balan

// Array creating
let primes = [|2;3;5;7;11|]

let animals = 
    [|
        "cat"
        "dog"
        "mouse"
    |]

    |> Array.map(fun x -> 
        match x with
        | "dog" -> "bird"
        | _ -> x) 

    |> Array.iter(printfn "%A")

let someNums = [|100.0..120.0..150.0|]

let someEvens = [| for i in 1..20 do
                            if i % 2 = 0 then yield i|]
// %A is the print format for printing arrays
printfn "%A" someEvens

let lastDays year = 
    [|
        for i in 1..12 do
            let firstDay = DateTime(year, i, 1)
            let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, i)-1))
            yield lastDay.Date
    |]
lastDays 2015 //looks butt-ugly

// Demonstrating how Array.create is not very useful
let notUsefulArray = Array.create 10 3.3

// Demonstrating how Array.zeroCreate isn't useful either:
let buttUglyArray : string[] = Array.zeroCreate 10

let lastDays2 year = Array.init 12(fun i ->
    let month = i + 1
    let firstDay = DateTime(year, i, 1)
    let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, i)-1))
    lastDay)
lastDays2 2015

(* Creating an array from any other array or IEnumerable
 using Array.ofSeq. Here we create an array from IEnumerable
to return the files of a given directory
*)
let files = System.IO.Directory.EnumerateFiles(@"/home/jacque/Documents")
            |> Array.ofSeq
            //To print out to the screen:
            |> Array.iter(printfn "%s")