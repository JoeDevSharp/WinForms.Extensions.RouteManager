# WinForm Router
The Router class is a C# implementation designed to facilitate navigation and dynamic management of views and forms in a Windows Forms application. It provides methods and functionalities to switch between different views, pass props during navigation, and control routing in general.

## Key Features:

- View Registration: The router allows registering a list of routes or views available in the application. Each route contains information such as the route name, associated component (form), navigation type, and corresponding image/icon.
- View Switching: Through the To methods, the router facilitates the transition from one view to another. You can specify the route name and optionally pass props or additional parameters to customize the target.
- view. The router handles the transition between the corresponding forms.
- Props Management: The router supports the ability to pass props or additional properties during view switching. These props can be used to transfer relevant information to the destination view and enable further customization and adaptability.
- Different Navigation Types: The router allows specifying different navigation types, such as standard navigation, displaying forms in the center of the screen, default dialogs, and custom dialogs. Each navigation type is handled differently, based on the logic defined in the corresponding methods.

## Benefits:

- Modularity and Flexibility: The router facilitates the creation of more modular and flexible Windows Forms applications by enabling dynamic management of views and forms.
- Component Reusability: The router's approach allows for reusing components and forms in different sections of the application, improving development and maintenance efficiency.
- Separation of Concerns: By centralizing navigation management in the router, it achieves better separation of concerns and a more organized code structure.

In summary, the Router class implemented in C# provides a solution for dynamic management of views and forms in a Windows Forms application. It allows switching between different views, passing props during navigation, and controlling various navigation types. With this implementation, you can achieve greater modularity, flexibility, and component reusability in your application.
