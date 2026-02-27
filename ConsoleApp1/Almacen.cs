using System.Collections.Generic;
using System.Linq;

public class Almacen
{
	private List<Producto> productos = new List<Producto>();

	public bool AgregarProducto(Producto producto)
	{
		if (productos.Any(p => p.Codigo == producto.Codigo))
			return false;

		productos.Add(producto);
		return true;
	}
	// commit almacen
	public Producto BuscarProducto(string codigo)
	{
		return productos.FirstOrDefault(p => p.Codigo == codigo);
	}

	public bool EliminarProducto(string codigo)
	{
		var producto = BuscarProducto(codigo);
		if (producto != null)
		{
			productos.Remove(producto);
			return true;
		}
		return false;
	}

	public List<Producto> ListarProductos()
	{
		return productos;
	}

	public int CantidadProductos()
	{
		return productos.Count;
	}
}