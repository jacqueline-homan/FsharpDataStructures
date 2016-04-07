open System
open System.IO
open System.Collections.Generic
open System.Net
open Data.Library1
open Data.Types


let myAccount =
    {
        Number = "12345678"
        Name = "Unemployed Female Developer"
        Balance = 350.22
    }
// %g print format best suited for currency
printfn "Hello, %s. Your balance is: %g" myAccount.Name myAccount.Balance

printfn ""
printfn "Creating arrays using a literal:"
let someEvens = [| for i in 1..20 do
                            if i % 2 = 0 then yield i|]
printfn""
printfn "%A" someEvens
printfn""
printfn "The third element in the array is: %A" someEvens.[3]
someEvens.[3] <- 42
printfn "Now the third element in the array is: %A" someEvens.[3]

let lastDays year = 
    [|
        for i in 1..12 do
            let firstDay = DateTime(year, i, 1)
            let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, i)-1))
            yield lastDay.Date
    |]
printfn ""
printfn "Last days of 2015: %A" (lastDays 2015)
printfn""
let lastDaysExcelBug year =
    [| for i in 1..12 do
        let firstDay = DateTime(year, i, 1)
        let dayCount = float(DateTime.DaysInMonth(year, i))
        let lastDay = firstDay.AddDays(dayCount-1.)
        let lastDayExcel =
            if firstDay = DateTime(1900, 2, 1) then
                29
            else
                lastDay.Day
        yield lastDayExcel
   |]
printfn "Excel Leap Year example: %A" (lastDaysExcelBug 1900)

printfn ""
printfn "Creating the last days array using Array.init:"
let lastDays2 year = Array.init 12(fun i ->
    let month = i + 1
    let firstDay = DateTime(year, month, 1)
    let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, month)-1))
    lastDay)
printfn "%A"(lastDays2 2015)

printfn ""
printfn "Creating an array from IEnumerable that shows the files"
printfn "in a given directory using Array.ofSeq:"
printfn""
let files = Directory.EnumerateFiles(@"/home/jacque/Screencaps/F# Code Challenges")
            |> Array.ofSeq 
            |> Array.iter(printfn "%s")


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

// Doing the same thing but with a List
let muppets =
    ["Cookie Monster"; "Kermit"; "Oscar the Grouch"]
printfn "%A" muppets

muppets
    |> List.map( fun x ->
        match x with
        | "Oscar the Grouch" -> "President Muppet, Donald Trump"
        | _ -> x)
    |> List.iter(printfn " %s")

let numbers = [|1..10|]
let cubes =
    numbers
    |> Array.map(fun x -> x * x * x)
    |> Array.iter(printfn "%i")

let hotdogs = [|"beef";"pork";"chicken"; "turkey"; "vegetarian"|]
let capitalizeHotdogs =
    hotdogs
    |> Array.map(fun hotdog -> hotdog.ToUpper())
    |> Array.iter(printfn "%s")

let initCap str =
    if String.IsNullOrEmpty str then
        str
    else 
        str.[0].ToString().ToUpperInvariant() + str.[1..]

let initCapHotdogs =
    hotdogs
    |> Array.map(fun hotdog -> initCap hotdog)
    |> Array.iter(printfn "%s")

//Using Array.mapi to find the consonants
let findConsonants (s:string) =
    let consonants = "bcdfghjklmn"
    s.ToCharArray()
    |> Array.mapi(fun x y -> if consonants.Contains(y.ToString()) then
                                sprintf "Consonant at position: %i %c" x y
                             else 
                                "Something else")


let findConsonants2 (s:string) =
    let consonants = "bcdfghjklmn"
    s.ToCharArray()
    |> Array.iteri(fun x y -> if consonants.Contains(y.ToString()) then
                                printfn "Consonant at position: %i %c" x y)


printfn ""                                   
//Demonstrating Array.filter
let lastDayOfMonth year =
    [|
        for i in 1..12 do
            let firstDay = DateTime(year, i, 1)
            let dayCount = float(DateTime.DaysInMonth(year, i))
            let lastDay = firstDay.AddDays(dayCount-1.)
            yield lastDay
     |]
let isWeekend (day:DateTime) =
    day.DayOfWeek = DayOfWeek.Saturday || day.DayOfWeek = DayOfWeek.Sunday

let bigRedButtonDays year =
    lastDayOfMonth year
    |> Array.filter(fun d -> isWeekend d)
printfn "Big Red Button days: %A" (bigRedButtonDays 2016)


//Option data types: Where some results may fail
let getRequests() =
    let requests =
        [|
            "https://github.com"
            "https://pluralsight.com"
            "htto://99.99.99.99/doesntexist"
        |]
    use wc = new WebClient()


[<EntryPoint>]
let main argv = 
    printfn ""
    printfn "Hope you've enjoyed F# lessons" 
    0 // return an integer exit code

