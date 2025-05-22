using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;

Console.WriteLine();
IRepository repository = new SQLRepository();
Controller controller = new Controller(repository);
controller.Run();