namespace Data

module Library1 =

    let myTuple = (1, "two") // tuple data type
    let x, y = myTuple  // Decomposing the tuple data type 

    type BankAccount =
        {
            Number: string
            Name: string
            Balance: double
        }


    