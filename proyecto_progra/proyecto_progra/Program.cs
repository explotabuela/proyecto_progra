using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace CasaDonSimon
{
    class Program
    {
        static List<string> ticketNombres = new List<string>();
        static List<int> ticketPrecios = new List<int>();
        static int totalCuenta = 0;

        private static string AgregarTicket(int v1, int v2) => throw new NotImplementedException();
        private static int ImprimirTicket(int v1, int v2)
        {
            throw new NotImplementedException();
        }
        //no se que es eso pero porfin sirve el foco jajajaj

        private static int LeerEntero(int v1, int v2)
        {
            throw new NotImplementedException();
        }
        //no se que es eso pero porfin sirve el foco jajajaj


        static void Main(string[] args)
        {
            MenuPrincipal();
            ImprimirTicket();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presiona ENTER para cerrar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void MenuPrincipal()
        {
            int salir = 0;
            while (salir == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\x1b[1m- - - - - - - - - MENÚ - - - - - - - - -\x1b[0m");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\x1b[1mLa casa de Don Simón\x1b[0m");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tradición y ambiente familiar");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Servicio para eventos y reuniones");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Martes a domingo de 7:30A.M. a 2:30P.M.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Av. Antonio Rosales 552 ote.");
                Console.WriteLine(" ");
                Console.WriteLine(" ");


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Seleccione una categoría:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Entradas");
                Console.WriteLine("2. Chilaquiles");
                Console.WriteLine("3. Burritos");
                Console.WriteLine("4. Huevos");
                Console.WriteLine("5. Desayunos completos");
                Console.WriteLine("6. Los tradicionales");
                Console.WriteLine("7. Sándwiches");
                Console.WriteLine("8. Menú Kids");
                Console.WriteLine("9. Bebidas para iniciar el día");
                Console.WriteLine("10. Mostrar ticket");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Su elección: ");
                int op = LeerEntero(1, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                if (op == 1) MenuEntradas();
                else if (op == 2) MenuChilaquiles();
                else if (op == 3) MenuBurritos();
                else if (op == 4) MenuHuevos();
                else if (op == 5) MenuDesayunosCompletos();
                else if (op == 6) MenuTradicionales();
                else if (op == 7) MenuSandwiches();
                else if (op == 8) MenuKids();
                else if (op == 9) MenuBebidas_Completo_Color();
                else if (op == 10) salir = 1;

                Console.WriteLine(" ");
            }
        }

        static void MenuEntradas()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - ENTRADAS - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1. Avena (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Comienza tu día con un toque de calidez y nutrición con nuestra reconfortante avena acompañada de manzana verde, plátano, nuez y pasas.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2. Kekis (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $110");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Los tradicionales, deléitate con los favoritos de Don Simón.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3. Hot Cakes (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Son el desayuno perfecto para empezar tu día con una sonrisa. ¡Un clásico favorito!");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4. Pan francés");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("2 rebanadas partidas a la mitad acompañadas de mermelada de la casa y una lluvia de azúcar glass.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5. Fruta de temporada CH (300gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Acompañada de una porción de yogurt natural, granola y miel.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6. Fruta de temporada GD (500gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Acompañada de una porción de yogurt natural, granola y miel.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7. Guacamole (150gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Con un toque de tomate, cebolla y cilantro, disfruta de este clásico favorito que te hará desear más con cada bocado.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8. Queso fundido (250gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tradicional queso tipo gouda gratinado con arrachera con chorizo.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9. Queso fundido con arrachera (100gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tradicional queso tipo gouda gratinado con arrachera con chorizo.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("10. Queso fundido con chorizo (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tradicional queso tipo gouda gratinado con arrachera con chorizo.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("11. Panela asada cn frijoles de la olla");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Panela asada (200gr), bañada con salsa verde, con un toque de cilantro y acompañada con frijol y la olla.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("12. Gorditas con asientos (3 piezas)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $110");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Acompañadas con salsa de gallo.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("13. Colache (200gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $135");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Calabacita picada con verduras gratinadas y acompañado de frijol refrito.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("14. Ejotes o nopales con verdura (200gr)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Mezclados con verduras, salteados con mantequilla saborizada y acompañados de frijoles refritos.");
            Console.WriteLine(" ");



            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-14)   15. Regresar");
            static int LeerEntero(int min, int max)
            {
                int valor;
                while (true)
                {
                    Console.Write("Seleccione una opción: ");
                    if (int.TryParse(Console.ReadLine(), out valor) && valor >= min && valor <= max)
                    {
                        return valor;
                    }
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            int e = LeerEntero(1, 15);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (e == 15) return;

            string nombre = "";
            int precio = 0;
            if (e == 1) { nombre = "Avena (350ml)"; precio = 90; }
            else if (e == 2) { nombre = "Kekis (3 piezas)"; precio = 110; }
            else if (e == 3) { nombre = "Hot Cakes (3 piezas)"; precio = 130; }
            else if (e == 4) { nombre = "Pan francés"; precio = 125; }
            else if (e == 5) { nombre = "Fruta de temporada CH (300gr)"; precio = 70; }
            else if (e == 6) { nombre = "Fruta de temporada GD (500gr)"; precio = 90; }
            else if (e == 7) { nombre = "Guacamole (150gr)"; precio = 90; }
            else if (e == 8) { nombre = "Queso fundido (250gr)"; precio = 130; }
            else if (e == 9) { nombre = "Queso fundido con arrachera (100gr)"; precio = 185; }
            else if (e == 10) { nombre = "Queso fundido con chorizo (80gr)"; precio = 150; }
            else if (e == 11) { nombre = "Panela asada con frijoles de la olla"; precio = 120; }
            else if (e == 12) { nombre = "Gorditas con asientos (3 piezas)"; precio = 110; }
            else if (e == 13) { nombre = "Colache (200gr)"; precio = 135; }
            else if (e == 14) { nombre = "Ejotes o nopales con verdura (200gr)"; precio = 130; }

            if (nombre != "")
            {
                string op = AgregarATicket(nombre, precio);
                int o = ConfirmadoCorto();
            }
        }

        // CHILAQUILES
        static void MenuChilaquiles()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - CHILAQUILES - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. CHILAQUILES ROJOS / VERDES");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Crujientes totopos con salsa roja o verde, crema, queso y cebolla.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. CHILAQUILES SUIZOS / POBLANOS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Gratinados o bañados en salsa poblana, con crema, queso y cebolla.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Extras:");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("   - Con huevo");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   +$25");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("   - Con pollo");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   +$35");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-2)   3. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int op = LeerEntero(1, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (op == 3) return;

            string nombre = (op == 1) ? "Chilaquiles rojos/verdes" : "Chilaquiles suizos/poblanos";
            int precio = (op == 1) ? 140 : 150;

            Console.Write("¿Agregar huevo por $25? 1=Sí 2=No: ");
            int h = LeerEntero(1, 2);
            if (h == 1) precio = precio + 25;

            Console.Write("¿Agregar pollo por $35? 1=Sí 2=No: ");
            int p = LeerEntero(1, 2);
            if (p == 1) precio = precio + 35;

            AgregarATicket(nombre, precio);
            ConfirmadoCorto();
        }

        // BURRITOS (por pieza)
        static void MenuBurritos()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - BURRITOS (precio por pieza) - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. MACHACA (50gr)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. BISTEC DE ARRACHERA (100gr)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $120");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. PAPAS CON CHORIZO (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. CHICHARRÓN (80gr)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $95");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("5. FRIJOL CON QUESO FRESCO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Todos los burritos van acompañados con salsa pico de gallo y guacamole.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-5)   6. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int b = LeerEntero(1, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (b == 6) return;

            string n = "";
            int pr = 0;
            if (b == 1) { n = "Burrito Machaca (50gr)"; pr = 120; }
            else if (b == 2) { n = "Burrito Bistec de arrachera (100gr)"; pr = 120; }
            else if (b == 3) { n = "Burrito Papas con chorizo (80gr)"; pr = 70; }
            else if (b == 4) { n = "Burrito Chicharrón (80gr)"; pr = 95; }
            else if (b == 5) { n = "Burrito Frijol con queso fresco"; pr = 60; }

            AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        // HUEVOS
        static void MenuHuevos()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - HUEVOS - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. HUEVOS O CLARAS AL GUSTO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $130");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("A elegir: Jamón, salchicha, tocino, nopales, mexicanos, papas, chorizo, ejotes, o sopitas. A elegir: Chilorio, machaca o chicharrón.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. HUEVOS CAMPESINOS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo estrellado montados sobre jamón y tortilla frita, bañados en salsa de la casa.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. HUEVOS A LA TAMBORA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $180");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo estrellado montados sobre chilorio natural y tortilla frita, bañados con salsa ranchera.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. MONTADITOS SINALOENSES");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo estrellado montados sobre pan de caja dorado con mantequilla, una cama de aguacate, coronado con tiras de tocino, acompañados de ensalada fresca con queso panela.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("5. HUEVOS DIVORCIADOS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo estrellado montados sobre jamón y gordita frita, bañados en salsa verde y roja en salsa roja.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("6. HUEVOS ARRIEROS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo bañados con salsa arriera, y puntas de arrachera (80gr) encebolladas.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("7. OMELETTE DON SIMÓN");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Relleno de espinaca, champiñón, mantequilla saborizada y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("8. OMELETTE DE 3 QUESOS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Relleno de mezcla de 3 quesos, jamón y acompañado de papas fritas en cuadros. ¡Pídelo bañado en tu salsa favorita! (Roja / Verde / Ranchera).");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("9. OMELETTE DE CAMARÓN");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Relleno de camarón (80gr), con queso gratinado, bañado en salsa con crema de chile morrón rojo y acompañado de papas fritas en cuadros.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("10. OMELETTE POBLANO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $179");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Relleno de rajas poblanas con queso, elote y cebolla, bañado en salsa poblana y acompañado de papas fritas en cuadros.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("11. OMELETTE CULICHI");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Relleno de chilorio (80gr) con queso, bañado en salsa ranchera y acompañado de papas fritas en cuadros.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Todos los desayunos van acompañados de frijoles refritos.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-11)   12. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int h = LeerEntero(1, 12);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (h == 12) return;

            string n = "";
            int pr = 0;
            if (h == 1) { n = "Huevos o claras al gusto"; pr = 130; }
            else if (h == 2) { n = "Huevos campesinos"; pr = 150; }
            else if (h == 3) { n = "Huevos a la tambora"; pr = 180; }
            else if (h == 4) { n = "Montaditos sinaloenses"; pr = 175; }
            else if (h == 5) { n = "Huevos divorciados"; pr = 165; }
            else if (h == 6) { n = "Huevos arrieros"; pr = 185; }
            else if (h == 7) { n = "Omelette Don Simón"; pr = 179; }
            else if (h == 8) { n = "Omelette de 3 quesos"; pr = 179; }
            else if (h == 9) { n = "Omelette de camarón"; pr = 210; }
            else if (h == 10) { n = "Omelette poblano"; pr = 179; }
            else if (h == 11) { n = "Omelette culichi"; pr = 185; }

            AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        // DESAYUNOS COMPLETOS
        static void MenuDesayunosCompletos()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - DESAYUNOS COMPLETOS - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. COMBINACIÓN POBLANA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, rajas poblanas con queso, elote y cebolla, tamal natural, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. COMBINACIÓN DEL CAMPO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, papas con verdura gratinadas, chilaquiles verdes, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. COMBINACIÓN MAR Y TIERRA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $210");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, tiras de arrachera (100gr) encebolladas, camarón (80gr) ranchero, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. COMBINACIÓN SINALOENSE");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, chilorio (80gr) a la mexicana, dos quesadillas, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("5. COMBINACIÓN SONORA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, machaca (50gr) a la mexicana, chilaquiles rojos, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("6. COMBINACIÓN COSALÁ");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $175");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, colache con verdura, queso gratinado, tamal frito, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("7. COMBINACIÓN MI RANCHO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $200");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de huevo, tiras de arrachera (100gr) encebolladas, chorizo (80gr) con papa, frijol refrito, dos quesadillas y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("8. COMBINACIÓN DON SIMÓN");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Tamal gratinado, chilaquiles poblanos, chicharrones (80gr) a la mexicana, frijol refrito y coronado con aguacate.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("9. COMBINACIÓN AMERICANA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 piezas de hot cakes, 2 piezas de huevos estrellados y tiras de tocino.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-9)   10. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int d = LeerEntero(1, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (d == 10) return;

            string n = "";
            int pr = 0;
            if (d == 1) { n = "Combinación poblana"; pr = 175; }
            else if (d == 2) { n = "Combinación del campo"; pr = 175; }
            else if (d == 3) { n = "Combinación mar y tierra"; pr = 210; }
            else if (d == 4) { n = "Combinación sinaloense"; pr = 185; }
            else if (d == 5) { n = "Combinación sonora"; pr = 185; }
            else if (d == 6) { n = "Combinación Cosalá"; pr = 175; }
            else if (d == 7) { n = "Combinación mi rancho"; pr = 200; }
            else if (d == 8) { n = "Combinación Don Simón"; pr = 185; }
            else if (d == 9) { n = "Combinación americana"; pr = 170; }

            AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        // LOS TRADICIONALES
        static void MenuTradicionales()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - LOS TRADICIONALES - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. TACOS DORADOS (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De maíz, rellenas de papa (100gr) con carne deshebrada (50gr), coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañados de consomé de res.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. TOSTADAS (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. GORDITAS (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $150");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De carne deshebrada (60gr) con frijol y papas fritas en cuadros, coronadas con lechuga romana, tomate, pepino, cebolla curtida, queso, crema y acompañadas de consomé de res.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. ENCHILADAS VERDES O ROJAS (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $165");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De maíz, rellenas de pechuga de pollo deshebrada (90gr) coronadas con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañadas de frijoles refritos.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("5. ENCHILADAS SUIZAS O POBLANAS (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De maíz, rellenas de pechuga de pollo deshebrada (90gr), gratinadas, coronadas con aguacate y acompañadas de frijoles refritos.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("6. ORDEN DE ASADO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $170");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Papa (100gr) y carne (100gr) en forma de cuadros, coronado con lechuga romana, tomate, pepino, cebolla curtida, aguacate, queso, crema y acompañado de consomé de res.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("7. PIEZA TACO, TOSTADA O GORDITA");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Pieza individual de tu antojo.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-7)   8. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int t = LeerEntero(1, 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (t == 8) return;

            string n = "";
            int pr = 0;
            if (t == 1) { n = "Tacos dorados (3 piezas)"; pr = 150; }
            else if (t == 2) { n = "Tostadas (3 piezas)"; pr = 150; }
            else if (t == 3) { n = "Gorditas (3 piezas)"; pr = 150; }
            else if (t == 4) { n = "Enchiladas verdes o rojas (3 piezas)"; pr = 165; }
            else if (t == 5) { n = "Enchiladas suizas o poblanas (3 piezas)"; pr = 170; }
            else if (t == 6) { n = "Orden de asado"; pr = 170; }
            else if (t == 7) { n = "Pieza taco/tostada/gordita"; pr = 55; }


            int op = AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        static void MenuSandwiches()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - SÁNDWICHES - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. SÁNDWICH ESPECIAL");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $185");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Sándwich de pechuga de pollo (100gr), tocino y jamón, gratinado por encima, acompañado de papas fritas en cuadros y un mix de lechuga. ¡Delicioso!");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. CLUB SÁNDWICH");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Sándwich de jamón y queso tipo americano, lechuga, tomate, aguacate, acompañado de papas a la francesa.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-2)   3. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int s = LeerEntero(1, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (s == 3) return;

            string n = "";
            int pr = 0;
            if (s == 1) { n = "Sándwich especial"; pr = 185; }
            else if (s == 2) { n = "Club sándwich"; pr = 140; }

            AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        static void MenuKids()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - MENÚ KIDS - - -");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. SALCHIPULPOS CON HUEVO");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $125");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("2 salchichas cortadas en forma de pulpo y 2 piezas de huevo.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. MINI HOT CAKES (3 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $90");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Con porción de plátano y mermelada de fresa artesanal.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. COMBINACIÓN KIDS");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("3 mini hot cakes, 2 piezas de huevo revuelto y salchipulpo.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. DEDITOS “PÍO PÍO” (6 PIEZAS)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $140");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("De pechuga de pollo (120gr), empanizados, acompañados de papas a la francesa (80gr) y de aderezo kétchup.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-4)   5. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int k = LeerEntero(1, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (k == 5) return;

            string n = "";
            int pr = 0;
            if (k == 1) { n = "Salchipulpos con huevo"; pr = 125; }
            else if (k == 2) { n = "Mini hot cakes (3 piezas)"; pr = 90; }
            else if (k == 3) { n = "Combinación kids"; pr = 140; }
            else if (k == 4) { n = "Deditos 'Pío Pío' (6 piezas)"; pr = 140; }

            AgregarATicket(n, pr);
            ConfirmadoCorto();
        }

        static void MenuBebidas_Completo_Color()
        {
            string ticketNombre = "";
            int ticketPrecio = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- - - BEBIDAS PARA INICIAR EL DÍA - - -");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("1. Café americano (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Café clásico preparado al momento, intenso y aromático.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("2. Café descafeinado (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Sabor y cuerpo del café con menos cafeína.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("3. Café de olla (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Receta tradicional con notas de canela y piloncillo.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("4. Café Chai (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Mezcla especiada y cremosa estilo chai.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("5. Capuchino vainilla / avellana / original (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Espresso con leche espumosa; elige tu sabor.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("6. Chocolate caliente (350ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Cacao cremoso y dulce.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("7. Agua para café (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Preparación ligera de café diluido.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("8. Té (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Manzanilla / Verde / Canela.");
            Console.WriteLine(" ");


            Console.ForegroundColor = ConsoleColor.Green; Console.Write("9. Té Chai Vainilla (250ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   Caliente $65   Rocas $75   Frapé $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Infusión especiada con toque de vainilla.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("10. Chocomilk (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Bebida láctea con chocolate, fría.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("11. Leche (300ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Vaso de leche fría.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("12. Licuados (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $75");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Plátano / Fresa / Frutas de temporada.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("13. Jugos (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Verde / Betabel / Zanahoria.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("14. Jugo de naranja (300ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Naranja exprimida al momento.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("15. Refrescos (355ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Surtido de bebidas gaseosas.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("16. Limonada (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Clásica y refrescante.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("17. Limonada mineral (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Con burbujas y un toque cítrico.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("18. Té helado (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $55");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Té frío con notas cítricas.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("19. Aguas frescas (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $60");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Pepino limón / Fresa limón / Horchata / Jamaica.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("20. Horchata de fresa (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Horchata con toque de fresa.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("21. Horchata café (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $70");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Horchata con un toque de café.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("22. Jamaica con fruta (400ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $65");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Agua de jamaica con fruta picada.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("23. Agua embotellada (600ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $29");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Agua natural embotellada.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Green; Console.Write("24. Agua mineral (600ml)");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("   $50");
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Agua con gas.");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Qué desea ordenar? (1-24)   25. Regresar");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int elec = LeerEntero(1, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            if (elec == 25) return;

            if (elec == 1) { ticketNombre = "Café americano (250ml)"; ticketPrecio = 60; }
            else if (elec == 2) { ticketNombre = "Café descafeinado (250ml)"; ticketPrecio = 60; }
            else if (elec == 3) { ticketNombre = "Café de olla (350ml)"; ticketPrecio = 65; }
            else if (elec == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Preparación Chai: 1. Caliente  2. Rocas  3. Frapé: ");
                int v = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                if (v == 1) { ticketNombre = "Café Chai (250ml) - Caliente"; ticketPrecio = 65; }
                else if (v == 2) { ticketNombre = "Café Chai (250ml) - Rocas"; ticketPrecio = 75; }
                else { ticketNombre = "Café Chai (250ml) - Frapé"; ticketPrecio = 75; }
                Console.WriteLine(" ");
            }
            else if (elec == 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Sabor: 1. Vainilla  2. Avellana  3. Original: ");
                int s = LeerEntero(1, 3);
                Console.Write("Preparación: 1. Caliente  2. Rocas  3. Frapé: ");
                int v = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                string sabor = (s == 1) ? "Vainilla" : (s == 2) ? "Avellana" : "Original";
                string prep = (v == 1) ? "Caliente" : (v == 2) ? "Rocas" : "Frapé";
                int precio = (v == 1) ? 65 : 75;
                ticketNombre = "Capuchino " + sabor + " (250ml) - " + prep;
                ticketPrecio = precio;
                Console.WriteLine(" ");
            }
            else if (elec == 6) { ticketNombre = "Chocolate caliente (350ml)"; ticketPrecio = 75; }
            else if (elec == 7) { ticketNombre = "Agua para café (250ml)"; ticketPrecio = 50; }
            else if (elec == 8)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Tipo de té: 1. Manzanilla  2. Verde  3. Canela: ");
                int t = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                if (t == 1) ticketNombre = "Té Manzanilla (250ml)";
                else if (t == 2) ticketNombre = "Té Verde (250ml)";
                else ticketNombre = "Té Canela (250ml)";
                ticketPrecio = 50;
                Console.WriteLine(" ");
            }
            else if (elec == 9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Preparación Té Chai Vainilla: 1. Caliente  2. Rocas  3. Frapé: ");
                int v = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                if (v == 1) { ticketNombre = "Té Chai Vainilla (250ml) - Caliente"; ticketPrecio = 65; }
                else if (v == 2) { ticketNombre = "Té Chai Vainilla (250ml) - Rocas"; ticketPrecio = 75; }
                else { ticketNombre = "Té Chai Vainilla (250ml) - Frapé"; ticketPrecio = 75; }
                Console.WriteLine(" ");
            }
            else if (elec == 10) { ticketNombre = "Chocomilk (400ml)"; ticketPrecio = 75; }
            else if (elec == 11) { ticketNombre = "Leche (300ml)"; ticketPrecio = 50; }
            else if (elec == 12)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Licuado: 1. Plátano  2. Fresa  3. Frutas de temporada: ");
                int s = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                if (s == 1) ticketNombre = "Licuado de Plátano (400ml)";
                else if (s == 2) ticketNombre = "Licuado de Fresa (400ml)";
                else ticketNombre = "Licuado Frutas de temporada (400ml)";
                ticketPrecio = 75;
                Console.WriteLine(" ");
            }
            else if (elec == 13)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Jugo: 1. Verde  2. Betabel  3. Zanahoria: ");
                int j = LeerEntero(1, 3);
                Console.ForegroundColor = ConsoleColor.White;
                if (j == 1) ticketNombre = "Jugo Verde (400ml)";
                else if (j == 2) ticketNombre = "Jugo de Betabel (400ml)";
                else ticketNombre = "Jugo de Zanahoria (400ml)";
                ticketPrecio = 70;
                Console.WriteLine(" ");
            }
            else if (elec == 14) { ticketNombre = "Jugo de naranja (300ml)"; ticketPrecio = 60; }
            else if (elec == 15) { ticketNombre = "Refresco (355ml)"; ticketPrecio = 50; }
            else if (elec == 16) { ticketNombre = "Limonada (400ml)"; ticketPrecio = 55; }
            else if (elec == 17) { ticketNombre = "Limonada mineral (400ml)"; ticketPrecio = 60; }
            else if (elec == 18) { ticketNombre = "Té helado (400ml)"; ticketPrecio = 55; }
            else if (elec == 19)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Agua fresca: 1. Pepino limón  2. Fresa limón  3. Horchata  4. Jamaica: ");
                int a = LeerEntero(1, 4);
                Console.ForegroundColor = ConsoleColor.White;
                if (a == 1) ticketNombre = "Agua fresca Pepino limón (400ml)";
                else if (a == 2) ticketNombre = "Agua fresca Fresa limón (400ml)";
                else if (a == 3) ticketNombre = "Agua fresca Horchata (400ml)";
                else ticketNombre = "Agua fresca Jamaica (400ml)";
                ticketPrecio = 60;
                Console.WriteLine(" ");
            }
            else if (elec == 20) { ticketNombre = "Horchata de fresa (400ml)"; ticketPrecio = 70; }
            else if (elec == 21) { ticketNombre = "Horchata café (400ml)"; ticketPrecio = 70; }
            else if (elec == 22) { ticketNombre = "Jamaica con fruta (400ml)"; ticketPrecio = 65; }
            else if (elec == 23) { ticketNombre = "Agua embotellada (600ml)"; ticketPrecio = 29; }
            else if (elec == 24) { ticketNombre = "Agua mineral (600ml)"; ticketPrecio = 50; }

            if (ticketNombre != "")
            {
                AgregarATicket(ticketNombre, ticketPrecio);
                ConfirmadoCorto();
            }
        }
    }
}
