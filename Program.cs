using System;
using System.Collections.Generic;


List<int> roomNumbers = new List<int>();
List<string> roomTypes = new List<string>();
List<decimal> roomPrices = new List<decimal>();
List<string> roomStatus = new List<string>();
List<string> roomDetails = new List<string>();

int option;
bool isValidOption;

do
{
    Console.Clear();
    Console.WriteLine("==================================================");
    Console.WriteLine("     SISTEMA DE GESTIÓN DE HABITACIONES DE HOTEL  ");
    Console.WriteLine("==================================================");
    Console.WriteLine("1. Registrar nueva habitación");
    Console.WriteLine("2. Listar todas las habitaciones");
    Console.WriteLine("3. Buscar habitación");
    Console.WriteLine("4. Modificar habitación");
    Console.WriteLine("5. Eliminar habitación");
    Console.WriteLine("0. Salir del programa");
    Console.WriteLine("==================================================");
    Console.WriteLine("Elija una opción correspondiente (0 - 5): ");

    isValidOption = int.TryParse(Console.ReadLine(), out option);

    if (!isValidOption)
    {
        Console.WriteLine("\nERROR! Opción inválida. Introduzca un número del 0 al 5.");
        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
        continue;
    }

    switch (option)
    {
        case 1:
            Console.WriteLine("\n=== REGISTRAR NUEVA HABITACIÓN ===");
            
            
            int roomNum;
            while (true)
            {
                Console.WriteLine("Ingrese el número de la habitación (Ej. 101):");
                string inputNum = (Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(inputNum, out roomNum) || roomNum <= 0)
                {
                    Console.WriteLine("ERROR! El número de habitación debe ser un entero positivo.");
                    continue;
                }

                if (roomNumbers.Contains(roomNum))
                {
                    Console.WriteLine($"ERROR! La habitación #{roomNum} ya se encuentra registrada. Ingrese otra.");
                    continue;
                }
                break;
            }

            
            string roomType = "";
            while (true)
            {
                Console.WriteLine("\nSeleccione el tipo de habitación:");
                Console.WriteLine("1. Individual (Simple)");
                Console.WriteLine("2. Doble");
                Console.WriteLine("3. Matrimonial");
                Console.WriteLine("4. Suite Junior");
                Console.WriteLine("5. Suite Presidencial");
                Console.WriteLine("Elija una opción (1 - 5):");

                if (int.TryParse(Console.ReadLine(), out int typeChoice))
                {
                    switch (typeChoice)
                    {
                        case 1: roomType = "Individual (Simple)"; break;
                        case 2: roomType = "Doble"; break;
                        case 3: roomType = "Matrimonial"; break;
                        case 4: roomType = "Suite Junior"; break;
                        case 5: roomType = "Suite Presidencial"; break;
                    }
                    if (!string.IsNullOrEmpty(roomType)) break;
                }
                Console.WriteLine("ERROR! Opción de tipo inválida. Intente de nuevo.");
            }

          
            decimal roomPrice;
            while (true)
            {
                Console.WriteLine("\nIngrese el precio por noche ($):");
                string inputPrice = (Console.ReadLine() ?? "").Trim();

                if (decimal.TryParse(inputPrice, out roomPrice) && roomPrice >= 0)
                {
                    break;
                }
                Console.WriteLine("ERROR! El precio debe ser un valor numérico válido mayor o igual a 0.");
            }

            
            string roomStatusVal = "";
            while (true)
            {
                Console.WriteLine("\nSeleccione el estado de la habitación:");
                Console.WriteLine("1. Disponible");
                Console.WriteLine("2. Ocupada");
                Console.WriteLine("3. Mantenimiento");
                Console.WriteLine("4. Limpieza");
                Console.WriteLine("Elija una opción (1 - 4):");

                if (int.TryParse(Console.ReadLine(), out int statusChoice))
                {
                    switch (statusChoice)
                    {
                        case 1: roomStatusVal = "Disponible"; break;
                        case 2: roomStatusVal = "Ocupada"; break;
                        case 3: roomStatusVal = "Mantenimiento"; break;
                        case 4: roomStatusVal = "Limpieza"; break;
                    }
                    if (!string.IsNullOrEmpty(roomStatusVal)) break;
                }
                Console.WriteLine("ERROR! Opción de estado inválida. Intente de nuevo.");
            }

           
            Console.WriteLine("\nIngrese detalles o ubicación (Ej. Vista al mar, Piso 2):");
            string details = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(details)) details = "Estándar";

           
            roomNumbers.Add(roomNum);
            roomTypes.Add(roomType);
            roomPrices.Add(roomPrice);
            roomStatus.Add(roomStatusVal);
            roomDetails.Add(details);

            Console.WriteLine($"\n¡Éxito! Habitación #{roomNum} registrada correctamente.");
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 2:
            Console.WriteLine("\n=== LISTADO GENERAL DE HABITACIONES ===");
            if (roomNumbers.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas en el sistema.");
            }
            else
            {
                for (int i = 0; i < roomNumbers.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] N.º: {roomNumbers[i]} | \nTipo: {roomTypes[i]} | \nPrecio: ${roomPrices[i]:F2} | \nEstado: {roomStatus[i]} | \nDetalle: {roomDetails[i]}");
                }
                Console.WriteLine($"\nTotal de habitaciones registradas: {roomNumbers.Count}");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 3:
            Console.WriteLine("\n=== BUSCAR HABITACIÓN ===");
            if (roomNumbers.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas para buscar.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Ingrese el número de la habitación a buscar:");
            if (int.TryParse(Console.ReadLine(), out int searchNum))
            {
                int index = roomNumbers.IndexOf(searchNum);
                if (index != -1)
                {
                    Console.WriteLine($"\n[¡Encontrada!]");
                    Console.WriteLine($"N.º Habitación: {roomNumbers[index]}");
                    Console.WriteLine($"Tipo: {roomTypes[index]}");
                    Console.WriteLine($"Precio: ${roomPrices[index]:F2}");
                    Console.WriteLine($"Estado: {roomStatus[index]}");
                    Console.WriteLine($"Detalle: {roomDetails[index]}");
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna habitación con ese número.");
                }
            }
            else
            {
                Console.WriteLine("ERROR! Entrada inválida. Debe ingresar un número entero.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 4:
            Console.WriteLine("\n=== MODIFICAR HABITACIÓN ===");
            if (roomNumbers.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas para modificar.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Ingrese el número de la habitación que desea modificar:");
            if (int.TryParse(Console.ReadLine(), out int modNum))
            {
                int index = roomNumbers.IndexOf(modNum);
                if (index != -1)
                {
                    Console.WriteLine($"\nDatos actuales -> Precio: ${roomPrices[index]:F2} | Estado: {roomStatus[index]}");
                    
                    
                    Console.WriteLine("Ingrese el nuevo precio (o presione Enter para mantener el actual):");
                    string priceInput = (Console.ReadLine() ?? "").Trim();
                    if (priceInput != "")
                    {
                        if (decimal.TryParse(priceInput, out decimal newPrice) && newPrice >= 0)
                        {
                            roomPrices[index] = newPrice;
                            Console.WriteLine("-> Precio actualizado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("-> ERROR: Precio inválido. Se mantuvo el precio anterior.");
                        }
                    }

                    
                    Console.WriteLine("\n¿Desea cambiar el estado de la habitación? (1. Sí / 2. No):");
                    if (int.TryParse(Console.ReadLine(), out int changeStatusChoice) && changeStatusChoice == 1)
                    {
                        string newStatusVal = "";
                        while (true)
                        {
                            Console.WriteLine("Seleccione el nuevo estado:");
                            Console.WriteLine("1. Disponible");
                            Console.WriteLine("2. Ocupada");
                            Console.WriteLine("3. Mantenimiento");
                            Console.WriteLine("4. Limpieza");
                            Console.WriteLine("Elija una opción (1 - 4):");

                            if (int.TryParse(Console.ReadLine(), out int statusChoice))
                            {
                                switch (statusChoice)
                                {
                                    case 1: newStatusVal = "Disponible"; break;
                                    case 2: newStatusVal = "Ocupada"; break;
                                    case 3: newStatusVal = "Mantenimiento"; break;
                                    case 4: newStatusVal = "Limpieza"; break;
                                }
                                if (!string.IsNullOrEmpty(newStatusVal))
                                {
                                    roomStatus[index] = newStatusVal;
                                    Console.WriteLine("-> Estado actualizado con éxito.");
                                    break;
                                }
                            }
                            Console.WriteLine("ERROR! Opción inválida. Intente de nuevo.");
                        }
                    }

                    Console.WriteLine("\n¡Proceso de modificación finalizado!");
                }
                else
                {
                    Console.WriteLine("No existe una habitación registrada con ese número.");
                }
            }
            else
            {
                Console.WriteLine("ERROR! Entrada inválida. Debe ingresar un número entero.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 5:
            Console.WriteLine("\n=== ELIMINAR HABITACIÓN ===");
            if (roomNumbers.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas para eliminar.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Ingrese el número de la habitación que desea eliminar:");
            if (int.TryParse(Console.ReadLine(), out int delNum))
            {
                int index = roomNumbers.IndexOf(delNum);
                if (index != -1)
                {
                    // Confirmación de seguridad antes de borrar
                    Console.WriteLine($"¿Está seguro de eliminar la habitación #{roomNumbers[index]}? (S/N):");
                    string confirm = (Console.ReadLine() ?? "").Trim().ToUpper();

                    if (confirm == "S")
                    {
                        
                        roomNumbers.RemoveAt(index);
                        roomTypes.RemoveAt(index);
                        roomPrices.RemoveAt(index);
                        roomStatus.RemoveAt(index);
                        roomDetails.RemoveAt(index);

                        Console.WriteLine("\n¡Habitación eliminada correctamente del sistema!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna habitación con ese número.");
                }
            }
            else
            {
                Console.WriteLine("ERROR! Entrada inválida. Debe ingresar un número entero.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case 0:
            Console.WriteLine("\n=== GRACIAS POR UTILIZAR NUESTRO SISTEMA. HASTA PRONTO! ===");
            break;

        default:
            Console.WriteLine("\nERROR! Opción fuera de rango (Elija entre 0 y 5).");
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;
    }
}
while (option != 0);