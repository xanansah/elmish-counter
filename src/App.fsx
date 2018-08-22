#r "../node_modules/fable-core/Fable.Core.dll"
#r "../node_modules/fable-react/Fable.React.dll"
#r "../node_modules/fable-elmish/Fable.Elmish.dll"
#r "../node_modules/fable-elmish-react/Fable.Elmish.React.dll"

open Fable.Core
open Fable.Import
open Elmish

// model

type Msg =
| Increment
| Decrement

let initialModel () = 0

// update

let update (msg:Msg) model =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

// rendering view with React

module R = Fable.Helpers.React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props

let view model dispatch =
    let onClick msg =
        OnClick <| fun _ -> msg |> dispatch

    R.div []
        [ R.button [ onClick Decrement ] [ unbox "-" ]
          R.div [] [ unbox (string model) ]
          R.button [ onClick Increment ] [ unbox "+" ]
        ]

open Elmish.React

// app

Program.mkSimple initialModel update view
|> Program.withConsoleTrace
|> Program.withReact "app"
|> Program.run
