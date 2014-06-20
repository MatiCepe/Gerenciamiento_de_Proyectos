using System;
using System.Collections.Generic;
using System.Linq;
using GP.Dominio.Models;
using GP.Log;
using GP.Repositorio.Repositories;

namespace SystemTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Presione una tecla para proceder a crear las entidades y sus valores por defecto...");
            ConsoleKeyInfo k;
            do
            {
                Menu();
                Console.WriteLine("Presione 'Enter' para finalizar o '0' para mostrar el menu de nuevo.");
                k = Console.ReadKey();
                Console.Clear();
            }
            while (k.Key == ConsoleKey.NumPad0);
            Console.Beep();
        }

        static void Menu()
        {
            Console.WriteLine("Seleccione la opcion: ");
            Console.WriteLine("1 - Crear BD y cargar datos:");
            Console.WriteLine("2 - Modificar los datos:");
            Console.WriteLine("3 - Mostrar los datos:");
            Console.WriteLine("4 - Eliminar datos:");

            bool proceso = false;

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case (ConsoleKey.NumPad1):
                    {
                        Console.Clear();
                        if (Add() == 1) proceso = true;
                        break;
                    }
                case (ConsoleKey.NumPad2):
                    {
                        Console.Clear();
                        if (Update() == 1) proceso = true;
                        break;
                    }
                case (ConsoleKey.NumPad3):
                    {
                        Console.Clear();
                        if (Listar() == 1) proceso = true;
                        break;
                    }
                case (ConsoleKey.NumPad4):
                    {
                        Console.Clear();
                        Console.WriteLine("Lo sentimos. Accion no implementada");
                        break;
                    }
            }
            if (!proceso)
            {
                Console.WriteLine("Lamentablemente ocurrio un error. Vea el archivo de log.");
            }
        }

        static int Add()
        {
            Console.WriteLine("Procesando la creacion....");
            try
            {
                AddValores();
                AddGerente();
                AddFactor();
                AddProyecto();
                return 1;
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }
        }

        static int Update()
        {
            Console.WriteLine("Procesando la modificacion....");
            try
            {
                UpdateValores();
                UpdateGerente();
                UpdateFactor();
                UpdateProyecto();
                return 1;
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }
        }

        // Los Datos de los procesos estan hardcodeados
        static void AddValores()
        {
            ValorRepository valorRepository = new ValorRepository();
            if (valorRepository.GetAll().Count == 0)
                {
                    var valor = new Valor();

                    valor.Nombre = "Bajo";
                    valor.Influencia = 0;
                    valorRepository.Create(valor);

                    valor.Nombre = "Medio";
                    valor.Influencia = 1;
                    valorRepository.Create(valor);

                    valor.Nombre = "Alto";
                    valor.Influencia = 2;
                    valorRepository.Create(valor);

                    Console.WriteLine("Valores agregados con exito");
                }
        }

        static void AddGerente()
        {

            GerenteRepository gerenteRepository = new GerenteRepository();
           
            // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
            if (gerenteRepository.GetAll().Count == 0)
            {
                var gerente = new Gerente();

                gerente.Nombre = "Victor Valotto";
                gerenteRepository.Create(gerente);

                Console.WriteLine("Gerente '" + gerente.Nombre + "' agregado con exito");
            } 
        }

        static void AddFactor()
        {
                FactorRepository factorRepository = new FactorRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                if (factorRepository.GetAll().Count == 0)
                {
                    ValorRepository valorRepository = new ValorRepository();
                    var factor = new Factor();

                    factor.Nombre = "Tiempo";
                    factor.ValoresSeleccionados = valorRepository.GetAll();
                    factorRepository.Create(factor);

                    Console.WriteLine("Factor '" + factor.Nombre + "' agregado con exito");
                }
        }

        static void AddProyecto()
        {
                ProyectoRepository proyectoRepository = new ProyectoRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                if (proyectoRepository.GetAll().Count == 0)
                {
                    var factorRepository = new FactorRepository();
                    var factor = factorRepository.GetAll().FirstOrDefault(); // Selecciono el primer factor de la lista
                    // Este GetAll() obtiene solo factores, pero no trae el listado de valores asociados e ValoresSeleccionados
                    // ToDo: Modificar el GetAll de este repositorio para que lo haga (Capa de Negocio)

                    ValorRepository valorRepository = new ValorRepository();
                    // var valorSeleccionado = valorRepository.GetByID(factor.ValoresSeleccionados.FirstOrDefault().ValorId);
                    var valorSeleccionado = valorRepository.GetAll().FirstOrDefault(); // Selecciono el primer valor disponible

                    var proyectoFactor = new ProyectoFactor();
                    var p2 = new List<ProyectoFactor>(0);
                    proyectoFactor.Factor = factor;
                    proyectoFactor.ValorSeleccionado = valorSeleccionado;
                    p2.Add(proyectoFactor);

                    var gerenteRepository = new GerenteRepository();
                    var gerente = gerenteRepository.GetAll().FirstOrDefault();

                    var proyecto = new Proyecto();

                    proyecto.Nombre = "Proyecto de Prueba";
                    proyecto.Fecha = DateTime.Today;
                    proyecto.Descripcion = "Este es un proyecto de prueba...";
                    proyecto.Caracterizacion = 1;
                    proyecto.Gerente = gerente;
                    proyecto.ProyectoFactor = p2;
                    proyectoRepository.Create(proyecto);

                    Console.WriteLine("El Proyecto '" + proyecto.Nombre + "' fue agregado con exito, con los siguientes datos:");
                    Console.WriteLine("Fecha: " + proyecto.Fecha.ToString());
                    Console.WriteLine("Descripcion: " + proyecto.Descripcion);
                    Console.WriteLine("Sus Factores son: " + proyecto.ProyectoFactor.FirstOrDefault().Factor.Nombre);
                    Console.WriteLine("Y el Valor de su factor es: " + proyecto.ProyectoFactor.FirstOrDefault().ValorSeleccionado.Nombre + " con una influencia de : " + proyecto.ProyectoFactor.FirstOrDefault().ValorSeleccionado.Influencia);
                }
        }

        static void UpdateValores()
        {
                ValorRepository valorRepository = new ValorRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                var valores = valorRepository.GetAll();
                if (valores.Count == 0)
                {
                    Console.WriteLine("No hay valores a editar");
                }
                else
                {
                    valores[0].Nombre= "Bajos";
                    valores[0].Influencia = 0;
                    valorRepository.Update(valores[0]);

                    valores[1].Nombre = "Medios";
                    valores[2].Influencia = 1;
                    valorRepository.Update(valores[1]);

                    valores[2].Nombre = "Altos";
                    valores[2].Influencia = 2;
                    valorRepository.Update(valores[2]);
                }
        }

        static void UpdateGerente()
        {
                GerenteRepository gerenteRepository = new GerenteRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                var gerentes = gerenteRepository.GetAll();
                if (gerentes.Count == 0)
                {
                    Console.WriteLine("No hay gerentes para modificar");
                }
                else
                {
                    gerentes[0].Nombre = "Aldo Sigura";
                    gerenteRepository.Update(gerentes[0]);
                }
        }

        static void UpdateFactor()
        {
                FactorRepository factorRepository = new FactorRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                var factores = factorRepository.GetAll();
                if (factores.Count == 0)
                {
                    Console.WriteLine("No hay factores para modificar");
                }
                else
                {
                    factores[0].Nombre = "Calidad";
                    factorRepository.Update(factores[0]);
                }
        }

        static void UpdateProyecto()
        {
                ProyectoRepository proyectoRepository = new ProyectoRepository();

                // Controlo que no haya valores cargados previamente para que no explote o genere datos repetidos.
                var proyectos = proyectoRepository.GetAll();
                if (proyectos.Count == 0)
                {
                    Console.WriteLine("No hay proyectos para modificar");
                }
                else
                {
                    proyectos[0].Nombre = "Proyecto de Prueba Modificado";
                    proyectos[0].Fecha = DateTime.Now;
                    proyectos[0].Descripcion = "Este es un proyecto de prueba que se modifico";
                    proyectos[0].Caracterizacion = 2;
                    proyectoRepository.Update(proyectos[0]);
                }
        }

        static int Listar()
        {
            GerenteRepository gerenteRepository = new GerenteRepository();
            ValorRepository valorRepository = new ValorRepository();
            FactorRepository factorRepository = new FactorRepository();
            ProyectoRepository proyectoRepository = new ProyectoRepository();
            try
            {
                var gerentes = gerenteRepository.GetAll();
                var valores = valorRepository.GetAll();
                var factores = factorRepository.GetAll();
                var proyectos = proyectoRepository.GetAll();

                Console.WriteLine("Listado de Gerentes:");
                for (int i = 0; i < gerentes.Count(); i++)
                {
                    Console.WriteLine("Gerente Numero " + (int)(i + 1));
                    Console.WriteLine("Nombre: " + gerentes[i].Nombre);
                }

                Console.WriteLine("Listado de Valores:");
                for (int i = 0; i < valores.Count(); i++)
                {
                    Console.WriteLine("Valor Numero " + (int)(i + 1));
                    Console.WriteLine("Nombre: " + valores[i].Nombre + " y su Influencia es: " + valores[i].Influencia);
                }

                Console.WriteLine("Listado de Factores:");
                for (int i = 0; i < factores.Count(); i++)
                {
                    Console.WriteLine("Factor Numero " + (int)(i + 1));
                    Console.WriteLine("Nombre: " + factores[i].Nombre);
                }

                Console.WriteLine("Listado de Proyectos:");
                for (int i = 0; i < proyectos.Count(); i++)
                {
                    Console.WriteLine("Proyecto Numero " + (int)(i + 1));
                    Console.WriteLine("Nombre: " + proyectos[i].Nombre + ", su fecha es: " + proyectos[i].Fecha + ", y su Caracterizacion es: " + proyectos[i].Caracterizacion);
                }

                return 1;
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }

        }
    }
}
