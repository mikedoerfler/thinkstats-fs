open System
open System.IO

let ex1_3 = 
    let text = File.ReadAllLines("2002FemPreg.dat")
    let content = Array.map Pregnancies.parsePregnancy text 

    // #1
    printfn "%d pregnancies" content.Length

    // #2
    let liveBirthCount = 
        content
        |> Array.filter Pregnancies.isLiveBirth 
        |> Array.length

    printfn "%d live births " liveBirthCount


    0

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    // return an integer exit code
    ex1_3
