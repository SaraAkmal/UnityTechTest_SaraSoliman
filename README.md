# UnityTechTest
## Requirements
- Unity 2022.3.16f1
- Example is presented in SampleScene
## Written Questions (brief)
1. __Explain briefly (2–3 sentences each) the roles of the model, view and controller in MVC.__ 
- Model:
Model class holds the data and state of the game at runtime, it's concerned with caching data and less about retrieving/storing data from/in cloud & player prefs.
- View:
View class takes care of how the data is presented to the player. It's usually Monobehavior in Unity as it's responsible for changing the interface & screen elements.
- Controller:
Handles the interaction between the model and the view. Usually responsible for taking user input and updating the model & the view.
2. __When might a Service Locator be preferable to directly passing dependencies? What are 
potential drawbacks of this pattern?__
- In environments that lacks robust implementation of Dependency Injection or doesn't utilize it, service locator can be added without disrupting the existing codebase.
It could be useful in isolated contexts or a small module. It can also be used if the service provider is only known at runtime.
- The potential drawback is testability is challenging because service locator uses singleton pattern and for test cases to work it needs to run in parallel with several different instances at once unlike dependency injection where each class has their own instance of the required service.
It can lead to tight coupling of code if it has been over used.
3. __How can a “null” service help when using a Service Locator?__
  - Null service prevents the client from explicitly checking if the service is null before each time they require it and ensures no errors/exceptions takes place.
## Improvements that I would make with more time. 
- Move objects in a confined space related to the camera that is handled through the view script.
- Implement a UI controller that handles changing the score text.
- Figure out how to make a single View script that can be handled through multiple controllers.
