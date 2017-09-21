using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class PhisicalServer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва фізичного сервера")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Тип центрального процесора")]
        public int CpuTypeId { get; set; }
        [Required]
        [Display(Name = "Тип накопичувача")]
        public int HddTypeId { get; set; }
        [Required]
        [Display(Name = "Віртуальний сервер")]
        public int VirtualServerId { get; set; }
        [Required]
        [Display(Name = "Кількість ядер ЦП")]
        public int CountCpuCores { get; set; }
        [Required]
        [Display(Name = "Кількість жостких дисків")]
        public int CountHdd { get; set; }
        [Required]
        [Display(Name = "Кількість оперативної пам'яті")]
        public int CountRam { get; set; }
        [Required]
        [Display(Name = "Максимальна кількість Mhz ЦП")]
        public int CpuMax { get; set; }
        [Required]
        [Display(Name = "Максимальна кількість об'єму жостких дисків")]
        public int HddMax { get; set; }
        [Required]
        [Display(Name = "Максимальна кількість оперативної пам'яті")]
        public int RamMax { get; set; }
        [Required]
        [Display(Name = "Максимальна кількість споживання електроенергії")]
        public int PowerConsumptionMax { get; set; }

        public virtual CpuType CpuType { get; set; }
        public virtual HddType HddType { get; set; }
        public virtual VirtualServer VirtualServer { get; set; }

        public virtual ICollection<ServerDataCenter>ServerDataCenters { get; set; }
    }
}