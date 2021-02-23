namespace FsWpfINotifyPropertyChanged

open System.Windows
open FsWpfINotifyPropertyChanged.ViewModels

module MainWindow =
  let initialize (window: Window) =
    // binding viewmodel
    window.DataContext <- MainWindowViewModel()
    ()
