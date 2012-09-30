module Pregnancies

open System

type Pregnancy = {
    CaseId : string;
    BabySex : string;
    BirthWeightPounds: string;
    BirthWeightOunces : string;
    PrgLength : int;
    Outcome : string;
    BirthOrder: int option;
    AgePregnancy : string;
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

    (*
            ('caseid', 1, 12, int),
            ('nbrnaliv', 22, 22, int),
            ('babysex', 56, 56, int),
            ('birthwgt_lb', 57, 58, int),
            ('birthwgt_oz', 59, 60, int),
            ('prglength', 275, 276, int),
            ('outcome', 277, 277, int),
            ('birthord', 278, 279, int),
            ('agepreg', 284, 287, int),
            ('finalwgt', 423, 440, float),
    *)
let parsePregnancy (line:string) =
    { 
        CaseId = line.Substring(0, 12);
        BabySex = line.Substring(55,1);
        BirthWeightPounds = line.Substring(57,2);
        BirthWeightOunces = line.Substring(58,2);
        PrgLength = Int32.Parse(line.Substring(274, 2));
        Outcome = line.Substring(276, 1);
        BirthOrder = parseNullableInt(line.Substring(277, 2));
        AgePregnancy = line.Substring(283, 3);
        FinalWeight = Double.Parse(line.Substring(422, 17));
    }

