using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RequerimientosSPS.Models;
using System.IO;

namespace RequerimientosSPS.Controllers
{
    public class BuscadorController : Controller
    {
        private spsrequerimientosEntities db = new spsrequerimientosEntities();
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.analistas = new MultiSelectList(db.analista, "id", "nombre");
            ViewBag.areas = new MultiSelectList(db.area, "id", "descripcion");
            ViewBag.prioridades = new MultiSelectList(db.prioridad, "id", "descripcion");
            ViewBag.origenes = new MultiSelectList(db.origen, "id", "descripcion");
            ViewBag.clases = new MultiSelectList(db.clase, "id", "descripcion");
            ViewBag.impuestos = new MultiSelectList(db.impuesto, "id", "descripcion");
            ViewBag.estados = new MultiSelectList(db.estadoSps, "id", "descripcion");
            ViewBag.severidades = new MultiSelectList(db.severidad, "id", "descripcion");
            ViewBag.vusers = new MultiSelectList(db.sps.Select(s => s.vuser).Distinct());
            ViewBag.referencias = new MultiSelectList(db.sps.Select(s => s.referencia).Distinct());
            ViewBag.tipos = new MultiSelectList(db.sps.Select(s => s.tipo).Distinct());
            ViewBag.caratulas = new MultiSelectList(db.sps.Select(s => s.caratula).Distinct());
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(DateTime? fechaDesde, DateTime? fechaHasta, List<int> analistas, List<string> vusers, List<int> prioridades,
            List<int> areas, List<int> origenes, List<int> clases, List<int> impuestos, List<int> estados, List<int> severidades, 
            List<int> referencias, List<int> tipos, List<int> caratulas)
        {
            IQueryable<sps> resultados = db.sps;

            if (fechaDesde != null) resultados = resultados.Where(sps => sps.fechaOrigen >= fechaDesde);
            if (fechaHasta != null) resultados = resultados.Where(sps => sps.fechaOrigen <= fechaDesde);
            if (vusers != null) resultados = resultados.Where(r => vusers.Contains(r.vuser));
            if (referencias != null) resultados = resultados.Where(r => vusers.Contains(r.referencia));
            if (tipos != null) resultados = resultados.Where(r => vusers.Contains(r.tipo));
            if (caratulas != null) resultados = resultados.Where(r => vusers.Contains(r.caratula));
            if (analistas != null) resultados = resultados.Join(analistas, sps => sps.analista_Id, id => id, (sps, id) => sps);
            if (prioridades != null) resultados = resultados.Join(prioridades, sps => sps.prioridad_id, id => id, (sps, id) => sps);
            if (areas != null) resultados = resultados.Join(areas, sps => sps.area_Id, id => id, (sps, id) => sps);
            if (origenes != null) resultados = resultados.Join(origenes, sps => sps.origen_id, id => id, (sps, id) => sps);
            if (clases != null) resultados = resultados.Join(clases, sps => sps.clase_Id, id => id, (sps, id) => sps);
            if (impuestos != null) resultados = resultados.Join(impuestos, sps => sps.impuesto_Id, id => id, (sps, id) => sps);
            if (estados != null) resultados = resultados.Join(estados, sps => sps.estadoSps_Id, id => id, (sps, id) => sps);
            if (severidades != null) resultados = resultados.Join(severidades, sps => sps.severidad_id, id => id, (sps, id) => sps);
            return View(resultados.ToList());
        }

    }
}
