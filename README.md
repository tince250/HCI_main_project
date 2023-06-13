# Tripago - Travel Agency information system WPF app
The main project for subject "Human-Computer Interaction" 

``Team 20``
<br />
<br />
Tripago is an app dedicated to two types of users:
- travel agents
- travelers - users interested in booking and browsing tours

There are four entity types that the app handles:
- tours
- attractions
- accommodation
- restaurants

Travel agent has CRUD athorization for each type, while the traveler can view the information provided by the travel agents and book/reserve tours.

The ``focus`` of the project is building an app with excellent ``UI and UX``, for the specific needs of a shortsighted granny travel agent who presents the app via a wall projector :)

## Technology stack
- WPF
- MVVM
- SQLite database
- Material Design
- HTML + CSS - for online Help documentation

## Team members
- Tina Mihajlovic
- Srdjan Stjepanovic
- Nemanja Vujadinovic

## Running the project
To run the project:
- clone git repo
- open HCI_main_project.sln file using VisualStudio with .NET 6.0 support
- run the app

The app uses an *in-memory* SQLite database, so you won't have any data at the start. Feel free to run the **data.sql** script and input some baseline data in the database to get you going. You can do this using any DB manager supporting SQLite (e.g. DBeaver).

``Important:``
- to create a "traveler" account, simply register using the registration form
- to create a "travel agent" account, you have to insert the entity directly into the database, as agents can't register by themselves (contact team members to help you if needed)
