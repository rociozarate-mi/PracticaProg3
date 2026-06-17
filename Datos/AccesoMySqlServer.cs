using System;
using MySqlConnector;

namespace starter.Datos
{
    public class AccesoMySql : IAccesoDatos
    {
        private readonly string _cs =
        "Server=localhost;Port=3307;User ID=root;Password=Curso.NET2026;";

        // =====================================================
        // RF2 - CREAR ESTRUCTURA
        // =====================================================
        public void CrearEstructura()
{
    using var conn = new MySqlConnection(_cs.Replace("Database=practico;", ""));
    conn.Open();

    // 1. Crear base
    using (var cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS practico;", conn))
    {
        cmd.ExecuteNonQuery();
    }

    using (var cmd = new MySqlCommand("USE practico;", conn))
    {
        cmd.ExecuteNonQuery();
    }

    // 2. DROP + CREATE separados (IMPORTANTE)
    string[] scripts =
    {
        "DROP TABLE IF EXISTS detalle_pedido;",
        "DROP TABLE IF EXISTS pedidos;",
        "DROP TABLE IF EXISTS productos;",
        "DROP TABLE IF EXISTS clientes;",
        "DROP TABLE IF EXISTS categorias;",

        @"CREATE TABLE categorias(
            id INT AUTO_INCREMENT PRIMARY KEY,
            nombre VARCHAR(100)
        );",

        @"CREATE TABLE clientes(
            id INT AUTO_INCREMENT PRIMARY KEY,
            nombre VARCHAR(100),
            email VARCHAR(100)
        );",

        @"CREATE TABLE productos(
            id INT AUTO_INCREMENT PRIMARY KEY,
            nombre VARCHAR(100),
            precio DECIMAL(10,2),
            stock INT,
            categoria_id INT
        );",

        @"CREATE TABLE pedidos(
            id INT AUTO_INCREMENT PRIMARY KEY,
            cliente_id INT,
            fecha DATETIME
        );",

        @"CREATE TABLE detalle_pedido(
            pedido_id INT,
            producto_id INT,
            cantidad INT,
            precio_unitario DECIMAL(10,2),
            PRIMARY KEY (pedido_id, producto_id)
        );"
    };

    foreach (var sql in scripts)
    {
        using var cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("RF2 OK - estructura creada");
}

        // =====================================================
        // RF3 - INSERT DATOS
        // =====================================================
        public void InsertarDatosPrueba()
        {
            using var conn = new MySqlConnection(_cs + "Database=practico;");
            conn.Open();

            using var tx = conn.BeginTransaction();

            try
            {
                int cat1 = InsertCategoria(conn, tx, "Electrónica");
                int cat2 = InsertCategoria(conn, tx, "Libros");
                int cat3 = InsertCategoria(conn, tx, "Hogar");

                int p1 = InsertProducto(conn, tx, "Notebook", 850000, 10, cat1);
                int p2 = InsertProducto(conn, tx, "Mouse", 12000, 50, cat1);
                int p3 = InsertProducto(conn, tx, "Teclado", 35000, 30, cat1);
                int p4 = InsertProducto(conn, tx, "Clean Code", 28000, 20, cat2);
                int p5 = InsertProducto(conn, tx, "Lampara", 15000, 15, cat3);

                int c1 = InsertCliente(conn, tx, "Juan", "juan@mail.com");
                int c2 = InsertCliente(conn, tx, "Ana", "ana@mail.com");

                int ped1 = InsertPedido(conn, tx, c1);
                int ped2 = InsertPedido(conn, tx, c2);

                InsertDetalle(conn, tx, ped1, p1, 1, 850000);
                InsertDetalle(conn, tx, ped1, p2, 2, 12000);

                InsertDetalle(conn, tx, ped2, p3, 1, 35000);
                InsertDetalle(conn, tx, ped2, p4, 1, 28000);

                tx.Commit();
                Console.WriteLine("RF3 OK");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("ERROR RF3: " + ex.Message);
            }
        }

        // =====================================================
        // RF4 - OPERACIONES
        // =====================================================
        public void EjecutarOperaciones()
{
    using var conn = new MySqlConnection(_cs + "Database=practico;");
    conn.Open();

    using var tx = conn.BeginTransaction();

    try
    {
        Console.WriteLine("\n===== RF4 - C1 PRODUCTOS CON CATEGORÍA =====");

        string sqlC1 = @"
SELECT p.id, p.nombre, p.precio, c.nombre
FROM productos p
INNER JOIN categorias c ON p.categoria_id = c.id;";

        using (var cmd = new MySqlCommand(sqlC1, conn, tx))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"#{reader.GetInt32(0)} {reader.GetString(1)} - ${reader.GetDecimal(2)} [{reader.GetString(3)}]"
                );
            }
        }

        Console.WriteLine("\n===== RF4 - C2 DETALLE PEDIDO + TOTAL =====");

        string sqlC2 = @"
        SELECT 
            d.pedido_id,
            p.nombre,
            d.cantidad,
            d.precio_unitario,
            (d.cantidad * d.precio_unitario) AS subtotal
        FROM detalle_pedido d
        INNER JOIN productos p ON p.id = d.producto_id
        WHERE d.pedido_id = 1;";

        decimal total = 0;

        using (var cmd = new MySqlCommand(sqlC2, conn, tx))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                decimal sub = reader.GetDecimal(4);
                total += sub;

                Console.WriteLine(
                    $"{reader.GetString(1)} x{reader.GetInt32(2)} @ {reader.GetDecimal(3)} = {sub}"
                );
            }
        }

        Console.WriteLine($"\nTOTAL pedido #1: ${total}");

        Console.WriteLine("\n===== RF4 - U1 AUMENTO 10% PRECIO POR CATEGORÍA =====");

        string sqlU1 = @"
        UPDATE productos
        SET precio = precio * 1.10
        WHERE categoria_id = 1;";

        using (var cmd = new MySqlCommand(sqlU1, conn, tx))
        {
            int filas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Productos actualizados: {filas}");
        }

        Console.WriteLine("\n===== RF4 - D1 DELETE DETALLE =====");

        string sqlD1 = @"
        DELETE FROM detalle_pedido
        WHERE pedido_id = 1 AND producto_id = 2;";

        using (var cmd = new MySqlCommand(sqlD1, conn, tx))
        {
            int filas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas eliminadas: {filas}");
        }

        tx.Commit();

        Console.WriteLine("\nOPERACIONES CONFIRMADAS (COMMIT)");
    }
    catch (Exception ex)
    {
        tx.Rollback();
        Console.WriteLine("ERROR RF4: " + ex.Message);
    }
}

        // =====================================================
        // RF5 - ROLLBACK
        // =====================================================
        public void DemostrarRollback()
{
    using var conn = new MySqlConnection(_cs + "Database=practico;");
    conn.Open();

    try
    {
        Console.WriteLine("\n===== RF5 - DEMOSTRAR ROLLBACK =====");

        int productoId = 1;

        // =========================
        // 1. VALOR ANTES
        // =========================
        decimal precioAntes = 0;

        using (var cmd = new MySqlCommand(
            "SELECT precio FROM productos WHERE id = @id;", conn))
        {
            cmd.Parameters.AddWithValue("@id", productoId);
            precioAntes = Convert.ToDecimal(cmd.ExecuteScalar());
        }

        Console.WriteLine($"Precio ANTES: {precioAntes}");

        // =========================
        // 2. TRANSACCIÓN
        // =========================
        using var tx = conn.BeginTransaction();

        try
        {
            // UPDATE dentro de transacción
            using (var cmd = new MySqlCommand(
                "UPDATE productos SET precio = precio * 10 WHERE id = @id;",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@id", productoId);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("UPDATE ejecutado dentro de transacción");

            // =========================
            // 3. ERROR FORZADO
            // =========================
            throw new Exception("ERROR SIMULADO PARA PROBAR ROLLBACK");

            // tx.Commit(); nunca llega acá
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("ROLLBACK EJECUTADO");
        }

        // =========================
        // 4. VALOR DESPUÉS
        // =========================
        decimal precioDespues = 0;

        using (var cmd = new MySqlCommand(
            "SELECT precio FROM productos WHERE id = @id;", conn))
        {
            cmd.Parameters.AddWithValue("@id", productoId);
            precioDespues = Convert.ToDecimal(cmd.ExecuteScalar());
        }

        Console.WriteLine($"Precio DESPUÉS: {precioDespues}");

        // =========================
        // 5. VALIDACIÓN FINAL
        // =========================
        if (precioAntes == precioDespues)
        {
            Console.WriteLine("OK: ROLLBACK FUNCIONA (el dato NO cambió)");
        }
        else
        {
            Console.WriteLine("ERROR: el rollback falló");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("ERROR RF5: " + ex.Message);
    }
}

        // =====================================================
        // HELPERS
        // =====================================================

        private int InsertCategoria(MySqlConnection c, MySqlTransaction t, string n)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO categorias(nombre) VALUES (@n); SELECT LAST_INSERT_ID();",
                c, t);
            cmd.Parameters.AddWithValue("@n", n);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertProducto(MySqlConnection c, MySqlTransaction t,
            string n, decimal p, int s, int cat)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO productos(nombre,precio,stock,categoria_id) VALUES (@n,@p,@s,@c); SELECT LAST_INSERT_ID();",
                c, t);

            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@s", s);
            cmd.Parameters.AddWithValue("@c", cat);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertCliente(MySqlConnection c, MySqlTransaction t, string n, string e)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO clientes(nombre,email) VALUES (@n,@e); SELECT LAST_INSERT_ID();",
                c, t);

            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@e", e);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertPedido(MySqlConnection c, MySqlTransaction t, int cli)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO pedidos(cliente_id,fecha) VALUES (@c,NOW()); SELECT LAST_INSERT_ID();",
                c, t);

            cmd.Parameters.AddWithValue("@c", cli);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void InsertDetalle(MySqlConnection c, MySqlTransaction t,
            int ped, int prod, int cant, decimal precio)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO detalle_pedido VALUES (@p,@pr,@c,@pu);",
                c, t);

            cmd.Parameters.AddWithValue("@p", ped);
            cmd.Parameters.AddWithValue("@pr", prod);
            cmd.Parameters.AddWithValue("@c", cant);
            cmd.Parameters.AddWithValue("@pu", precio);

            cmd.ExecuteNonQuery();
        }
    }
}