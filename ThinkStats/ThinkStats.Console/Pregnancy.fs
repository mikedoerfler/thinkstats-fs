module Pregnancies

open System

type Pregnancy = {
    CaseId : int;
    PrgLength : int;
    Outcome : int;
    BirthOrder: int option;
    FinalWeight : float
}

let isLiveBirth preg = 
    match preg.BirthOrder with
    | Some x -> true
    | None -> false

let parseNullableInt text =
    match Int32.TryParse text with
    | (true, result) -> Some result
    | (false, _) -> None

let parsePregnancy (line:string) =
    { 
        CaseId = Int32.Parse(line.Substring(0, 12));
        PrgLength = Int32.Parse(line.Substring(274, 2));
        Outcome = Int32.Parse(line.Substring(276, 1));
        BirthOrder = parseNullableInt(line.Substring(277, 2));
        FinalWeight = Double.Parse(line.Substring(422, 17));
    }

