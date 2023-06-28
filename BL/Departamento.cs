using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Empleado;

namespace BL
{
    public class Departamento
    {
        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using (DL.TelcelContext cnn = new DL.TelcelContext())
                {
                    var query = cnn.Departamentos.FromSqlRaw($"DepartamentoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            DepartamentoObj departamento = new DepartamentoObj();
                            departamento.IdDepartamento = row.IdDepartamento;
                            departamento.Descripcion = row.Descripcion;

                            result.Objects.Add(departamento);
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
        public class DepartamentoObj
        {
            public int IdDepartamento { get; set; }

            public string? Descripcion { get; set; }

            public List<object>? Departamentos { get; set; }
        }
    }
}
