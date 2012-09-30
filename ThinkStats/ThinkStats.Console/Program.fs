open System
open System.IO

let ex1_3 = 
    let content = 
        File.ReadLines("2002FemPreg.dat")
        |> Seq.map Pregnancies.parsePregnancy
        |> Seq.toArray

    // #1
    printfn "%d pregnancies" content.Length

    // #2
    let liveBirths = 
        content
        |> Array.filter Pregnancies.isLiveBirth 

    let liveBirthCount = 
        liveBirths
        |> Array.length

    printfn "%d live births " liveBirthCount

    // #3
    let firstBorn = 
        liveBirths
        |> Array.filter (fun (x) -> x.BirthOrder.Value = 1)

    let notFirstBorn = 
        liveBirths
        |> Array.filter (fun (x) -> x.BirthOrder.Value <> 1)

    printfn "number of live births for the first born: %d" firstBorn.Length
    printfn "number of live births for the other born: %d" notFirstBorn.Length

    // #4
    let firstBornWeeksAvg = 
        firstBorn
        |> Array.averageBy (fun (x) -> (float)x.PrgLength)

    let notFirstBornWeeksAvg = 
        notFirstBorn
        |> Array.averageBy (fun (x) -> (float)x.PrgLength)

    printfn "average weeks of pregancy for the first born: %f" firstBornWeeksAvg
    printfn "average weeks of pregancy for the not first born: %f" notFirstBornWeeksAvg

    let diffInDays = (firstBornWeeksAvg - notFirstBornWeeksAvg) * 7.0
    let diffInHours = (diffInDays) * 24.0

    printfn "diff in days: %f" diffInDays
    printfn "diff in hours: %f" diffInHours


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    // return an integer exit code
    ex1_3
    0
