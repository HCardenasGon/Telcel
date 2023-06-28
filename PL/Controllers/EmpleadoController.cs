using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            BL.Empleado.EmpleadoObj empleado = new BL.Empleado.EmpleadoObj();
            BL.Empleado.Result result = BL.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult GetAll(BL.Empleado.EmpleadoObj empleado)
        {
            BL.Empleado.Result result = BL.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(empleado);
        }

        [HttpGet]
        public IActionResult Form()
        {
            BL.Empleado.Result departamentoResult = BL.Departamento.GetAll();
            BL.Empleado.Result puestoResult = BL.Puesto.GetAll();

            BL.Empleado.EmpleadoObj empleado = new BL.Empleado.EmpleadoObj();

            empleado.Departamento = new BL.Departamento.DepartamentoObj();
            empleado.Puesto = new BL.Puesto.PuestoObj();

            if (departamentoResult.Correct)
            {
                empleado.Departamento.Departamentos = departamentoResult.Objects;
                empleado.Puesto.Puestos = puestoResult.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta  " + departamentoResult.ErrorMessage;
                return View("Modal");
            }
            return View(empleado);
        }

        [HttpPost]
        public IActionResult Form(BL.Empleado.EmpleadoObj empleado)
        {
            BL.Empleado.Result result = new BL.Empleado.Result();

            result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                ViewBag.Message = "Registro correctamente insertado";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al insertar el registro";
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int idEmpleado)
        {
            BL.Empleado.EmpleadoObj empleado = new BL.Empleado.EmpleadoObj();
            empleado.IdEmpleado = idEmpleado;

            BL.Empleado.Result result = BL.Empleado.Delete(empleado);
            if (result.Correct)
            {
                ViewBag.Message = "Registro correctamente Eliminado";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro";
            }
            return View("Modal");
        }
    }
}