using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static Result Add(EmpleadoObj empleado)
        {
            Result result = new Result();

            try
            {
                using (DL.TelcelContext cnn = new DL.TelcelContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static Result Delete(EmpleadoObj empleado)
        {
            Result result = new Result();

            try
            {
                using (DL.TelcelContext cnn = new DL.TelcelContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoDelete {empleado.IdEmpleado}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static Result Update(EmpleadoObj empleado)
        {
            Result result = new Result();

            try
            {
                using (DL.TelcelContext cnn = new DL.TelcelContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado}, '{empleado.Nombre}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static Result GetAll(EmpleadoObj empleadoR)
        {
            Result result = new Result();

            try
            {
                using (DL.TelcelContext cnn = new DL.TelcelContext())
                {
                    var query = cnn.Empleados.FromSqlRaw($"EmpleadoGetAll '{empleadoR.Nombre}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            EmpleadoObj empleado = new EmpleadoObj();
                            empleado.IdEmpleado = row.IdEmpleado;
                            empleado.Nombre = row.Nombre;

                            empleado.Puesto = new Puesto.PuestoObj();
                            empleado.Puesto.IdPuesto = row.IdPuesto;
                            empleado.Puesto.Descripcion = row.DescripcionPuesto;

                            empleado.Departamento = new Departamento.DepartamentoObj();
                            empleado.Departamento.IdDepartamento = row.IdDepartamento;
                            empleado.Departamento.Descripcion = row.DescripcionDepartamento;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public class Result
        {
            public bool Correct { get; set; }
            public string? ErrorMessage { get; set; }
            public Exception? Ex { get; set; }
            public object? Object { get; set; }
            public List<object>? Objects { get; set; }
        }

        public class EmpleadoObj
        {
            public int IdEmpleado { get; set; }

            public string? Nombre { get; set; }

            public BL.Puesto.PuestoObj? Puesto { get; set; }

            public BL.Departamento.DepartamentoObj? Departamento { get; set; }

            public List<object>? Empleados { get; set; }
        }
    }
}
