using System;
using System.Linq;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Monge Shimizu Paulina y Rubio Espino Dylan Arturo 2-F

namespace CasaDonSimon
{
    class Program
    {
        // listas para guardar el ticket
        static List<string> ticketNombres = new List<string>();   // guardar nombre
        static List<int> ticketPrecios = new List<int>();          // guardar precio
        static int totalCuenta = 0;                                // total

        // margen para que todo quede parejito y no pegado a la orilla
        static string sangria = "    ";

        // ===================================================================
        //  COLORES MEXICANOS (esto es lo del ASCII que dijo la profe)
        //  son codigos para poner colores mas bonitos como los de la bandera
        // ===================================================================

        // prender los colores (sin esto salen letras raras)
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr handle, out uint modo);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr handle, uint modo);

        // prender colores
        static void PrenderColores()
        {
            try
            {
                IntPtr salida = GetStdHandle(-11);   // la pantalla
                uint modo;
                GetConsoleMode(salida, out modo);
                modo = modo | 4;                     // prender el modo de colores
                SetConsoleMode(salida, modo);
            }
            catch
            {
                // si no se puede ni modo, seguimos
            }
        }

        // poner verde (verde de la bandera)
        static void Verde()
        {
            Console.Write("\x1b[38;2;0;174;96m");
        }

        // poner blanco
        static void Blanco()
        {
            Console.Write("\x1b[38;2;245;245;245m");
        }

        // poner rojo (rojo de la bandera)
        static void Rojo()
        {
            Console.Write("\x1b[38;2;206;43;55m");
        }

        // poner dorado (para los precios)
        static void Dorado()
        {
            Console.Write("\x1b[38;2;240;195;75m");
        }

        // poner amarillo (para las descripciones)
        static void Amarillo()
        {
            Console.Write("\x1b[38;2;232;205;120m");
        }

        // poner gris (para textos chiquitos)
        static void Gris()
        {
            Console.Write("\x1b[38;2;150;150;150m");
        }

        // quitar el color (dejarlo normal)
        static void Normal()
        {
            Console.Write("\x1b[0m");
        }

        // ===================================================================
        //  COSAS PARA DECORAR
        // ===================================================================

        // limpiar la pantalla
        static void Limpiar()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                // si no hay pantalla real no pasa nada
            }
        }

        // hacer un titulo GRANDE adentro de una caja bonita
        // separo cada letra con un espacio para que se vea mas grande
        static void TituloGrande(string texto)
        {
            // hacer las letras separadas
            string grande = "";
            for (int i = 0; i < texto.Length; i++)
            {
                grande = grande + char.ToUpper(texto[i]);
                if (i < texto.Length - 1)
                {
                    grande = grande + " ";
                }
            }

            // que tan ancha va la caja por dentro
            int anchoAdentro = grande.Length + 8;

            // armar la linea de arriba y abajo
            string borde = "";
            for (int i = 0; i < anchoAdentro; i++)
            {
                borde = borde + "═";
            }

            // centrar el texto adentro de la caja
            int sobran = anchoAdentro - grande.Length;
            int ladoIzq = sobran / 2;
            int ladoDer = sobran - ladoIzq;

            // armar los espacios de los lados
            string espIzq = "";
            for (int i = 0; i < ladoIzq; i++)
            {
                espIzq = espIzq + " ";
            }
            string espDer = "";
            for (int i = 0; i < ladoDer; i++)
            {
                espDer = espDer + " ";
            }

            // dibujar la caja (marco verde y letras blancas)
            Verde();
            Console.WriteLine(sangria + "╔" + borde + "╗");
            Console.Write(sangria + "║");
            Blanco();
            Console.Write(espIzq + grande + espDer);
            Verde();
            Console.WriteLine("║");
            Console.WriteLine(sangria + "╚" + borde + "╝");
            Normal();
        }

        // poner una barra verde (como la bandera)
        static void BarraVerde()
        {
            Verde();
            Console.WriteLine(sangria + "████████████████████████████████████████████████████");
            Normal();
        }

        // poner una barra roja (como la bandera)
        static void BarraRoja()
        {
            Rojo();
            Console.WriteLine(sangria + "████████████████████████████████████████████████████");
            Normal();
        }

        // una linea bonita para separar
        static void LineaBonita()
        {
            Dorado();
            Console.WriteLine(sangria + "✦ ───────────────────────────────────────────── ✦");
            Normal();
        }

        // una linea de estrellitas
        static void LineaEstrellas()
        {
            Dorado();
            Console.WriteLine(sangria + "★ ° · . ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ ✦ . · ° ★");
            Normal();
        }

        // ===================================================================
        //  COSAS PARA QUE FUNCIONE
        // ===================================================================

        // leer un numero (batalle un monton aqui pero ya jala)
        static int LeerEntero(int minimo, int maximo)
        {
            int numero = 0;        // aqui guardo el numero
            bool sirve = false;    // para saber si esta bien

            // repetir hasta que escriba bien
            while (sirve == false)
            {
                string texto = Console.ReadLine();                 // leer lo que escribio
                bool sePudo = int.TryParse(texto, out numero);     // pasarlo a numero

                // revisar que sea numero y este en el rango
                if (sePudo == true && numero >= minimo && numero <= maximo)
                {
                    sirve = true;   // ya quedo bien
                }
                else
                {
                    // si no, avisar y preguntar otra vez
                    Rojo();
                    Console.Write(sangria + "Oops, escribe un numero del " + minimo + " al " + maximo + ": ");
                    Dorado();
                }
            }

            return numero;   // regresar el numero bueno
        }

        // preguntar la opcion (escribe "Su eleccion" parejito con lo demas)
        static int PreguntarOpcion(int minimo, int maximo)
        {
            Dorado();
            Console.Write(sangria + "Su elección: ");
            int op = LeerEntero(minimo, maximo);
            Normal();
            return op;
        }

        // agregar el platillo al ticket
        static void AgregarATicket(string nombre, int precio)
        {
            ticketNombres.Add(nombre);    // guardar nombre
            ticketPrecios.Add(precio);    // guardar precio
            totalCuenta = totalCuenta + precio;   // sumar al total
        }

        // mensaje despues de elegir algo
        static void Confirmado()
        {
            Console.WriteLine();
            Verde();
            Console.WriteLine(sangria + "✓ ¡Perfecto! Se agregó a tu ticket.");
            Gris();
            Console.WriteLine(sangria + "(Presiona ENTER para continuar...)");
            Normal();
            Console.ReadLine();
        }

        // ===================================================================
        //  AQUI EMPIEZA EL PROGRAMA
        // ===================================================================

        static void Main(string[] args)
        {
            // esto es para que se vean los acentos y la ñ
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // prender los colores bonitos
            PrenderColores();

            // mostrar la bienvenida
            PantallaBienvenida();

            // ir al menu
            MenuPrincipal();

            // al final mostrar el ticket
            ImprimirTicket();

            // despedida
            Console.WriteLine();
            Verde();
            Console.WriteLine(sangria + "¡Gracias por su visita, vuelva pronto!");
            Gris();
            Console.WriteLine(sangria + "(Presiona ENTER para cerrar...)");
            Normal();
            Console.ReadLine();
        }

        // pantalla de bienvenida bien bonita
        static void PantallaBienvenida()
        {
            Limpiar();
            Console.WriteLine();

            // bandera mexicana arriba (verde, blanco, rojo)
            BarraVerde();
            Blanco();
            Console.WriteLine(sangria + "                  ¡ B I E N V E N I D O S !");
            Normal();
            BarraRoja();
            Console.WriteLine();

            // titulo grande del restaurante
            TituloGrande("La Casa de Don Simón");
            Console.WriteLine();

            // datos del restaurante
            Verde();
            Console.WriteLine(sangria + "Tradición y ambiente familiar");
            Blanco();
            Console.WriteLine(sangria + "Servicio para eventos y reuniones");
            Rojo();
            Console.WriteLine(sangria + "Martes a domingo   7:30 a.m. - 2:00 p.m.");
            Console.WriteLine(sangria + "Av. Antonio Rosales 552 ote.");
            Normal();
            Console.WriteLine();

            LineaEstrellas();
            Console.WriteLine();

            // decir que le pique a enter
            Dorado();
            Console.WriteLine(sangria + "Presiona ENTER para ver nuestro menú...");
            Normal();
            Console.ReadLine();
        }

        // el menu principal con las categorias
        static void MenuPrincipal()
        {
            int opcion = 0;   // lo que elige el cliente

            // repetir el menu hasta que elija salir (el 11)
            while (opcion != 11)
            {
                Limpiar();
                Console.WriteLine();

                // titulo grande
                TituloGrande("Menú");
                Console.WriteLine();

                // datos del restaurante
                Verde();
                Console.WriteLine(sangria + "La Casa de Don Simón");
                Blanco();
                Console.WriteLine(sangria + "Tradición y ambiente familiar");
                Rojo();
                Console.WriteLine(sangria + "Servicio para eventos y reuniones");
                Console.WriteLine(sangria + "Martes a domingo  7:30 a.m. - 2:00 p.m.");
                Console.WriteLine(sangria + "Av. Antonio Rosales 552 ote.");
                Normal();
                Console.WriteLine();

                LineaBonita();
                Console.WriteLine();

                // las categorias
                Verde();
                Console.WriteLine(sangria + "1.  Entradas");
                Console.WriteLine(sangria + "2.  Chilaquiles");
                Console.WriteLine(sangria + "3.  Burritos");
                Console.WriteLine(sangria + "4.  Huevos");
                Console.WriteLine(sangria + "5.  Desayunos completos");
                Console.WriteLine(sangria + "6.  Los tradicionales");
                Console.WriteLine(sangria + "7.  Sándwiches");
                Console.WriteLine(sangria + "8.  Menú kids");
                Console.WriteLine(sangria + "9.  Bebidas para iniciar el día");
                Console.WriteLine(sangria + "10. Especialidades Don Simón");
                Rojo();
                Console.WriteLine(sangria + "11. Terminar y ver mi ticket");
                Normal();
                Console.WriteLine();

                // decir que escriba el numero
                Blanco();
                Console.WriteLine(sangria + "Escribe el número de la categoría para elegir tu platillo");
                Normal();

                // preguntar
                opcion = PreguntarOpcion(1, 11);

                // mandar a cada menu segun lo que eligio
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
                        // se sale del menu
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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Avena (350ml)");
            Dorado();
            Console.WriteLine("   $90");
            Amarillo();
            Console.WriteLine(sangria + "   Comienza tu día con un toque de calidez y nutrición con nuestra reconfortante avena acompañada de manzana verde, plátano, nuez y pasas.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Kekis (3 piezas)");
            Dorado();
            Console.WriteLine("   $110");
            Amarillo();
            Console.WriteLine(sangria + "   Los tradicionales, deléitate con los favoritos de Don Simón.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Hot cakes (3 piezas)");
            Dorado();
            Console.WriteLine("   $130");
            Amarillo();
            Console.WriteLine(sangria + "   Son el desayuno perfecto para empezar tu día con una sonrisa. ¡Un clásico favorito!");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Pan Francés");
            Dorado();
            Console.WriteLine("   $125");
            Amarillo();
            Console.WriteLine(sangria + "   2 rebanadas partidas a la mitad acompañadas de mermelada de la casa y una lluvia de azúcar glass.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Fruta de temporada Ch (300gr)");
            Dorado();
            Console.WriteLine("   $70");
            Amarillo();
            Console.WriteLine(sangria + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Normal();
            Console.WriteLine();

            // opcion 6
            Verde();
            Console.Write(sangria + "6. Fruta de temporada Gd (500gr)");
            Dorado();
            Console.WriteLine("   $90");
            Amarillo();
            Console.WriteLine(sangria + "   Acompañada de una porción de yogurt natural, granola y miel.");
            Normal();
            Console.WriteLine();

            // opcion 7
            Verde();
            Console.Write(sangria + "7. Guacamole (150gr)");
            Dorado();
            Console.WriteLine("   $90");
            Amarillo();
            Console.WriteLine(sangria + "   Con un toque de tomate, cebolla y cilantro, disfruta de este clásico favorito que te hará desear más con cada bocado.");
            Normal();
            Console.WriteLine();

            // opcion 8
            Verde();
            Console.Write(sangria + "8. Queso fundido (250gr)");
            Dorado();
            Console.WriteLine("   $130");
            Amarillo();
            Console.WriteLine(sangria + "   Tradicional queso tipo gouda gratinado.");
            Normal();
            Console.WriteLine();

            // opcion 9
            Verde();
            Console.Write(sangria + "9. Queso fundido con arrachera (100gr)");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   Tradicional queso tipo gouda gratinado con arrachera.");
            Normal();
            Console.WriteLine();

            // opcion 10
            Verde();
            Console.Write(sangria + "10. Queso fundido con chorizo (80gr)");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   Tradicional queso tipo gouda gratinado con chorizo.");
            Normal();
            Console.WriteLine();

            // opcion 11
            Verde();
            Console.Write(sangria + "11. Panela asada con frijoles de la olla");
            Dorado();
            Console.WriteLine("   $120");
            Amarillo();
            Console.WriteLine(sangria + "   Panela asada (200gr), bañada con salsa verde, con un toque de cilantro y acompañada con frijol de la olla.");
            Normal();
            Console.WriteLine();

            // opcion 12
            Verde();
            Console.Write(sangria + "12. Gorditas con asientos (3 piezas)");
            Dorado();
            Console.WriteLine("   $90");
            Amarillo();
            Console.WriteLine(sangria + "   Acompañadas con salsa pico de gallo.");
            Normal();
            Console.WriteLine();

            // opcion 13
            Verde();
            Console.Write(sangria + "13. Colache (200gr)");
            Dorado();
            Console.WriteLine("   $135");
            Amarillo();
            Console.WriteLine(sangria + "   Calabacita picada con verduras gratinadas y acompañado de frijol refrito.");
            Normal();
            Console.WriteLine();

            // opcion 14
            Verde();
            Console.Write(sangria + "14. Ejotes o nopales con verdura (200gr)");
            Dorado();
            Console.WriteLine("   $130");
            Amarillo();
            Console.WriteLine(sangria + "   Mezclados con verduras, salteados con mantequilla saborizada y acompañados de frijoles refritos.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (15 = Regresar al menú principal)");
            Normal();

            // preguntar que quiere
            int opcion = PreguntarOpcion(1, 15);

            // si elige regresar
            if (opcion == 15)
            {
                return;
            }

            // ver que eligio y guardar nombre y precio
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

        // ===================================================================
        //  CHILAQUILES
        // ===================================================================
        static void MenuChilaquiles()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Chilaquiles");
            Console.WriteLine();

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Chilaquiles rojos / verdes");
            Dorado();
            Console.WriteLine("   $140");
            Amarillo();
            Console.WriteLine(sangria + "   Crujientes totopos bañados en salsa roja o verde, con crema, queso y cebolla.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Chilaquiles suizos / poblanos");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   Gratinados o bañados en salsa poblana, con crema, queso y cebolla.");
            Normal();
            Console.WriteLine();

            // los extras
            Rojo();
            Console.WriteLine(sangria + "- - - Puedes agregarle un extra - - -");
            Verde();
            Console.WriteLine(sangria + "Con huevo  +$25        Con pollo  +$35");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Normal();

            // preguntar
            int opcion = PreguntarOpcion(1, 3);

            // si regresa
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
            Rojo();
            Console.WriteLine(sangria + "¿Desea agregarle huevo por $25?   (1 = Sí   2 = No)");
            Normal();
            int huevo = PreguntarOpcion(1, 2);
            if (huevo == 1)
            {
                precio = precio + 25;          // sumar el huevo
                nombre = nombre + " + huevo";
            }

            // preguntar por el pollo
            Console.WriteLine();
            Rojo();
            Console.WriteLine(sangria + "¿Desea agregarle pollo por $35?   (1 = Sí   2 = No)");
            Normal();
            int pollo = PreguntarOpcion(1, 2);
            if (pollo == 1)
            {
                precio = precio + 35;          // sumar el pollo
                nombre = nombre + " + pollo";
            }

            // agregar
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

            Gris();
            Console.WriteLine(sangria + "(Los precios son por pieza)");
            Normal();
            Console.WriteLine();

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Machaca (50gr)");
            Dorado();
            Console.WriteLine("   $120");
            Amarillo();
            Console.WriteLine(sangria + "   Burrito de machaca acompañado con salsa pico de gallo y guacamole.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Bistec de arrachera (100gr)");
            Dorado();
            Console.WriteLine("   $120");
            Amarillo();
            Console.WriteLine(sangria + "   Burrito de bistec de arrachera acompañado con salsa pico de gallo y guacamole.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Papas con chorizo (80gr)");
            Dorado();
            Console.WriteLine("   $70");
            Amarillo();
            Console.WriteLine(sangria + "   Burrito de papas con chorizo acompañado con salsa pico de gallo y guacamole.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Chicharrón (80gr)");
            Dorado();
            Console.WriteLine("   $95");
            Amarillo();
            Console.WriteLine(sangria + "   Burrito de chicharrón acompañado con salsa pico de gallo y guacamole.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Frijol con queso fresco");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   Burrito de frijol con queso fresco acompañado con salsa pico de gallo y guacamole.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (6 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 6);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Huevos o claras al gusto");
            Dorado();
            Console.WriteLine("   $130");
            Amarillo();
            Console.WriteLine(sangria + "   A elegir: jamón, salchicha, tocino, nopales, mexicanos, papas, chorizo, ejotes, o sopitas. A elegir: chilorio, machaca o chicharrón.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Huevos campesinos");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo estrellado montados sobre jamón y tortilla frita, bañados en salsa de la casa.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Huevos a la tambora");
            Dorado();
            Console.WriteLine("   $180");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo estrellado montados sobre chilorio natural y tortilla frita, bañados con salsa ranchera.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Montaditos sinaloenses");
            Dorado();
            Console.WriteLine("   $175");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo estrellado montados sobre pan de caja dorado con mantequilla, una cama de aguacate, coronado con tiras de tocino, acompañados de ensalada fresca con queso panela.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Huevos divorciados");
            Dorado();
            Console.WriteLine("   $165");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo estrellado montados sobre jamón y gordita frita, uno bañado en salsa verde y otro en salsa roja.");
            Normal();
            Console.WriteLine();

            // opcion 6
            Verde();
            Console.Write(sangria + "6. Huevos arrieros");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo bañados con salsa arriera, y puntas de arrachera (80gr) encebolladas.");
            Normal();
            Console.WriteLine();

            // opcion 7
            Verde();
            Console.Write(sangria + "7. Omelette Don Simón");
            Dorado();
            Console.WriteLine("   $179");
            Amarillo();
            Console.WriteLine(sangria + "   Relleno de espinaca, champiñón, mantequilla saborizada y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Normal();
            Console.WriteLine();

            // opcion 8
            Verde();
            Console.Write(sangria + "8. Omelette de 3 quesos");
            Dorado();
            Console.WriteLine("   $179");
            Amarillo();
            Console.WriteLine(sangria + "   Relleno de mezcla de 3 quesos, jamón y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Normal();
            Console.WriteLine();

            // opcion 9
            Verde();
            Console.Write(sangria + "9. Omelette de camarón");
            Dorado();
            Console.WriteLine("   $210");
            Amarillo();
            Console.WriteLine(sangria + "   Relleno de camarón (80gr), con queso gratinado, bañado en salsa con crema de chile morrón rojo y acompañado de papas fritas en cuadros.");
            Normal();
            Console.WriteLine();

            // opcion 10
            Verde();
            Console.Write(sangria + "10. Omelette poblano");
            Dorado();
            Console.WriteLine("   $179");
            Amarillo();
            Console.WriteLine(sangria + "   Relleno de rajas poblanas con queso, elote y cebolla, bañado en salsa poblana y acompañado de papas fritas en cuadros.");
            Normal();
            Console.WriteLine();

            // opcion 11
            Verde();
            Console.Write(sangria + "11. Omelette culichi");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   Relleno de chilorio (80gr) con queso, bañado en salsa ranchera y acompañado de papas fritas en cuadros.");
            Normal();
            Console.WriteLine();

            Gris();
            Console.WriteLine(sangria + "Todos los desayunos van acompañados de frijoles refritos.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (12 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 12);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Combinación poblana");
            Dorado();
            Console.WriteLine("   $175");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, rajas poblanas con queso, elote y cebolla, tamal natural, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Combinación del campo");
            Dorado();
            Console.WriteLine("   $175");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, papas con verdura gratinadas, chilaquiles verdes, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Combinación mar y tierra");
            Dorado();
            Console.WriteLine("   $210");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, camarón (80gr) ranchero, dos quesadillas, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Combinación sinaloense");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, chilorio (80gr) a la mexicana, dos quesadillas, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Combinación sonora");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, machaca (50gr) a la mexicana, chilaquiles rojos, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 6
            Verde();
            Console.Write(sangria + "6. Combinación Cosalá");
            Dorado();
            Console.WriteLine("   $175");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, colache con verdura, queso gratinado, tamal frito, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 7
            Verde();
            Console.Write(sangria + "7. Combinación mi rancho");
            Dorado();
            Console.WriteLine("   $200");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de huevo, tiras de arrachera (100gr) encebolladas, chorizo (80gr) con papa, frijol refrito, dos quesadillas y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 8
            Verde();
            Console.Write(sangria + "8. Combinación Don Simón");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   Tamal gratinado, chilaquiles poblanos, chicharrones (80gr) a la mexicana, frijol refrito y coronado con aguacate.");
            Normal();
            Console.WriteLine();

            // opcion 9
            Verde();
            Console.Write(sangria + "9. Combinación americana");
            Dorado();
            Console.WriteLine("   $170");
            Amarillo();
            Console.WriteLine(sangria + "   2 piezas de hot cakes, 2 piezas de huevos estrellados y tiras de tocino.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (10 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 10);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Tacos dorados (3 piezas)");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   De maíz, rellenas de papa (100gr) con carne deshebrada (50gr), coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañados de consomé de res.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Tostadas (3 piezas)");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Gorditas (3 piezas)");
            Dorado();
            Console.WriteLine("   $150");
            Amarillo();
            Console.WriteLine(sangria + "   De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Enchiladas verdes o rojas (3 piezas)");
            Dorado();
            Console.WriteLine("   $165");
            Amarillo();
            Console.WriteLine(sangria + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr) coronadas con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañadas de frijoles refritos.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Enchiladas suizas o poblanas (3 piezas)");
            Dorado();
            Console.WriteLine("   $170");
            Amarillo();
            Console.WriteLine(sangria + "   De maíz, rellenas de pechuga de pollo deshebrada (90gr), gratinadas, coronadas con aguacate y acompañadas de frijoles refritos.");
            Normal();
            Console.WriteLine();

            // opcion 6
            Verde();
            Console.Write(sangria + "6. Orden de asado");
            Dorado();
            Console.WriteLine("   $170");
            Amarillo();
            Console.WriteLine(sangria + "   Papa (100gr) y carne (100gr) en forma de cuadros, coronado con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañado de consomé de res.");
            Normal();
            Console.WriteLine();

            // opcion 7
            Verde();
            Console.Write(sangria + "7. Pieza taco, tostada o gordita");
            Dorado();
            Console.WriteLine("   $55");
            Amarillo();
            Console.WriteLine(sangria + "   Pieza individual de tu antojo.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (8 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 8);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Sándwich especial");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   Sándwich de pechuga de pollo (100gr), tocino y jamón, gratinado por encima, acompañado de papas fritas en cuadros y un mix de lechuga. ¡Delicioso!");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Club sándwich");
            Dorado();
            Console.WriteLine("   $140");
            Amarillo();
            Console.WriteLine(sangria + "   Sándwich de jamón y queso tipo americano, lechuga, tomate, aguacate, acompañado de papas a la francesa.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (3 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 3);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Salchipulpos con huevo");
            Dorado();
            Console.WriteLine("   $125");
            Amarillo();
            Console.WriteLine(sangria + "   2 salchichas cortadas en forma de pulpo y 2 piezas de huevo.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Mini hot cakes (3 piezas)");
            Dorado();
            Console.WriteLine("   $90");
            Amarillo();
            Console.WriteLine(sangria + "   Con porción de plátano y mermelada de fresa artesanal.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Combinación kids");
            Dorado();
            Console.WriteLine("   $140");
            Amarillo();
            Console.WriteLine(sangria + "   3 mini hot cakes, 2 piezas de huevo revuelto y salchipulpo.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Deditos \"Pío Pío\" (6 piezas)");
            Dorado();
            Console.WriteLine("   $140");
            Amarillo();
            Console.WriteLine(sangria + "   De pechuga de pollo (120gr), empanizados, acompañados de papas a la francesa (80gr) y de aderezo kétchup.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (5 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 5);

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

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Café americano (250ml)");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   Café clásico preparado al momento, intenso y aromático.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Café descafeinado (250ml)");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   Sabor y cuerpo del café con menos cafeína.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Café de olla (350ml)");
            Dorado();
            Console.WriteLine("   $65");
            Amarillo();
            Console.WriteLine(sangria + "   Receta tradicional con notas de canela y piloncillo.");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Café Chai (250ml)");
            Dorado();
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Amarillo();
            Console.WriteLine(sangria + "   Mezcla especiada y cremosa estilo chai.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Capuchino vainilla / avellana / original (250ml)");
            Dorado();
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Amarillo();
            Console.WriteLine(sangria + "   Espresso con leche espumosa, elige tu sabor.");
            Normal();
            Console.WriteLine();

            // opcion 6
            Verde();
            Console.Write(sangria + "6. Chocolate caliente (350ml)");
            Dorado();
            Console.WriteLine("   $75");
            Amarillo();
            Console.WriteLine(sangria + "   Cacao cremoso y dulce.");
            Normal();
            Console.WriteLine();

            // opcion 7
            Verde();
            Console.Write(sangria + "7. Agua para café (250ml)");
            Dorado();
            Console.WriteLine("   $50");
            Amarillo();
            Console.WriteLine(sangria + "   Preparación ligera de café diluido.");
            Normal();
            Console.WriteLine();

            // opcion 8
            Verde();
            Console.Write(sangria + "8. Té (250ml)");
            Dorado();
            Console.WriteLine("   $50");
            Amarillo();
            Console.WriteLine(sangria + "   A elegir: manzanilla, verde o canela.");
            Normal();
            Console.WriteLine();

            // opcion 9
            Verde();
            Console.Write(sangria + "9. Té Chai Vainilla (250ml)");
            Dorado();
            Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Amarillo();
            Console.WriteLine(sangria + "   Infusión especiada con un toque de vainilla.");
            Normal();
            Console.WriteLine();

            // opcion 10
            Verde();
            Console.Write(sangria + "10. Chocomilk (400ml)");
            Dorado();
            Console.WriteLine("   $75");
            Amarillo();
            Console.WriteLine(sangria + "   Bebida láctea con chocolate, bien fría.");
            Normal();
            Console.WriteLine();

            // opcion 11
            Verde();
            Console.Write(sangria + "11. Leche (300ml)");
            Dorado();
            Console.WriteLine("   $50");
            Amarillo();
            Console.WriteLine(sangria + "   Vaso de leche fría.");
            Normal();
            Console.WriteLine();

            // opcion 12
            Verde();
            Console.Write(sangria + "12. Licuados (400ml)");
            Dorado();
            Console.WriteLine("   $75");
            Amarillo();
            Console.WriteLine(sangria + "   A elegir: plátano, fresa o frutas de temporada.");
            Normal();
            Console.WriteLine();

            // opcion 13
            Verde();
            Console.Write(sangria + "13. Jugos (400ml)");
            Dorado();
            Console.WriteLine("   $70");
            Amarillo();
            Console.WriteLine(sangria + "   A elegir: verde, betabel o zanahoria.");
            Normal();
            Console.WriteLine();

            // opcion 14
            Verde();
            Console.Write(sangria + "14. Jugo de naranja (300ml)");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   Naranja exprimida al momento.");
            Normal();
            Console.WriteLine();

            // opcion 15
            Verde();
            Console.Write(sangria + "15. Refrescos (355ml)");
            Dorado();
            Console.WriteLine("   $50");
            Amarillo();
            Console.WriteLine(sangria + "   Surtido de bebidas gaseosas.");
            Normal();
            Console.WriteLine();

            // opcion 16
            Verde();
            Console.Write(sangria + "16. Limonada (400ml)");
            Dorado();
            Console.WriteLine("   $55");
            Amarillo();
            Console.WriteLine(sangria + "   Clásica y refrescante.");
            Normal();
            Console.WriteLine();

            // opcion 17
            Verde();
            Console.Write(sangria + "17. Limonada mineral (400ml)");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   Con burbujas y un toque cítrico.");
            Normal();
            Console.WriteLine();

            // opcion 18
            Verde();
            Console.Write(sangria + "18. Té helado (400ml)");
            Dorado();
            Console.WriteLine("   $55");
            Amarillo();
            Console.WriteLine(sangria + "   Té frío con notas cítricas.");
            Normal();
            Console.WriteLine();

            // opcion 19
            Verde();
            Console.Write(sangria + "19. Aguas frescas (400ml)");
            Dorado();
            Console.WriteLine("   $60");
            Amarillo();
            Console.WriteLine(sangria + "   A elegir: pepino limón, fresa limón, horchata o jamaica.");
            Normal();
            Console.WriteLine();

            // opcion 20
            Verde();
            Console.Write(sangria + "20. Horchata de fresa (400ml)");
            Dorado();
            Console.WriteLine("   $70");
            Amarillo();
            Console.WriteLine(sangria + "   Horchata con un rico toque de fresa.");
            Normal();
            Console.WriteLine();

            // opcion 21
            Verde();
            Console.Write(sangria + "21. Horchata café (400ml)");
            Dorado();
            Console.WriteLine("   $70");
            Amarillo();
            Console.WriteLine(sangria + "   Horchata con un toque de café.");
            Normal();
            Console.WriteLine();

            // opcion 22
            Verde();
            Console.Write(sangria + "22. Jamaica con fruta (400ml)");
            Dorado();
            Console.WriteLine("   $65");
            Amarillo();
            Console.WriteLine(sangria + "   Agua de jamaica con fruta picada.");
            Normal();
            Console.WriteLine();

            // opcion 23
            Verde();
            Console.Write(sangria + "23. Agua embotellada (600ml)");
            Dorado();
            Console.WriteLine("   $29");
            Amarillo();
            Console.WriteLine(sangria + "   Agua natural embotellada.");
            Normal();
            Console.WriteLine();

            // opcion 24
            Verde();
            Console.Write(sangria + "24. Agua mineral (600ml)");
            Dorado();
            Console.WriteLine("   $50");
            Amarillo();
            Console.WriteLine(sangria + "   Agua mineral con gas.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (25 = Regresar al menú principal)");
            Normal();

            int opcion = PreguntarOpcion(1, 25);

            if (opcion == 25)
            {
                return;
            }

            // aqui guardo la bebida y su precio
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
                    Rojo();
                    Console.WriteLine(sangria + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Normal();
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
                    Rojo();
                    Console.WriteLine(sangria + "¿Qué sabor?   (1 = Vainilla   2 = Avellana   3 = Original)");
                    Normal();
                    int saborCap = PreguntarOpcion(1, 3);

                    // preguntar como lo quiere
                    Console.WriteLine();
                    Rojo();
                    Console.WriteLine(sangria + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Normal();
                    int prepCap = PreguntarOpcion(1, 3);

                    // armar el nombre del sabor
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

                    // armar como lo quiere y el precio
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
                    // preguntar tipo de te
                    Console.WriteLine();
                    Rojo();
                    Console.WriteLine(sangria + "¿Qué tipo de té?   (1 = Manzanilla   2 = Verde   3 = Canela)");
                    Normal();
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
                    Rojo();
                    Console.WriteLine(sangria + "¿Cómo lo quiere?   (1 = Caliente   2 = En las rocas   3 = Frapé)");
                    Normal();
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
                    // preguntar sabor del licuado
                    Console.WriteLine();
                    Rojo();
                    Console.WriteLine(sangria + "¿Qué sabor de licuado?   (1 = Plátano   2 = Fresa   3 = Frutas de temporada)");
                    Normal();
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
                    // preguntar tipo de jugo
                    Console.WriteLine();
                    Rojo();
                    Console.WriteLine(sangria + "¿Qué tipo de jugo?   (1 = Verde   2 = Betabel   3 = Zanahoria)");
                    Normal();
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
                    // preguntar sabor del agua fresca
                    Console.WriteLine();
                    Rojo();
                    Console.WriteLine(sangria + "¿Qué sabor de agua fresca?");
                    Console.WriteLine(sangria + "(1 = Pepino limón   2 = Fresa limón   3 = Horchata   4 = Jamaica)");
                    Normal();
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

            Rojo();
            Console.WriteLine(sangria + "¿Qué sección desea ver?");
            Normal();
            Console.WriteLine();
            Verde();
            Console.WriteLine(sangria + "1. Especialidades (toda la semana)");
            Console.WriteLine(sangria + "2. Exclusivos de fin de semana");
            Console.WriteLine(sangria + "3. ¿Tienes un evento próximo?");
            Rojo();
            Console.WriteLine(sangria + "4. Regresar al menú principal");
            Normal();
            Console.WriteLine();

            int subMenu = PreguntarOpcion(1, 4);

            // ir a la seccion que eligio
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

        // especialidades de toda la semana
        static void MenuEspecialidadesNormales()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Especialidades");
            Console.WriteLine();

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Camarones rancheros");
            Dorado();
            Console.WriteLine("   $200");
            Amarillo();
            Console.WriteLine(sangria + "   Camarones (150gr) rancheros, acompañados de frijol refrito y dos quesadillas.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Marlin sinaloense");
            Dorado();
            Console.WriteLine("   $200");
            Amarillo();
            Console.WriteLine(sangria + "   Marlin (150gr) a la mexicana, acompañado de frijol refrito y dos quesadillas.");
            Normal();
            Console.WriteLine();

            // opcion 3
            Verde();
            Console.Write(sangria + "3. Lengua de res");
            Dorado();
            Console.WriteLine("   $240");
            Amarillo();
            Console.WriteLine(sangria + "   Medallones de lengua de res (150gr) en salsa ranchera, verde, roja o poblana, acompañada de frijol refrito y dos quesadillas. También disponible en caldo (sin frijol ni quesadillas).");
            Normal();
            Console.WriteLine();

            // opcion 4
            Verde();
            Console.Write(sangria + "4. Bistec ranchero");
            Dorado();
            Console.WriteLine("   $240");
            Amarillo();
            Console.WriteLine(sangria + "   Bistec de arrachera (200gr), acompañado de frijol refrito y dos quesadillas.");
            Normal();
            Console.WriteLine();

            // opcion 5
            Verde();
            Console.Write(sangria + "5. Hígado encebollado / ranchero");
            Dorado();
            Console.WriteLine("   $160");
            Amarillo();
            Console.WriteLine(sangria + "   Hígado (200gr), acompañado de frijol refrito y dos quesadillas.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (6 = Regresar)");
            Normal();

            int opcion = PreguntarOpcion(1, 6);

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

        // especialidades solo de fin de semana
        static void MenuFinDeSemana()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("Fin de semana");
            Console.WriteLine();

            Gris();
            Console.WriteLine(sangria + "(Exclusivos de sábado y domingo)");
            Normal();
            Console.WriteLine();

            // opcion 1
            Verde();
            Console.Write(sangria + "1. Orden de menudo tradicional");
            Dorado();
            Console.WriteLine("   $175");
            Amarillo();
            Console.WriteLine(sangria + "   Menudo tradicional preparado con la receta de la casa.");
            Normal();
            Console.WriteLine();

            // opcion 2
            Verde();
            Console.Write(sangria + "2. Orden de menudo guisado");
            Dorado();
            Console.WriteLine("   $185");
            Amarillo();
            Console.WriteLine(sangria + "   Menudo guisado al estilo Don Simón.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Rojo();
            Console.WriteLine(sangria + "¿Qué desea ordenar?   (3 = Regresar)");
            Normal();

            int opcion = PreguntarOpcion(1, 3);

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

        // pantalla con la info de los eventos
        static void MostrarInfoEvento()
        {
            Limpiar();
            Console.WriteLine();
            TituloGrande("¿Tienes un evento?");
            Console.WriteLine();

            Rojo();
            Console.WriteLine(sangria + "¿Tienes algún evento próximo?");
            Normal();
            Console.WriteLine();
            Blanco();
            Console.WriteLine(sangria + "La Casa de Don Simón ofrece servicio");
            Console.WriteLine(sangria + "para eventos y reuniones especiales.");
            Normal();
            Console.WriteLine();
            Amarillo();
            Console.WriteLine(sangria + "Pregunta por nuestros paquetes al:");
            Normal();
            Console.WriteLine();
            Verde();
            Console.WriteLine(sangria + "☎  667 852 97 96");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Console.WriteLine();

            Gris();
            Console.WriteLine(sangria + "Abierto al público de martes a domingo");
            Console.WriteLine(sangria + "7:30 a.m. a 2:00 p.m.   (descansamos los lunes)");
            Normal();
            Console.WriteLine();

            Dorado();
            Console.WriteLine(sangria + "Presiona ENTER para regresar...");
            Normal();
            Console.ReadLine();
        }

        // ===================================================================
        //  TICKET FINAL
        // ===================================================================
        static void ImprimirTicket()
        {
            Limpiar();
            Console.WriteLine();

            // bandera arriba del ticket
            BarraVerde();
            TituloGrande("Tu ticket");
            BarraRoja();
            Console.WriteLine();

            Verde();
            Console.WriteLine(sangria + "La Casa de Don Simón");
            Gris();
            Console.WriteLine(sangria + "Av. Antonio Rosales 552 ote.");
            Normal();
            Console.WriteLine();

            LineaBonita();
            Console.WriteLine();

            // si no pidio nada
            if (ticketNombres.Count == 0)
            {
                Rojo();
                Console.WriteLine(sangria + "No se agregó ningún platillo a la orden.");
                Normal();
                Console.WriteLine();
            }
            else
            {
                // recorrer las listas y mostrar cada cosa
                for (int i = 0; i < ticketNombres.Count; i++)
                {
                    Verde();
                    Console.Write(sangria + "• " + ticketNombres[i]);
                    Dorado();
                    Console.WriteLine("   $" + ticketPrecios[i]);
                    Normal();
                }

                Console.WriteLine();
                LineaBonita();
                Console.WriteLine();

                // mostrar el total
                Dorado();
                Console.WriteLine(sangria + "TOTAL A PAGAR:   $" + totalCuenta);
                Normal();
                Console.WriteLine();
            }

            LineaEstrellas();
        }
    }
}
