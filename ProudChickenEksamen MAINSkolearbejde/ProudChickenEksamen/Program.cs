using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;

Console.WriteLine();
IRepository repository = new SQLRepository();
SQLController controller = new SQLController(repository);
controller.Run();