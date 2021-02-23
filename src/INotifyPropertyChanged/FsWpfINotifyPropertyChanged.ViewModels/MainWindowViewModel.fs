namespace FsWpfINotifyPropertyChanged.ViewModels

open System.ComponentModel
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

[<AbstractClass>]
type ViewModelBase() =
  let propertyChanged = Event<_, _>()
  
  interface INotifyPropertyChanged with
    [<CLIEvent>]
    member __.PropertyChanged = propertyChanged.Publish
    
  // NotifyPropertyChanged発火用のsetメソッド
  member __.SetValue<'T> (field: 'T byref, value: 'T,  name) =
    if obj.Equals(field, value) then
      false
    else
      field <- value
      propertyChanged.Trigger(__, PropertyChangedEventArgs(name))
      true

type MainWindowViewModel () = 
  inherit ViewModelBase()
  let mutable title = "Test title"
  let mutable number = 500

  member __.Title
    with get() = title
    and set(v) = __.SetValue(&title, v, nameof(__.Title)) |> ignore
        
  member __.Number
    with get() = number
    and set(v) = __.SetValue(&number, v, nameof(__.Number)) |> ignore