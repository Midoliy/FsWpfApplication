namespace FsWpfINotifyPropertyChanged.ViewModels

open System.ComponentModel
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

[<AbstractClass>]
type ViewModelBase() =
  let propertyChanged = Event<_, _>()
  
  interface INotifyPropertyChanged with
    [<CLIEvent>]
    member __.PropertyChanged = propertyChanged.Publish

  member __.OnPropertyChanged([<CallerMemberName; Optional; DefaultParameterValue("")>] memberName: string) =
    if not(System.String.IsNullOrEmpty(memberName)) then
      propertyChanged.Trigger(__, PropertyChangedEventArgs(memberName))
    
  

type MainWindowViewModel () = 
  inherit ViewModelBase()
  let mutable title = "Test title"
  let mutable number = 500

  member __.Title
    with get() = title
    and set(title') = title <- title'; __.OnPropertyChanged()
        
  member __.Number
    with get() = number
    and set(number') = number <- number'; __.OnPropertyChanged()