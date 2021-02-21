namespace FsWpfApplication

open System.Windows
open FsWpfApplication.ViewModels

module MainWindow =
  let initialize (window: Window) =
    // binding viewmodel
    window.DataContext <- MainWindowViewModel()
    ()
