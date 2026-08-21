using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();

        string[] lineas = File.ReadAllLines("Aaron_Orellana.csv");

        for (int i = 1; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(',');

            Estudiante est = new Estudiante
            {
                Id = int.Parse(datos[0]),
                Nombre = datos[1],
                Carrera = datos[2]
            };

            estudiantes.Add(est);
        }

        foreach (var est in estudiantes)
        {
            Console.WriteLine($"Id: {est.Id}, Nombre: {est.Nombre}, Carrera: {est.Carrera}");
        }

        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(estudiantes, opciones);

        File.WriteAllText("estudiantes.json", json);

        Console.WriteLine("Archivo estudiantes.json generado correctamente.");
    }
}

