using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PuestoController : Controller
    {
        public IActionResult GetAll()
        {
            BL.Empleado.Result result = BL.Puesto.GetAll();
            BL.Puesto.PuestoObj puesto = new BL.Puesto.PuestoObj();

            if (result.Correct)
            {
                puesto.Puestos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(puesto);
        }
    }
}
