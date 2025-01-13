<Query Kind="FSharpProgram" />

open System

let getGreeting name = sprintf "Hello, %s! Isn't F# great" name

let names = ["Don"; "Julia"; "Xi"]

names
|> List.map getGreeting
|> List.iter (fun greeting -> printfn "%s" greeting)
