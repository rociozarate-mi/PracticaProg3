using System;
using Npgsql;

namespace starter.Datos
{
    public class AccesoPostgres : IAccesoDatos
    {
        private readonly string _csAdmin =
            "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres";

        private readonly string _csPractic0 =
            "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=practico";

        // =====================================================
        // RF2 - CREAR ESTRUCTURA (POSTGRES)
        // =====================================================
        public void CrearEstructura()
        {
            using var conn = new NpgsqlConnection(_csAdmin);
            conn.Open();

            // 1) Crear DB (NO existe IF NOT EXISTS en todas configs → se controla)
            using (var cmdDb = new NpgsqlCommand(
                "SELECT 1 FROM pg_database WHERE datname = 'practico'", conn))
            {
                var exists = cmdDb.ExecuteScalar();

                if (exists == null)
                {
                    using var createDb = new NpgsqlCommand(
                        "CREATE DATABASE practico", conn);
                    createDb.ExecuteNonQuery();
                }
            }

            Console.WriteLine("DB verificada/creada: practico");

            // 2) Crear tablas en DB practico
            using var conn2 = new NpgsqlConnection(_csPractic0);
            conn2.Open();

            string sql = @"
                DROP TABLE IF EXISTS detalle_pedido;
                DROP TABLE IF EXISTS pedidos;
                DROP TABLE IF EXISTS productos;
                DROP TABLE IF EXISTS clientes;
                DROP TABLE IF EXISTS categorias;

                CREATE TABLE categorias(
                    id SERIAL PRIMARY KEY,
                    nombre VARCHAR(100)
                );

                CREATE TABLE clientes(
                    id SERIAL PRIMARY KEY,
                    nombre VARCHAR(100),
                    email VARCHAR(100)
                );

                CREATE TABLE productos(
                    id SERIAL PRIMARY KEY,
                    nombre VARCHAR(100),
                    precio NUMERIC(10,2),
                    stock INT,
                    categoria_id INT
                );

                CREATE TABLE pedidos(
                    id SERIAL PRIMARY KEY,
                    cliente_id INT,
                    fecha TIMESTAMP
                );

                CREATE TABLE detalle_pedido(
                    pedido_id INT,
                    producto_id INT,
                    cantidad INT,
                    precio_unitario NUMERIC(10,2),
                    PRIMARY KEY (pedido_id, producto_id)
                );
                ";

            using var cmd = new NpgsqlCommand(sql, conn2);
            cmd.ExecuteNonQuery();

            Console.WriteLine("RF2 OK PostgreSQL");
        }

        // =====================================================
        // RF3 - INSERT (TRANSACCIÓN)
        // =====================================================
        public void InsertarDatosPrueba()
        {
            using var conn = new NpgsqlConnection(_csPractic0);
            conn.Open();

            using var tx = conn.BeginTransaction();

            try
            {
                int cat1 = InsertarCategoria(conn, tx, "Electrónica");
                int cat2 = InsertarCategoria(conn, tx, "Libros");
                int cat3 = InsertarCategoria(conn, tx, "Hogar");

                int p1 = InsertarProducto(conn, tx, "Notebook", 850000, 10, cat1);
                int p2 = InsertarProducto(conn, tx, "Mouse", 12000, 50, cat1);
                int p3 = InsertarProducto(conn, tx, "Teclado", 35000, 30, cat1);
                int p4 = InsertarProducto(conn, tx, "Clean Code", 28000, 20, cat2);
                int p5 = InsertarProducto(conn, tx, "Lampara", 15000, 15, cat3);

                int c1 = InsertarCliente(conn, tx, "Juan", "juan@mail.com");
                int c2 = InsertarCliente(conn, tx, "Ana", "ana@mail.com");

                int ped1 = InsertarPedido(conn, tx, c1);
                int ped2 = InsertarPedido(conn, tx, c2);

                InsertarDetalle(conn, tx, ped1, p1, 1, 850000);
                InsertarDetalle(conn, tx, ped1, p2, 2, 12000);

                InsertarDetalle(conn, tx, ped2, p3, 1, 35000);
                InsertarDetalle(conn, tx, ped2, p4, 1, 28000);

                tx.Commit();
                Console.WriteLine("RF3 OK PostgreSQL (commit)");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("ERROR RF3: " + ex.Message);
            }
        }

        // =====================================================
        // HELPERS POSTGRES
        // =====================================================

        private int InsertarCategoria(NpgsqlConnection conn, NpgsqlTransaction tx, string nombre)
        {
            var cmd = new NpgsqlCommand(
                "INSERT INTO categorias(nombre) VALUES (@n) RETURNING id;", conn, tx);

            cmd.Parameters.AddWithValue("@n", nombre);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertarProducto(NpgsqlConnection conn, NpgsqlTransaction tx,
            string nombre, decimal precio, int stock, int catId)
        {
            var cmd = new NpgsqlCommand(
                @"INSERT INTO productos(nombre,precio,stock,categoria_id)
                  VALUES (@n,@p,@s,@c) RETURNING id;", conn, tx);

            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@p", precio);
            cmd.Parameters.AddWithValue("@s", stock);
            cmd.Parameters.AddWithValue("@c", catId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertarCliente(NpgsqlConnection conn, NpgsqlTransaction tx, string n, string e)
        {
            var cmd = new NpgsqlCommand(
                "INSERT INTO clientes(nombre,email) VALUES (@n,@e) RETURNING id;", conn, tx);

            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@e", e);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertarPedido(NpgsqlConnection conn, NpgsqlTransaction tx, int clienteId)
        {
            var cmd = new NpgsqlCommand(
                "INSERT INTO pedidos(cliente_id,fecha) VALUES (@c,NOW()) RETURNING id;", conn, tx);

            cmd.Parameters.AddWithValue("@c", clienteId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void InsertarDetalle(NpgsqlConnection conn, NpgsqlTransaction tx,
            int pedId, int prodId, int cant, decimal precio)
        {
            var cmd = new NpgsqlCommand(
                @"INSERT INTO detalle_pedido(pedido_id,producto_id,cantidad,precio_unitario)
                  VALUES (@p,@pr,@c,@pu);", conn, tx);

            cmd.Parameters.AddWithValue("@p", pedId);
            cmd.Parameters.AddWithValue("@pr", prodId);
            cmd.Parameters.AddWithValue("@c", cant);
            cmd.Parameters.AddWithValue("@pu", precio);

            cmd.ExecuteNonQuery();
        }
        // =====================================================
// RF4 - CONSULTAS, UPDATE Y DELETE
// =====================================================
public void EjecutarOperaciones()
{
    using var conn = new NpgsqlConnection(_csPractic0);
    conn.Open();

    using var tx = conn.BeginTransaction();

    try
    {
        Console.WriteLine("\nC1 - INNER JOIN");

        var c1 = new NpgsqlCommand(@"
            SELECT p.nombre, c.nombre
            FROM productos p
            INNER JOIN categorias c
                ON p.categoria_id = c.id",
            conn, tx);

        using (var rd = c1.ExecuteReader())
        {
            while (rd.Read())
            {
                Console.WriteLine(
                    $"Producto: {rd.GetString(0)} | Categoría: {rd.GetString(1)}");
            }
        }

        Console.WriteLine("\nC2 - JOIN + SUM + GROUP BY");

        var c2 = new NpgsqlCommand(@"
            SELECT pe.id,
                   SUM(dp.cantidad * dp.precio_unitario) AS total
            FROM pedidos pe
            INNER JOIN detalle_pedido dp
                ON pe.id = dp.pedido_id
            GROUP BY pe.id",
            conn, tx);

        using (var rd = c2.ExecuteReader())
        {
            while (rd.Read())
            {
                Console.WriteLine(
                    $"Pedido {rd.GetInt32(0)} - Total: {rd.GetDecimal(1)}");
            }
        }

        Console.WriteLine("\nU1 - UPDATE (+10%)");

        var upd = new NpgsqlCommand(@"
            UPDATE productos
            SET precio = precio * 1.10",
            conn, tx);

        int filasUpd = upd.ExecuteNonQuery();

        Console.WriteLine($"Productos actualizados: {filasUpd}");

        Console.WriteLine("\nD1 - DELETE");

        var del = new NpgsqlCommand(@"
            DELETE FROM clientes
            WHERE nombre = @nombre",
            conn, tx);

        del.Parameters.AddWithValue("@nombre", "Ana");

        int filasDel = del.ExecuteNonQuery();

        Console.WriteLine($"Clientes eliminados: {filasDel}");

        tx.Commit();

        Console.WriteLine("RF4 OK PostgreSQL");
    }
    catch
    {
        tx.Rollback();
        throw;
    }
}

// =====================================================
// RF5 - ROLLBACK
// =====================================================
public void DemostrarRollback()
{
    using var conn = new NpgsqlConnection(_csPractic0);
    conn.Open();

    decimal precioAntes;

    using (var cmd = new NpgsqlCommand(
        "SELECT precio FROM productos WHERE id = 1",
        conn))
    {
        precioAntes = Convert.ToDecimal(cmd.ExecuteScalar());
    }

    Console.WriteLine($"\nPrecio original: {precioAntes}");

    using var tx = conn.BeginTransaction();

    try
    {
        var upd = new NpgsqlCommand(
            "UPDATE productos SET precio = 999999 WHERE id = 1",
            conn,
            tx);

        upd.ExecuteNonQuery();

        throw new Exception("Error forzado para probar rollback");
    }
    catch
    {
        tx.Rollback();

        Console.WriteLine("Rollback ejecutado.");
    }

    decimal precioDespues;

    using (var cmd = new NpgsqlCommand(
        "SELECT precio FROM productos WHERE id = 1",
        conn))
    {
        precioDespues = Convert.ToDecimal(cmd.ExecuteScalar());
    }

    Console.WriteLine($"Precio luego del rollback: {precioDespues}");

    if (precioAntes == precioDespues)
    {
        Console.WriteLine("RF5 OK PostgreSQL");
    }
    else
    {
        Console.WriteLine("RF5 FALLÓ");
    }
}
    }
}