//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALUMNOMATERIA
    {
        public int IDALUMNOMATERIA { get; set; }
        public Nullable<int> IDALUMNO { get; set; }
        public Nullable<int> IDMATERIA { get; set; }
    
        public virtual ALUMNO ALUMNO { get; set; }
        public virtual MATERIA MATERIA { get; set; }
    }
}
