using CoreEscuela.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            // nameof => construye dinamicamente ese parametro nulo
            if (dicObsEsc == null) 
                throw new ArgumentException(nameof(dicObsEsc));

            this._diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            // GetValueOrDefault => trae el valor de la llave Escuela
            //var lista = this._diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);

            //IEnumerable<Evaluacion> rta;
            // TryGetValue => Permite decidir si llega o no el valor
            if (this._diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista)) 
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                //rta = null;
                // Escribir en el log de auditoria

                return new List<Evaluacion>(); //Lista vacia
            }

            //return rta; // hace un casteo de la Escuela
        }

        // Sobrecarga
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            // linq
            // de cada evaluacion en nuestra lista de evaluaciones,
            // seleccione la evaluacion de asginatura
            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
            //where ev.Nota >= 3.0

            //return from Evaluacion ev in listaEvaluaciones
            //        select ev.Asignatura;
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionXAsignatura()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var listaEval); // variable de salida

            // Recorrido a todas las asignaturas
            foreach (var asign in listaAsig)
            {
                // linq
                // Traemos todas las evaluaciones que coicidan con lo actual y lo agregamos en dicRta
                var evalsAsignatura = from eval in listaEval
                                      where eval.Asignatura.Nombre == asign
                                      select eval;

                dicRta.Add(asign, evalsAsignatura);
            }

            // Recomendacion: En cualquier programa dividir es la clave del exito
            // Si vemos que el problema se vuelve demasiado complejo es porque realmente no es un problema
            // sino un conjunto de problemas más pequeños
            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnosPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dictEvalxAsig = GetDicEvaluacionXAsignatura();

            foreach (var asignConEval in dictEvalxAsig)
            {
                var promediosAlumnos /*dummy*/ = from eval in asignConEval.Value
                            //group eval by new { eval.Alumno.UniqueId, eval.Nota }// Agrupar por alumno y asignatura (El orden es importante)
                            //group eval by eval.Alumno.UniqueId into grupoEvalsAlumno
                            group eval by new { 
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }  into grupoEvalsAlumno
                            //select new  // Tipo anonimo que devuelve dos valores
                            select new AlumnoPromedio
                            { 
                                //eval.Alumno.UniqueId, 
                                //NombreAlumno = eval.Alumno.Nombre, // Distinguiendo el nombre de Alumno al de Evaluacion
                                //NombreEval = eval.Nombre,
                                //eval.Nota 

                                alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota) //Promedio
                            };

                //foreach (var item in dummy) { item.Nombre } // Ejemplo

                //var mitipoanonimo = new
                //{
                //    numero = 90, nombre = "Angel"
                //};

                rta.Add(asignConEval.Key, promediosAlumnos);
            }

            return rta;
        }
    }
}
