﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ApiEvaluacion
{
    public partial class Evaluaciodetalle
    {
        public Evaluaciodetalle()
        {
            Detallepregunta = new HashSet<Detallepreguntum>();
        }

        /// <summary>
        /// Clave primaria evaluacion detalle
        /// </summary>
        public int KeyEvdt { get; set; }
        /// <summary>
        /// Fk tabla evaluaciones
        /// </summary>
        public int? Fkeva { get; set; }
        /// <summary>
        /// Fk Funcionario evaluado
        /// </summary>
        public decimal? FunId { get; set; }
        /// <summary>
        /// Fk tipo evaluacion
        /// </summary>
        public int? Fktipoeva { get; set; }
        /// <summary>
        /// total bloque 1
        /// </summary>
        public int? Blq1 { get; set; }
        /// <summary>
        /// total bloque 2
        /// </summary>
        public int? Blq2 { get; set; }
        /// <summary>
        /// total bloque 3
        /// </summary>
        public int? Blq3 { get; set; }
        /// <summary>
        /// total bloque 4
        /// </summary>
        public int? Blq4 { get; set; }
        /// <summary>
        /// puntaje total de evaluacion
        /// </summary>
        public int? Bltotal { get; set; }
        /// <summary>
        /// Fk cargo historial
        /// </summary>
        public int? CarId { get; set; }
        /// <summary>
        /// Fk direccion historial
        /// </summary>
        public int? DirId { get; set; }
        /// <summary>
        /// Escala de puntaje tipo string
        /// </summary>
        public string Pntescala { get; set; }
        /// <summary>
        /// fortalezas
        /// </summary>
        public string Rtfort { get; set; }
        /// <summary>
        /// debilidades
        /// </summary>
        public string Rtdeb { get; set; }
        /// <summary>
        /// compromisos
        /// </summary>
        public string Rtcomp { get; set; }
        /// <summary>
        /// capacitaciones
        /// </summary>
        public string Rtcapc { get; set; }
        /// <summary>
        /// Fk Funcionario que  evalua
        /// </summary>
        public decimal? Fkfunceval { get; set; }

        public virtual Evaluacion FkevaNavigation { get; set; }
        public virtual Tpevaluacion FktipoevaNavigation { get; set; }
        public virtual Funcionario Fun { get; set; }
        public virtual ICollection<Detallepreguntum> Detallepregunta { get; set; }
    }
}