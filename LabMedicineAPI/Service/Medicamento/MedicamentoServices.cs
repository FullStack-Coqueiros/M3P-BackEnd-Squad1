using AutoMapper;
using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Paciente;

namespace LabMedicineAPI.Service.Medicamento
{

    public class MedicamentoServices : IMedicamentoServices
    {
        readonly IRepository<MedicamentoModel> _repository;
        readonly IMapper _mapper;

        public MedicamentoServices(IRepository<MedicamentoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<MedicamentoGetDTO> Get(int? pacienteId)
        {
            IEnumerable<MedicamentoModel> medicamentos;
            if (pacienteId.HasValue)
            {
                medicamentos = _repository.GetAll().Where(c => c.PacienteId == pacienteId.Value);
            }
            else
            {
                medicamentos = _repository.GetAll();
            }
            var medicamentosDTO = _mapper.Map<IEnumerable<MedicamentoGetDTO>>(medicamentos);
            return medicamentosDTO;
        }

        public MedicamentoGetDTO GetById(int id)
        {
            var medicamento = _repository.GetById(id);
            var medicamentoDTO = _mapper.Map<MedicamentoGetDTO>(medicamento);
            return medicamentoDTO;
        }

        public MedicamentoModel MedicamentoCreateDTO(MedicamentoCreateDTO medicamentoCreateDTO)
        {
            var medicamento = _mapper.Map<MedicamentoModel>(medicamentoCreateDTO);
            var medicamentoCreated = _repository.Create(medicamento);
            var medicamentoCreatedDTO = _mapper.Map<MedicamentoModel>(medicamentoCreated);
            return medicamentoCreatedDTO;

        }
        public MedicamentoModel MedicamentoUpdateDTO(int id, MedicamentoUpdateDTO updateMedicamentoDTO)
        {
            var medicamento = _repository.GetById(id);
            if (medicamento == null)
            {
                throw new Exception("Medicamento com id indicado não encontrado");
            }
            _mapper.Map(updateMedicamentoDTO, medicamento);

            var medicamentoUpdated = _repository.Update(medicamento);
            var medicamentoUpdateDTO = _mapper.Map<MedicamentoModel>(medicamentoUpdated);
            return medicamentoUpdateDTO;
        }

        public bool DeleteMedicamento(int id)
        {
            return _repository.Delete(id);
        }

    }

}
