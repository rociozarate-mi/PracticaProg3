namespace starter.Datos
{
    public static class FabricaDeMotor
    {
        public static IAccesoDatos Crear(Motor motor)
        {
            return motor switch
            {
                Motor.MySql => new AccesoMySql(),
                Motor.Postgres => new AccesoPostgres(),
                Motor.SqlServer => new AccesoSqlServer(),
                _ => throw new Exception("Motor no soportado")
            };
        }
    }
}