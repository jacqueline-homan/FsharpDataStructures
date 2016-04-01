open System
open System.IO
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



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

