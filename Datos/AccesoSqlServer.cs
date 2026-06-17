using Microsoft.Data.SqlClient;

namespace starter.Datos
{
    public class AccesoSqlServer : IAccesoDatos
    {
        private readonly string _cs =
            "Server=localhost,1433;User Id=sa;Password=Curso.NET2026;TrustServerCertificate=True;";

        public void CrearEstructura()
{
    using (var conn = new SqlConnection(_cs))
    {
        conn.Open();

        string sql = @"
        IF DB_ID('practico') IS NULL
            CREATE DATABASE practico";

        using var cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }

    string csPractico =
        "Server=localhost,1433;Database=practico;User Id=sa;Password=Curso.NET2026;TrustServerCertificate=True;";

    using var conn2 = new SqlConnection(csPractico);
    conn2.Open();

    string sql2 = @"
    USE practico;

    IF OBJECT_ID('detalle_pedido','U') IS NOT NULL DROP TABLE detalle_pedido;
    IF OBJECT_ID('pedidos','U') IS NOT NULL DROP TABLE pedidos;
    IF OBJECT_ID('productos','U') IS NOT NULL DROP TABLE productos;
    IF OBJECT_ID('clientes','U') IS NOT NULL DROP TABLE clientes;
    IF OBJECT_ID('categorias','U') IS NOT NULL DROP TABLE categorias;

    CREATE TABLE categorias(
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100)
    );

    CREATE TABLE clientes(
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100),
        email VARCHAR(100)
    );

    CREATE TABLE productos(
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100),
        precio DECIMAL(10,2),
        stock INT,
        categoria_id INT
    );

    CREATE TABLE pedidos(
        id INT IDENTITY(1,1) PRIMARY KEY,
        cliente_id INT,
        fecha DATETIME
    );

    CREATE TABLE detalle_pedido(
        pedido_id INT,
        producto_id INT,
        cantidad INT,
        precio_unitario DECIMAL(10,2),
        PRIMARY KEY (pedido_id, producto_id)
    );
    ";
    var scripts = sql2.Split(';');
    foreach (var sql in scripts)
    {
    if (string.IsNullOrWhiteSpace(sql)) continue;

    using var cmd = new SqlCommand(sql, conn2);
    cmd.ExecuteNonQuery();
    }
    using var cmd2 = new SqlCommand(sql2, conn2);
    cmd2.ExecuteNonQuery();

    Console.WriteLine("RF2 OK SQL Server");
}
    //=================================================
    //  RF3 - INSERT DATOS|
    //|                                                |
    //=================================================
    public void InsertarDatosPrueba()
{
    using var conn = new SqlConnection(_cs + "Database=practico;");
    conn.Open();

    using var tx = conn.BeginTransaction();

    try
    {
        // =====================
        // CATEGORÍAS
        // =====================
        var cmdCat = new SqlCommand(@"
            INSERT INTO categorias(nombre) VALUES
            ('Bebidas'),
            ('Snacks'),
            ('Limpieza');

            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        cmdCat.ExecuteNonQuery();

        // =====================
        // CLIENTES
        // =====================
        var cmdCli1 = new SqlCommand(@"
            INSERT INTO clientes(nombre, email)
            VALUES ('Juan Perez', 'juan@mail.com');

            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        int cliente1Id = Convert.ToInt32(cmdCli1.ExecuteScalar());

        var cmdCli2 = new SqlCommand(@"
            INSERT INTO clientes(nombre, email)
            VALUES ('Maria Gomez', 'maria@mail.com');

            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        int cliente2Id = Convert.ToInt32(cmdCli2.ExecuteScalar());

        // =====================
        // PRODUCTOS
        // =====================
        var cmdProd1 = new SqlCommand(@"
            INSERT INTO productos(nombre, precio, stock, categoria_id)
            VALUES ('Coca Cola', 1200, 10, 1);
            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        int prod1 = Convert.ToInt32(cmdProd1.ExecuteScalar());

        var cmdProd2 = new SqlCommand(@"
            INSERT INTO productos(nombre, precio, stock, categoria_id)
            VALUES ('Papitas', 800, 20, 2);
            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        int prod2 = Convert.ToInt32(cmdProd2.ExecuteScalar());

        var cmdProd3 = new SqlCommand(@"
            INSERT INTO productos(nombre, precio, stock, categoria_id)
            VALUES ('Detergente', 1500, 15, 3);
            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        int prod3 = Convert.ToInt32(cmdProd3.ExecuteScalar());

        // =====================
        // PEDIDO 1
        // =====================
        var cmdPed1 = new SqlCommand(@"
            INSERT INTO pedidos(cliente_id, fecha)
            VALUES (@cliente, GETDATE());

            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        cmdPed1.Parameters.AddWithValue("@cliente", cliente1Id);
        int pedido1Id = Convert.ToInt32(cmdPed1.ExecuteScalar());

        // DETALLE PEDIDO 1
        var cmdDet1 = new SqlCommand(@"
            INSERT INTO detalle_pedido(pedido_id, producto_id, cantidad, precio_unitario)
            VALUES (@p, @prod, 2, 1200);
        ", conn, tx);

        cmdDet1.Parameters.AddWithValue("@p", pedido1Id);
        cmdDet1.Parameters.AddWithValue("@prod", prod1);
        cmdDet1.ExecuteNonQuery();

        var cmdDet2 = new SqlCommand(@"
            INSERT INTO detalle_pedido(pedido_id, producto_id, cantidad, precio_unitario)
            VALUES (@p, @prod, 1, 800);
        ", conn, tx);

        cmdDet2.Parameters.AddWithValue("@p", pedido1Id);
        cmdDet2.Parameters.AddWithValue("@prod", prod2);
        cmdDet2.ExecuteNonQuery();

        // =====================
        // PEDIDO 2
        // =====================
        var cmdPed2 = new SqlCommand(@"
            INSERT INTO pedidos(cliente_id, fecha)
            VALUES (@cliente, GETDATE());

            SELECT SCOPE_IDENTITY();
        ", conn, tx);

        cmdPed2.Parameters.AddWithValue("@cliente", cliente2Id);
        int pedido2Id = Convert.ToInt32(cmdPed2.ExecuteScalar());

        // DETALLE PEDIDO 2
        var cmdDet3 = new SqlCommand(@"
            INSERT INTO detalle_pedido(pedido_id, producto_id, cantidad, precio_unitario)
            VALUES (@p, @prod, 3, 1500);
        ", conn, tx);

        cmdDet3.Parameters.AddWithValue("@p", pedido2Id);
        cmdDet3.Parameters.AddWithValue("@prod", prod3);
        cmdDet3.ExecuteNonQuery();

        
        tx.Commit();

        Console.WriteLine("RF3 OK - datos insertados correctamente");
    }
    catch (Exception ex)
    {
        tx.Rollback();
        Console.WriteLine("Error RF3: " + ex.Message);
    }
}

        // =====================================================
        // RF4 - CONSULTAS, UPDATE Y DELETE
        // =====================================================
        public void EjecutarOperaciones()
{
    using var conn = new SqlConnection(_cs + "Database=practico;");
    conn.Open();

    try
    {
        // =========================
        // C1: INNER JOIN (Pedidos + Clientes)
        // =========================
        string c1 = @"
            SELECT 
                p.id AS PedidoId,
                c.nombre AS Cliente,
                p.fecha
            FROM pedidos p
            INNER JOIN clientes c ON c.id = p.cliente_id;
        ";

        using (var cmd = new SqlCommand(c1, conn))
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("=== C1: PEDIDOS POR CLIENTE ===");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Pedido {reader["PedidoId"]} - {reader["Cliente"]} - {reader["fecha"]}"
                );
            }
        }

        // =========================
        // C2: TOTAL POR PEDIDO (SUM)
        // =========================
        string c2 = @"
            SELECT 
                dp.pedido_id,
                SUM(dp.cantidad * dp.precio_unitario) AS Total
            FROM detalle_pedido dp
            GROUP BY dp.pedido_id;
        ";

        using (var cmd = new SqlCommand(c2, conn))
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("\n=== C2: TOTAL POR PEDIDO ===");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Pedido {reader["pedido_id"]} - Total: {reader["Total"]}"
                );
            }
        }

        // =========================
        // C3: JOIN COMPLETO (detalle + producto)
        // =========================
        string c3 = @"
            SELECT 
                p.id AS Pedido,
                pr.nombre AS Producto,
                dp.cantidad,
                dp.precio_unitario
            FROM detalle_pedido dp
            INNER JOIN productos pr ON pr.id = dp.producto_id
            INNER JOIN pedidos p ON p.id = dp.pedido_id;
        ";

        using (var cmd = new SqlCommand(c3, conn))
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("\n=== C3: DETALLE DE PEDIDOS ===");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Pedido {reader["Pedido"]} - {reader["Producto"]} - Cant: {reader["cantidad"]} - Precio: {reader["precio_unitario"]}"
                );
            }
        }

        Console.WriteLine("\nRF4 OK - consultas ejecutadas correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error RF4: " + ex.Message);
    }
}
public void DemostrarRollback()
{
    using var conn = new SqlConnection(_cs + "Database=practico;");
    conn.Open();

    using var tx = conn.BeginTransaction();

    try
    {
        Console.WriteLine("Iniciando operación con error controlado...");

        // =========================
        // INSERT OK
        // =========================
        var cmd1 = new SqlCommand(@"
            INSERT INTO categorias(nombre)
            VALUES ('Categoria RF5');
        ", conn, tx);

        cmd1.ExecuteNonQuery();

        // =========================
        // ERROR INTENCIONAL
        // =========================
        var cmdError = new SqlCommand(@"
            INSERT INTO productos(nombre, precio, stock, categoria_id)
            VALUES ('ERROR PRODUCTO', 'NO_NUMERO', 10, 1);
        ", conn, tx);

        cmdError.ExecuteNonQuery(); // 🔴 acá falla a propósito

        // =========================
        // COMMIT (NO SE EJECUTA)
        // =========================
        tx.Commit();

        Console.WriteLine("RF5 OK");
    }
    catch (Exception ex)
    {
        // =========================
        // ROLLBACK
        // =========================
        tx.Rollback();

        Console.WriteLine("ROLLBACK EJECUTADO CORRECTAMENTE");
        Console.WriteLine("Error: " + ex.Message);
    }
}

}
}