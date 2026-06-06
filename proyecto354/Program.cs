using System;
using System.Linq;
using System.Threading;
using System.Text;
using System.Collections.Generic;

// Monge Shimizu Paulina y Rubio Espino Dylan Arturo 2-F

namespace CasaDonSimon
{
    class Program
    {
        // platillos guardar 
        static List<string> ticketNombres = new List<string>();
        static List<int> ticketPrecios = new List<int>();
        static int totalCuenta = 0;

        // este metodo sirve para leer numeros
        static int LeerEntero(int minimo, int maximo)
        {
            int numero = 0;
            bool esValido = false;

            while (esValido == false)
            {
                string entrada = Console.ReadLine();
                bool sePudo = int.TryParse(entrada, out numero);

                if (sePudo == true && numero >= minimo && numero <= maximo)
                {
                    esValido = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Numero no valido, escribe del " + minimo + " al " + maximo + ": ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            return numero;
        }

        // nombre y precio
        static void AgregarATicket(string nombre, int precio)
        {
            ticketNombres.Add(nombre);
            ticketPrecios.Add(precio);
            totalCuenta = totalCuenta + precio;
        }

        // imprimir
        static void ImprimirTicket()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("         La Casa de Don Simon           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     Av. Antonio Rosales 552 ote.       ");
            Console.WriteLine("  Martes a domingo de 7:30 a 2:00 p.m. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            if (ticketNombres.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  No se agrego ningun platillo.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            else
            {
                // imprimir plato
                for (int i = 0; i < ticketNombres.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  " + ticketNombres[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   $" + ticketPrecios[i]);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  TOTAL A PAGAR:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                $" + totalCuenta);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("========================================");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        //mensaje dsps de eleccion
        static void Confirmado()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("  Perfectooooo!!! Se agrego al ticket.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Presiona ENTER para continuar...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MenuPrincipal();

            //ticket
            ImprimirTicket();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Gracias por su visita! Presiona ENTER para cerrar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void MenuPrincipal()
        {
            int opcion = 0;

            while (opcion != 11)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("- - - - - - - - - MENU - - - - - - - - -");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("        La Casa de Don Simon");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     Tradicion y ambiente familiar");
                Console.WriteLine("  Servicio para eventos y reuniones");
                Console.WriteLine("  Martes a domingo 7:30 a.m. a 2:00 p.m.");
                Console.WriteLine("    Av. Antonio Rosales 552 ote.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Seleccione una categoria:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1.  Entradas");
                Console.WriteLine("2.  Chilaquiles");
                Console.WriteLine("3.  Burritos");
                Console.WriteLine("4.  Huevos");
                Console.WriteLine("5.  Desayunos completos");
                Console.WriteLine("6.  Los tradicionales");
                Console.WriteLine("7.  Sandwiches");
                Console.WriteLine("8.  Menu kids");
                Console.WriteLine("9.  Bebidas para iniciar el dia");
                Console.WriteLine("10. Especialidades Don Simon");
                Console.WriteLine("11. Terminar y ver ticket");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Su eleccion: ");

                opcion = LeerEntero(1, 11);
                Console.ForegroundColor = ConsoleColor.White;

                // elecicion
                switch (opcion)
                {
                    case 1:
                        MenuEntradas();
                        break;
                    case 2:
                        MenuChilaquiles();
                        break;
                    case 3:
                        MenuBurritos();
                        break;
                    case 4:
                        MenuHuevos();
                        break;
                    case 5:
                        MenuDesayunosCompletos();
                        break;
                    case 6:
                        MenuTradicionales();
                        break;
                    case 7:
                        MenuSandwiches();
                        break;
                    case 8:
                        MenuKids();
                        break;
                    case 9:
                        MenuBebidas();
                        break;
                    case 10:
                        MenuEspecialidades();
                        break;
                    case 11:         
                        break;
                }
            }
        }

        //entardas
        static void MenuEntradas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Entradas - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Avena (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Comienza tu dia con un toque de calidez y nutricion con nuestra");
            Console.WriteLine("   reconfortante avena acompanada de manzana verde, platano, nuez y pasas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Kekis (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $110");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Los tradicionales, deleitate con los favoritos de Don Simon.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Son el desayuno perfecto para empezar tu dia con una sonrisa. Un clasico favorito!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Pan frances");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 rebanadas partidas a la mitad acompanadas de mermelada de la casa");
            Console.WriteLine("   y una lluvia de azucar glass.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Fruta de temporada chica (300gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Acompanada de una porcion de yogurt natural, granola y miel.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Fruta de temporada grande (500gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Acompanada de una porcion de yogurt natural, granola y miel.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Guacamole (150gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Con un toque de tomate, cebolla y cilantro. Clasico favorito!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8. Queso fundido (250gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Tradicional queso tipo gouda gratinado.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9. Queso fundido con arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Tradicional queso tipo gouda gratinado con arrachera.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("10. Queso fundido con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Tradicional queso tipo gouda gratinado con chorizo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("11. Panela asada con frijoles de la olla");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Panela asada (200gr), banada con salsa verde, con un toque de cilantro");
            Console.WriteLine("   y acompanada con frijol de la olla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("12. Gorditas con asientos (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Acompanadas con salsa pico de gallo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("13. Colache (200gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $135");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Calabacita picada con verduras gratinadas y acompanado de frijol refrito.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("14. Ejotes o nopales con verdura (200gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Mezclados con verduras, salteados con mantequilla saborizada");
            Console.WriteLine("   y acompanados de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-14)   15. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 15);

            if (opcion == 15)
            {
                return;
            }

            // que platillo entrada
            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Avena (350ml)";
                    precio = 90;
                    break;
                case 2:
                    nombre = "Kekis (3 piezas)";
                    precio = 110;
                    break;
                case 3:
                    nombre = "Hot cakes (3 piezas)";
                    precio = 130;
                    break;
                case 4:
                    nombre = "Pan frances";
                    precio = 125;
                    break;
                case 5:
                    nombre = "Fruta de temporada chica (300gr)";
                    precio = 70;
                    break;
                case 6:
                    nombre = "Fruta de temporada grande (500gr)";
                    precio = 90;
                    break;
                case 7:
                    nombre = "Guacamole (150gr)";
                    precio = 90;
                    break;
                case 8:
                    nombre = "Queso fundido (250gr)";
                    precio = 130;
                    break;
                case 9:
                    nombre = "Queso fundido con arrachera (100gr)";
                    precio = 185;
                    break;
                case 10:
                    nombre = "Queso fundido con chorizo (80gr)";
                    precio = 150;
                    break;
                case 11:
                    nombre = "Panela asada con frijoles de la olla";
                    precio = 120;
                    break;
                case 12:
                    nombre = "Gorditas con asientos (3 piezas)";
                    precio = 90;
                    break;
                case 13:
                    nombre = "Colache (200gr)";
                    precio = 135;
                    break;
                case 14:
                    nombre = "Ejotes o nopales con verdura (200gr)";
                    precio = 130;
                    break;
            }

            if (nombre != "")
            {
                AgregarATicket(nombre, precio);
                Confirmado();
            }
        }

        //chilaquiles
        static void MenuChilaquiles()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Chilaquiles - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Chilaquiles rojos / verdes");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Crujientes totopos con salsa roja o verde, crema, queso y cebolla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Chilaquiles suizos / poblanos");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Gratinados o banados en salsa poblana, con crema, queso y cebolla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Extras disponibles:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   - Con huevo");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   +$25");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   - Con pollo");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   +$35");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-2)   3. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 3);

            if (opcion == 3)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Chilaquiles rojos / verdes";
                    precio = 140;
                    break;
                case 2:
                    nombre = "Chilaquiles suizos / poblanos";
                    precio = 150;
                    break;
            }

            // extras?
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Agregar huevo por $25? (1=Si  2=No): ");
            int huevo = LeerEntero(1, 2);
            if (huevo == 1)
            {
                precio = precio + 25;
                nombre = nombre + " + huevo";
            }

            Console.Write("Agregar pollo por $35? (1=Si  2=No): ");
            int pollo = LeerEntero(1, 2);
            if (pollo == 1)
            {
                precio = precio + 35;
                nombre = nombre + " + pollo";
            }

            Console.ForegroundColor = ConsoleColor.White;

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // burritos
        static void MenuBurritos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Burritos (precio por pieza) - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Machaca (50gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $120");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Bistec de arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $120");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Papas con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Chicharron (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $95");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Frijol con queso fresco");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Todos los burritos van acompanados con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-5)   6. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 6);

            if (opcion == 6)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Burrito de machaca (50gr)";
                    precio = 120;
                    break;
                case 2:
                    nombre = "Burrito de bistec de arrachera (100gr)";
                    precio = 120;
                    break;
                case 3:
                    nombre = "Burrito de papas con chorizo (80gr)";
                    precio = 70;
                    break;
                case 4:
                    nombre = "Burrito de chicharron (80gr)";
                    precio = 95;
                    break;
                case 5:
                    nombre = "Burrito de frijol con queso fresco";
                    precio = 60;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // eggs
        static void MenuHuevos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Huevos - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Huevos o claras al gusto");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   A elegir: Jamon, salchicha, tocino, nopales, mexicanos, papas,");
            Console.WriteLine("   chorizo, ejotes, o sopitas. Tambien: Chilorio, machaca o chicharron.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Huevos campesinos");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo estrellado montados sobre jamon y tortilla frita,");
            Console.WriteLine("   banados en salsa de la casa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Huevos a la tambora");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $180");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo estrellado montados sobre chilorio natural y tortilla");
            Console.WriteLine("   frita, banados con salsa ranchera.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Montaditos sinaloenses");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo estrellado sobre pan de caja dorado con mantequilla,");
            Console.WriteLine("   cama de aguacate, coronado con tiras de tocino y ensalada fresca.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Huevos divorciados");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo estrellado sobre jamon y gordita frita,");
            Console.WriteLine("   uno banado en salsa verde y otro en salsa roja.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Huevos arrieros");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo banados con salsa arriera, y puntas de arrachera");
            Console.WriteLine("   (80gr) encebolladas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Omelette Don Simon");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Relleno de espinaca, champinon, mantequilla saborizada y papas fritas.");
            Console.WriteLine("   Pidelo banado en tu salsa favorita (roja / verde / ranchera).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8. Omelette de 3 quesos");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Relleno de mezcla de 3 quesos, jamon y papas fritas en cuadros.");
            Console.WriteLine("   Pidelo banado en tu salsa favorita (roja / verde / ranchera).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9. Omelette de camaron");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Relleno de camaron (80gr), con queso gratinado, banado en salsa con");
            Console.WriteLine("   crema de chile morron rojo y papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("10. Omelette poblano");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Relleno de rajas poblanas con queso, elote y cebolla, banado en salsa");
            Console.WriteLine("   poblana y papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("11. Omelette culichi");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Relleno de chilorio (80gr) con queso, banado en salsa ranchera");
            Console.WriteLine("   y papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Todos los desayunos van acompanados de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-11)   12. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 12);

            if (opcion == 12)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Huevos o claras al gusto";
                    precio = 130;
                    break;
                case 2:
                    nombre = "Huevos campesinos";
                    precio = 150;
                    break;
                case 3:
                    nombre = "Huevos a la tambora";
                    precio = 180;
                    break;
                case 4:
                    nombre = "Montaditos sinaloenses";
                    precio = 175;
                    break;
                case 5:
                    nombre = "Huevos divorciados";
                    precio = 165;
                    break;
                case 6:
                    nombre = "Huevos arrieros";
                    precio = 185;
                    break;
                case 7:
                    nombre = "Omelette Don Simon";
                    precio = 179;
                    break;
                case 8:
                    nombre = "Omelette de 3 quesos";
                    precio = 179;
                    break;
                case 9:
                    nombre = "Omelette de camaron";
                    precio = 210;
                    break;
                case 10:
                    nombre = "Omelette poblano";
                    precio = 179;
                    break;
                case 11:
                    nombre = "Omelette culichi";
                    precio = 185;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // desyaunos
        static void MenuDesayunosCompletos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Desayunos completos - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Combinacion poblana");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, rajas poblanas con queso, elote y cebolla, tamal");
            Console.WriteLine("   natural, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Combinacion del campo");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, papas con verdura gratinadas, chilaquiles verdes,");
            Console.WriteLine("   frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Combinacion mar y tierra");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, camaron");
            Console.WriteLine("   (80gr) ranchero, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Combinacion sinaloense");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, chilorio (80gr) a la mexicana, dos quesadillas,");
            Console.WriteLine("   frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Combinacion sonora");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, machaca (50gr) a la mexicana, chilaquiles rojos,");
            Console.WriteLine("   frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Combinacion Cosala");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, colache con verdura, queso gratinado, tamal frito,");
            Console.WriteLine("   frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Combinacion mi rancho");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, chorizo");
            Console.WriteLine("   (80gr) con papa, frijol refrito, dos quesadillas y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8. Combinacion Don Simon");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Tamal gratinado, chilaquiles poblanos, chicharrones (80gr) a la mexicana,");
            Console.WriteLine("   frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9. Combinacion americana");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 piezas de hot cakes, 2 piezas de huevos estrellados y tiras de tocino.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-9)   10. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 10);

            if (opcion == 10)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Combinacion poblana";
                    precio = 175;
                    break;
                case 2:
                    nombre = "Combinacion del campo";
                    precio = 175;
                    break;
                case 3:
                    nombre = "Combinacion mar y tierra";
                    precio = 210;
                    break;
                case 4:
                    nombre = "Combinacion sinaloense";
                    precio = 185;
                    break;
                case 5:
                    nombre = "Combinacion sonora";
                    precio = 185;
                    break;
                case 6:
                    nombre = "Combinacion Cosala";
                    precio = 175;
                    break;
                case 7:
                    nombre = "Combinacion mi rancho";
                    precio = 200;
                    break;
                case 8:
                    nombre = "Combinacion Don Simon";
                    precio = 185;
                    break;
                case 9:
                    nombre = "Combinacion americana";
                    precio = 170;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        //tradicionales
        static void MenuTradicionales()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Los tradicionales - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Tacos dorados (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De maiz, rellenos de papa (100gr) con carne deshebrada (50gr), coronados");
            Console.WriteLine("   con lechuga romana, tomate, pepino, cebolla curtida, queso, crema");
            Console.WriteLine("   y acompanados de consome de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Tostadas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De carne deshebrada (60gr) con frijol y papas fritas, coronadas con");
            Console.WriteLine("   lechuga romana, tomate, pepino, cebolla curtida, queso, crema");
            Console.WriteLine("   y acompanadas de consome de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Gorditas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De carne deshebrada (60gr) con frijol y papas fritas, coronadas con");
            Console.WriteLine("   lechuga romana, tomate, pepino, cebolla curtida, queso, crema");
            Console.WriteLine("   y acompanadas de consome de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Enchiladas verdes o rojas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De maiz, rellenas de pechuga de pollo deshebrada (90gr), coronadas con");
            Console.WriteLine("   lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema");
            Console.WriteLine("   y acompanadas de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Enchiladas suizas o poblanas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De maiz, rellenas de pechuga de pollo deshebrada (90gr), gratinadas,");
            Console.WriteLine("   coronadas con aguacate y acompanadas de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Orden de asado");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Papa (100gr) y carne (100gr) en cuadros, coronado con lechuga romana,");
            Console.WriteLine("   tomate, pepino, cebolla curtida, aguacate, queso, crema");
            Console.WriteLine("   y acompanado de consome de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Pieza taco, tostada o gordita");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Pieza individual de tu antojo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-7)   8. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 8);

            if (opcion == 8)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Tacos dorados (3 piezas)";
                    precio = 150;
                    break;
                case 2:
                    nombre = "Tostadas (3 piezas)";
                    precio = 150;
                    break;
                case 3:
                    nombre = "Gorditas (3 piezas)";
                    precio = 150;
                    break;
                case 4:
                    nombre = "Enchiladas verdes o rojas (3 piezas)";
                    precio = 165;
                    break;
                case 5:
                    nombre = "Enchiladas suizas o poblanas (3 piezas)";
                    precio = 170;
                    break;
                case 6:
                    nombre = "Orden de asado";
                    precio = 170;
                    break;
                case 7:
                    nombre = "Pieza taco, tostada o gordita";
                    precio = 55;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // sandwhiches
        static void MenuSandwiches()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Sandwiches - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Sandwich especial");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Sandwich de pechuga de pollo (100gr), tocino y jamon, gratinado por");
            Console.WriteLine("   encima, acompanado de papas fritas en cuadros y un mix de lechuga.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Club sandwich");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Sandwich de jamon y queso tipo americano, lechuga, tomate, aguacate,");
            Console.WriteLine("   acompanado de papas a la francesa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-2)   3. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 3);

            if (opcion == 3)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Sandwich especial";
                    precio = 185;
                    break;
                case 2:
                    nombre = "Club sandwich";
                    precio = 140;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // menu kids
        static void MenuKids()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Menu kids - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Salchipulpos con huevo");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   2 salchichas cortadas en forma de pulpo y 2 piezas de huevo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Mini hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Con porcion de platano y mermelada de fresa artesanal.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Combinacion kids");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   3 mini hot cakes, 2 piezas de huevo revuelto y salchipulpo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Deditos Pio Pio (6 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   De pechuga de pollo (120gr), empanizados, acompanados de papas a la");
            Console.WriteLine("   francesa (80gr) y de aderezo ketchup.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-4)   5. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 5);

            if (opcion == 5)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Salchipulpos con huevo";
                    precio = 125;
                    break;
                case 2:
                    nombre = "Mini hot cakes (3 piezas)";
                    precio = 90;
                    break;
                case 3:
                    nombre = "Combinacion kids";
                    precio = 140;
                    break;
                case 4:
                    nombre = "Deditos Pio Pio (6 piezas)";
                    precio = 140;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // bebidas
        static void MenuBebidas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Bebidas para iniciar el dia - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Cafe americano (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Cafe clasico preparado al momento, intenso y aromatico.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Cafe descafeinado (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Sabor y cuerpo del cafe con menos cafeina.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Cafe de olla (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Receta tradicional con notas de canela y piloncillo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Cafe chai (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frape $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Mezcla especiada y cremosa estilo chai.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Capuchino vainilla / avellana / original (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frape $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Espresso con leche espumosa, elige tu sabor.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Chocolate caliente (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Cacao cremoso y dulce.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Agua para cafe (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Preparacion ligera de cafe diluido.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8. Te (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Manzanilla / Verde / Canela.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9. Te chai vainilla (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frape $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Infusion especiada con toque de vainilla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("10. Chocomilk (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Bebida lactea con chocolate, fria.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("11. Leche (300ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Vaso de leche fria.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("12. Licuados (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Platano / Fresa / Frutas de temporada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("13. Jugos (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Verde / Betabel / Zanahoria.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("14. Jugo de naranja (300ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Naranja exprimida al momento.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("15. Refrescos (355ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Surtido de bebidas gaseosas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("16. Limonada (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Clasica y refrescante.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("17. Limonada mineral (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Con burbujas y un toque citrico.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("18. Te helado (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Te frio con notas citricas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("19. Aguas frescas (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Pepino limon / Fresa limon / Horchata / Jamaica.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("20. Horchata de fresa (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Horchata con toque de fresa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("21. Horchata cafe (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Horchata con un toque de cafe.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("22. Jamaica con fruta (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Agua de jamaica con fruta picada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("23. Agua embotellada (600ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $29");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Agua natural embotellada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("24. Agua mineral (600ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Agua con gas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-24)   25. Regresar al menu principal");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 25);

            if (opcion == 25)
            {
                return;
            }

            string nombreBebida = "";
            int precioBebida = 0;

            // bebidas opciones
            switch (opcion)
            {
                case 1:
                    nombreBebida = "Cafe americano (250ml)";
                    precioBebida = 60;
                    break;
                case 2:
                    nombreBebida = "Cafe descafeinado (250ml)";
                    precioBebida = 60;
                    break;
                case 3:
                    nombreBebida = "Cafe de olla (350ml)";
                    precioBebida = 65;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Como lo quiere?");
                    Console.WriteLine("1. Caliente  2. En las rocas  3. Frape");
                    Console.Write("Su eleccion: ");
                    int prepChai = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (prepChai == 1)
                    {
                        nombreBebida = "Cafe chai caliente (250ml)";
                        precioBebida = 65;
                    }
                    else if (prepChai == 2)
                    {
                        nombreBebida = "Cafe chai en las rocas (250ml)";
                        precioBebida = 75;
                    }
                    else
                    {
                        nombreBebida = "Cafe chai frape (250ml)";
                        precioBebida = 75;
                    }
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Que sabor?");
                    Console.WriteLine("1. Vainilla  2. Avellana  3. Original");
                    Console.Write("Su eleccion: ");
                    int saborCap = LeerEntero(1, 3);
                    Console.WriteLine("Como lo quiere?");
                    Console.WriteLine("1. Caliente  2. En las rocas  3. Frape");
                    Console.Write("Su eleccion: ");
                    int prepCap = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;

                    string sabor = "";
                    switch (saborCap)
                    {
                        case 1:
                            sabor = "vainilla";
                            break;
                        case 2:
                            sabor = "avellana";
                            break;
                        case 3:
                            sabor = "original";
                            break;
                    }

                    string prepCapNombre = "";
                    int prepCapPrecio = 0;
                    switch (prepCap)
                    {
                        case 1:
                            prepCapNombre = "caliente";
                            prepCapPrecio = 65;
                            break;
                        case 2:
                            prepCapNombre = "en las rocas";
                            prepCapPrecio = 75;
                            break;
                        case 3:
                            prepCapNombre = "frape";
                            prepCapPrecio = 75;
                            break;
                    }

                    nombreBebida = "Capuchino " + sabor + " " + prepCapNombre + " (250ml)";
                    precioBebida = prepCapPrecio;
                    break;
                case 6:
                    nombreBebida = "Chocolate caliente (350ml)";
                    precioBebida = 75;
                    break;
                case 7:
                    nombreBebida = "Agua para cafe (250ml)";
                    precioBebida = 50;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Que tipo de te?");
                    Console.WriteLine("1. Manzanilla  2. Verde  3. Canela");
                    Console.Write("Su eleccion: ");
                    int tipoTe = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (tipoTe)
                    {
                        case 1:
                            nombreBebida = "Te manzanilla (250ml)";
                            break;
                        case 2:
                            nombreBebida = "Te verde (250ml)";
                            break;
                        case 3:
                            nombreBebida = "Te canela (250ml)";
                            break;
                    }
                    precioBebida = 50;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Como lo quiere?");
                    Console.WriteLine("1. Caliente  2. En las rocas  3. Frape");
                    Console.Write("Su eleccion: ");
                    int prepTeC = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (prepTeC)
                    {
                        case 1:
                            nombreBebida = "Te chai vainilla caliente (250ml)";
                            precioBebida = 65;
                            break;
                        case 2:
                            nombreBebida = "Te chai vainilla en las rocas (250ml)";
                            precioBebida = 75;
                            break;
                        case 3:
                            nombreBebida = "Te chai vainilla frape (250ml)";
                            precioBebida = 75;
                            break;
                    }
                    break;
                case 10:
                    nombreBebida = "Chocomilk (400ml)";
                    precioBebida = 75;
                    break;
                case 11:
                    nombreBebida = "Leche (300ml)";
                    precioBebida = 50;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Que sabor de licuado?");
                    Console.WriteLine("1. Platano  2. Fresa  3. Frutas de temporada");
                    Console.Write("Su eleccion: ");
                    int sabLic = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (sabLic)
                    {
                        case 1:
                            nombreBebida = "Licuado de platano (400ml)";
                            break;
                        case 2:
                            nombreBebida = "Licuado de fresa (400ml)";
                            break;
                        case 3:
                            nombreBebida = "Licuado de frutas de temporada (400ml)";
                            break;
                    }
                    precioBebida = 75;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Que tipo de jugo?");
                    Console.WriteLine("1. Verde  2. Betabel  3. Zanahoria");
                    Console.Write("Su eleccion: ");
                    int tipoJugo = LeerEntero(1, 3);
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (tipoJugo)
                    {
                        case 1:
                            nombreBebida = "Jugo verde (400ml)";
                            break;
                        case 2:
                            nombreBebida = "Jugo de betabel (400ml)";
                            break;
                        case 3:
                            nombreBebida = "Jugo de zanahoria (400ml)";
                            break;
                    }
                    precioBebida = 70;
                    break;
                case 14:
                    nombreBebida = "Jugo de naranja (300ml)";
                    precioBebida = 60;
                    break;
                case 15:
                    nombreBebida = "Refresco (355ml)";
                    precioBebida = 50;
                    break;
                case 16:
                    nombreBebida = "Limonada (400ml)";
                    precioBebida = 55;
                    break;
                case 17:
                    nombreBebida = "Limonada mineral (400ml)";
                    precioBebida = 60;
                    break;
                case 18:
                    nombreBebida = "Te helado (400ml)";
                    precioBebida = 55;
                    break;
                case 19:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Que sabor de agua fresca?");
                    Console.WriteLine("1. Pepino limon  2. Fresa limon  3. Horchata  4. Jamaica");
                    Console.Write("Su eleccion: ");
                    int sabAgua = LeerEntero(1, 4);
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (sabAgua)
                    {
                        case 1:
                            nombreBebida = "Agua fresca de pepino limon (400ml)";
                            break;
                        case 2:
                            nombreBebida = "Agua fresca de fresa limon (400ml)";
                            break;
                        case 3:
                            nombreBebida = "Agua fresca de horchata (400ml)";
                            break;
                        case 4:
                            nombreBebida = "Agua fresca de jamaica (400ml)";
                            break;
                    }
                    precioBebida = 60;
                    break;
                case 20:
                    nombreBebida = "Horchata de fresa (400ml)";
                    precioBebida = 70;
                    break;
                case 21:
                    nombreBebida = "Horchata cafe (400ml)";
                    precioBebida = 70;
                    break;
                case 22:
                    nombreBebida = "Jamaica con fruta (400ml)";
                    precioBebida = 65;
                    break;
                case 23:
                    nombreBebida = "Agua embotellada (600ml)";
                    precioBebida = 29;
                    break;
                case 24:
                    nombreBebida = "Agua mineral (600ml)";
                    precioBebida = 50;
                    break;
            }

            if (nombreBebida != "")
            {
                AgregarATicket(nombreBebida, precioBebida);
                Confirmado();
            }
        }

        // especialidades
        static void MenuEspecialidades()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Especialidades Don Simon - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que seccion desea ver?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Especialidades (disponibles toda la semana)");
            Console.WriteLine("2. Exclusivos de fin de semana");
            Console.WriteLine("3. Tienes un evento proximo? Ver informacion");
            Console.WriteLine("4. Regresar al menu principal");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int subMenu = LeerEntero(1, 4);
            Console.ForegroundColor = ConsoleColor.White;

            switch (subMenu)
            {
                case 1:
                    MenuEspecialidadesNormales();
                    break;
                case 2:
                    MenuFinDeSemana();
                    break;
                case 3:
                    MostrarInfoEvento();
                    break;
                case 4:
                    return;
            }
        }

        static void MenuEspecialidadesNormales()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Especialidades Don Simon - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Camarones rancheros");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Camarones (150gr) rancheros, acompanados de frijol refrito");
            Console.WriteLine("   y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Marlin sinaloense");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Marlin (150gr) a la mexicana, acompanado de frijol refrito");
            Console.WriteLine("   y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Lengua de res");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Medallones de lengua de res (150gr) en salsa ranchera, verde, roja");
            Console.WriteLine("   o poblana, acompanada de frijol refrito y dos quesadillas.");
            Console.WriteLine("   Tambien disponible en caldo (sin frijol ni quesadillas).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Bistec ranchero");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Bistec de arrachera (200gr), acompanado de frijol refrito");
            Console.WriteLine("   y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Higado encebollado / ranchero");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $160");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Higado (200gr), acompanado de frijol refrito y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-5)   6. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 6);

            if (opcion == 6)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Camarones rancheros";
                    precio = 200;
                    break;
                case 2:
                    nombre = "Marlin sinaloense";
                    precio = 200;
                    break;
                case 3:
                    nombre = "Lengua de res";
                    precio = 240;
                    break;
                case 4:
                    nombre = "Bistec ranchero";
                    precio = 240;
                    break;
                case 5:
                    nombre = "Higado encebollado / ranchero";
                    precio = 160;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuFinDeSemana()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - Exclusivos de fin de semana - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Orden de menudo tradicional");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Menudo tradicional preparado con receta de la casa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Orden de menudo guisado");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Menudo guisado al estilo Don Simon.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Que desea ordenar? (1-2)   3. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Su eleccion: ");

            int opcion = LeerEntero(1, 3);

            if (opcion == 3)
            {
                return;
            }

            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Menudo tradicional";
                    precio = 175;
                    break;
                case 2:
                    nombre = "Menudo guisado";
                    precio = 185;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // info del restaurante
        static void MostrarInfoEvento()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     Tienes algun evento proximo?       ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  La Casa de Don Simon ofrece servicio");
            Console.WriteLine("  para eventos y reuniones especiales.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Pregunta por nuestros paquetes al:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("        667 852 97 96");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Horario de atencion:");
            Console.WriteLine("  Martes a domingo de 7:30 a.m. a 2:00 p.m.");
            Console.WriteLine("  Descansamos los lunes.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Presione ENTET para regresar...");
            Console.ReadLine();
        }
    }
}
