using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        protected ConfigurationMapper()
        {
            // Origem ... Destino
            CreateMap<UsuarioCreateDTO, UsuarioModel>();
            
            
        }
    }
}