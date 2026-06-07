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
        static List<string> ticketNombres = new List<string>();
        static List<int> ticketPrecios = new List<int>();
        static int totalCuenta = 0;

        // saber el ancho de la pantalla
        static int AnchoConsola()
        {
            return Console.WindowWidth;
        }

        // escribir varios espacios
        static void Espacios(int cuantos)
        {
            for (int i = 0; i < cuantos; i++)
            {
                Console.Write(" ");
            }
        }

        // centrar un texto y bajar de linea
        static void Centrar(string texto)
        {
            int antes = (AnchoConsola() - texto.Length) / 2;
            if (antes < 0)
            {
                antes = 0;
            }
            Espacios(antes);
            Console.WriteLine(texto);
        }

        // centrar un texto sin bajar de linea
        static void CentrarSinSalto(string texto)
        {
            int antes = (AnchoConsola() - texto.Length) / 2;
            if (antes < 0)
            {
                antes = 0;
            }
            Espacios(antes);
            Console.Write(texto);
        }

        // calcular el espacio para acomodar la lista de platillos en columna
        static string Sangria()
        {
            int antes = (AnchoConsola() - 100) / 2;
            if (antes < 4)
            {
                antes = 4;
            }
            string espacios = "";
            for (int i = 0; i < antes; i++)
            {
                espacios = espacios + " ";
            }
            return espacios;
        }

        // dibujar un titulo grande dentro de un marco centrado
        static void TituloGrande(string texto)
        {
            // separar las letras para que se vea grande
            string grande = "";
            for (int i = 0; i < texto.Length; i++)
            {
                grande = grande + char.ToUpper(texto[i]);
                if (i < texto.Length - 1)
                {
                    grande = grande + " ";
                }
            }

            int adentro = grande.Length + 8;

            // armar el borde de arriba y abajo
            string borde = "";
            for (int i = 0; i < adentro; i++)
            {
                borde = borde + "═";
            }

            // centrar el texto dentro del marco
            int sobran = adentro - grande.Length;
            int izq = sobran / 2;
            int der = sobran - izq;
            string espIzq = "";
            for (int i = 0; i < izq; i++)
            {
                espIzq = espIzq + " ";
            }
            string espDer = "";
            for (int i = 0; i < der; i++)
            {
                espDer = espDer + " ";
            }

            int largoCaja = adentro + 2;
            int margen = (AnchoConsola() - largoCaja) / 2;
            if (margen < 0)
            {
                margen = 0;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Espacios(margen);
            Console.WriteLine("╔" + borde + "╗");
            Espacios(margen);
            Console.Write("║" + espIzq);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(grande);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(espDer + "║");
            Espacios(margen);
            Console.WriteLine("╚" + borde + "╝");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // leer un numero y revisar que sea valido
        static int LeerEntero(int minimo, int maximo)
        {
            int numero = 0;
            bool sirve = false;

            while (sirve == false)
            {
                string texto = Console.ReadLine();
                bool sePudo = int.TryParse(texto, out numero);

                if (sePudo == true && numero >= minimo && numero <= maximo)
                {
                    sirve = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    CentrarSinSalto("Escribe un número del " + minimo + " al " + maximo + ": ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }

            return numero;
        }

        // preguntar la opcion con el texto centrado
        static int PreguntarOpcion(int minimo, int maximo)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CentrarSinSalto("Su elección: ");
            int opcion = LeerEntero(minimo, maximo);
            Console.ForegroundColor = ConsoleColor.White;
            return opcion;
        }

        // agregar un platillo al ticket
        static void AgregarATicket(string nombre, int precio)
        {
            ticketNombres.Add(nombre);
            ticketPrecios.Add(precio);
            totalCuenta = totalCuenta + precio;
        }

        // avisar que se agrego al ticket
        static void Confirmado()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar(">> ¡Perfecto! Se agregó a tu ticket.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Presiona ENTER para continuar...)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // poner los acentos y la ñ
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            PantallaBienvenida();
            MenuPrincipal();
            ImprimirTicket();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("¡Gracias por su visita, vuelva pronto!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Presiona ENTER para cerrar...)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void PantallaBienvenida()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("· ° · ───────────────────────────── · ° ·");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("¡ B I E N V E N I D O S !");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("· ° · ───────────────────────────── · ° ·");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();

            TituloGrande("La Casa de Don Simón");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Tradición y ambiente familiar");
            Console.ForegroundColor = ConsoleColor.White;
            Centrar("Servicio para eventos y reuniones");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("Martes a domingo   7:30 a.m. - 2:00 p.m.");
            Centrar("Av. Antonio Rosales 552 ote.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("Presiona ENTER para ver nuestro menú...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void MenuPrincipal()
        {
            int opcion = 0;

            // repetir el menu hasta que elija salir
            while (opcion != 11)
            {
                Console.Clear();
                Console.WriteLine();

                TituloGrande("Menú");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Centrar("La Casa de Don Simón");
                Console.ForegroundColor = ConsoleColor.White;
                Centrar("Tradición y ambiente familiar");
                Console.ForegroundColor = ConsoleColor.Red;
                Centrar("Martes a domingo  7:30 a.m. - 2:00 p.m.");
                Centrar("Av. Antonio Rosales 552 ote.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Centrar("───────────  Elige una categoría  ───────────");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Centrar("1.  Entradas");
                Centrar("2.  Chilaquiles");
                Centrar("3.  Burritos");
                Centrar("4.  Huevos");
                Centrar("5.  Desayunos completos");
                Centrar("6.  Los tradicionales");
                Centrar("7.  Sándwiches");
                Centrar("8.  Menú kids");
                Centrar("9.  Bebidas para iniciar el día");
                Centrar("10. Especialidades Don Simón");
                Console.ForegroundColor = ConsoleColor.Red;
                Centrar("11. Terminar y ver mi ticket");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Centrar("Escribe el número de la categoría para elegir tu platillo");
                Console.ForegroundColor = ConsoleColor.White;

                // preguntar la categoria
                opcion = PreguntarOpcion(1, 11);

                // mandar a cada menu
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

        static void MenuEntradas()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Entradas");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Avena (350ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Comienza tu día con un toque de calidez y nutrición con nuestra reconfortante avena acompañada de manzana verde, plátano, nuez y pasas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Kekis (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $110");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Los tradicionales, deléitate con los favoritos de Don Simón.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Son el desayuno perfecto para empezar tu día con una sonrisa. ¡Un clásico favorito!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Pan Francés");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 rebanadas partidas a la mitad acompañadas de mermelada de la casa y una lluvia de azúcar glass.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Fruta de temporada Ch (300gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "6. Fruta de temporada Gd (500gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "7. Guacamole (150gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Con un toque de tomate, cebolla y cilantro, disfruta de este clásico favorito que te hará desear más con cada bocado.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "8. Queso fundido (250gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Tradicional queso tipo gouda gratinado.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "9. Queso fundido con arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Tradicional queso tipo gouda gratinado con arrachera.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "10. Queso fundido con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Tradicional queso tipo gouda gratinado con chorizo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "11. Panela asada con frijoles de la olla");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Panela asada (200gr), bañada con salsa verde, con un toque de cilantro y acompañada con frijol de la olla.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "12. Gorditas con asientos (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Acompañadas con salsa pico de gallo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "13. Colache (200gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $135");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Calabacita picada con verduras gratinadas y acompañado de frijol refrito.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "14. Ejotes o nopales con verdura (200gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Mezclados con verduras, salteados con mantequilla saborizada y acompañados de frijoles refritos.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (15 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 15);

            // si elige regresar
            if (opcion == 15)
            {
                return;
            }

            // ver que eligio
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
                    nombre = "Pan Francés";
                    precio = 125;
                    break;
                case 5:
                    nombre = "Fruta de temporada Ch (300gr)";
                    precio = 70;
                    break;
                case 6:
                    nombre = "Fruta de temporada Gd (500gr)";
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

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuChilaquiles()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Chilaquiles");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Chilaquiles rojos / verdes");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Crujientes totopos bañados en salsa roja o verde, con crema, queso y cebolla.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Chilaquiles suizos / poblanos");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Gratinados o bañados en salsa poblana, con crema, queso y cebolla.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("- - - Puedes agregarle un extra - - -");
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Con huevo  +$25        Con pollo  +$35");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 3);

            // si elige regresar
            if (opcion == 3)
            {
                return;
            }

            // ver que eligio
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

            // preguntar por el huevo
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Desea agregarle huevo por $25?   (1 = Sí   2 = No)");
            Console.ForegroundColor = ConsoleColor.White;
            int huevo = PreguntarOpcion(1, 2);
            if (huevo == 1)
            {
                // sumar el huevo
                precio = precio + 25;
                nombre = nombre + " + huevo";
            }

            // preguntar por el pollo
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Desea agregarle pollo por $35?   (1 = Sí   2 = No)");
            Console.ForegroundColor = ConsoleColor.White;
            int pollo = PreguntarOpcion(1, 2);
            if (pollo == 1)
            {
                // sumar el pollo
                precio = precio + 35;
                nombre = nombre + " + pollo";
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuBurritos()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Burritos");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Los precios son por pieza)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Machaca (50gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Burrito de machaca acompañado con salsa pico de gallo y guacamole.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Bistec de arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Burrito de bistec de arrachera acompañado con salsa pico de gallo y guacamole.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Papas con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Burrito de papas con chorizo acompañado con salsa pico de gallo y guacamole.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Chicharrón (80gr)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $95");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Burrito de chicharrón acompañado con salsa pico de gallo y guacamole.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Frijol con queso fresco");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Burrito de frijol con queso fresco acompañado con salsa pico de gallo y guacamole.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (6 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 6);

            // si elige regresar
            if (opcion == 6)
            {
                return;
            }

            // ver que eligio
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
                    nombre = "Burrito de chicharrón (80gr)";
                    precio = 95;
                    break;
                case 5:
                    nombre = "Burrito de frijol con queso fresco";
                    precio = 60;
                    break;
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuHuevos()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Huevos");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Huevos o claras al gusto");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   A elegir: jamón, salchicha, tocino, nopales, mexicanos, papas, chorizo, ejotes, o sopitas. A elegir: chilorio, machaca o chicharrón.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Huevos campesinos");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo estrellado montados sobre jamón y tortilla frita, bañados en salsa de la casa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Huevos a la tambora");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $180");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo estrellado montados sobre chilorio natural y tortilla frita, bañados con salsa ranchera.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Montaditos sinaloenses");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo estrellado montados sobre pan de caja dorado con mantequilla, una cama de aguacate, coronado con tiras de tocino, acompañados de ensalada fresca con queso panela.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Huevos divorciados");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo estrellado montados sobre jamón y gordita frita, uno bañado en salsa verde y otro en salsa roja.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "6. Huevos arrieros");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo bañados con salsa arriera, y puntas de arrachera (80gr) encebolladas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "7. Omelette Don Simón");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Relleno de espinaca, champiñón, mantequilla saborizada y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "8. Omelette de 3 quesos");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Relleno de mezcla de 3 quesos, jamón y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "9. Omelette de camarón");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Relleno de camarón (80gr), con queso gratinado, bañado en salsa con crema de chile morrón rojo y acompañado de papas fritas en cuadros.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "10. Omelette poblano");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Relleno de rajas poblanas con queso, elote y cebolla, bañado en salsa poblana y acompañado de papas fritas en cuadros.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "11. Omelette culichi");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Relleno de chilorio (80gr) con queso, bañado en salsa ranchera y acompañado de papas fritas en cuadros.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("Todos los desayunos van acompañados de frijoles refritos.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (12 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 12);

            // si elige regresar
            if (opcion == 12)
            {
                return;
            }

            // ver que eligio
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
                    nombre = "Omelette Don Simón";
                    precio = 179;
                    break;
                case 8:
                    nombre = "Omelette de 3 quesos";
                    precio = 179;
                    break;
                case 9:
                    nombre = "Omelette de camarón";
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

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuDesayunosCompletos()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Desayunos completos");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Combinación poblana");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, rajas poblanas con queso, elote y cebolla, tamal natural, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Combinación del campo");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, papas con verdura gratinadas, chilaquiles verdes, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Combinación mar y tierra");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, camarón (80gr) ranchero, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Combinación sinaloense");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, chilorio (80gr) a la mexicana, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Combinación sonora");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, machaca (50gr) a la mexicana, chilaquiles rojos, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "6. Combinación Cosalá");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, colache con verdura, queso gratinado, tamal frito, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "7. Combinación mi rancho");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, chorizo (80gr) con papa, frijol refrito, dos quesadillas y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "8. Combinación Don Simón");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Tamal gratinado, chilaquiles poblanos, chicharrones (80gr) a la mexicana, frijol refrito y coronado con aguacate.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "9. Combinación americana");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 piezas de hot cakes, 2 piezas de huevos estrellados y tiras de tocino.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (10 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 10);

            // si elige regresar
            if (opcion == 10)
            {
                return;
            }

            // ver que eligio
            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Combinación poblana";
                    precio = 175;
                    break;
                case 2:
                    nombre = "Combinación del campo";
                    precio = 175;
                    break;
                case 3:
                    nombre = "Combinación mar y tierra";
                    precio = 210;
                    break;
                case 4:
                    nombre = "Combinación sinaloense";
                    precio = 185;
                    break;
                case 5:
                    nombre = "Combinación sonora";
                    precio = 185;
                    break;
                case 6:
                    nombre = "Combinación Cosalá";
                    precio = 175;
                    break;
                case 7:
                    nombre = "Combinación mi rancho";
                    precio = 200;
                    break;
                case 8:
                    nombre = "Combinación Don Simón";
                    precio = 185;
                    break;
                case 9:
                    nombre = "Combinación americana";
                    precio = 170;
                    break;
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuTradicionales()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Los tradicionales");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Tacos dorados (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De maíz, rellenas de papa (100gr) con carne deshebrada (50gr), coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañados de consomé de res.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Tostadas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Gorditas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Enchiladas verdes o rojas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr) coronadas con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañadas de frijoles refritos.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Enchiladas suizas o poblanas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr), gratinadas, coronadas con aguacate y acompañadas de frijoles refritos.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "6. Orden de asado");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Papa (100gr) y carne (100gr) en forma de cuadros, coronado con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañado de consomé de res.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "7. Pieza taco, tostada o gordita");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Pieza individual de tu antojo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (8 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 8);

            // si elige regresar
            if (opcion == 8)
            {
                return;
            }

            // ver que eligio
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

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuSandwiches()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Sándwiches");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Sándwich especial");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Sándwich de pechuga de pollo (100gr), tocino y jamón, gratinado por encima, acompañado de papas fritas en cuadros y un mix de lechuga. ¡Delicioso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Club sándwich");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Sándwich de jamón y queso tipo americano, lechuga, tomate, aguacate, acompañado de papas a la francesa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 3);

            // si elige regresar
            if (opcion == 3)
            {
                return;
            }

            // ver que eligio
            string nombre = "";
            int precio = 0;

            switch (opcion)
            {
                case 1:
                    nombre = "Sándwich especial";
                    precio = 185;
                    break;
                case 2:
                    nombre = "Club sándwich";
                    precio = 140;
                    break;
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuKids()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Menú kids");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Salchipulpos con huevo");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   2 salchichas cortadas en forma de pulpo y 2 piezas de huevo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Mini hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Con porción de plátano y mermelada de fresa artesanal.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Combinación kids");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   3 mini hot cakes, 2 piezas de huevo revuelto y salchipulpo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Deditos \"Pío Pío\" (6 piezas)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   De pechuga de pollo (120gr), empanizados, acompañados de papas a la francesa (80gr) y de aderezo kétchup.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (5 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 5);

            // si elige regresar
            if (opcion == 5)
            {
                return;
            }

            // ver que eligio
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
                    nombre = "Combinación kids";
                    precio = 140;
                    break;
                case 4:
                    nombre = "Deditos Pío Pío (6 piezas)";
                    precio = 140;
                    break;
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuBebidas()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Bebidas");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Café americano (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Café clásico preparado al momento, intenso y aromático.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Café descafeinado (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Sabor y cuerpo del café con menos cafeína.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Café de olla (350ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Receta tradicional con notas de canela y piloncillo.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Café Chai (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Mezcla especiada y cremosa estilo chai.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Capuchino vainilla / avellana / original (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Espresso con leche espumosa, elige tu sabor.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "6. Chocolate caliente (350ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Cacao cremoso y dulce.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "7. Agua para café (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Preparación ligera de café diluido.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "8. Té (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   A elegir: manzanilla, verde o canela.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "9. Té Chai Vainilla (250ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Infusión especiada con un toque de vainilla.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "10. Chocomilk (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Bebida láctea con chocolate, bien fría.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "11. Leche (300ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Vaso de leche fría.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "12. Licuados (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   A elegir: plátano, fresa o frutas de temporada.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "13. Jugos (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   A elegir: verde, betabel o zanahoria.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "14. Jugo de naranja (300ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Naranja exprimida al momento.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "15. Refrescos (355ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Surtido de bebidas gaseosas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "16. Limonada (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Clásica y refrescante.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "17. Limonada mineral (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Con burbujas y un toque cítrico.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "18. Té helado (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Té frío con notas cítricas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "19. Aguas frescas (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   A elegir: pepino limón, fresa limón, horchata o jamaica.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "20. Horchata de fresa (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Horchata con un rico toque de fresa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "21. Horchata café (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Horchata con un toque de café.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "22. Jamaica con fruta (400ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Agua de jamaica con fruta picada.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "23. Agua embotellada (600ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $29");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Agua natural embotellada.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "24. Agua mineral (600ml)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Agua mineral con gas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (25 = Regresar al menú principal)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar la bebida
            int opcion = PreguntarOpcion(1, 25);

            // si elige regresar
            if (opcion == 25)
            {
                return;
            }

            // ver que eligio
            string nombreBebida = "";
            int precioBebida = 0;

            switch (opcion)
            {
                case 1:
                    nombreBebida = "Café americano (250ml)";
                    precioBebida = 60;
                    break;
                case 2:
                    nombreBebida = "Café descafeinado (250ml)";
                    precioBebida = 60;
                    break;
                case 3:
                    nombreBebida = "Café de olla (350ml)";
                    precioBebida = 65;
                    break;
                case 4:
                    // preguntar como lo quiere
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int prepChai = PreguntarOpcion(1, 3);
                    switch (prepChai)
                    {
                        case 1:
                            nombreBebida = "Café Chai caliente (250ml)";
                            precioBebida = 65;
                            break;
                        case 2:
                            nombreBebida = "Café Chai en las rocas (250ml)";
                            precioBebida = 75;
                            break;
                        case 3:
                            nombreBebida = "Café Chai frapé (250ml)";
                            precioBebida = 75;
                            break;
                    }
                    break;
                case 5:
                    // preguntar el sabor
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Qué sabor?   (1 = Vainilla   2 = Avellana   3 = Original)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int saborCap = PreguntarOpcion(1, 3);

                    // preguntar como lo quiere
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int prepCap = PreguntarOpcion(1, 3);

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

                    string preparacion = "";
                    int precioCap = 0;
                    switch (prepCap)
                    {
                        case 1:
                            preparacion = "caliente";
                            precioCap = 65;
                            break;
                        case 2:
                            preparacion = "en las rocas";
                            precioCap = 75;
                            break;
                        case 3:
                            preparacion = "frapé";
                            precioCap = 75;
                            break;
                    }

                    nombreBebida = "Capuchino " + sabor + " " + preparacion + " (250ml)";
                    precioBebida = precioCap;
                    break;
                case 6:
                    nombreBebida = "Chocolate caliente (350ml)";
                    precioBebida = 75;
                    break;
                case 7:
                    nombreBebida = "Agua para café (250ml)";
                    precioBebida = 50;
                    break;
                case 8:
                    // preguntar el tipo de te
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Qué tipo de té?   (1 = Manzanilla   2 = Verde   3 = Canela)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int tipoTe = PreguntarOpcion(1, 3);
                    switch (tipoTe)
                    {
                        case 1:
                            nombreBebida = "Té de manzanilla (250ml)";
                            break;
                        case 2:
                            nombreBebida = "Té verde (250ml)";
                            break;
                        case 3:
                            nombreBebida = "Té de canela (250ml)";
                            break;
                    }
                    precioBebida = 50;
                    break;
                case 9:
                    // preguntar como lo quiere
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int prepTeChai = PreguntarOpcion(1, 3);
                    switch (prepTeChai)
                    {
                        case 1:
                            nombreBebida = "Té Chai Vainilla caliente (250ml)";
                            precioBebida = 65;
                            break;
                        case 2:
                            nombreBebida = "Té Chai Vainilla en las rocas (250ml)";
                            precioBebida = 75;
                            break;
                        case 3:
                            nombreBebida = "Té Chai Vainilla frapé (250ml)";
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
                    // preguntar el sabor del licuado
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Qué sabor de licuado?   (1 = Plátano   2 = Fresa   3 = Frutas de temporada)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int sabLicuado = PreguntarOpcion(1, 3);
                    switch (sabLicuado)
                    {
                        case 1:
                            nombreBebida = "Licuado de plátano (400ml)";
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
                    // preguntar el tipo de jugo
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Qué tipo de jugo?   (1 = Verde   2 = Betabel   3 = Zanahoria)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int tipoJugo = PreguntarOpcion(1, 3);
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
                    nombreBebida = "Té helado (400ml)";
                    precioBebida = 55;
                    break;
                case 19:
                    // preguntar el sabor del agua fresca
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centrar("¿Qué sabor de agua fresca?");
                    Centrar("(1 = Pepino limón   2 = Fresa limón   3 = Horchata   4 = Jamaica)");
                    Console.ForegroundColor = ConsoleColor.White;
                    int sabAgua = PreguntarOpcion(1, 4);
                    switch (sabAgua)
                    {
                        case 1:
                            nombreBebida = "Agua fresca de pepino limón (400ml)";
                            break;
                        case 2:
                            nombreBebida = "Agua fresca de fresa limón (400ml)";
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
                    nombreBebida = "Horchata café (400ml)";
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

            // agregar al ticket
            AgregarATicket(nombreBebida, precioBebida);
            Confirmado();
        }

        static void MenuEspecialidades()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Especialidades Don Simón");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué sección desea ver?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("1. Especialidades (toda la semana)");
            Centrar("2. Exclusivos de fin de semana");
            Centrar("3. ¿Tienes un evento próximo?");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("4. Regresar al menú principal");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // preguntar la seccion
            int subMenu = PreguntarOpcion(1, 4);

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
            Console.WriteLine();
            TituloGrande("Especialidades");
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Camarones rancheros");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Camarones (150gr) rancheros, acompañados de frijol refrito y dos quesadillas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Marlin sinaloense");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Marlin (150gr) a la mexicana, acompañado de frijol refrito y dos quesadillas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "3. Lengua de res");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Medallones de lengua de res (150gr) en salsa ranchera, verde, roja o poblana, acompañada de frijol refrito y dos quesadillas. También disponible en caldo (sin frijol ni quesadillas).");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "4. Bistec ranchero");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Bistec de arrachera (200gr), acompañado de frijol refrito y dos quesadillas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "5. Hígado encebollado / ranchero");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $160");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Hígado (200gr), acompañado de frijol refrito y dos quesadillas.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (6 = Regresar)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 6);

            // si elige regresar
            if (opcion == 6)
            {
                return;
            }

            // ver que eligio
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
                    nombre = "Hígado encebollado / ranchero";
                    precio = 160;
                    break;
            }

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuFinDeSemana()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("Fin de semana");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Exclusivos de sábado y domingo)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            string s = Sangria();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "1. Orden de menudo tradicional");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Menudo tradicional preparado con la receta de la casa.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s + "2. Orden de menudo guisado");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s + "   Menudo guisado al estilo Don Simón.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Qué desea ordenar?   (3 = Regresar)");
            Console.ForegroundColor = ConsoleColor.White;

            // preguntar el platillo
            int opcion = PreguntarOpcion(1, 3);

            // si elige regresar
            if (opcion == 3)
            {
                return;
            }

            // ver que eligio
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

            // agregar al ticket
            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MostrarInfoEvento()
        {
            Console.Clear();
            Console.WriteLine();
            TituloGrande("¿Tienes un evento?");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("¿Tienes algún evento próximo?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Centrar("La Casa de Don Simón ofrece servicio");
            Centrar("para eventos y reuniones especiales.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Centrar("Pregunta por nuestros paquetes al:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Tel:  667 852 97 96");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("Abierto al público de martes a domingo");
            Centrar("7:30 a.m. a 2:00 p.m.   (descansamos los lunes)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("Presiona ENTER para regresar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void ImprimirTicket()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            TituloGrande("Tu ticket");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("La Casa de Don Simón");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("Av. Antonio Rosales 552 ote.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Centrar("──────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            string s = Sangria();

            // si no pidio nada
            if (ticketNombres.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centrar("No se agregó ningún platillo a la orden.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            else
            {
                // recorrer las listas y mostrar cada platillo
                for (int i = 0; i < ticketNombres.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(s + "- " + ticketNombres[i]);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("   $" + ticketPrecios[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Centrar("──────────────────────────────────────────────");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                // mostrar el total
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Centrar("TOTAL A PAGAR:   $" + totalCuenta);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}
