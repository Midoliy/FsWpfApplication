open System
open System.Windows
open FsWpfApplication

[<STAThread>]
[<EntryPoint>]
let main(_) =
  let application = 
    Application.LoadComponent(Uri("App.xaml", UriKind.Relative)) 
    :?> Application

  application.Activated
  |> Event.add (fun _ -> MainWindow.initialize application.MainWindow)

  application.Run()
