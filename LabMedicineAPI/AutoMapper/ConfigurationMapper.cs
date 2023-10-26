using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.DTOs.Dieta;
using LabMedicineAPI.DTOs.Endereco;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            

            CreateMap<UsuarioCreateDTO, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioGetDTO, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioModel,UsuarioUpdateDTO>().ReverseMap();

            CreateMap<PacienteCreateDTO, PacienteModel>().ReverseMap();
            CreateMap<PacienteGetDTO, PacienteModel>().ReverseMap();
            CreateMap<PacienteModel,PacienteUpdateDTO>().ReverseMap();
            
            CreateMap<ConsultaCreateDTO, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaGetDTO, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaUpdateDTO, ConsultaModel>().ReverseMap();
 
            CreateMap<ExameCreateDTO, ExameModel>().ReverseMap();
            CreateMap<ExameGetDTO, ExameModel>().ReverseMap();
            CreateMap<ExameModel, ExameUpdateDTO>().ReverseMap();
           
            CreateMap<MedicamentoCreateDTO, MedicamentoModel>().ReverseMap();
            CreateMap<MedicamentoGetDTO, MedicamentoModel>().ReverseMap();
            CreateMap<MedicamentoModel, MedicamentoUpdateDTO>().ReverseMap();
            
            CreateMap<ExercicioCreateDTO, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioGetDTO, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioModel, ExercicioUpdateDTO>().ReverseMap();

            CreateMap<DietaCreateDTO, DietaModel>().ReverseMap();
            CreateMap<DietaGetDTO, DietaModel>().ReverseMap();
            CreateMap<DietaModel, DietaUpdateDTO>().ReverseMap();
          
            CreateMap<EnderecoCreateDTO, EnderecoModel>().ReverseMap();
            CreateMap<EnderecoGetDTO, EnderecoModel>().ReverseMap();
            CreateMap<EnderecoModel, EnderecoUpdateDTO>().ReverseMap();
        }
    }
}