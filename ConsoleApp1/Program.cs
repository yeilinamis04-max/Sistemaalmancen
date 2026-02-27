using System;

class Program
{
	static void Main(string[] args)
	{
		Almacen almacen = new Almacen();
		bool salir = false;

		while (!salir)
		{
			Console.WriteLine("\n--- SISTEMA DE GESTIÓN DE PRODUCTOS ---");
			Console.WriteLine("1. Registrar producto");
			Console.WriteLine("2. Buscar producto");
			Console.WriteLine("3. Eliminar producto");
			Console.WriteLine("4. Listar productos");
			Console.WriteLine("5. Mostrar cantidad total");
			Console.WriteLine("6. Salir");
			Console.Write("Seleccione una opción: ");

			string opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					Console.Write("Código: ");
					string codigo = Console.ReadLine();

					Console.Write("Nombre: ");
					string nombre = Console.ReadLine();

					Console.Write("Precio: ");
					if (!double.TryParse(Console.ReadLine(), out double precio))
					{
						Console.WriteLine("Precio inválido.");
						break;
					}

					if (almacen.AgregarProducto(new Producto(codigo, nombre, precio)))
						Console.WriteLine("Producto registrado correctamente.");
					else
						Console.WriteLine("Error: Ya existe un producto con ese código.");
					break;

				case "2":
					Console.Write("Ingrese código a buscar: ");
					var producto = almacen.BuscarProducto(Console.ReadLine());
					Console.WriteLine(producto != null ? producto.ToString() : "Producto no encontrado.");
					break;

				case "3":
					Console.Write("Ingrese código a eliminar: ");
					Console.WriteLine(almacen.EliminarProducto(Console.ReadLine())
						? "Producto eliminado correctamente."
						: "Producto no encontrado.");
					break;

				case "4":
					var lista = almacen.ListarProductos();
					if (lista.Count == 0)
						Console.WriteLine("No hay productos registrados.");
					else
						foreach (var p in lista)
							Console.WriteLine(p);
					break;

				case "5":
					Console.WriteLine($"Cantidad total de productos: {almacen.CantidadProductos()}");
					break;

				case "6":
					salir = true;
					Console.WriteLine("Saliendo del sistema...");
					break;

				default:
					Console.WriteLine("Opción inválida. Intente nuevamente.");
					break;
			}
		}
	}
}
