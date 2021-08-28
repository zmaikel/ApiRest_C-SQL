namespace CapaDatos.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Persona
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TPE_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string TPE_Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string TPE_Apellido1 { get; set; }

        [Required]
        [StringLength(20)]
        public string TPE_Apellido2 { get; set; }

        public short TPE_EDAD { get; set; }

        public int TPE_TPR_ID { get; set; }

        public decimal? TPE_SALARIO { get; set; }

        public int TPE_TGE_ID { get; set; }

        public virtual T_Genero T_Genero { get; set; }

        public virtual T_Provincia T_Provincia { get; set; }
    }
}
