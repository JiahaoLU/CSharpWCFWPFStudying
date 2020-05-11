# CSharpWCFWPFStudying
## Caution
* Latest classes overwrites previous contents in ServiceWCF and WPFClientWCF
* Console projects only has partial contents of first classes

## Prerequirements
* Object Oriented and basic programming knowledges
* Generic type
* Delegate and Event
* Interface
* Attribute
* Lambda expression
* Using
* Operator ?.

## ServiceWCF and WPFClientWCF compose a complete Model-View-ViewModel application
*This pattern allows a relatively loose coupling (couplage lâche) among the view design, business logic and data.*
*That's to say, no business code will appear in view design part, vice versa.*
*The view code only knows names of methods and properties provided by view model.*
*To get access to the DB, LINQ is essential for data querying in WCF service and also a clear reference of WCF in WPF project.*

* WPF UI (DataContext, DataBinding)
* Relay Command Light ViewModel (ICommand, INotifyPropertyChanged)
* WCF service(service api, db interface, ObservableCollection<T>, sync and wait, IIS)
* Entity Framework Data Base & Entity Model (LINQ)
