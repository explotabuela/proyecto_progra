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
        // aqui guardo lo que pide el cliente
        static List<string> ticketNombres = new List<string>();
        static List<int> ticketPrecios = new List<int>();
        static int totalCuenta = 0;

        // margen para que el texto no quede pegado a la orilla
        static string margen = "      ";

        // ===================================================================
        //  METODOS DE DECORACION
        // ===================================================================

        // regresa el ancho de la pantalla (si no se puede, usa 80)
        static int AnchoConsola()
        {
            int ancho = 80;
            try
            {
                if (Console.WindowWidth > 0)
                {
                    ancho = Console.WindowWidth;
                }
            }
            catch
            {
                ancho = 80;
            }
            return ancho;
        }

        // limpia la pantalla (si no se puede, no pasa nada)
        static void Limpiar()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                // si no hay consola real solo seguimos
            }
        }

        // este metodo centra un texto en la pantalla
        // cuenta cuantos espacios necesita poner antes para que quede en medio
        static void Centrar(string texto)
        {
            int anchoConsola = AnchoConsola();
            int espaciosAntes = (anchoConsola - texto.Length) / 2;

            if (espaciosAntes < 0)
            {
                espaciosAntes = 0;
            }

            for (int i = 0; i < espaciosAntes; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(texto);
        }

        // igual que centrar pero no baja de linea (sirve para escribir y luego teclear)
        static void CentrarSinSalto(string texto)
        {
            int anchoConsola = AnchoConsola();
            int espaciosAntes = (anchoConsola - texto.Length) / 2;

            if (espaciosAntes < 0)
            {
                espaciosAntes = 0;
            }

            for (int i = 0; i < espaciosAntes; i++)
            {
                Console.Write(" ");
            }
            Console.Write(texto);
        }

        // este metodo hace un titulo GRANDE dentro de un marco bonito
        // separo cada letra con un espacio para que la palabra se vea mas grande
        static void TituloGrande(string texto)
        {
            string grande = "";
            for (int i = 0; i < texto.Length; i++)
            {
                grande = grande + char.ToUpper(texto[i]);
                if (i < texto.Length - 1)
                {
                    grande = grande + " ";
                }
            }

            // espacios de relleno a cada lado del texto
            string relleno = "    ";
            string interior = relleno + grande + relleno;

            // armo la linea del borde del mismo largo que el interior
            string borde = "";
            for (int i = 0; i < interior.Length; i++)
            {
                borde = borde + "═";
            }

            // ----- linea de arriba -----
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Centrar("╔" + borde + "╗");

            // ----- linea del medio (marco cyan + letras amarillas) -----
            string lineaMedio = "║" + interior + "║";
            int espaciosAntes = (AnchoConsola() - lineaMedio.Length) / 2;
            if (espaciosAntes < 0)
            {
                espaciosAntes = 0;
            }
            for (int i = 0; i < espaciosAntes; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("║" + relleno);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(grande);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(relleno + "║");

            // ----- linea de abajo -----
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Centrar("╚" + borde + "╝");
            Console.ResetColor();
        }

        // una linea decorada para separar cosas
        static void LineaDecorada()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Centrar("✦  ·  ·  ─────────────────────────────────  ·  ·  ✦");
            Console.ResetColor();
        }

        // ===================================================================
        //  METODOS DE LOGICA
        // ===================================================================

        // este metodo lee numeros y revisa que esten en el rango
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
                    Console.Write(margen + "Número no válido, escribe del " + minimo + " al " + maximo + ": ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            return numero;
        }

        // pide la opcion mostrando "Su elección" justo en el centro de la pantalla
        static int LeerEnteroCentrado(int minimo, int maximo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            CentrarSinSalto("Su elección: ");
            return LeerEntero(minimo, maximo);
        }

        // este metodo agrega el platillo al ticket y suma el precio
        static void AgregarATicket(string nombre, int precio)
        {
            ticketNombres.Add(nombre);
            ticketPrecios.Add(precio);
            totalCuenta = totalCuenta + precio;
        }

        // mensaje despues de elegir algo
        static void Confirmado()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("✓ ¡Perfecto! Se agregó a tu ticket.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Presiona ENTER para continuar...)");
            Console.ResetColor();
            Console.ReadLine();
        }

        // ===================================================================
        //  PROGRAMA PRINCIPAL
        // ===================================================================

        static void Main(string[] args)
        {
            // esto sirve para que se vean bien los acentos y la letra ñ
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            PantallaBienvenida();
            MenuPrincipal();
            ImprimirTicket();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Centrar("¡Gracias por su visita, vuelva pronto!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Centrar("(Presiona ENTER para cerrar...)");
            Console.ResetColor();
            Console.ReadLine();
        }

        // pantalla bonita de bienvenida
        static void PantallaBienvenida()
        {
            Limpiar();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("★ ° · . ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ . · ° ★");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("¡ B I E N V E N I D O S !");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("★ ° · . ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ . · ° ★");
            Console.WriteLine();
            Console.WriteLine();

            TituloGrande("La Casa de Don Simón");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("Tradición y ambiente familiar");
            Centrar("Servicio para eventos y reuniones");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("Martes a domingo   7:30 a.m. - 2:00 p.m.");
            Centrar("Av. Antonio Rosales 552 ote.");
            Console.WriteLine();

            LineaDecorada();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Presiona ENTER para ver nuestro menú...");
            Console.ResetColor();
            Console.ReadLine();
        }

        static void MenuPrincipal()
        {
            int opcion = 0;

            while (opcion != 11)
            {
                Limpiar();
                Console.WriteLine();

                // titulo grande del menu
                TituloGrande("Menú");
                Console.WriteLine();

                // datos del restaurante en color bonito
                Console.ForegroundColor = ConsoleColor.Magenta;
                Centrar("La Casa de Don Simón");
                Centrar("Tradición y ambiente familiar");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Centrar("Servicio para eventos y reuniones");
                Centrar("Martes a domingo  7:30 a.m. - 2:00 p.m.");
                Centrar("Av. Antonio Rosales 552 ote.");
                Console.WriteLine();

                LineaDecorada();
                Console.WriteLine();

                // las categorias del menu
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
                Console.WriteLine();

                // instruccion para elegir
                Console.ForegroundColor = ConsoleColor.Cyan;
                Centrar("Escribe el número de la categoría para elegir tu platillo");
                Console.WriteLine();

                opcion = LeerEnteroCentrado(1, 11);
                Console.ResetColor();

                // mando a cada menu segun lo que eligio
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

        // ===================================================================
        //  ENTRADAS
        // ===================================================================
        static void MenuEntradas()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Entradas");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Avena (350ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Comienza tu día con un toque de calidez y nutrición con nuestra reconfortante avena acompañada de manzana verde, plátano, nuez y pasas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Kekis (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $110");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Los tradicionales, deléitate con los favoritos de Don Simón.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Son el desayuno perfecto para empezar tu día con una sonrisa. ¡Un clásico favorito!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Pan Francés");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 rebanadas partidas a la mitad acompañadas de mermelada de la casa y una lluvia de azúcar glass.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Fruta de temporada Ch (300gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "6. Fruta de temporada Gd (500gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "7. Guacamole (150gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Con un toque de tomate, cebolla y cilantro, disfruta de este clásico favorito que te hará desear más con cada bocado.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "8. Queso fundido (250gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Tradicional queso tipo gouda gratinado.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "9. Queso fundido con arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Tradicional queso tipo gouda gratinado con arrachera.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "10. Queso fundido con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Tradicional queso tipo gouda gratinado con chorizo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "11. Panela asada con frijoles de la olla");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Panela asada (200gr), bañada con salsa verde, con un toque de cilantro y acompañada con frijol de la olla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "12. Gorditas con asientos (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Acompañadas con salsa pico de gallo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "13. Colache (200gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $135");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Calabacita picada con verduras gratinadas y acompañado de frijol refrito.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "14. Ejotes o nopales con verdura (200gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Mezclados con verduras, salteados con mantequilla saborizada y acompañados de frijoles refritos.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (15 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 15);
            Console.ResetColor();

            if (opcion == 15)
            {
                return;
            }

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

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  CHILAQUILES
        // ===================================================================
        static void MenuChilaquiles()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Chilaquiles");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Chilaquiles rojos / verdes");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Crujientes totopos bañados en salsa roja o verde, con crema, queso y cebolla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Chilaquiles suizos / poblanos");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Gratinados o bañados en salsa poblana, con crema, queso y cebolla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("- - - Puedes agregarles un extra - - -");
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Con huevo  +$25        Con pollo  +$35");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 3);
            Console.ResetColor();

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

            // pregunto por los extras (sin que quede pegado a la orilla)
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(margen + "¿Desea agregarle huevo por $25?   (1 = Sí   2 = No)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(margen + "Su elección: ");
            int huevo = LeerEntero(1, 2);
            if (huevo == 1)
            {
                precio = precio + 25;
                nombre = nombre + " + huevo";
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(margen + "¿Desea agregarle pollo por $35?   (1 = Sí   2 = No)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(margen + "Su elección: ");
            int pollo = LeerEntero(1, 2);
            if (pollo == 1)
            {
                precio = precio + 35;
                nombre = nombre + " + pollo";
            }
            Console.ResetColor();

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  BURRITOS
        // ===================================================================
        static void MenuBurritos()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Burritos");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("(Los precios son por pieza)");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Machaca (50gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Burrito de machaca acompañado con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Bistec de arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Burrito de bistec de arrachera acompañado con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Papas con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Burrito de papas con chorizo acompañado con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Chicharrón (80gr)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $95");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Burrito de chicharrón acompañado con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Frijol con queso fresco");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Burrito de frijol con queso fresco acompañado con salsa pico de gallo y guacamole.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (6 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 6);
            Console.ResetColor();

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
                    nombre = "Burrito de chicharrón (80gr)";
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

        // ===================================================================
        //  HUEVOS
        // ===================================================================
        static void MenuHuevos()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Huevos");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Huevos o claras al gusto");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   A elegir: jamón, salchicha, tocino, nopales, mexicanos, papas, chorizo, ejotes, o sopitas. A elegir: chilorio, machaca o chicharrón.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Huevos campesinos");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo estrellado montados sobre jamón y tortilla frita, bañados en salsa de la casa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Huevos a la tambora");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $180");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo estrellado montados sobre chilorio natural y tortilla frita, bañados con salsa ranchera.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Montaditos sinaloenses");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo estrellado montados sobre pan de caja dorado con mantequilla, una cama de aguacate, coronado con tiras de tocino, acompañados de ensalada fresca con queso panela.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Huevos divorciados");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo estrellado montados sobre jamón y gordita frita, uno bañado en salsa verde y otro en salsa roja.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "6. Huevos arrieros");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo bañados con salsa arriera, y puntas de arrachera (80gr) encebolladas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "7. Omelette Don Simón");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Relleno de espinaca, champiñón, mantequilla saborizada y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "8. Omelette de 3 quesos");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Relleno de mezcla de 3 quesos, jamón y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "9. Omelette de camarón");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Relleno de camarón (80gr), con queso gratinado, bañado en salsa con crema de chile morrón rojo y acompañado de papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "10. Omelette poblano");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Relleno de rajas poblanas con queso, elote y cebolla, bañado en salsa poblana y acompañado de papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "11. Omelette culichi");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Relleno de chilorio (80gr) con queso, bañado en salsa ranchera y acompañado de papas fritas en cuadros.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("Todos los desayunos van acompañados de frijoles refritos.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (12 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 12);
            Console.ResetColor();

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

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  DESAYUNOS COMPLETOS
        // ===================================================================
        static void MenuDesayunosCompletos()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Desayunos completos");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Combinación poblana");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, rajas poblanas con queso, elote y cebolla, tamal natural, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Combinación del campo");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, papas con verdura gratinadas, chilaquiles verdes, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Combinación mar y tierra");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, camarón (80gr) ranchero, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Combinación sinaloense");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, chilorio (80gr) a la mexicana, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Combinación sonora");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, machaca (50gr) a la mexicana, chilaquiles rojos, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "6. Combinación Cosalá");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, colache con verdura, queso gratinado, tamal frito, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "7. Combinación mi rancho");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, chorizo (80gr) con papa, frijol refrito, dos quesadillas y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "8. Combinación Don Simón");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Tamal gratinado, chilaquiles poblanos, chicharrones (80gr) a la mexicana, frijol refrito y coronado con aguacate.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "9. Combinación americana");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 piezas de hot cakes, 2 piezas de huevos estrellados y tiras de tocino.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (10 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 10);
            Console.ResetColor();

            if (opcion == 10)
            {
                return;
            }

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

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  LOS TRADICIONALES
        // ===================================================================
        static void MenuTradicionales()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Los tradicionales");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Tacos dorados (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De maíz, rellenas de papa (100gr) con carne deshebrada (50gr), coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañados de consomé de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Tostadas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Gorditas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Enchiladas verdes o rojas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr) coronadas con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañadas de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Enchiladas suizas o poblanas (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr), gratinadas, coronadas con aguacate y acompañadas de frijoles refritos.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "6. Orden de asado");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Papa (100gr) y carne (100gr) en forma de cuadros, coronado con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañado de consomé de res.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "7. Pieza taco, tostada o gordita");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Pieza individual de tu antojo.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (8 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 8);
            Console.ResetColor();

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

        // ===================================================================
        //  SANDWICHES
        // ===================================================================
        static void MenuSandwiches()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Sándwiches");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Sándwich especial");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Sándwich de pechuga de pollo (100gr), tocino y jamón, gratinado por encima, acompañado de papas fritas en cuadros y un mix de lechuga. ¡Delicioso!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Club sándwich");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Sándwich de jamón y queso tipo americano, lechuga, tomate, aguacate, acompañado de papas a la francesa.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 3);
            Console.ResetColor();

            if (opcion == 3)
            {
                return;
            }

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

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  MENU KIDS
        // ===================================================================
        static void MenuKids()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Menú kids");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Salchipulpos con huevo");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   2 salchichas cortadas en forma de pulpo y 2 piezas de huevo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Mini hot cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Con porción de plátano y mermelada de fresa artesanal.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Combinación kids");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   3 mini hot cakes, 2 piezas de huevo revuelto y salchipulpo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Deditos \"Pío Pío\" (6 piezas)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   De pechuga de pollo (120gr), empanizados, acompañados de papas a la francesa (80gr) y de aderezo kétchup.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (5 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 5);
            Console.ResetColor();

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
                    nombre = "Combinación kids";
                    precio = 140;
                    break;
                case 4:
                    nombre = "Deditos Pío Pío (6 piezas)";
                    precio = 140;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        // ===================================================================
        //  BEBIDAS
        // ===================================================================
        static void MenuBebidas()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Bebidas");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Café americano (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Café clásico preparado al momento, intenso y aromático.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Café descafeinado (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Sabor y cuerpo del café con menos cafeína.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Café de olla (350ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Receta tradicional con notas de canela y piloncillo.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Café Chai (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Mezcla especiada y cremosa estilo chai.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Capuchino vainilla / avellana / original (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Espresso con leche espumosa, elige tu sabor.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "6. Chocolate caliente (350ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Cacao cremoso y dulce.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "7. Agua para café (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Preparación ligera de café diluido.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "8. Té (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   A elegir: manzanilla, verde o canela.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "9. Té Chai Vainilla (250ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Infusión especiada con un toque de vainilla.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "10. Chocomilk (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Bebida láctea con chocolate, bien fría.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "11. Leche (300ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Vaso de leche fría.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "12. Licuados (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   A elegir: plátano, fresa o frutas de temporada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "13. Jugos (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   A elegir: verde, betabel o zanahoria.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "14. Jugo de naranja (300ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Naranja exprimida al momento.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "15. Refrescos (355ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Surtido de bebidas gaseosas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "16. Limonada (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Clásica y refrescante.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "17. Limonada mineral (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Con burbujas y un toque cítrico.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "18. Té helado (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Té frío con notas cítricas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "19. Aguas frescas (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   A elegir: pepino limón, fresa limón, horchata o jamaica.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "20. Horchata de fresa (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Horchata con un rico toque de fresa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "21. Horchata café (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Horchata con un toque de café.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "22. Jamaica con fruta (400ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Agua de jamaica con fruta picada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "23. Agua embotellada (600ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $29");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Agua natural embotellada.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "24. Agua mineral (600ml)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Agua mineral con gas.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (25 = Regresar al menú principal)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 25);
            Console.ResetColor();

            if (opcion == 25)
            {
                return;
            }

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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int prepChai = LeerEntero(1, 3);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Qué sabor?   (1 = Vainilla   2 = Avellana   3 = Original)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int saborCap = LeerEntero(1, 3);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int prepCap = LeerEntero(1, 3);
                    Console.ResetColor();

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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Qué tipo de té?   (1 = Manzanilla   2 = Verde   3 = Canela)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int tipoTe = LeerEntero(1, 3);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int prepTeChai = LeerEntero(1, 3);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Qué sabor de licuado?   (1 = Plátano   2 = Fresa   3 = Frutas de temporada)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int sabLicuado = LeerEntero(1, 3);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Qué tipo de jugo?   (1 = Verde   2 = Betabel   3 = Zanahoria)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int tipoJugo = LeerEntero(1, 3);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(margen + "¿Qué sabor de agua fresca?");
                    Console.WriteLine(margen + "(1 = Pepino limón   2 = Fresa limón   3 = Horchata   4 = Jamaica)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(margen + "Su elección: ");
                    int sabAgua = LeerEntero(1, 4);
                    Console.ResetColor();
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

            AgregarATicket(nombreBebida, precioBebida);
            Confirmado();
        }

        // ===================================================================
        //  ESPECIALIDADES DON SIMON (tiene sub-menus)
        // ===================================================================
        static void MenuEspecialidades()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Especialidades Don Simón");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué sección desea ver?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("1. Especialidades (toda la semana)");
            Centrar("2. Exclusivos de fin de semana");
            Centrar("3. ¿Tienes un evento próximo?");
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("4. Regresar al menú principal");
            Console.WriteLine();

            int subMenu = LeerEnteroCentrado(1, 4);
            Console.ResetColor();

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
            Limpiar();
            Console.WriteLine();
            TituloGrande("Especialidades");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Camarones rancheros");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Camarones (150gr) rancheros, acompañados de frijol refrito y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Marlin sinaloense");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Marlin (150gr) a la mexicana, acompañado de frijol refrito y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "3. Lengua de res");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Medallones de lengua de res (150gr) en salsa ranchera, verde, roja o poblana, acompañada de frijol refrito y dos quesadillas. También disponible en caldo (sin frijol ni quesadillas).");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "4. Bistec ranchero");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $240");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Bistec de arrachera (200gr), acompañado de frijol refrito y dos quesadillas.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "5. Hígado encebollado / ranchero");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $160");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Hígado (200gr), acompañado de frijol refrito y dos quesadillas.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (6 = Regresar)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 6);
            Console.ResetColor();

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
                    nombre = "Hígado encebollado / ranchero";
                    precio = 160;
                    break;
            }

            AgregarATicket(nombre, precio);
            Confirmado();
        }

        static void MenuFinDeSemana()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Fin de semana");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("(Exclusivos de sábado y domingo)");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "1. Orden de menudo tradicional");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Menudo tradicional preparado con la receta de la casa.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margen + "2. Orden de menudo guisado");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(margen + "   Menudo guisado al estilo Don Simón.");
            Console.WriteLine();

            LineaDecorada();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Qué desea ordenar?   (3 = Regresar)");
            Console.WriteLine();

            int opcion = LeerEnteroCentrado(1, 3);
            Console.ResetColor();

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

        // pantalla con la informacion de eventos
        static void MostrarInfoEvento()
        {
            Limpiar();
            Console.WriteLine();
            Console.WriteLine();
            TituloGrande("¿Tienes un evento?");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("¿Tienes algún evento próximo?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Centrar("La Casa de Don Simón ofrece servicio");
            Centrar("para eventos y reuniones especiales.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Centrar("Pregunta por nuestros paquetes al:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("☎  667 852 97 96");
            Console.WriteLine();

            LineaDecorada();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("Abierto al público de martes a domingo");
            Centrar("7:30 a.m. a 2:00 p.m.   (descansamos los lunes)");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Centrar("Presiona ENTER para regresar...");
            Console.ResetColor();
            Console.ReadLine();
        }

        // ===================================================================
        //  TICKET FINAL
        // ===================================================================
        static void ImprimirTicket()
        {
            Limpiar();
            Console.WriteLine();
            Console.WriteLine();

            TituloGrande("Tu ticket");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("La Casa de Don Simón");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Centrar("Av. Antonio Rosales 552 ote.");
            Console.WriteLine();

            LineaDecorada();
            Console.WriteLine();

            if (ticketNombres.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Centrar("No se agregó ningún platillo a la orden.");
                Console.WriteLine();
            }
            else
            {
                // recorro las listas y muestro cada cosa que se pidio
                for (int i = 0; i < ticketNombres.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(margen + "• " + ticketNombres[i]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("   $" + ticketPrecios[i]);
                }

                Console.WriteLine();
                LineaDecorada();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Centrar("TOTAL A PAGAR:   $" + totalCuenta);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Centrar("★ ° · . ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ . · ° ★");
            Console.ResetColor();
        }
    }
}
