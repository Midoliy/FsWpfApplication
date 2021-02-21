namespace FsWpfApplication.ViewModels

open System.Threading.Tasks
open Epoxy
open Epoxy.Supplemental

type MainWindowViewModel() as this =
  inherit ViewModel()

  do
    this.Title <- "Sample Title"
    this.Change <- Command.Factory.Create(fun () -> 
      Task.Run(fun () -> 
        this.Title <- "Changed Title!!"
      ))

  member __.Title
    with get () = __.GetValue<string>() 
    and set (title) = __.SetValue<string>(title)

  member __.Change
    with get () = __.GetValue<Command>() 
    and set (command) = __.SetValue<Command>(command)
