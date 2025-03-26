using System;
using System.Collections.Generic;

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }
}

class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int contadorId = 1;

    public void AgregarContacto()
    {
        Console.WriteLine("Agregar nuevo contacto");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        
        contactos.Add(new Contacto(contadorId++, nombre, telefono, email, direccion));
        Console.WriteLine("Contacto agregado exitosamente.\n");
    }

    public void VerContactos()
    {
        Console.WriteLine("Id\tNombre\tTeléfono\tEmail\tDirección");
        Console.WriteLine("-----------------------------------------------------------");
        foreach (var contacto in contactos)
        {
            Console.WriteLine($"{contacto.Id}\t{contacto.Nombre}\t{contacto.Telefono}\t{contacto.Email}\t{contacto.Direccion}");
        }
    }

    public void BuscarContacto()
    {
        Console.Write("Ingrese el ID del contacto a buscar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);

        if (contacto != null)
        {
            Console.WriteLine($"Nombre: {contacto.Nombre}, Teléfono: {contacto.Telefono}, Email: {contacto.Email}, Dirección: {contacto.Direccion}\n");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.\n");
        }
    }

    public void EditarContacto()
    {
        Console.Write("Ingrese el ID del contacto a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);

        if (contacto != null)
        {
            Console.Write("Nuevo nombre: ");
            contacto.Nombre = Console.ReadLine();
            Console.Write("Nuevo teléfono: ");
            contacto.Telefono = Console.ReadLine();
            Console.Write("Nuevo email: ");
            contacto.Email = Console.ReadLine();
            Console.Write("Nueva dirección: ");
            contacto.Direccion = Console.ReadLine();
            Console.WriteLine("Contacto actualizado.\n");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.\n");
        }
    }

    public void EliminarContacto()
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);

        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado exitosamente.\n");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        bool running = true;

        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactos");

        while (running)
        {
            Console.WriteLine("1. Agregar Contacto\t2. Ver Contactos\t3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto\t5. Eliminar Contacto\t6. Salir");
            Console.Write("Elige una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1: agenda.AgregarContacto(); break;
                    case 2: agenda.VerContactos(); break;
                    case 3: agenda.BuscarContacto(); break;
                    case 4: agenda.EditarContacto(); break;
                    case 5: agenda.EliminarContacto(); break;
                    case 6: running = false; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
            else
            {
                Console.WriteLine("Ingrese un número válido.");
            }
        }
    }
}
